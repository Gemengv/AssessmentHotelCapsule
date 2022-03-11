using System;

namespace AssessmentCapsuleHotel
{
    class MainClass
    {
        public static void Main()
        {
            SelectFromMenu();

        }

        private static string SelectFromMenu()
        {
            Console.WriteLine(@"Welcome to Capsule-Capsule.
===========================
Enter the number of capsules available: 100

There are 100 unoccupied capsules ready to be booked.");
            Console.Write(@"Guest Menu
==========
1. Check In
2. Check Out
3. View Guests
4. Exit
Choose on option [1-4]:");

            return Console.ReadLine();
        }
    }

}
