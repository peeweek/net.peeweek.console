using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    [AutoRegisterConsoleCommand]
    public class ExitCommand : IConsoleCommand
    {
        public void Execute(string[] args)
        {
            if (Application.isEditor)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
                Application.Quit();
                
        }

        public string GetHelp()
        {
            return @"usage: exit 
" + GetSummary();
        }

        public string GetName()
        {
            return "exit";
        }

        public IEnumerable<Console.Alias> GetAliases()
        {
            yield return Console.Alias.Get("quit", "exit");
        }

        public string GetSummary()
        {
            return "Exits the game";
        }
    }

}
