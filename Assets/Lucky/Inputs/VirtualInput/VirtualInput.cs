namespace Lucky.Inputs.VirtualInput
{
    public abstract class VirtualInput
    {
        public VirtualInput()
        {
            InputManager.Instance.Register(this);
        }

        public void Deregister()
        {
            InputManager.Instance.Deregister(this);
        }

        public abstract void Update();
    }
}