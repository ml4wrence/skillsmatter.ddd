using System;

namespace SkillsMatter.Domain.Events
{
    public struct Sprint_was_closed
    {
        public readonly Guid _sprint;

        public Sprint_was_closed(Guid sprint)
        {
            _sprint = sprint;
        }
    }
}