namespace GameEngine {
    public abstract class EntitySystem {
        public abstract void Run(float deltaTime);
    }

    public abstract class EntitySystem<T> : EntitySystem where T : Entity<T> {
        public override void Run(float deltaTime) {
            foreach (T entity in Entity<T>.ALL)
                Run(entity, deltaTime);
        }

        public abstract void Run(T entity, float deltaTime);
    }
}
