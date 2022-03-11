using System;

namespace AssessmentCapsuleHotel
{
    class MainClass
    {
        public static void Main()
        {
            string[] capsules = new string[100];
            bool menuRunning = true;

            while (menuRunning)
            {
                switch (SelectFromMenu())
                {
                    case "1":
                    CheckIn(capsules);
                        break;
                    case "2":
                        //check out guess
                        break;
                    case "3":
                        //view guests 10 capsules, 5 from above, 5 from below
                        break;
                    case "4":
                        Console.WriteLine(@"====
Are you sure you want to exit?
All data will be lost.
Exit [y/n]: ");
                        
                        if (Exit(Console.ReadLine().ToLower()) == "y")
                        {
                            Console.WriteLine("Goodbye!");
                            menuRunning = false;
                        }
                        break;

                    
                }
            }

        }

        private static string[] CheckIn(string[] assignCapsule)
        {
            Console.WriteLine("Guest Name: ");
            string guestName = Console.ReadLine();
            Console.WriteLine("Capsule #[1-100]: ");
            string checkRoom = Console.ReadLine();
            for(int i = 0; i < assignCapsule.Length; i++)
            {
                if (string.IsNullOrEmpty(assignCapsule[i]))
                {
                    assignCapsule[i] = guestName;
                    Console.WriteLine($"Capsule is empty. {guestName} is booked in capsule# {checkRoom }");
                    break;
                }
                else
                {
                    Console.WriteLine("Capsule is taken, please choose another room.");
                    checkRoom = Console.ReadLine();
                }
            }

            return assignCapsule;
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

        private static string Exit(string input)
        {
            bool stayOnMenu = true;
            while (stayOnMenu)
            {
                switch (input)
                {
                    case "n":
                        return input;
                        break;
                    case "y":
                        
                        stayOnMenu = false;
                        return input;
                        break;
                    default:
                        Console.WriteLine("Invalid entry, please enter in y or n.");
                        input = Console.ReadLine();
                        break;
                }

            }
            return input;
        }

    }

}
