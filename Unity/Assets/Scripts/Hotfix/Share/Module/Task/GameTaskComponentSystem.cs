namespace ET
{
    [EntitySystemOf(typeof(GameTaskComponent))]
    [FriendOfAttribute(typeof(ET.GameTaskComponent))]
    public static partial class GameTaskComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameTaskComponent self)
        {
        }

        public static void AcceptTask(this GameTaskComponent self, int taskId)
        {
            // 已经接取的任务，不处理
            if (self.AcceptedTasks.Contains(taskId))
            {
                return;
            }
            
            TaskConfig config = TaskConfigCategory.Instance.Get(taskId);
            
            // 已完成且非日常任务，不处理
            if (self.CompletedTasks.Contains(taskId) && config.Type != TaskType.TaskType_Daily)
            {
                return;
            }
            
            self.AcceptedTasks.Add(taskId);
        }

        public static void CommitTask(this GameTaskComponent self, int taskId)
        {
            // 不在接取任务列表里，不处理
            if (!self.AcceptedTasks.Contains(taskId))
            {
                return;
            }
            
            // 判断任务条件是否完成
            
            // 完成任务，给奖励
        }
    }
}