using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SkillsMatter.Domain;
using SkillsMatter.Domain.Commands;
using SkillsMatter.Domain.Events;
using SkillsMatter.Domain.Infrastructure;
using SkillsMatter.Domain.QueryAndResponce;

namespace Tests
{
    public class TestBase
    {
        protected List<EventMessage> produced_events;
        protected List<EventMessage> historical_events;
        private object _responce;

        [SetUp]
        public void Setup()
        {
            historical_events = new List<EventMessage>();
            produced_events = new List<EventMessage>();
        }


        protected EventMessage Task_Assigned(Guid task, Guid sprint) => new EventMessage(sprint, new Task_assigned(task, sprint));

        protected EventMessage Task_defined(Guid task) => new EventMessage(task, new Task_defined(task));

        protected Guid Task_one()
        {
            return Guid.Parse("D03DD7C8-525D-4808-A7C2-6E1E8F4FBF34");

        }

        protected void Given(params EventMessage[] history)
        {
            historical_events.AddRange(history);
        }


        public Show_Sprint Show_Sprint(Guid sprint) => new Show_Sprint(sprint);

        public SprintInfo Sprint(IEnumerable<Guid> tasks)
        {
            return new SprintInfo(tasks);
        }

        public Status Started()
        {
            return Status.Started;
        }


        public IEnumerable<Guid> Tasks(params Guid[] tasks)
        {
            return tasks;
        }
        protected void When(object command)
        {
            var command_handler = new CommandHandler(produced_events.Add, () => historical_events);
            command_handler.Execute(command);
        }

        protected void Query(object query)
        {
            var queryHandler = new QueryHandler(() => historical_events);
            _responce = queryHandler.Handle(query);
        }


        protected void Response(object responce)
        {
            responce.ToString().Should().BeEquivalentTo(_responce.ToString());
        }


        protected void Then(params EventMessage[] expected_events)
        {
            CollectionAssert.AreEqual(expected_events.Select(_ => _._e).ToList(), produced_events.Select(_ => _._e).ToList());
        }

        protected EventMessage Sprint_could_not_be_started(Guid sprint) => new EventMessage(sprint, new Sprint_could_not_be_started(sprint));

        protected Start_sprint Start_sprint(Guid sprint)
        {
            return new Start_sprint(sprint);
        }

        protected EventMessage Sprint_has_been_created(Guid sprint) => new EventMessage(sprint, new Sprint_has_been_created(sprint));
        protected EventMessage Sprint_has_been_started(Guid sprint) => new EventMessage(sprint, new Sprint_has_been_started(sprint));

        protected Guid Sprint_one() => Guid.Parse("7B2F3C34-C114-4386-BABE-F2AAF9ADB804");
        protected Guid Sprint_two() => Guid.Parse("BB4F518E-030D-404F-9D58-1B383527909B");

        protected EventMessage Sprint_was_closed(Guid sprint) => new EventMessage(sprint, new Sprint_was_closed(sprint));

        protected EventMessage Task_was_finished(Guid task) => new EventMessage(task, new Task_was_finished(task));

        protected object Finish_task(Guid task, Guid sprint)
        {
            return new Finish_task(task, sprint);
        }
        /*protected IEnumerable<object> Sprint_with_a_task()
        {
             Sprint_has_been_created(Sprint_one());
             Task_defined(Task_one());
             Task_Assigned(Task_one(), Sprint_one());
        }*/
    }
}