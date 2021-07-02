using System.Reflection;
using Armadillo.Netscape.Console;

namespace Armadillo.Netscape
{
	[System.AttributeUsage(System.AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	sealed class ConsoleVarAttribute : System.Attribute
	{
		readonly string command;

		public string Command { get => command; }
		public string Help { get; set; }

		// This is a positional argument
		public ConsoleVarAttribute(string command)
		{
			this.command = command;
		}

		public ConsoleCommand CreateConsoleVar(PropertyInfo info)
		{
            UnityEngine.Debug.Log($"Adding ConsoleVar \"{Command}\". Found within {info.DeclaringType.FullName}");

			return new ConsoleCommand()
			{
				Command = Command,
				Description = Help,
				OnInvoke = (parameters) => { info.SetValue(null, parameters[0]); },
				Owner = info.DeclaringType.Assembly,
				Info = info
			};
		}
	}
}