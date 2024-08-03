
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
    [EnableClass]
    public sealed partial class TaskConfig : BeanBase
    {
        public TaskConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            Type = (TaskType)_buf.ReadInt();
            Desc = _buf.ReadString();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);SubTask = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); SubTask.Add(_e0);}}
            PreTask = _buf.ReadInt();
            NextTask = _buf.ReadInt();
            TaskReward = _buf.ReadInt();
            AcceptNpcConfig = _buf.ReadInt();
            CompleteNpcConfig = _buf.ReadInt();

            PostInit();
        }

        public static TaskConfig DeserializeTaskConfig(ByteBuf _buf)
        {
            return new TaskConfig(_buf);
        }

        /// <summary>
        /// 任务id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 任务名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 任务类型
        /// </summary>
        public readonly TaskType Type;

        /// <summary>
        /// 任务描述
        /// </summary>
        public readonly string Desc;

        /// <summary>
        /// 子任务列表
        /// </summary>
        public readonly System.Collections.Generic.List<int> SubTask;

        /// <summary>
        /// 前置任务
        /// </summary>
        public readonly int PreTask;

        /// <summary>
        /// 后置任务
        /// </summary>
        public readonly int NextTask;

        /// <summary>
        /// 任务奖励
        /// </summary>
        public readonly int TaskReward;

        /// <summary>
        /// 任务奖励
        /// </summary>
        public RewardConfig TaskRewardConfig => RewardConfigCategory.Instance.GetOrDefault(TaskReward);

        /// <summary>
        /// 接取任务NPC
        /// </summary>
        public readonly int AcceptNpcConfig;

        /// <summary>
        /// 接取任务NPC
        /// </summary>
        public UnitConfig AcceptNpcConfigConfig => UnitConfigCategory.Instance.GetOrDefault(AcceptNpcConfig);

        /// <summary>
        /// 交付任务NPC
        /// </summary>
        public readonly int CompleteNpcConfig;

        /// <summary>
        /// 交付任务NPC
        /// </summary>
        public UnitConfig CompleteNpcConfigConfig => UnitConfigCategory.Instance.GetOrDefault(CompleteNpcConfig);

        public const int __ID__ = -1794275001;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Type:" + Type + ","
            + "Desc:" + Desc + ","
            + "SubTask:" + Luban.StringUtil.CollectionToString(SubTask) + ","
            + "PreTask:" + PreTask + ","
            + "NextTask:" + NextTask + ","
            + "TaskReward:" + TaskReward + ","
            + "AcceptNpcConfig:" + AcceptNpcConfig + ","
            + "CompleteNpcConfig:" + CompleteNpcConfig + ","
            + "}";
        }

        partial void PostInit();
    }
}
