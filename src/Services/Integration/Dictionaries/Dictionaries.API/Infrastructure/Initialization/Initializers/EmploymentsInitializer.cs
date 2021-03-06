﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Employments;
using Dictionaries.Db.Dto.Models.Employments;
using Dictionaries.Db.Synchronization.Events.Employments;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("employments.json")]
    public class EmploymentsInitializer :
        BaseDictionaryInitializer<DtoEmployment, Employment>
    {
        public EmploymentsInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Employment> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoEmployment>);

            var @event = new EmploymentsChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}