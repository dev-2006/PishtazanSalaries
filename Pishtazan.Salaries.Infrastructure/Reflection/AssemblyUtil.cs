using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Infrastructure.Reflection
{
    public static class AssemblyUtil
    {
        public static T[] LoadInstances<T>()
        {
            return LoadInstances<T>(Assembly.GetAssembly(typeof(T))!);
        }

        public static T[] LoadInstances<T>(Assembly assembly)
        {
            var types = LoadTypes<T>(assembly);

            return types.Select(t => (T)Activator.CreateInstance(t)!).ToArray();
        }

        public static Type[] LoadTypes<T>()
        {
            return LoadTypes<T>(Assembly.GetAssembly(typeof(T))!);
        }

        public static Type[] LoadTypes<T>(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(T)) && t.IsClass && !t.IsAbstract).ToArray();
        }
    }
}
