using System;
using System.Reflection;

namespace Armadillo.Netscape.Console
{
	internal struct ConsoleCommand
	{
		public string Command { get; internal set; }
		public string Description { get; internal set; }

		public Action<object[]> OnInvoke { get; internal set; }
		public string[] ParameterDescriptions { get; internal set; }
		public Assembly Owner { get; internal set; }
		public MemberInfo Info { get; internal set; }
	}
}
