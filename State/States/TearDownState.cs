using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    /// <summary>
    /// Each State sub-class implements a behavior associated with a state of Context. In the fourth phase 
    /// (third one is determining whether the expected outcome has been obtained.), we tear down the test
    /// fixture to put the world back into the state in which you found it.
    /// </summary>
    class TearDownState : TestState
    {
        public TearDownState(TestState state)
        {
            this.currentTest = state.CurrentTest;
            this.profileId = state.ProfileId;
        }

        public override void UseProfile()
        {
            Console.WriteLine("Status ->" + this.currentTest.State.GetType().Name);
            Console.WriteLine("[DEL] Profile is DELETED!");
        }
    }
}
