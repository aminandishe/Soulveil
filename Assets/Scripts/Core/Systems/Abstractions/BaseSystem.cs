using System;
using UnityEngine;

namespace Core.Systems.Abstractions
{
    public abstract class BaseGamePlaySystem
    {
        public virtual void OnActivated() { }
        public virtual void OnDeActivated(){ }
        
        protected void ExecuteActionSafe(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch(Exception e)
            {
                Debug.LogException(e);
            }
        }


        protected void ExecuteActionSafe<T>(Action<T> action, T t)
        {
            try
            {
                action?.Invoke(t);
            }
            catch(Exception e)
            {
                Debug.LogException(e);
            }
        }

        protected TResult ExecuteActionSafe<T, TResult>(Func<T, TResult> func, T t)
        {
            try
            {
                return func(t);
            }
            catch(Exception e)
            {
                Debug.LogException(e);
                return default;
            }
        }
    }
}