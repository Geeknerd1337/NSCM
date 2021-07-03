using System.Reflection;
using Armadillo.Netscape.Console;

namespace Armadillo.Netscape
{
    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class ConsoleCmdAttribute : System.Attribute
    {
        readonly string command;

        public string Command { get => command; }
        public string Help { get; set; }

        public ConsoleCmdAttribute(string command)
        {
            this.command = command;
        }

        public ConsoleCommand CreateConsoleCmd(MethodInfo info)
        {
            UnityEngine.Debug.Log($"Adding ConsoleCmd \"{Command}\". Found within {info.DeclaringType.FullName}");

            return new ConsoleCommand()
            {
                Command = Command,
                Description = Help,
                ParameterDescriptions = GetParamterInfo(info),
                OnInvoke = (parameters) => { info.Invoke(null, parameters); },
                Owner = info.DeclaringType.Assembly,
                Info = info
            };
        }

        public string[] GetParamterInfo(MethodInfo info)
        {
            string[] paramterBuilder = new string[info.GetParameters().Length];

            foreach (var parameter in info.GetParameters())
            {
                if (!parameter.IsDefined(typeof(ParameterDescAttribute)))
                    continue;
				
				paramterBuilder[parameter.Position] = parameter.GetCustomAttribute<ParameterDescAttribute>().Description;
            }

			return paramterBuilder;
        }
    }
}