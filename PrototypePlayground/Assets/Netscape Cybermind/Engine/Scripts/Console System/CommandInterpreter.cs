using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Armadillo.Netscape.Console
{
	internal static class CommandInterpreter
	{
		public static object[] ConvertArgs(Type[] paramters, string[] args)
		{
			List<object> finalArgs = new List<object>();

			for (int i = 0; i < args.Length; i++)
			{
				finalArgs.Add(System.Convert.ChangeType(args[i], paramters[i]));
			}

			return finalArgs.ToArray();
		}

		public static Type[] GetParameterTypes(MemberInfo info)
		{
			List<Type> paramteres = new List<Type>();

			if (info is PropertyInfo propertyInfo)
				return new Type[] { propertyInfo.PropertyType };

			if (info is MethodInfo methodInfo)
			{
				foreach (var item in methodInfo.GetParameters())
					paramteres.Add(item.ParameterType);
			}

			return paramteres.ToArray();
		}

		public static string[] SplitArguments(this string commandLine)
		{
			var parmChars = commandLine.ToCharArray();
			var inSingleQuote = false;
			var inDoubleQuote = false;
			for (var index = 0; index < parmChars.Length; index++)
			{
				if (parmChars[index] == '"' && !inSingleQuote)
				{
					inDoubleQuote = !inDoubleQuote;
					parmChars[index] = '\n';
				}
				if (parmChars[index] == '\'' && !inDoubleQuote)
				{
					inSingleQuote = !inSingleQuote;
					parmChars[index] = '\n';
				}
				if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
					parmChars[index] = '\n';
			}
			return (new string(parmChars)).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}