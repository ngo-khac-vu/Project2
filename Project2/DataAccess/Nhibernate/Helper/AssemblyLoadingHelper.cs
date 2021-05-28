using System;
using System.Linq;
using System.Reflection;

namespace DataAccess.Nhibernate.Helper
{
    public static class AssemblyLoadingHelper
    {
        public static Assembly GetOrLoadAssembly(string assemblyName)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().ToList().FirstOrDefault(s => s.GetName().FullName == assemblyName || s.GetName().Name == assemblyName);
            return assembly ?? Assembly.Load(assemblyName);
        }
    }
}
