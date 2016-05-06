using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using State.Context;

namespace State.States
{
    /// <summary>
    /// Each State sub-class implements a behavior associated with a state of Context. 
    /// In this second phase, we interact with the SUT.
    /// </summary>
    class InteractState : TestState
    {
        public InteractState(TestState state)
        {
            this.currentTest = state.CurrentTest;
            this.profileId = new Random().Next(123456, 999999).ToString();
        }

        public override void UseProfile()
        {
            Console.WriteLine("Status ->" + this.currentTest.State.GetType().Name);
            Console.WriteLine("[GET] Retrieved Profile:" + profileId);
            this.currentTest.State = new TearDownState(this);
            this.currentTest.State.UseProfile();
        }
    }
}
