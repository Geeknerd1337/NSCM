using System;
using System.Reflection;

namespace Armadillo.Netscape.Console
{
	internal static class CommandFactory
	{
		public static void AddAssembly(Assembly assembly)
		{
			foreach (var type in assembly.GetTypes())
				foreach (var member in type.GetMembers())
					CreateCommand(member);
		}

		public static void CreateCommand(MemberInfo info)
		{
			if (info is MethodInfo methodInfo && info.IsDefined(typeof(ConsoleCmdAttribute)))
				CommandSystem.AddCommand(methodInfo.GetCustomAttribute<ConsoleCmdAttribute>().CreateConsoleCmd(methodInfo));

			if (info is PropertyInfo propertyInfo && info.IsDefined(typeof(ConsoleVarAttribute)))
				CommandSystem.AddCommand(propertyInfo.GetCustomAttribute<ConsoleVarAttribute>().CreateConsoleVar(propertyInfo));
		}
	}
}