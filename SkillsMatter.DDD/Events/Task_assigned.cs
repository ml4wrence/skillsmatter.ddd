using System;

namespace SkillsMatter.Domain.Events
{
    public struct Task_assigned
    {
        public readonly Guid Task;
        public readonly Guid Sprint;

        public Task_assigned(Guid task, Guid sprint)
        {
            Task = task;
            Sprint = sprint;
        }
    }
}