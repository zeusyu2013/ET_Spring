﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ET
{
    public class WorldActor: Singleton<WorldActor>, ISingletonAwake, ISingletonLoad
    {
        private readonly Dictionary<Type, List<IProcessActorHandler>> handlers = new();

        private readonly ConcurrentDictionary<int, ConcurrentQueue<MessageObject>> messages = new();
        
        public void Awake()
        {
            this.Load();
        }

        public void Load()
        {
            var types = EventSystem.Instance.GetTypes(typeof (ProcessActorHandlerAttribute));
            foreach (Type type in types)
            {
                IProcessActorHandler processActorHandler = Activator.CreateInstance(type) as IProcessActorHandler;
                if (processActorHandler == null)
                {
                    Log.Error($"Process Actor Handler {type.Name} 需要继承 IProcessActorHandler");
                    continue;
                }

                Type messageType = processActorHandler.GetMessageType();
                if (!this.handlers.TryGetValue(messageType, out var list))
                {
                    list = new List<IProcessActorHandler>();
                    this.handlers.Add(messageType, list);
                }
                list.Add(processActorHandler);
            }
        }

        public void Handle(MessageObject messageObject)
        {
            if (!this.handlers.TryGetValue(messageObject.GetType(), out var list))
            {
                throw new Exception($"not found process actor handler: {messageObject.GetType().FullName}");
            }

            foreach (IProcessActorHandler processActorHandler in list)
            {
                processActorHandler.Handle(messageObject);
            }
        }
        
        public void Send(int processId, MessageObject messageObject)
        {
            if (!this.messages.TryGetValue(processId, out var queue))
            {
                return;
            }
            queue.Enqueue(messageObject);
        }
        
        public void Fetch(int processId, int count, List<MessageObject> list)
        {
            if (!this.messages.TryGetValue(processId, out var queue))
            {
                return;
            }

            for (int i = 0; i < count; ++i)
            {
                if (!queue.TryDequeue(out var message))
                {
                    break;
                }
                list.Add(message);
            }
        }

        public void AddActor(int processId)
        {
            var queue = new ConcurrentQueue<MessageObject>();
            this.messages[processId] = queue;
        }
        
        public void RemoveActor(int processId)
        {
            this.messages.TryRemove(processId, out _);
        }
    }
}