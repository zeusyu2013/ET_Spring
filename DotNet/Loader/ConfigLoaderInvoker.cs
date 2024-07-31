using System;
using System.Collections.Generic;
using System.IO;
using Luban;

namespace ET
{
    [Invoke]
    public class GetAllConfigBytes : AInvokeHandler<ConfigLoader.GetAllConfigBytes, ETTask<Dictionary<Type, ByteBuf>>>
    {
        public override async ETTask<Dictionary<Type, ByteBuf>> Handle(ConfigLoader.GetAllConfigBytes args)
        {
            Dictionary<Type, ByteBuf> output = new Dictionary<Type, ByteBuf>();
            List<string> startConfigs = new List<string>()
            {
                "StartMachineConfigCategory",
                "StartProcessConfigCategory",
                "StartSceneConfigCategory",
                "StartZoneConfigCategory",
            };
            HashSet<Type> configTypes = CodeTypes.Instance.GetTypes(typeof(ConfigAttribute));
            foreach (Type configType in configTypes)
            {
                string configFilePath;
                if (startConfigs.Contains(configType.Name))
                {
                    configFilePath = $"../Config/Excel/s/{Options.Instance.StartConfig}/{configType.Name}.bytes";
                }
                else
                {
                    configFilePath = $"../Config/Excel/s/{configType.Name}.bytes";
                }

                output[configType] = new ByteBuf(File.ReadAllBytes(configFilePath));
            }

            await ETTask.CompletedTask;
            return output;
        }
    }

    [Invoke]
    public class GetOneConfigBytes : AInvokeHandler<ConfigLoader.GetOneConfigBytes, ByteBuf>
    {
        public override ByteBuf Handle(ConfigLoader.GetOneConfigBytes args)
        {
            ByteBuf configBytes = new ByteBuf(File.ReadAllBytes($"../Config/Excel/s/{args.ConfigName}.bytes"));
            return configBytes;
        }
    }

    [Invoke]
    public class ReloadOneConfig : AInvokeHandler<ConfigLoader.ReloadOneConfig, ETTask<ByteBuf>>
    {
        public override async ETTask<ByteBuf> Handle(ConfigLoader.ReloadOneConfig args)
        {
            await ETTask.CompletedTask;
            
            ByteBuf configBytes = new ByteBuf(File.ReadAllBytes($"../Config/Excel/s/{args.ConfigName}.bytes"));
            return configBytes;
        }
    }
}