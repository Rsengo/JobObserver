using System.Collections.Generic;
using System.Reflection;

namespace BuildingBlocks.Extensions.Assemblies
{
    public static class AssemblyExtensions
    {
        /// <summary>
        ///     Получения дерева сборок (включая текущую)
        /// </summary>
        /// <param name="rootAssembly">Корневая сборка</param>
        /// <returns></returns>
        public static ISet<Assembly> LoadAssembliesTree(this Assembly rootAssembly)
        {
            var path = rootAssembly.CodeBase;

            var tree = new HashSet<Assembly> { rootAssembly };

            var refAssemblies = rootAssembly.GetReferencedAssemblies();

            foreach (var assemblyName in refAssemblies)
            {
                if (assemblyName.CodeBase !=  path)
                    continue;

                var assembly = Assembly.Load(assemblyName);
                var subTree = assembly.LoadAssembliesTree();

                tree.UnionWith(subTree);
            }

            return tree;
        }
    }
}
