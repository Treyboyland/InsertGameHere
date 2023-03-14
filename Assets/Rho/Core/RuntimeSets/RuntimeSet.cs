using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{
    /// <summary>
    /// A Runtime set acts like a external collection that can be given to components who can then add/remove/observe for various uses.
    /// Example is a RuntimeSet<GameObject> that can be used to create a number of assets like: PlayerSet, BotPlayerSet, BlocksSet, etc.
    /// You then reference a set like this: [SerializeField] RuntimeGameObjectSet _activePlayersSet
    /// Source: https://youtu.be/raQ3iHhE_Kk?t=2382
    /// </summary>
    public abstract class RuntimeSet<T> : ScriptableObject, ICollection<T>
    {
        protected List<T> _items = new List<T>();

        public delegate void RuntimeSetEventHandler(RuntimeSet<T> sender);

        public event RuntimeSetEventHandler SetChanged = delegate {};

        public virtual int Count => ((ICollection<T>)_items).Count;

        public virtual bool IsReadOnly => ((ICollection<T>)_items).IsReadOnly;

        public virtual void Add(T item)
        {
            ((ICollection<T>)_items).Add(item);
            SetChanged(this);
        }

        public virtual void Clear()
        {
            ((ICollection<T>)_items).Clear();
            SetChanged(this);
        }

        public virtual bool Contains(T item)
        {
            return ((ICollection<T>)_items).Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)_items).CopyTo(array, arrayIndex);
            SetChanged(this);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return ((ICollection<T>)_items).GetEnumerator();
        }

        public virtual bool Remove(T item)
        {
            var rval =  ((ICollection<T>)_items).Remove(item);
            SetChanged(this);
            return rval;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<T>)_items).GetEnumerator();
        }
    }
}
