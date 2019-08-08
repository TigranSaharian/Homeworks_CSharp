using System;
using static Delegate_And_Event.Delegates;

namespace Delegate_And_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            // create stringHelper object as helper
            StringHelper helper = new StringHelper();

            // Create two delegate
            CountDelegate countDelegate1 = helper.GetCount;
            CountDelegate countDelegate2 = helper.CountSymbolOfText;

            // The test string
            string testString = "Apricote";

            // Here we use first method
            Console.WriteLine("The quantity letters of text {0}", testDelegate(countDelegate1, testString));

            // Here we use second method
            Console.WriteLine("The quantity 'A' of text {0}" + "\n", testDelegate(countDelegate2, testString));

            // The method which use delegaet and test text 
            int testDelegate(CountDelegate count, string text)
            {
                return count(text);
            }

            // Create Student object as student
            Student student = new Student();

            // Create Delegate method that call the method Show
            //ShowMessage method = Show;
            student.Moving = Show;

            // Here we take the lenght of for loop, and use delegate
            student.Move(3); //method

            // method Show, that get message
            void Show(string message)
            {
                Console.WriteLine(message);
            }

            Student_2 student_2 = new Student_2();

            student_2.Moving += Student_2_Moving;
            student_2.Move(7);
        }
                                            // Sudent_2     // Parameter from the class 
        private static void Student_2_Moving(object sender, MovingEventArg e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
