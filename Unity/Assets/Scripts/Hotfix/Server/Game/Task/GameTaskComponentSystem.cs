namespace ET.Server
{
    [EntitySystemOf(typeof(GameTaskComponent))]
    [FriendOfAttribute(typeof(GameTaskComponent))]
    public static partial class GameTaskComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameTaskComponent self)
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

        public static void UpdateTaskSchdule(this GameTaskComponent self, SubTaskType type, params object[] args)
        {
            if (self.AcceptedTasks.Count < 1)
            {
                return;
            }

            foreach (int task in self.AcceptedTasks)
            {
                TaskConfig config = TaskConfigCategory.Instance.Get(task);
                if (config == null)
                {
                    continue;
                }

                foreach (int i in config.SubTask)
                {
                    SubTaskConfig subTaskConfig = SubTaskConfigCategory.Instance.Get(i);
                    if (subTaskConfig == null)
                    {
                        continue;
                    }

                    if (subTaskConfig.SubTaskType != type)
                    {
                        continue;
                    }
                }
            }
        }

        public static void CommitTask(this GameTaskComponent self, int taskId)
        {
            // 不在接取任务列表里，不处理
            if (!self.AcceptedTasks.Contains(taskId))
            {
                return;
            }

            // 判断任务条件是否完成
            TaskConfig config = TaskConfigCategory.Instance.Get(taskId);

            // 完成任务
            self.AcceptedTasks.Remove(taskId);
            self.CompletedTasks.Add(taskId);

            EventSystem.Instance.Publish(self.Scene(), new TaskComplete());

            // 给奖励
            self.GetParent<Unit>().GetComponent<RewardComponent>().Reward(config.TaskReward);
        }
    }
}