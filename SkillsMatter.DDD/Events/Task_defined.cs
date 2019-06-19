using System;

namespace SkillsMatter.Domain.Events
{
    public struct Task_defined
    {
        public readonly Guid Task;

        public Task_defined(Guid task)
        {
            Task = task;
        }
    }
}