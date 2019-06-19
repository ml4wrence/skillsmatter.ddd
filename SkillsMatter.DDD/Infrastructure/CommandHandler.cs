using System;
using System.Collections.Generic;
using System.Linq;
using SkillsMatter.Domain.Commands;

namespace SkillsMatter.Domain.Infrastructure
{
    public class CommandHandler
    {
        private readonly Action<EventMessage> _publish;
        private readonly Func<List<EventMessage>> _all_events;

        public CommandHandler(Action<EventMessage> publish, Func<List<EventMessage>> all_events)
        {
            _publish = publish;
            _all_events = all_events;
        }

        public void Execute(object command)
        { 
            switch (command)
            {
                case Start_sprint s:
                {
                    var state = 
                        new SprintState(
                            _all_events()
                                .Where(_ => _._source == s.Sprint)
                                .Select(_ => _._e));
                    var sprint = 
                        new Sprint(state,
                            (e) =>
                            {
                                state.Apply(e);
                                _publish(new EventMessage(s.Sprint,e));
                            });
                    sprint.Start();
                }
                    break;

                case Finish_task s:
                {
                    var state =
                        new SprintState(
                            _all_events()
                                .Where(_ => _._source == s.Sprint)
                                .Select(_ => _._e));
                    var sprint =
                        new Sprint(state,
                            (e) =>
                            {
                                state.Apply(e);
                                _publish(new EventMessage(s.Sprint, e));
                            });
                    sprint.Finish_task(s.Task);
                }
                    break;

            }
        }
    }

    public class EventMessage
    {
        public readonly Guid _source;
        public readonly object _e;

        public EventMessage(Guid source, object e)
        {
            _source = source;
            _e = e;
        }
    }
}