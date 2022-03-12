using System;

namespace AssessmentCapsuleHotel
{
    class MainClass
    {
        public static void Main()
        {
            // make sure everything within unocupied
            // for loop makes this makes sense and set equal to this for each indicies
            string[] capsules = new string[100];
            AssignUnoccupied(capsules);
           
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
                        CheckOut(capsules);
                        break;
                    case "3":
                        //view guests 10 capsules, 5 from above, 5 from below
                        ViewCapsules(capsules);
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
                    default:
                        Console.WriteLine("Invalid entry. Please enter 1-4.");
                        break;

                    
                }
            }

        }
        private static string CheckIfNum(string validate)
        {
            double checkNum;
            string hold = validate;

            if (!double.TryParse(validate, out checkNum))
            {
                Console.Write("Please enter in a number between 1 and 100.");
                //hold = Console.WriteLine();
            }

            return validate;
        }
        private static string CheckDecimal(string validate)
        {
            bool checkDecimal = true;

            while (checkDecimal)
            {
                if (validate.Contains("."))
                {
                    Console.WriteLine("Please enter a whole number between 1 and 100.");
                    validate = Console.ReadLine();
                }
            }
            return validate;
        }
        private static string CheckNumInrange(string validate)
        {
            CheckDecimal(validate);
            int num = int.Parse(validate);
            bool checkNum = true;

            while (checkNum)
            {
                if (num > 0 && num < 101)
                {
                    return validate;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                    num = int.Parse(Console.ReadLine());
                }
            }

            return null;
        }


        private static string[] AssignUnoccupied(string[] nameIndicies)
        {
            for (int i = 0; i < nameIndicies.Length; i++)
            {
                nameIndicies[i] = "unoccupied";
                Console.WriteLine($"{i + 1}. {nameIndicies[i]}");
            }
            return nameIndicies;
        }

        private static string[] ViewCapsules(string[] capsules)
        {
            for (int i = 0; i < capsules.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {capsules} ");
            }

            return null;
        }

        private static string[] CheckIn(string[] assignCapsule)
        {
            Console.WriteLine("Guest Name: ");
            string guestName = Console.ReadLine();
            Console.WriteLine("Capsule #[1-100]: ");
            string roomInput = CheckNumInrange(Console.ReadLine());
            int checkRoom = int.Parse(roomInput) - 1;
            bool isEmpty = true;
            while (isEmpty)
            {
                // cant check length of an empty array
                if (assignCapsule[checkRoom] == "unoccupied")
                {
                    assignCapsule[checkRoom] = guestName;
                    Console.WriteLine($"Capsule is empty. {guestName} is booked in capsule# {checkRoom }");
                    isEmpty = false;
                }
                else
                {

                    Console.WriteLine($"Capsule# {checkRoom} is taken, please choose another room.");
                    checkRoom = int.Parse(Console.ReadLine());
                }
            }

            return assignCapsule;
        }

        private static string[] CheckOut(string[] clearCapsule)
        {
            Console.WriteLine("Which capsule are you checking out?");
            int checkRoom = int.Parse(Console.ReadLine()) - 1;
            bool isOccupied = true;

            while (isOccupied)
            {
                if(clearCapsule[checkRoom] == "unoccupied")
                {
                    Console.WriteLine("Error, this capsule is already unoccupied. Please enter another capsule number: ");
                    checkRoom = int.Parse(Console.ReadLine());
                }
                else
                {
                    string holdName = clearCapsule[checkRoom];
                    clearCapsule[checkRoom] = "unoccupied";
                    Console.WriteLine($"{holdName} is checked out from capsule #{checkRoom}.");
                    isOccupied = false;
                }

            }

            return clearCapsule;
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
