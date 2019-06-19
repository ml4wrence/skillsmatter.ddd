using System;

namespace SkillsMatter.Domain.Commands
{
    public struct Finish_task
    {
        public readonly Guid Task;
        public readonly Guid Sprint;

        public Finish_task(Guid task, Guid sprint)
        {
            Task = task;
            Sprint = sprint;
        }
    }
}