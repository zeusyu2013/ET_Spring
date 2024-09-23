using System;
using System.Linq;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UIPackageComponent))]
    [EntitySystemOf(typeof(UIPackageComponent))]
    public static partial class UIPackageComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIPackageComponent self)
        {
            self.AddPackage(UIPackageName.Common).Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this UIPackageComponent self)
        {
            self.RemoveAll();
        }

        /// <summary>
        /// 添加包
        /// </summary>
        /// <param name="self"></param>
        /// <param name="packageName"></param>
        public static async ETTask AddPackage(this UIPackageComponent self, string packageName)
        {
            if (self.PackageDic.ContainsKey(packageName))
            {
                self.PackageDic[packageName] += 1;
                return;
            }

            self.PackageDic.Add(packageName, 1);

            string path = $"Assets/Bundles/FairyGUI/{packageName}/{packageName}_fui.bytes";
            TextAsset asset = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<TextAsset>(path);
            self.AddLoadInfo(packageName, path);
            if (asset == null)
            {
                return;
            }

            UIPackage.AddPackage(asset.bytes, "", self.PackageLoadFunc);
        }

        public static void RemovePackage(this UIPackageComponent self, string packageName)
        {
            if (!self.PackageDic.ContainsKey(packageName))
            {
                return;
            }

            self.PackageDic[packageName] -= 1;
        }

        public static void RemoveUselessPackage(this UIPackageComponent self)
        {
            var keys = self.PackageDic.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                if (self.PackageDic[keys[i]] > 0)
                {
                    continue;
                }

                self.PackageDic.Remove(keys[i]);
                self.RemoveLoadInfo(keys[i]);
            }
        }

        /// <summary>
        /// 添加加载的信息
        /// </summary>
        private static void AddLoadInfo(this UIPackageComponent self, string packageName, string path)
        {
            if (self.MutiLoadKey.Contains(packageName, path))
            {
                return;
            }

            self.MutiLoadKey.Add(packageName, path);
        }

        private static void RemoveLoadInfo(this UIPackageComponent self, string packageName)
        {
            if (!self.MutiLoadKey.TryGetValue(packageName, out var value))
            {
                return;
            }

            foreach (var key in value)
            {
                self.Scene().GetComponent<ResourcesLoaderComponent>().RemoveHandler(key);
            }

            value.Clear();
            self.MutiLoadKey.Remove(packageName);
        }

        private static void RemoveAll(this UIPackageComponent self)
        {
            UIPackage.RemoveAllPackages();
            foreach (var kv in self.MutiLoadKey)
            {
                foreach (var key in kv.Value)
                {
                    self.Scene().GetComponent<ResourcesLoaderComponent>().RemoveHandler(key);
                }
            }

            self.PackageDic.Clear();
            self.MutiLoadKey.Clear();
        }

        /// <summary>
        /// 包加载资源回调函数
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name">名字</param>
        /// <param name="extension">后缀</param>
        /// <param name="type">资源类型</param>
        /// <param name="item">包Item</param>
        private static void PackageLoadFunc(this UIPackageComponent self, string name, string extension, Type type, PackageItem item)
        {
            self.PackageLoad(name, extension, type, item).Coroutine();
        }

        // 自定义包加载函数
        private static async ETTask PackageLoad(this UIPackageComponent self, string name, string extension, Type type, PackageItem item)
        {
            string path = $"Assets/Bundles/FairyGUI/{item.owner.name}/{item.owner.name}_{name}{extension}";
            self.AddLoadInfo(item.owner.name, path);
            var o = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync(type, path);
            if (o == null)
            {
                return;
            }

            item.owner.SetItemAsset(item, o, DestroyMethod.Unload);
        }
    }
}