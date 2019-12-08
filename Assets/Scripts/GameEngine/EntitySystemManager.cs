using System.Collections.Generic;
using UnityEngine;

namespace GameEngine {
    public abstract class EntitySystemManager : MonoBehaviour {
        /// <summary>
        /// Every system in this array will execute in the Update loop in order.
        /// </summary>
        public abstract IEnumerable<EntitySystem> UpdateSystems { get; protected set; }
        /// <summary>
        /// Every system in this array will execute in the LateUpdate loop in order.
        /// </summary>
        public abstract IEnumerable<EntitySystem> LateUpdateSystems { get; protected set; }
        /// <summary>
        /// Every system in this array will execute in the FixedUpdate loop in order.
        /// </summary>
        public abstract IEnumerable<EntitySystem> FixedUpdateSystems { get; protected set; }

        private void Update() {
            float deltaTime = Time.deltaTime;
            foreach (EntitySystem entitySystem in UpdateSystems)
                entitySystem.Run(deltaTime);
        }

        private void LateUpdate() {
            float deltaTime = Time.deltaTime;
            foreach (EntitySystem entitySystem in LateUpdateSystems)
                entitySystem.Run(deltaTime);
        }

        private void FixedUpdate() {
            float deltaTime = Time.fixedDeltaTime;
            foreach (EntitySystem entitySystem in FixedUpdateSystems)
                entitySystem.Run(deltaTime);
        }
    }
}
