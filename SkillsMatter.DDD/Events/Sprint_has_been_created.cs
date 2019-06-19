using System;

namespace SkillsMatter.Domain.Events
{
    public struct Sprint_has_been_created
    {
        public readonly Guid Sprint;

        public Sprint_has_been_created(Guid sprint)
        {
            Sprint = sprint;
        }
    }
}