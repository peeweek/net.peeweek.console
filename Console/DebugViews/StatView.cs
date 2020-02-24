using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    public class StatView : DebugView
    {
        public StatView() : base(0.2f) { }

        public override string GetView()
        {
            return "DEBUG VIEW";
        }
    }
}
