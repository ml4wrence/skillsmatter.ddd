using System;

namespace SkillsMatter.Domain.Events
{
    public struct Task_was_finished
    {
        public readonly Guid _task;

        public Task_was_finished(Guid task)
        {
            _task = task;
        }
    }
}