using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.Db.Models.Specializations;
using Dictionaries.Db.Dto.Models.Specializations;
using Dictionaries.Db.Synchronization.Events.Specializations;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("specializations.json")]
    public class SpecializationsInitializer :
        BaseDictionaryInitializer<DtoSpecializationSync, Specialization>
    {
        public SpecializationsInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Specialization> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoSpecialization>);

            var @event = new SpecializationsChanged()
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
        protected override Task<IEnumerable<Specialization>> SaveDataAsync(
            IEnumerable<Specialization> dataFromJson)
        {
            var flatData = GetFlatData(dataFromJson);
            return base.SaveDataAsync(flatData);
        }

        private IEnumerable<Specialization> GetFlatData(IEnumerable<Specialization> data)
        {
            var result = new List<Specialization>();
            result.AddRange(data);

            foreach (var datum in data)
            {
                var children = datum.Specializations;
                datum.Specializations = null;
                datum.Parent = null;

                if (children == null || !children.Any())
                    continue;

                var childrenFlat = GetFlatData(children);
                result.AddRange(childrenFlat);
            }

            return result;
        }
    }
}