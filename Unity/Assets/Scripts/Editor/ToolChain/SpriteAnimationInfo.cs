using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace ET
{
    [Serializable]
    public class SingleSpriteAnimationInfo
    {
        [LabelText("动画名称")]
        public string AnimationName;

        [LabelText("动画帧率")]
        public int Frame;

        [LabelText("序列帧图")]
        public string[] Sprites;
    }

    [CreateAssetMenu]
    public class SpriteAnimationInfo : ScriptableObject
    {
        [LabelText("角色名")]
        public string SpriteName;

        [LabelText("序列帧集合")]
        public SingleSpriteAnimationInfo[] spriteAnimationInfos;

        private string _animationPath = "Assets/Res/Unit/Atlas";

        private List<string> _usedSprites = new();

        [Button("构建动画")]
        public void BuildAnimations()
        {
            if (spriteAnimationInfos.Length < 1)
            {
                EditorHelper.LogError($"{this.SpriteName} 没有设置动作集");
                return;
            }

            this._usedSprites.Clear();

            string _roleFolder = $"{this._animationPath}/{this.SpriteName}";
            string _roleSpriteFolder = $"{this._animationPath}/{this.SpriteName}/Sprites";
            if (!Directory.Exists(_roleSpriteFolder))
            {
                EditorHelper.LogError($"{this.SpriteName} Sprites目录不存在");
                return;
            }

            string _animationFolder = $"{this._animationPath}/{this.SpriteName}/Animations";
            if (!Directory.Exists(_animationFolder))
            {
                Directory.CreateDirectory(_animationFolder);
            }

            foreach (SingleSpriteAnimationInfo info in this.spriteAnimationInfos)
            {
                foreach (string s in info.Sprites)
                {
                    string textureToPack = $"{_roleSpriteFolder}/{s}.png";
                    if (!this._usedSprites.Contains(textureToPack))
                    {
                        this._usedSprites.Add(textureToPack);
                    }
                }
            }

            if (this._usedSprites.Count < 1)
            {
                EditorHelper.LogError($"{this.SpriteName} 未使用任何精灵图");
                return;
            }

            // 打包精灵图集
            SpriteAnimationHelper.Pack($"{_roleFolder}/{this.SpriteName}.png", this._usedSprites);

            UnityEngine.Object[] sprites = AssetDatabase.LoadAllAssetsAtPath($"{_roleFolder}/{this.SpriteName}.png");
            if (sprites == null || sprites.Length < 1)
            {
                EditorHelper.LogError($"{this.SpriteName}角色精灵图集加载失败");
                return;
            }

            var spritesList = sprites.ToList();

            foreach (SingleSpriteAnimationInfo info in this.spriteAnimationInfos)
            {
                List<Sprite> animationSprites = new();
                foreach (string s in info.Sprites)
                {
                    Sprite sprite = spritesList.Find(x => x.name.Equals(s)) as Sprite;
                    if (sprite == null)
                    {
                        continue;
                    }

                    animationSprites.Add(sprite);
                }

                SpriteAnimationHelper.GenerateAnimationsBySpriteName($"{_animationFolder}/{info.AnimationName}.anim", info.Frame,
                    animationSprites.ToArray());
            }
        }
    }
}