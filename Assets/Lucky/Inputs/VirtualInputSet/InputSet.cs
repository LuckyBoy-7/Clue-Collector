using Lucky.Inputs.VirtualInput;
using UnityEngine;

namespace Lucky.Inputs.VirtualInputSet
{
    /// <summary>
    /// VirtualInput 集合
    /// </summary>
    public abstract class InputSet
    {
        protected BindingSet BindingSet => InputManager.Instance.bindingSet;
    }
}