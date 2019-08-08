using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate_And_Event
{
    class Student_2
    {
        public void Move(int distance) // Action<string> method
        {
            for (int i = 1; i < distance; i++)
            {
                Thread.Sleep(1000);
                Moving?.Invoke(this, new MovingEventArg(string.Format("The student walked {0}", i)));
            }
        }

        public event EventHandler<MovingEventArg> Moving;
    }
}
