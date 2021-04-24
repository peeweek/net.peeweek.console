using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    static class ConsoleUtility
    {
#if ENABLE_LEGACY_INPUT_MANAGER
        const string kPrefabName = "Console_LegacyInput";
#elif ENABLE_INPUT_SYSTEM
        const string kPrefabName = "Console_NewInputSystem";
#endif
        [RuntimeInitializeOnLoadMethod]
        static void CreateConsole()
        {
            var prefab = GameObject.Instantiate(Resources.Load<GameObject>(kPrefabName));
            prefab.name = "Console";
            GameObject.DontDestroyOnLoad(prefab);
            
        }
    }
}

