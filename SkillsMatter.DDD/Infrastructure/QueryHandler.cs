using System;
using System.Collections.Generic;
using System.Linq;
using SkillsMatter.Domain.QueryAndResponce;

namespace SkillsMatter.Domain.Infrastructure
{
    public class QueryHandler
    {
        private readonly Func<List<EventMessage>> _history;
        private Dictionary<Customer,List<\>>
        public QueryHandler(Func<List<EventMessage>> history)
        {
            _history = history;
            _SprintReadModel =
                new SprintState(
                    _history()
                        .Where(_ => _._source == s._sprint)
                        .Select(_ => _._e));

        }

        public object Handle(object query)
        {
            switch (query)
            {
                case Show_Sprint s:
                {
                    return new SprintInfo(state.tasks);
                }
                    break;

            }
            return null; // DONT DO THIS!!!!!
        }
    }
}