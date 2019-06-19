using System;
using System.Linq;
using SkillsMatter.Domain.Events;
using SkillsMatter.Domain.Infrastructure;

namespace SkillsMatter.Domain
{
    public class Sprint
    {
        private readonly SprintState _state;
        private readonly Action<object> _publish;

        public Sprint(SprintState state, Action<object> publish)
        {
            _state = state;
            _publish = publish;
        }

        public void Start()
        {
            if (_state.tasks.Any())
                _publish(new Sprint_has_been_started(_state.id));
            else
                _publish(new Sprint_could_not_be_started(_state.id));
        }

        public void Finish_task(Guid task)
        {
            if (_state.tasks.Contains(task)) _publish(new Task_was_finished(task));
            if (No_tasks_left()) _publish(new Sprint_was_closed(_state.id));
        }

        private bool No_tasks_left()
        {
            return !_state.tasks.Any();
        }
    }
}