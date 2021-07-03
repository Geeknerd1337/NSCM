using System.Reflection;
using Armadillo.Netscape.Console;

namespace Armadillo.Netscape
{
    [System.AttributeUsage(System.AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
    sealed class ParameterDescAttribute : System.Attribute
    {
        readonly string description;

        public string Description { get => description; }

        public ParameterDescAttribute(string description)
        {
            this.description = description;
        }
    }
}