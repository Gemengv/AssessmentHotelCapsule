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
            Console.WriteLine("Please enter in the capsule you want to check: ");
            int checkNum = int.Parse(Console.ReadLine()); 
             
            int countBelow5 = 10 - checkNum;

            int countAbove95 = checkNum - 90;

            if (checkNum > 0 && checkNum < 6)
            {
                for (int i = 0; i <= checkNum + countBelow5; i++)
                {
                    Console.WriteLine($"{i + 1}: {capsules[i]} ");
                }
            }
            else if (checkNum > 95 && checkNum < 101)
            {
                for (int i = checkNum - countAbove95 - 1; i <= 99  ; i++)
                {
                    Console.WriteLine($"{i+1}: {capsules[i]} ");
                }
            }
            else
            {

                for (int i = checkNum - 6; i < checkNum + 5; i++)
                {
                    Console.WriteLine($"{i + 1}: {capsules[i]} ");
                }
            }

            return capsules;
        }

        private static string[] CheckIn(string[] assignCapsule)
        {
            Console.WriteLine("Guest Name: ");
            string guestName = Console.ReadLine();
            Console.WriteLine("Capsule #[1-100]: ");
            string roomInput = (Console.ReadLine());
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
            bool isOccupied = true; 

            Console.WriteLine("Which capsule are you checking out?");
            int checkRoom = int.Parse(Console.ReadLine()) - 1;
            
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
       
        private static bool Same(string[] check)
        {
            string first = "occupied";
            for(int i = 1; i < check.Length; i++)
                if(check[i] == first)
                {
                    return false;
                }
            return true;
        }
    }

}
