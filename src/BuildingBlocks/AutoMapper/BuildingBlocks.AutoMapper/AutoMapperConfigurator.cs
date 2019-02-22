using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using BuildingBlocks.Extensions.Assemblies;

namespace BuildingBlocks.AutoMapper
{
    /// <summary>
    /// Конфигуратор автомаппера
    /// </summary>
    public class AutoMapperConfigurator
    {
        /// <summary>
        /// Инстанс
        /// </summary>
        private static AutoMapperConfigurator _instance;

        /// <summary>
        /// Локкер
        /// </summary>
        private static readonly object _syncRoot = new object();
        
        /// <summary>
        /// Множество сборок
        /// </summary>
        public ISet<Assembly> AssemblySet { get; }

        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private AutoMapperConfigurator() {
            AssemblySet = new HashSet<Assembly>();
        }

        /// <summary>
        /// Получение инстанса
        /// </summary>
        public static AutoMapperConfigurator Instance
        {
            get {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new AutoMapperConfigurator();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Создание конфигурации
        /// </summary>
        /// <param name="rootAssembly"> Корневая сборка. </param>
        /// <returns></returns>
        private MapperConfigurationExpression CreateConfig(Assembly rootAssembly)
        {
            var config = new MapperConfigurationExpression();
            var assemblyTree = rootAssembly.LoadAssembliesTree();

            AssemblySet.UnionWith(assemblyTree);
            
            foreach (var assembly in AssemblySet)
            {
                config.AddProfiles(assembly);
            } 

            return config;
        }

        /// <summary>
        /// Инициализация маппингов
        /// </summary>
        public void Initialize()
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var config = CreateConfig(callingAssembly);
            Mapper.Initialize(config);
        }
    }
}
