using System;
using System.Threading;
using static Delegate_And_Event.Delegates;

namespace Delegate_And_Event
{
    class Student
    {
        public void Move(int distance) // Action<string> method
        {
            for (int i = 1; i < distance; i++)
            {
                Thread.Sleep(1000);
                Moving?.Invoke(string.Format("The student walked {0}", i));
            }
            Thread.Sleep(1000);
            Console.WriteLine("\n" + "Now work event" + "\n");
        }

        public Action<string> Moving { get; set; }
    }
}
