using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonTypes
{
    public class ScriptParser
    {
        public List<Command> parseFile(string path)
        {
            var commands = new List<Command>();

            foreach (string line in File.ReadAllLines(path))
            {
                commands.Add(new Command(line));
            }

            return commands;
        }
    }

    public class Command
    {
        private String commandName;
        private List<String> args;
        public string CommandName { get => commandName;}
        public List<string> Args { get => args;}

        public Command(string line)
        {
            args = new List<string>();
            string[] parts = line.Split(null);

            commandName = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                args.Add(parts[i]);
            }
        }

        public String getArgsAsString()
        {
            return String.Join(" ", args.ToArray());
        }
    }

}
