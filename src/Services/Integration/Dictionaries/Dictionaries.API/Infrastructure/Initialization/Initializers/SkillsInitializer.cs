using System.Collections.Generic;
using System.Linq;
using Dictionaries.Db.Models.Skills;
using Dictionaries.Dto.Models.Skills;
using Dictionaries.EventBus.Events.Skills;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.Db;
using Dictionaries.API.Infrastructure.Initialization.Attributes;

namespace Dictionaries.API.Infrastructure.Initialization.Initializers
{
    [JsonFileName("skills.json")]
    public class SkillsInitializer :
        BaseDictionaryInitializer<DtoSkill, Skill>
    {
        public SkillsInitializer(
            string jsonPath,
            DictionariesDbContext context,
            IEventBus eventBus) :
            base(jsonPath, context, eventBus)
        {
        }

        protected override void ProduceEvent(IEnumerable<Skill> eventData)
        {
            var dtoData = eventData.Select(Mapper.Map<DtoSkill>);

            var @event = new SkillsChanged
            {
                Created = dtoData
            };

            _eventBus.Publish(@event);
        }
    }
}