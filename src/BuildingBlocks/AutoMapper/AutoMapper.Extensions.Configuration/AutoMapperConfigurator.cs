﻿using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using BuildingBlocks.Extensions.Assemblies;

namespace BuildingBlocks.Configuration.AutoMapper
{
    /// <summary>
    /// Конфигуратор автомаппера
    /// </summary>
    internal class AutoMapperConfigurator
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
        /// <returns></returns>
        private MapperConfigurationExpression CreateConfig()
        {
            var config = new MapperConfigurationExpression();
            var rootAssembly = Assembly.GetCallingAssembly();
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
            var config = CreateConfig();
            Mapper.Initialize(config);
        }
    }
}
