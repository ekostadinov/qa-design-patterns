using System;
using System.Runtime.InteropServices;
using State.Context;

namespace State.States
{
    /// <summary>
    /// Each State sub-class implements a behavior associated with a state of Context. This first phase, we use to set up the test fixture
    ///  (the "before" picture) that is required for the SUT to exhibit the expected behavior as well as anything we need to put in place
    ///  to be able to observe the actual outcome.
    /// </summary>
    class FixtureState : TestState
    {
        public FixtureState(TestState state)
        {
            this.currentTest = state.CurrentTest;
            this.profileId = state.ProfileId;
        }

        public FixtureState(MyCustomTest customTest)
        {
            this.currentTest = customTest;
        }

        public override void UseProfile()
        {
            Console.WriteLine("Status ->" + this.currentTest.State.GetType().Name);
            Console.WriteLine("[POST] Profile was created!");
            this.currentTest.State = new InteractState(this);
            this.currentTest.State.UseProfile();
        }
    }
}
