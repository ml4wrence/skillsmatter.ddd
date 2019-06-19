using System;

namespace SkillsMatter.Domain.Events
{
    public struct Sprint_could_not_be_started
    {
        public readonly Guid Sprint;
        public Sprint_could_not_be_started(Guid sprint)
        {
            Sprint = sprint;
        }
    }
}