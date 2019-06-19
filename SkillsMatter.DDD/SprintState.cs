using System;
using System.Collections.Generic;
using SkillsMatter.Domain.Events;

namespace SkillsMatter.Domain
{
    public class SprintState
    {
        public Guid id;
        public List<Guid> tasks;

        public SprintState(IEnumerable<object> allEvents)
        {
            foreach (var @event in allEvents)
            {
                Apply(@event);
            }
        }

        public void Apply(object @event)
        {
            switch (@event)
            {
                case Sprint_has_been_created s:
                    Apply(s);
                    break;
                case Task_assigned e:
                    Apply(e);
                    break;
                case Task_was_finished e:
                    Apply(e);
                    break;
            }
        }

        private void Apply(Sprint_has_been_created e)
        {
            id = e.Sprint;
            tasks = new List<Guid>();
        }

        private void Apply(Task_assigned e)
        {
            tasks.Add(e.Task);
        }

        private void Apply(Task_was_finished e)
        {
            tasks.Remove(e._task);
        }
    }
}