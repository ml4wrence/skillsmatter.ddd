using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillsMatter.Domain.QueryAndResponce
{
    public struct SprintInfo
    {
        private readonly IEnumerable<Guid> _tasks;

        public SprintInfo(IEnumerable<Guid> tasks)
        {
            _tasks = tasks;
        }

        public override string ToString()
        {
            return String.Join("-", _tasks.Select(_ => _.ToString().ToList()));

        }
    }
}