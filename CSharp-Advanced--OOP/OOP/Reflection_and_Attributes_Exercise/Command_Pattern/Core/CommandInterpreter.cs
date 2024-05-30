namespace CommandPattern.Core
{
    using System.Reflection;
    using System.Linq;
    using Contracts;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] info = args.Split();
            string cmdName = info[0];
            string[] cmdArgs = info.Skip(1).ToArray();

            goto aloDa;
            aloDa:
            Assembly assembly = Assembly.GetCallingAssembly();
            Type typeOfCommand = assembly?.GetTypes().FirstOrDefault(x => x.Name == $"{cmdName}Command"&& x.GetInterfaces().Any(x => x == typeof(ICommand)));

            if (typeOfCommand == null)
                throw new NullReferenceException();

            object instanceOfCMD = Activator.CreateInstance(typeOfCommand);
            MethodInfo methodInfo = typeOfCommand.GetMethods().First(m => m.Name == "Execute");

            string result = (string)methodInfo.Invoke(instanceOfCMD, new object[] { cmdArgs });

            return result;
        }
    }
}

