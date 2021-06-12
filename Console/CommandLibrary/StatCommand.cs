using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ConsoleUtility
{
    [AutoRegisterConsoleCommand]
    public class StatCommand : IConsoleCommand
    {
        public string name => "stat";

        public string summary => "Display Statistics about current game session";

        public string help => @"stat [<viewname>]
   *  stat <viewname>           shows a view based on its name
   *  stat                      lists all views that can be opened with the show command";

        public IEnumerable<Console.Alias> aliases => null;

        public void Execute(string[] args)
        {
            CacheViews();

            if (args.Length == 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Currently registered views in show command");
                foreach (var kvp in cachedViews)
                {
                    sb.AppendLine($"    * '{kvp.Key}' ({kvp.Value.Name})");
                }
                Console.Log(this.name, sb.ToString());
            }
            else if (args.Length == 1)
            {
                string name = args[0].ToLower();

                if (cachedViews.ContainsKey(name))
                    Console.RegisterView(cachedViews[name]);
                else
                    Console.Log(this.name, $"Could not find stat view of name '{name}'", LogType.Warning);
            }
            else
            {
                Console.Log(this.name, $"'stat' command Syntax: \n {help}", LogType.Log);
            }

        }

        static Dictionary<string, Type> cachedViews;

        void CacheViews()
        {
            if (cachedViews == null)
            {
                cachedViews = new Dictionary<string, Type>();
                foreach (var t in GetConcreteTypes<View>())
                {
                    var a = t.GetCustomAttributes(typeof(RegisterStatViewAttribute), true).FirstOrDefault() as RegisterStatViewAttribute;
                    if (a != null)
                    {
                        cachedViews.Add(a.name.ToLower(), t);
                    }
                }
            }
        }

        public static Type[] GetConcreteTypes<T>()
        {
            List<Type> types = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] assemblyTypes = null;

                try
                {
                    assemblyTypes = assembly.GetTypes();
                }
                catch
                {
                    Debug.LogError($"Could not load types from assembly : {assembly.FullName}");
                }

                if (assemblyTypes != null)
                {
                    foreach (Type t in assemblyTypes)
                    {
                        if (typeof(T).IsAssignableFrom(t) && !t.IsAbstract)
                        {
                            types.Add(t);
                        }
                    }
                }

            }
            return types.ToArray();
        }


    }
}
