using System;

namespace Delegate_And_Event
{
    class MovingEventArg : EventArgs
    {
        public MovingEventArg(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
