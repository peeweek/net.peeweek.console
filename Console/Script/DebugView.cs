using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    public abstract class DebugView
    {
        float m_UpdateRate;
        float m_TTL;

        string m_Lines;

        public DebugView(float updateRate = 10f)
        {
            m_UpdateRate = updateRate;
            m_TTL = 0;
            Initialize();
        }

        public bool Update()
        {
            if(m_TTL < 0)
            {
                m_TTL = 1.0f / m_UpdateRate;
                return true;
            }
            else
            {
                m_TTL -= Time.unscaledDeltaTime;
                return false;
            }
        }

        public virtual void Initialize() { }

        public abstract string GetView();

        public virtual void OnEnable() 
        { 
            m_TTL = 0.0f; 
        }

        public virtual void OnDisable() { }
    }
}
