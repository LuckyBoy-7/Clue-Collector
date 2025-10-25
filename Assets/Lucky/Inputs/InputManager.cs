using System.Collections.Generic;
using Lucky.Inputs.VirtualInputSet;
using Sirenix.OdinInspector.Editor.Drawers;

namespace Lucky.Inputs
{
    /// <summary>
    /// 对 VirtualInput 的管理
    /// </summary>
    public class InputManager
    {
        public static InputManager Instance;


        private readonly List<VirtualInput.VirtualInput> _inputs = new();

        public BindingSet bindingSet;

        public BasicInputSet basic;

        public InputManager()
        {
            Instance = this;
            bindingSet = new ();
            basic = new();
        }

        public void Update()
        {
            foreach (var button in _inputs)
            {
                button.Update();
            }
        }

        public void Register(VirtualInput.VirtualInput input) => _inputs.Add(input);
        public void Deregister(VirtualInput.VirtualInput input) => _inputs.Remove(input);
    }
}