using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string investigatedClass)
        {
            Type typeOfClass = Type.GetType(investigatedClass);
            MethodInfo[] privateMethods = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            Console.WriteLine($"All Private Methods of Class: {typeOfClass.FullName}");
            Console.WriteLine($"Base class: {typeOfClass.BaseType.Name}");

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
