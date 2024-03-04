using System;
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

            string path = $"Assets/Bundles/FairyGUI/{packageName}_fui.bytes";
            TextAsset asset = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<TextAsset>(path);
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

        public static void RemoveAll(this UIPackageComponent self)
        {
            UIPackage.RemoveAllPackages();
            self.PackageDic.Clear();
        }

        /// <summary>
        /// 包加载资源回调函数
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name">名字</param>
        /// <param name="extension">后缀</param>
        /// <param name="type">资源类型</param>
        /// <param name="item">包Item</param>
        public static void PackageLoadFunc(this UIPackageComponent self, string name, string extension, Type type, PackageItem item)
        {
            self.PackageLoad(name, extension, type, item).Coroutine();
        }

        // 自定义包加载函数
        public static async ETTask PackageLoad(this UIPackageComponent self, string name, string extension,  Type type, PackageItem item)
        {
            string path = $"Assets/Bundles/FairyGUI/{item.owner.name}_{name}{extension}";
            var o = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync(type, path);
            if (o == null)
            {
                return;
            }
            item.owner.SetItemAsset(item, o,  DestroyMethod.Unload);
        }
    }
}