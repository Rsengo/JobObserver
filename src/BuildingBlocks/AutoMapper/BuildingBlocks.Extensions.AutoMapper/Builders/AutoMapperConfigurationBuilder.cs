using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BuildingBlocks.Extensions.AutoMapper.Builders
{
    public class AutoMapperConfigurationBuilder
    {
        internal ICollection<Assembly> Assemblies { get; }

        internal AutoMapperConfigurationBuilder()
        {
            Assemblies = new List<Assembly>();
        }

        public void AddAssembly(Assembly assembly)
        {
            Assemblies.Add(assembly);
        }
    }
}
