namespace Lucky.Inputs
{
    public abstract class VirtualInput
    {
        public VirtualInput()
        {
            InputManager.Register(this);
        }

        public void Deregister()
        {
            InputManager.Deregister(this);
        }

        public abstract void Update();
    }
}