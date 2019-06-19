using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SkillsMatter.Domain;
using SkillsMatter.Domain.QueryAndResponce;

namespace Tests
{
    public class Tests: TestBase
    {

        [Test]
        public void Sprint_Without_Tasks_Cannot_Be_Started()
        {
            Given(
               Sprint_has_been_created(Sprint_one()));

            When(
                Start_sprint(Sprint_one()));

            Then(
                Sprint_could_not_be_started(Sprint_one()));
        }

        [Test]
        public void Sprint_With_Tasks_Can_Be_Started()
        {
            Given(
                Sprint_has_been_created(Sprint_one()),
                Task_defined(Task_one()),
                Task_Assigned(Task_one(), Sprint_one()));

            When(
                Start_sprint(Sprint_one()));

            Then(
                Sprint_has_been_started(Sprint_one()));
        }


        [Test]
        public void If_the_last_task_on_a_sprint_has_been_finished_the_sprint_is_closed()
        {
            Given(
                Sprint_has_been_created(Sprint_one()),
                Task_defined(Task_one()),
                Task_Assigned(Task_one(), Sprint_one()));

            When(
                Finish_task(Task_one(), Sprint_one()));

            Then(
                Task_was_finished(Task_one()),
                Sprint_was_closed(Sprint_one()));
        }

        [Test]
        public void If_the_last_task_on_a_sprint_has_been_finished_only_THAT_sprint_is_closed()
        {
            Given(
                Sprint_has_been_created(Sprint_one()),
                Sprint_has_been_created(Sprint_two()),
                Task_defined(Task_one()),
                Task_Assigned(Task_one(), Sprint_one()),
                Task_Assigned(Task_one(), Sprint_two()));

            When(
                Finish_task(Task_one(), Sprint_one()));

            Then(
                Task_was_finished(Task_one()),
                Sprint_was_closed(Sprint_one()));
        }

        // Readmodels
        [Test]
        public void Show_Sprintdata_for_a_started_Sprint()
        {
            Given(
                Sprint_has_been_created(Sprint_one()),
                Task_defined(Task_one()),
                Task_Assigned(Task_one(), Sprint_one()));

            Query(
                Show_Sprint(Sprint_one()));

            Response(
                Sprint(
                    Tasks(Task_one()))
                );
        }


    }
}