using System;
using System.Collections.Generic;
using System.IO;
using Animancer;
using Animancer.Editor.Tools;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public static class SpriteAnimationHelper
    {
        public static void GenerateAnimationsBySpriteName(string animationPath, int frame, Sprite[] sprites)
        {
            if (sprites == null || sprites.Length < 1)
            {
                EditorHelper.LogError("创建Sprite动画失败，精灵图数量少于1");
                return;
            }

            CreateAnimation(animationPath, frame, sprites);

            AssetDatabase.SaveAssets();
        }

        private static void CreateAnimation(string path, int frame, params Sprite[] sprites)
        {
            var clip = new AnimationClip
            {
                frameRate = frame,
            };

            var spriteKeyFrames = new ObjectReferenceKeyframe[sprites.Length];
            for (int i = 0; i < spriteKeyFrames.Length; i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe
                {
                    time = i / (float)frame,
                    value = sprites[i]
                };
            }

            var spriteBinding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");
            AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteKeyFrames);

            AssetDatabase.CreateAsset(clip, path);
        }

        public static void Pack(string path, List<string> textures)
        {
            if (string.IsNullOrEmpty(path) || textures.Count < 1)
            {
                return;
            }

            foreach (string s in textures)
            {
                MakeTextureReadable(s);
            }

            try
            {
                const string ProgressTitle = "打包图集";
                EditorUtility.DisplayProgressBar(ProgressTitle, "采集中……", 0);

                var tightSprites = GatherTightSprites(textures);

                EditorUtility.DisplayProgressBar(ProgressTitle, "打包中……", 0.1f);

                var packedTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false);

                var tightTextures = new Texture2D[tightSprites.Count];
                var index = 0;
                foreach (var sprite in tightSprites)
                    tightTextures[index++] = sprite.texture;

                var packedUVs = packedTexture.PackTextures(tightTextures, 1, 2048);

                EditorUtility.DisplayProgressBar(ProgressTitle, "加密中……", 0.4f);
                var bytes = packedTexture.EncodeToPNG();
                if (bytes == null)
                    return;

                EditorUtility.DisplayProgressBar(ProgressTitle, "写入文件……", 0.5f);
                File.WriteAllBytes(path, bytes);
                AssetDatabase.Refresh();

                var importer = AssetImporter.GetAtPath(path) as TextureImporter;
                importer.maxTextureSize = Math.Max(packedTexture.width, packedTexture.height);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Multiple;

                var data = new SpriteDataEditor(importer)
                {
                    SpriteCount = 0
                };

                CopyCompressionSettings(importer, textures);
                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();

                // Use the UV coordinates to set up sprites for the new texture.
                EditorUtility.DisplayProgressBar(ProgressTitle, "Generating Sprites", 0.7f);

                data.SpriteCount = tightSprites.Count;
                index = 0;
                foreach (var sprite in tightSprites)
                {
                    var rect = packedUVs[index];
                    rect.x *= packedTexture.width;
                    rect.y *= packedTexture.height;
                    rect.width *= packedTexture.width;
                    rect.height *= packedTexture.height;

                    var spriteRect = rect;
                    spriteRect.x += spriteRect.width * sprite.rect.x / sprite.texture.width;
                    spriteRect.y += spriteRect.height * sprite.rect.y / sprite.texture.height;
                    spriteRect.width *= sprite.rect.width / sprite.texture.width;
                    spriteRect.height *= sprite.rect.height / sprite.texture.height;

                    var pivot = sprite.pivot;
                    pivot.x /= rect.width;
                    pivot.y /= rect.height;

                    data.SetName(index, sprite.name);
                    data.SetRect(index, spriteRect);
                    data.SetAlignment(index, GetAlignment(sprite.pivot));
                    data.SetPivot(index, pivot);
                    data.SetBorder(index, sprite.border);

                    index++;
                }

                EditorUtility.DisplayProgressBar(ProgressTitle, "Saving", 0.9f);

                data.Apply();

                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();

                Selection.activeObject = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        public static void MakeTextureReadable(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (importer == null)
            {
                return;
            }

            if (importer.isReadable)
            {
                return;
            }

            importer.isReadable = true;
            importer.SaveAndReimport();
        }

        private static HashSet<Sprite> GatherTightSprites(List<string> textures)
        {
            var sprites = new HashSet<Sprite>();

            for (int i = 0; i < textures.Count; i++)
            {
                var path = textures[i];
                if (string.IsNullOrEmpty(path))
                    continue;

                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
                if (sprite == null)
                {
                    continue;
                }

                sprites.Add(CreateTightSprite(sprite));
            }

            return sprites;
        }

        private static Sprite CreateTightSprite(Sprite sprite)
        {
            var rect = sprite.rect;
            var width = Mathf.CeilToInt(rect.width);
            var height = Mathf.CeilToInt(rect.height);
            if (width == sprite.texture.width &&
                height == sprite.texture.height)
                return sprite;

            var pixels = sprite.texture.GetPixels(Mathf.FloorToInt(rect.x),
                Mathf.FloorToInt(rect.y),
                width,
                height);

            var texture = new Texture2D(width, height, sprite.texture.format, false, true);
            texture.SetPixels(pixels);
            texture.Apply();

            rect.x = 0;
            rect.y = 0;

            var pivot = sprite.pivot;
            pivot.x /= rect.width;
            pivot.y /= rect.height;

            var newSprite = Sprite.Create(texture, rect, pivot, sprite.pixelsPerUnit);
            newSprite.name = sprite.name;
            return newSprite;
        }

        private static TextureImporter GetTextureImporter(UnityEngine.Object asset)
        {
            var path = AssetDatabase.GetAssetPath(asset);
            if (string.IsNullOrEmpty(path))
                return null;

            return GetTextureImporter(path);
        }

        private static TextureImporter GetTextureImporter(string path) => AssetImporter.GetAtPath(path) as TextureImporter;

        private static void CopyCompressionSettings(TextureImporter copyTo, List<string> copyFrom)
        {
            var first = true;
            foreach (var texture in copyFrom)
            {
                var copyFromImporter = GetTextureImporter(texture);
                if (copyFromImporter == null)
                    continue;

                if (first)
                {
                    first = false;

                    copyTo.textureCompression = copyFromImporter.textureCompression;
                    copyTo.crunchedCompression = copyFromImporter.crunchedCompression;
                    copyTo.compressionQuality = copyFromImporter.compressionQuality;
                    copyTo.filterMode = copyFromImporter.filterMode;
                }
                else
                {
                    if (IsHigherQuality(copyFromImporter.textureCompression, copyTo.textureCompression))
                        copyTo.textureCompression = copyFromImporter.textureCompression;

                    if (copyFromImporter.crunchedCompression)
                        copyTo.crunchedCompression = true;

                    if (copyTo.compressionQuality < copyFromImporter.compressionQuality)
                        copyTo.compressionQuality = copyFromImporter.compressionQuality;

                    if (copyTo.filterMode > copyFromImporter.filterMode)
                        copyTo.filterMode = copyFromImporter.filterMode;
                }
            }
        }

        private static bool IsHigherQuality(TextureImporterCompression higher, TextureImporterCompression lower)
        {
            switch (higher)
            {
                case TextureImporterCompression.Uncompressed:
                    return lower != TextureImporterCompression.Uncompressed;

                case TextureImporterCompression.Compressed:
                    return lower == TextureImporterCompression.CompressedLQ;

                case TextureImporterCompression.CompressedHQ:
                    return
                            lower == TextureImporterCompression.Compressed ||
                            lower == TextureImporterCompression.CompressedLQ;

                case TextureImporterCompression.CompressedLQ:
                    return false;

                default:
                    throw CreateUnsupportedArgumentException(higher);
            }
        }

        public static string GetUnsupportedMessage<T>(T value) => $"Unsupported {typeof(T).FullName}: {value}";

        public static ArgumentException CreateUnsupportedArgumentException<T>(T value) => new ArgumentException(GetUnsupportedMessage(value));

        private static SpriteAlignment GetAlignment(Vector2 pivot)
        {
            switch (pivot.x)
            {
                case 0:
                    switch (pivot.y)
                    {
                        case 0: return SpriteAlignment.BottomLeft;
                        case 0.5f: return SpriteAlignment.BottomCenter;
                        case 1: return SpriteAlignment.BottomRight;
                    }

                    break;
                case 0.5f:
                    switch (pivot.y)
                    {
                        case 0: return SpriteAlignment.LeftCenter;
                        case 0.5f: return SpriteAlignment.Center;
                        case 1: return SpriteAlignment.RightCenter;
                    }

                    break;
                case 1:
                    switch (pivot.y)
                    {
                        case 0: return SpriteAlignment.TopLeft;
                        case 0.5f: return SpriteAlignment.TopCenter;
                        case 1: return SpriteAlignment.TopRight;
                    }

                    break;
            }

            return SpriteAlignment.Custom;
        }

        private static void FindDirectionalAnimationSet8(string path)
        {
            DirectionalAnimationSet8 set = ScriptableObject.CreateInstance<DirectionalAnimationSet8>();
            AssetDatabase.CreateAsset(set, path);

            var directory = Path.GetDirectoryName(path);

            var guids = AssetDatabase.FindAssets($"{set.name} t:{nameof(AnimationClip)}",
                new[] { directory });

            for (int i = 0; i < guids.Length; i++)
            {
                var tempPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(tempPath);
                if (clip == null)
                    continue;

                set.SetClipByName(clip);
            }
        }
    }
}