/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIUpdateComponent: Entity, IAwake, IDestroy
    {
        public GProgressBar Gupdate_progressbar { get; set; }
        public GTextField Gupdate_progress_text { get; set; }
    }
}