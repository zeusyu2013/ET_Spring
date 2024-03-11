using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace ET
{
    public class ShaderVariantsCollectionMergeWindow : OdinEditorWindow
    {
        [LabelText("变体文件"), Sirenix.OdinInspector.FilePath]
        public string oldShaderVariantsCollectionPath;

        [LabelText("新采集文件"), Sirenix.OdinInspector.FilePath]
        public string newShaderVariantsCollectionPath;

        [Button("合并差异到变体文件中")]
        public void Merge()
        {
            if (string.IsNullOrEmpty(oldShaderVariantsCollectionPath) ||
                string.IsNullOrEmpty(newShaderVariantsCollectionPath))
            {
                EditorHelper.LogError("路径不能为空");
                return;
            }

            LoadShaderVariantsCollection(oldShaderVariantsCollectionPath, out var older);
            LoadShaderVariantsCollection(newShaderVariantsCollectionPath, out var newer);

            DiffShaders(older, newer, out var diff);

            var oldShaderVariantCollection =
                    AssetDatabase.LoadAssetAtPath<ShaderVariantCollection>(oldShaderVariantsCollectionPath);

            foreach (var pair in diff)
            {
                foreach (var variant in pair.Value)
                {
                    oldShaderVariantCollection.Add(variant);
                }
            }

            EditorHelper.SaveAsset(oldShaderVariantCollection);
        }

        private void LoadShaderVariantsCollection(string path,
        out Dictionary<Shader, List<ShaderVariantCollection.ShaderVariant>> outer)
        {
            var collectionContent = new List<string>(File.ReadAllLines(path));
            if (collectionContent.Count < 1)
            {
                outer = null;
                return;
            }

            outer = new Dictionary<Shader, List<ShaderVariantCollection.ShaderVariant>>();
            var yaml = new List<string>();

            var i = 0;
            for (; i < collectionContent.Count; i++)
            {
                if (YamlLineHasKey(collectionContent[i], "m_Shaders"))
                {
                    break;
                }
            }

            var indent = 0;
            for (; i < collectionContent.Count; i++)
            {
                var line = collectionContent[i];
                var myIndent = GetYamlIndent(line);
                if (myIndent > indent)
                {
                    if (!line.EndsWith(":") && !line.Contains(": "))
                    {
                        yaml[yaml.Count - 1] += " " + line.Trim();
                        continue;
                    }
                }

                yaml.Add(line);
                indent = myIndent;
            }

            for (i = 0; i < yaml.Count; i++)
            {
                var y = yaml[i];
                if (yaml[i].Contains("first:"))
                {
                    var guid = GetValueFromYaml(y, "guid");
                    var shader = AssetDatabase.LoadAssetAtPath<Shader>(AssetDatabase.GUIDToAssetPath(guid));
                    if (shader == null)
                    {
                        continue;
                    }

                    if (!outer.ContainsKey(shader))
                    {
                        outer.Add(shader, new List<ShaderVariantCollection.ShaderVariant>());
                    }

                    i += 3;
                    indent = GetYamlIndent(yaml[i]);
                    var sv = new ShaderVariantCollection.ShaderVariant();
                    for (; i < yaml.Count; ++i)
                    {
                        y = yaml[i];
                        if (GetYamlIndent(y) != indent)
                        {
                            i -= 1;
                            break;
                        }

                        sv.shader = shader;
                        if (IsYamlLineNewEntry(y))
                        {
                        }

                        if (YamlLineHasKey(y, "passType"))
                        {
                            sv.passType = (PassType)int.Parse(GetValueFromYaml(y, "passType"));
                        }

                        if (YamlLineHasKey(y, "keywords"))
                        {
                            sv.keywords = GetValuesFromYaml(y, "keywords");
                        }

                        outer[shader].Add(sv);
                    }
                }
            }
        }

        private void DiffShaders(Dictionary<Shader, List<ShaderVariantCollection.ShaderVariant>> older,
        Dictionary<Shader, List<ShaderVariantCollection.ShaderVariant>> newer,
        out Dictionary<Shader, List<ShaderVariantCollection.ShaderVariant>> outer)
        {
            outer = new Dictionary<Shader, List<ShaderVariantCollection.ShaderVariant>>();

            foreach (var pair in newer)
            {
                if (older.ContainsKey(pair.Key))
                {
                    var o = older[pair.Key];
                    var n = pair.Value;
                    var diffShaderVariant = n.Except(o).ToList();
                    if (diffShaderVariant.Count > 1)
                    {
                        outer.Add(pair.Key, diffShaderVariant);
                    }
                }
                else
                {
                    outer.Add(pair.Key, pair.Value);
                }
            }
        }

        private void MergeShaderKeyword()
        {
        }

        #region 解析collection文件 感谢Unity并未提供Get函数

        private bool IsYamlLineNewEntry(string line)
        {
            foreach (var c in line)
            {
                // If a dash (before a not-space appears) this is a new entry
                if (c == '-') return true;
                // If not a dash, must be a space or indent has ended
                if (c != ' ') return false;
            }

            return false;
        }

        private int GetIndexOfYamlValue(string line, string key)
        {
            int i = line.IndexOf(key + ":", System.StringComparison.Ordinal);
            if (i >= 0)
            {
                // Skip to value
                i += key.Length + 2;
            }

            return i;
        }

        private bool YamlLineHasKey(string line, string key)
        {
            return GetIndexOfYamlValue(line, key) >= 0;
        }

        private int GetYamlIndent(string line)
        {
            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] != ' ' && line[i] != '-') return i;
            }

            return 0;
        }

        private string GetValueFromYaml(string line, string key)
        {
            int i = GetIndexOfYamlValue(line, key);
            if (i < 0)
            {
                return "";
                //throw new System.Exception((string.Format("Value not found for key {0} in YAML line {1}", key, line)));
            }

            StringBuilder sb = new StringBuilder();
            for (; i < line.Length; ++i)
            {
                char c = line[i];
                if (c == ',' || c == ' ') break;
                sb.Append(c);
            }

            return sb.ToString();
        }

        private string[] GetValuesFromYaml(string line, string key, List<string> exclude = null)
        {
            int i = GetIndexOfYamlValue(line, key);
            if (i < 0)
            {
                throw new System.Exception((string.Format("Value not found for key {0} in YAML line {1}", key, line)));
            }

            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (; i < line.Length; ++i)
            {
                char c = line[i];
                bool end = false;
                bool brk = false;
                if (c == ',')
                {
                    // Comma delimits keys
                    // Add the current entry and stop parsing
                    end = brk = true;
                }

                if (c == ' ')
                {
                    // Space delimits entries
                    // Add current entry, move to next
                    end = true;
                }

                if (end)
                {
                    result.Add(sb.ToString());
                    sb.Length = 0;
                    if (brk) break;
                }
                else
                {
                    sb.Append(c);
                }
            }

            // Catch last entry if line ends
            if (sb.Length > 0)
            {
                var s = sb.ToString();
                if (exclude == null || exclude.Count == 0 || !exclude.Contains(s))
                {
                    result.Add(sb.ToString());
                }
            }

            return result.ToArray();
        }

        #endregion
    }
}