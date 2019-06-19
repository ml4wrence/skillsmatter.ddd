using System;

namespace SkillsMatter.Domain.Events
{
    public struct Sprint_has_been_started
    {
        public readonly Guid Sprint;

        public Sprint_has_been_started(Guid sprint)
        {
            Sprint = sprint;
        }
    }
}