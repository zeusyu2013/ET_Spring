using System;

namespace ET
{
    public interface IEvent
    {
        Type Type { get; }
    }

    public abstract class AEvent<S, A> : IEvent where S : class, IScene where A : struct
    {
        public Type Type
        {
            get
            {
                return typeof(A);
            }
        }

        protected abstract ETTask Run(S scene, A args);

        public async ETTask Handle(S scene, A args)
        {
            try
            {
                await Run(scene, args);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}