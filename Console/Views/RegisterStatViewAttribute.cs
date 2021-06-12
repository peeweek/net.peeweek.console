using System;

namespace ConsoleUtility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterStatViewAttribute : Attribute
    {
        public readonly string name;
        public RegisterStatViewAttribute(string name)
        {
            this.name = name;
        }
    }
}



