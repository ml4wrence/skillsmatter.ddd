using System;

namespace SkillsMatter.Domain.QueryAndResponce
{
    public struct Show_Sprint
    {
        public readonly Guid _sprint;

        public Show_Sprint(Guid sprint)
        {
            _sprint = sprint;
        }
    }
}