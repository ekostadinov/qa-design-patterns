using State.Context;

namespace State.States
{
    /// <summary>
    /// Defines an interface for encapsulating the behavior associated with a particular state of the Context.
    /// </summary>
    abstract class TestState
    {
        protected MyCustomTest currentTest;
        protected string profileId;

        public MyCustomTest CurrentTest
        {
            get { return currentTest; }
            set { currentTest = value; }
        }

        public string ProfileId
        {
            get { return profileId; }
            set { profileId = value; }
        }

        public abstract void UseProfile();
    }
}
