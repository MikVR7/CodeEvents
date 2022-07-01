using System;
using System.Collections.Generic;

namespace CodeEvents
{
    /// <summary>
    /// Event system that mimics the UnityEvent system but its faster and adds some features.
    /// ... and whats best: It can be easily extended!
    /// </summary>
    public class AbstractEventSystem { }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 0 parameters.
    /// </summary>
    public class EventSystem : AbstractEventSystem
    {
        private List<Action> actions = new List<Action>();
        private List<Action> actionsPendingAdd = new List<Action>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action action)
        {
            //actions.Add(action);
            this.actionsPendingAdd.Add(action);
        }

        // TODO: test if that works on scene change too!
        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action action)
        {
            if (!actions.Contains(action) && !actionsPendingAdd.Contains(action)) { actionsPendingAdd.Add(action); }
        }

        public void RemoveListener(Action action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
            if (actionsPendingAdd.Contains(action))
            {
                actionsPendingAdd.Remove(action);
            }
        }

        public void RemoveAllListeners()
        {
            actions.Clear();
            actionsPendingAdd.Clear();
        }

        /// <summary>
        /// Invoke event inside list - faster than InvokeSafe, but might run into 
        /// exception if the list gets changed while iterating.
        /// </summary>
        public void Invoke()
        {
            this.CombinePendingToActions();
            actions.ForEach(i => i.Invoke());
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        public void InvokeSafe()
        {
            CombinePendingToActions();
            foreach (Action a in actions.ToArray())
            {
                a.Invoke();
            }
        }

        private void CombinePendingToActions()
        {
            this.actionsPendingAdd.ForEach(i => this.actions.Add(i));
            this.actionsPendingAdd.Clear();
        }

        public bool HasListeners()
        {
            return (this.actions.Count > 0) || (this.actionsPendingAdd.Count > 0);
        }

        public int GetCountListeners()
        {
            return this.actions.Count + this.actionsPendingAdd.Count;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 1 parameters.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventSystem<T> : AbstractEventSystem
    {
        private List<Action<T>> actions = new List<Action<T>>();
        
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T> action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
        }

        public void RemoveAllListeners()
        {
            actions.Clear();
        }

        /// <summary>
        /// Invoke event inside list - faster than InvokeSafe, but might run into 
        /// exception if the list gets changed while iterating.
        /// </summary>
        /// <param name="param0"></param>
        public void Invoke(T param0)
        {
            actions.ForEach(i => i.Invoke(param0));
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param0"></param>
        public void InvokeSafe(T param0)
        {
            foreach (Action<T> a in actions.ToArray())
            {
                a.Invoke(param0);
            }
        }

        public bool HasListeners()
        {
            return this.actions.Count > 0;
        }
        public int GetCountListeners()
        {
            return this.actions.Count;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 2 parameters.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class EventSystem<T1, T2> : AbstractEventSystem
    {
        private List<Action<T1, T2>> actions = new List<Action<T1, T2>>();

        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T1, T2> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T1, T2> action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
        }

        public void RemoveAllListeners()
        {
            actions.Clear();
        }

        /// <summary>
        /// Invoke event inside list - faster than InvokeSafe, but might run into 
        /// exception if the list gets changed while iterating.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        public void Invoke(T1 param0, T2 param1)
        {
            actions.ForEach(i => i.Invoke(param0, param1));
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public void InvokeSafe(T1 param1, T2 param2)
        {
            foreach (Action<T1, T2> a in actions.ToArray())
            {
                a.Invoke(param1, param2);
            }
        }

        public bool HasListeners()
        {
            return this.actions.Count > 0;
        }
        public int GetCountListeners()
        {
            return this.actions.Count;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 3 parameters.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class EventSystem<T1, T2, T3> : AbstractEventSystem
    {
        private List<Action<T1, T2, T3>> actions = new List<Action<T1, T2, T3>>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T1, T2, T3> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T1, T2, T3> action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
        }

        public void RemoveAllListeners()
        {
            actions.Clear();
        }

        /// <summary>
        /// Invoke event inside list - faster than InvokeSafe, but might run into 
        /// exception if the list gets changed while iterating.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public void Invoke(T1 param0, T2 param1, T3 param2)
        {
            actions.ForEach(i => i.Invoke(param0, param1, param2));
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public void InvokeSafe(T1 param1, T2 param2, T3 param3)
        {
            foreach (Action<T1, T2, T3> a in actions.ToArray())
            {
                a.Invoke(param1, param2, param3);
            }
        }

        public bool HasListeners()
        {
            return this.actions.Count > 0;
        }
        public int GetCountListeners()
        {
            return this.actions.Count;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 4 parameters.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public class EventSystem<T1, T2, T3, T4> : AbstractEventSystem
    {
        private List<Action<T1, T2, T3, T4>> actions = new List<Action<T1, T2, T3, T4>>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T1, T2, T3, T4> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T1, T2, T3, T4> action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
        }

        public void RemoveAllListeners()
        {
            actions.Clear();
        }

        /// <summary>
        /// Invoke event inside list - faster than InvokeSafe, but might run into 
        /// exception if the list gets changed while iterating.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public void Invoke(T1 param0, T2 param1, T3 param2, T4 param3)
        {
            actions.ForEach(i => i.Invoke(param0, param1, param2, param3));
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        public void InvokeSafe(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            foreach (Action<T1, T2, T3, T4> a in actions.ToArray())
            {
                a.Invoke(param1, param2, param3, param4);
            }
        }

        public bool HasListeners()
        {
            return this.actions.Count > 0;
        }
        public int GetCountListeners()
        {
            return this.actions.Count;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 5 parameters.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public class EventSystem<T1, T2, T3, T4, T5> : AbstractEventSystem
    {
        private List<Action<T1, T2, T3, T4, T5>> actions = new List<Action<T1, T2, T3, T4, T5>>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2, T3, T4, T5> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T1, T2, T3, T4, T5> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T1, T2, T3, T4, T5> action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
        }

        public void RemoveAllListeners()
        {
            actions.Clear();
        }

        /// <summary>
        /// Invoke event inside list - faster than InvokeSafe, but might run into 
        /// exception if the list gets changed while iterating.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        public void Invoke(T1 param0, T2 param1, T3 param2, T4 param3, T5 param4)
        {
            actions.ForEach(i => i.Invoke(param0, param1, param2, param3, param4));
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <param name="param5"></param>
        public void InvokeSafe(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            foreach (Action<T1, T2, T3, T4, T5> a in actions.ToArray())
            {
                a.Invoke(param1, param2, param3, param4, param5);
            }
        }

        public bool HasListeners()
        {
            return this.actions.Count > 0;
        }
        public int GetCountListeners()
        {
            return this.actions.Count;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}