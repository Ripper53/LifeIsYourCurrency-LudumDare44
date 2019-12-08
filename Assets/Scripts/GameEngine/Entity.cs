using System.Collections.Generic;
using UnityEngine;

namespace GameEngine {
    /// <summary>
    /// An entity is added to its ALL list: Entity&lt;<typeparamref name="T"/>&gt;.ALL
    /// </summary>
    /// <typeparam name="T">The class type!</typeparam>
    public abstract class Entity<T> : MonoBehaviour where T : Entity<T> {
        /// <summary>
        /// List of all <see cref="ALL"/> entites!
        /// </summary>
        public static readonly HashSet<T> ALL = new HashSet<T>();

        private void Awake() {
            ALL.Add((T)this);
            Init();
        }

        private void OnDestroy() {
            ALL.Remove((T)this);
            Destroyed();
        }

        /// <summary>
        /// Runs when the entity is created.
        /// </summary>
        protected abstract void Init();
        /// <summary>
        /// Runs when the entity is destroyed.
        /// </summary>
        protected abstract void Destroyed();
    }
}
