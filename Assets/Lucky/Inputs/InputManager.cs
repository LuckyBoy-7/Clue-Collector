using System.Collections.Generic;

namespace Lucky.Inputs
{
    /// <summary>
    /// 对 VirtualInput 的管理
    /// </summary>
    public static class InputManager
    {
        public static void Update()
        {
            foreach (var button in _inputs)
            {
                button.Update();
            }
        }

        public static void Register(VirtualInput input) => _inputs.Add(input);
        public static void Deregister(VirtualInput input) => _inputs.Remove(input);
        private static readonly List<VirtualInput> _inputs = new();
    }
}