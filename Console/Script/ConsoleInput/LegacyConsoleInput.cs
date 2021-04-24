#if ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine;

namespace ConsoleUtility
{
    public class LegacyConsoleInput : ConsoleInput
    {
        public KeyCode ToggleKey = KeyCode.Backslash;
        public KeyCode CycleViewKey = KeyCode.Tab;
        public KeyCode PreviousCommandKey = KeyCode.UpArrow;
        public KeyCode NextCommandKey = KeyCode.DownArrow;
        public KeyCode ScrollUpKey = KeyCode.PageUp;
        public KeyCode ScrollDownKey = KeyCode.PageDown;
        public KeyCode ValidateKey = KeyCode.Return;


        public override bool toggle => Input.GetKeyDown(ToggleKey);

        public override bool cycleView => Input.GetKeyDown(CycleViewKey);

        public override bool previousCommand => Input.GetKeyDown(PreviousCommandKey);

        public override bool nextCommand => Input.GetKeyDown(NextCommandKey);

        public override bool scrollUp => Input.GetKeyDown(ScrollUpKey);

        public override bool scrollDown => Input.GetKeyDown(ScrollDownKey);

        public override bool validate => Input.GetKeyDown(ValidateKey);
    }
}
#endif
