using Lucky.Inputs.VirtualInput;
using UnityEngine;

namespace Lucky.Inputs.VirtualInputSet
{
    /// <summary>
    /// VirtualInput 集合
    /// </summary>
    public class BasicInputSet : InputSet
    {
        public BasicInputSet()
        {
            Left = new VirtualButton(BindingSet.LeftBinding, 0);
            Right = new VirtualButton(BindingSet.RightBinding, 0);
            Up = new VirtualButton(BindingSet.UpBinding, 0);
            Down = new VirtualButton(BindingSet.DownBinding, 0);

            MenuLeft = new VirtualButton(BindingSet.MenuLeftBinding, 0).SetRepeat(0.6f, 0.02f);
            MenuRight = new VirtualButton(BindingSet.MenuRightBinding, 0).SetRepeat(0.6f, 0.02f);
            MenuUp = new VirtualButton(BindingSet.MenuUpBinding, 0).SetRepeat(0.6f, 0.02f);
            MenuDown = new VirtualButton(BindingSet.MenuDownBinding, 0).SetRepeat(0.6f, 0.02f);
            Backspace = new VirtualButton(BindingSet.BackspaceBinding, 0).SetRepeat(0.6f, 0.02f);
            Tab = new VirtualButton(BindingSet.TabBinding, 0).SetRepeat(0.6f, 0.02f);
            
            MoveX = new VirtualIntegerAxis(BindingSet.LeftBinding, BindingSet.RightBinding);
        }

        public VirtualButton Left;
        public VirtualButton Right;
        public VirtualButton Up;
        public VirtualButton Down;

        public VirtualButton MenuLeft;
        public VirtualButton MenuRight;
        public VirtualButton MenuUp;
        public VirtualButton MenuDown;
        public VirtualButton Backspace;
        public VirtualButton Tab;
        public VirtualIntegerAxis MoveX;
    }
}