using System;
using System.Diagnostics;

namespace ET
{
    public static class BuildByPipeline
    {
        private static Stopwatch _stopWatch;

        public static void Build()
        {
            _stopWatch = new Stopwatch();

            // 更新还原版本管理库
            VersionControl();

            // 修改工程设置
            ModifyProjectSettings();

            // 检查资源
            CheckResources();

            // hybridclr编译脚本及元数据
            BuildCode();

            // 打包差异资源
            BuildAssetBundles();

            // 打包工程
            BuildProject();
        }

        private static void VersionControl()
        {
            _stopWatch.Start();

            _stopWatch.Stop();

            Console.WriteLine($"VersionControl耗时：{_stopWatch.ElapsedMilliseconds}ms");
        }

        private static void ModifyProjectSettings()
        {
            _stopWatch.Start();

            _stopWatch.Stop();

            Console.WriteLine($"ModifyProjectSettings耗时：{_stopWatch.ElapsedMilliseconds}ms");
        }

        private static void CheckResources()
        {
            _stopWatch.Start();

            _stopWatch.Stop();

            Console.WriteLine($"CheckResources耗时：{_stopWatch.ElapsedMilliseconds}ms");
        }

        private static void BuildCode()
        {
            _stopWatch.Start();

            _stopWatch.Stop();

            Console.WriteLine($"BuildCode耗时：{_stopWatch.ElapsedMilliseconds}ms");
        }

        private static void BuildAssetBundles()
        {
            _stopWatch.Start();

            _stopWatch.Stop();

            Console.WriteLine($"BuildAssetBundles耗时：{_stopWatch.ElapsedMilliseconds}ms");
        }

        private static void BuildProject()
        {
            _stopWatch.Start();

            _stopWatch.Stop();

            Console.WriteLine($"BuildProject耗时：{_stopWatch.ElapsedMilliseconds}ms");
        }
    }
}