using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    [AutoRegisterConsoleCommand]
    public class StatCommand : IConsoleCommand
    {
        public string name => "stat";

        public string summary => "Display Statistics about current game session";

        public string help => "stat";

        public IEnumerable<Console.Alias> aliases => null;

        public void Execute(string[] args)
        {
            Console.RegisterView<StatView>();
        }
    }
}
