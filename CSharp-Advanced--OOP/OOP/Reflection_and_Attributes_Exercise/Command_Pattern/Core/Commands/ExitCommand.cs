namespace CommandPattern.Core.Commands
{
    using Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private int exitCode = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(exitCode);
            return null;
        }
    }
}

