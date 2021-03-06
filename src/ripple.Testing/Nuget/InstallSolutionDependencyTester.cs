﻿using NUnit.Framework;
using Rhino.Mocks;
using ripple.Model;
using ripple.Nuget;

namespace ripple.Testing.Nuget
{
    [TestFixture]
    public class InstallSolutionDependencyTester
    {
        private Dependency theDependency;
        private InstallSolutionDependency theStep;
        private INugetStepRunner theRunner;

        [SetUp]
        public void SetUp()
        {
            theDependency = new Dependency("Test");
            theStep = new InstallSolutionDependency(theDependency);

            theRunner = MockRepository.GenerateStub<INugetStepRunner>();

            theStep.Execute(theRunner);
        }

        [Test]
        public void installs_the_solution_dependency()
        {
            theRunner.AssertWasCalled(x => x.AddSolutionDependency(theDependency));
        }
    }
}