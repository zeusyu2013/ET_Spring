using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using YooAsset.Editor;
using BuildReport = UnityEditor.Build.Reporting.BuildReport;
using BuildResult = UnityEditor.Build.Reporting.BuildResult;

namespace ET
{
    public static class BuildHelper
    {
        private const string relativeDirPrefix = "../Release";

        public static string BuildFolder = "../Release/{0}/StreamingAssets/";

        [InitializeOnLoadMethod]
        public static void ReGenerateProjectFiles()
        {
            Unity.CodeEditor.CodeEditor.CurrentEditor.SyncAll();
        }

#if ENABLE_VIEW
        [MenuItem("ET/ChangeDefine/Remove ENABLE_VIEW", false, ETMenuItemPriority.ChangeDefine)]
        public static void RemoveEnableView()
        {
            EnableDefineSymbols("ENABLE_VIEW", false);
        }
#else
        [MenuItem("ET/ChangeDefine/Add ENABLE_VIEW", false, ETMenuItemPriority.ChangeDefine)]
        public static void AddEnableView()
        {
            EnableDefineSymbols("ENABLE_VIEW", true);
        }
#endif
        public static void EnableDefineSymbols(string symbols, bool enable)
        {
            Debug.Log($"EnableDefineSymbols {symbols} {enable}");
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var ss = defines.Split(';').ToList();
            if (enable)
            {
                if (ss.Contains(symbols))
                {
                    return;
                }

                ss.Add(symbols);
            }
            else
            {
                if (!ss.Contains(symbols))
                {
                    return;
                }

                ss.Remove(symbols);
            }

            Debug.Log($"EnableDefineSymbols {symbols} {enable}");
            defines = string.Join(";", ss);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defines);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public static void Build(PlatformType type, BuildOptions buildOptions)
        {
            BuildTarget buildTarget = BuildTarget.StandaloneWindows;
            string programName = "ET";
            string exeName = programName;
            switch (type)
            {
                case PlatformType.Windows:
                    buildTarget = BuildTarget.StandaloneWindows64;
                    exeName += ".exe";
                    break;
                case PlatformType.Android:
                    buildTarget = BuildTarget.Android;
                    exeName += ".apk";
                    break;
                case PlatformType.IOS:
                    buildTarget = BuildTarget.iOS;
                    break;
                case PlatformType.MacOS:
                    buildTarget = BuildTarget.StandaloneOSX;
                    break;
                case PlatformType.Linux:
                    buildTarget = BuildTarget.StandaloneLinux64;
                    break;
            }

            AssetDatabase.Refresh();

            Debug.Log("start build exe");

            string[] levels = { "Assets/Scenes/Init.unity" };
            BuildReport report = BuildPipeline.BuildPlayer(levels, $"{relativeDirPrefix}/{exeName}", buildTarget, buildOptions);
            if (report.summary.result != BuildResult.Succeeded)
            {
                Debug.Log($"BuildResult:{report.summary.result}");
                return;
            }

            Debug.Log("finish build exe");
            EditorUtility.OpenWithDefaultApp(relativeDirPrefix);
        }

        public static void BuildBundles(BuildTarget buildTarget, bool upload = false)
        {
            Debug.Log("开始构建资源");

            string buildOutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
            string streamingAssetsRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();

            ScriptableBuildParameters buildParameters = new ScriptableBuildParameters();
            buildParameters.BuildOutputRoot = buildOutputRoot;
            buildParameters.BuildinFileRoot = streamingAssetsRoot;
            buildParameters.BuildPipeline = EBuildPipeline.ScriptableBuildPipeline.ToString();
            buildParameters.BuildTarget = buildTarget;
            buildParameters.BuildMode = EBuildMode.IncrementalBuild;
            buildParameters.PackageName = "zz";
            DateTime now = DateTime.Now;
            string version = $"{now.Year}{now.Month}{now.Day}{now.Hour}{now.Minute}{now.Second}";
            buildParameters.PackageVersion = $"{Application.version}_{version}";
            buildParameters.VerifyBuildingResult = true;
            buildParameters.EnableSharePackRule = true;
            buildParameters.FileNameStyle = EFileNameStyle.BundleName_HashName;
            buildParameters.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
            buildParameters.BuildinFileCopyParams = "";
            //buildParameters.EncryptionServices
            buildParameters.CompressOption = ECompressOption.LZ4;

            ScriptableBuildPipeline buildPipeline = new ScriptableBuildPipeline();
            var result = buildPipeline.Run(buildParameters, true);
            Debug.Log(result.Success ? "构建成功" : $"构建失败，失败原因：{result.ErrorInfo}");

            if (result.Success && upload)
            {
                string outputDirectory = result.OutputPackageDirectory;
                if (string.IsNullOrEmpty(outputDirectory))
                {
                    return;
                }
                
                // todo 上传目录内文件到oss
            }
        }

        private static string GetPackageName()
        {
            Debug.Log($"执行命令参数：{System.Environment.GetCommandLineArgs()}");
            
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith("buildPackage"))
                {
                    return arg.Split("="[0])[1];
                }
            }

            return string.Empty;
        }
    }
}