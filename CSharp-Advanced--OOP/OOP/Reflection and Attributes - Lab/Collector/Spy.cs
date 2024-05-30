using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type typeOfClass = Type.GetType(investigatedClass);
            MethodInfo[] methods = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnType}");
            }
            return sb.ToString().Trim();
        }
    }
}
