using System;

namespace SkillsMatter.Domain.Commands
{
    public struct Start_sprint
    {
        public readonly Guid Sprint;

        public Start_sprint(Guid sprint)
        {
            Sprint = sprint;
        }
    }
}