using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIComponent))]
    public class UIPackageComponent: Entity, IAwake, IDestroy
    {
        public readonly Dictionary<string, int> PackageDic = new ();

        public string Path = "FairyGUI/";

        public MultiMap<string, string> MutiLoadKey = new();
    }
}