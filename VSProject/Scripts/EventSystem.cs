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

        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action action)
        {
            actions.Add(action);
        }

        // TODO: test if that works on scene change too!
        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action action)
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
        public void Invoke()
        {
            for (int i = 0; i < this.actions.Count; i++) { this.actions[i].Invoke(); }
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        public void InvokeByArray()
        {
            Action[] a = actions.ToArray();
            for (int i = 0; i < a.Length; i++) { a[i].Invoke(); }
        }

        public bool HasListeners()
        {
            return (this.actions.Count > 0);
        }

        public int GetCountListeners()
        {
            return this.actions.Count;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Event that takes 1 parameters.
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    public class EventSystem<T0> : AbstractEventSystem
    {
        private List<Action<T0>> actions = new List<Action<T0>>();

        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T0> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T0> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T0> action)
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
        public void Invoke(T0 param0)
        {
            for (int i = 0; i < actions.Count; i++) { actions[i].Invoke(param0); }
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param0"></param>
        public void InvokeByArray(T0 param0)
        {
            Action<T0>[] a = actions.ToArray();
            for (int i = 0; i < a.Length; i++) { a[i].Invoke(param0); }
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
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    public class EventSystem<T0, T1> : AbstractEventSystem
    {
        private List<Action<T0, T1>> actions = new List<Action<T0, T1>>();

        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T0, T1> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T0, T1> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T0, T1> action)
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
        public void Invoke(T0 param0, T1 param1)
        {
            for (int i = 0; i < actions.Count; i++) { actions[i].Invoke(param0, param1); }
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        public void InvokeByArray(T0 param0, T1 param1)
        {
            Action<T0, T1>[] a = actions.ToArray();
            for (int i = 0; i < a.Length; i++) { a[i].Invoke(param0, param1); }
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
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class EventSystem<T0, T1, T2> : AbstractEventSystem
    {
        private List<Action<T0, T1, T2>> actions = new List<Action<T0, T1, T2>>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T0, T1, T2> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T0, T1, T2> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T0, T1, T2> action)
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
        public void Invoke(T0 param0, T1 param1, T2 param2)
        {
            for (int i = 0; i < actions.Count; i++) { actions[i].Invoke(param0, param1, param2); }
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public void InvokeByArray(T0 param0, T1 param1, T2 param2)
        {
            Action<T0, T1, T2>[] a = actions.ToArray();
            for (int i = 0; i < a.Length; i++) { a[i].Invoke(param0, param1, param2); }
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
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class EventSystem<T0, T1, T2, T3> : AbstractEventSystem
    {
        private List<Action<T0, T1, T2, T3>> actions = new List<Action<T0, T1, T2, T3>>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T0, T1, T2, T3> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T0, T1, T2, T3> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T0, T1, T2, T3> action)
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
        public void Invoke(T0 param0, T1 param1, T2 param2, T3 param3)
        {
            for (int i = 0; i < actions.Count; i++) { actions[i].Invoke(param0, param1, param2, param3); }
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public void InvokeByArray(T0 param0, T1 param1, T2 param2, T3 param3)
        {
            Action<T0, T1, T2, T3>[] a = actions.ToArray();
            for (int i = 0; i < a.Length; i++) { a[i].Invoke(param0, param1, param2, param3); }
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
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public class EventSystem<T0, T1, T2, T3, T4> : AbstractEventSystem
    {
        private List<Action<T0, T1, T2, T3, T4>> actions = new List<Action<T0, T1, T2, T3, T4>>();
        /// <summary>
        /// Add function to functions list - old method.
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T0, T1, T2, T3, T4> action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Add action to action list IF the action is not yet added.
        /// Works in most cases way better!
        /// </summary>
        /// <param name="action"></param>
        public void AddListenerSingle(Action<T0, T1, T2, T3, T4> action)
        {
            if (!actions.Contains(action)) { actions.Add(action); }
        }

        public void RemoveListener(Action<T0, T1, T2, T3, T4> action)
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
        public void Invoke(T0 param0, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            for (int i = 0; i < actions.Count; i++) { actions[i].Invoke(param0, param1, param2, param3, param4); }
        }

        /// <summary>
        /// Invoke event inside array - slower but safer. List gets transformed to Array
        /// and then the array gets iterated.
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        public void InvokeByArray(T0 param0, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            Action<T0, T1, T2, T3, T4>[] a = actions.ToArray();
            for (int i = 0; i < a.Length; i++) { a[i].Invoke(param0, param1, param2, param3, param4); }
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