using UnityEngine;

namespace Lucky.Inputs
{
    /// <summary>
    /// 对 VirtualInput 的管理
    /// </summary>
    public static class InputConfig
    {
        #region Buttons

        public static void Initialize()
        {
            SetDefaultKeyboardControls(true);
            Left = new VirtualButton(LeftBinding, 0);
            Right = new VirtualButton(RightBinding, 0);
            Up = new VirtualButton(UpBinding, 0);
            Down = new VirtualButton(DownBinding, 0);
            MoveX = new VirtualIntegerAxis(LeftBinding, RightBinding, VirtualIntegerAxis.OverlapBehaviors.TakeNewer);
        }


        public static VirtualButton Left;
        public static VirtualButton Right;
        public static VirtualButton Up;
        public static VirtualButton Down;
        public static VirtualIntegerAxis MoveX;

        #endregion

        #region Bindings

        public static void SetDefaultKeyboardControls(bool reset)
        {
            if (reset || EscBinding.keys.Count <= 0)
            {
                EscBinding.keys.Clear();
                EscBinding.Add(KeyCode.Escape);
            }

            if (reset || PauseBinding.keys.Count <= 0)
            {
                PauseBinding.keys.Clear();
                PauseBinding.Add(KeyCode.Escape);
            }

            if (reset || LeftBinding.keys.Count <= 0)
            {
                LeftBinding.keys.Clear();
                // Left.Add(KeyCode.LeftArrow);
                LeftBinding.Add(KeyCode.J);
            }

            if (reset || RightBinding.keys.Count <= 0)
            {
                RightBinding.keys.Clear();
                // Right.Add(KeyCode.RightArrow);
                RightBinding.Add(KeyCode.L);
            }

            if (reset || DownBinding.keys.Count <= 0)
            {
                DownBinding.keys.Clear();
                // Down.Add(KeyCode.DownArrow);
                DownBinding.Add(KeyCode.K);
            }

            if (reset || UpBinding.keys.Count <= 0)
            {
                UpBinding.keys.Clear();
                // Up.Add(KeyCode.UpArrow);
                UpBinding.Add(KeyCode.I);
            }
        }


        public static Binding EscBinding = new Binding();

        public static Binding PauseBinding = new Binding();

        public static Binding LeftBinding = new Binding();

        public static Binding RightBinding = new Binding();

        public static Binding DownBinding = new Binding();
        public static Binding UpBinding = new Binding();

        #endregion
    }
}