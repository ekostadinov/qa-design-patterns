using System;
using State.States;

namespace State.Context
{
    /// <summary>
    /// This is the context class, that defines the interface of interest to clients. Also 
    /// maintains an instance of a ConcreteState subclass that defines the current state.
    /// </summary>
    class MyCustomTest
    {
        private TestState _state;

        public TestState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public MyCustomTest()
        {
            this._state = new FixtureState(this);
        }

        public void UseProfile()
        {
            _state.UseProfile();
        }
    }
}
