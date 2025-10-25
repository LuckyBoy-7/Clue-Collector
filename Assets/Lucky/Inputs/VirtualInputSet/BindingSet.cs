using UnityEngine;

namespace Lucky.Inputs.VirtualInputSet
{
    public class BindingSet
    {
        public Binding EscBinding = new Binding(KeyCode.Escape);

        public Binding PauseBinding = new Binding(KeyCode.Pause);

        public Binding LeftBinding = new Binding(KeyCode.LeftArrow);

        public Binding RightBinding = new Binding(KeyCode.RightArrow);

        public Binding DownBinding = new Binding(KeyCode.DownArrow);
        public Binding UpBinding = new Binding(KeyCode.UpArrow);
        public Binding MenuLeftBinding = new Binding(KeyCode.LeftArrow);

        public Binding MenuRightBinding = new Binding(KeyCode.RightArrow);

        public Binding MenuDownBinding = new Binding(KeyCode.DownArrow);
        public Binding MenuUpBinding = new Binding(KeyCode.UpArrow);
        public Binding BackspaceBinding = new Binding(KeyCode.Backspace);
        public Binding TabBinding = new Binding(KeyCode.Tab);
    }
}