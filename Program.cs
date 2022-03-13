using System;

namespace AssessmentCapsuleHotel

{

    class MainClass
    {
        public static void Main()
        {
       
            Console.WriteLine("Enter in Number of Capsules available: ");
            string capsuleInput = ValidateInt(Console.ReadLine());  
            int usedCapsule = int.Parse(capsuleInput); //capsule will be changing
            int totalCapsules = usedCapsule; // hold total number of capsules
            string[] capsules = new string[totalCapsules];

            AssignUnoccupied(capsules);

            bool menuRunning = true;

            while (menuRunning)
            {
                Console.WriteLine($"\nThere are {usedCapsule} capsules ready to be booked!");
                switch (SelectFromMenu())
                {
                    case "1":
                        CheckIn(capsules, totalCapsules);
                        usedCapsule = CapsuleMinus(usedCapsule);
                        break;
                    case "2":
                        if (IsAllCapsulesAvailable(capsules))
                        {
                            Console.WriteLine("All rooms are unoccupied.");
                        }
                        else
                        {
                            CheckOut(capsules, totalCapsules);
                            usedCapsule = CapsuleAdd(usedCapsule);
                        }
                        break;
                    case "3":
                        ViewCapsules(capsules, totalCapsules);
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
                        Console.WriteLine("Invalid entry. Please enter a number between 1 and 4.");
                        break;

                    
                }
            }

        }

        private static int CapsuleMinus(int capsules)
        {
            capsules = capsules - 1;
            return capsules;
        }
        private static int CapsuleAdd(int capsules)
        {
            capsules = capsules + 1;
            return capsules;
        }
        private static string ValidateInt(string validate)
        {
            bool isInt = true;
            while (isInt)
            {
                if (int.TryParse(validate, out int value))
                {
                    return validate;
                }
                else
                {
                    Console.WriteLine("Please enter in a number: ");
                    validate = Console.ReadLine();
                }

            }
            return validate;
        }

        private static string ValidateAll(string validate, int totalCapsuleAvail)
        {
            bool isInt = true;
            while (isInt) { 
            if (int.TryParse(validate, out int value))
            {
                if(int.Parse(validate) > 0 && int.Parse(validate) <= totalCapsuleAvail)
                    {
                        return validate;

                    }
                    else
                    {
                        Console.WriteLine($"Number is out of bounds. Please enter in a number between 1 and {totalCapsuleAvail}: ");
                        validate = Console.ReadLine();
                    }
                }
            else
            {
                Console.WriteLine($"Please enter in a number between 1 and {totalCapsuleAvail}: ");
                validate = Console.ReadLine();
            }

        }
            return validate;

        }

        private static string[] AssignUnoccupied(string[] nameIndicies)
        {
            for (int i = 0; i < nameIndicies.Length; i++)
            {
                nameIndicies[i] = "unoccupied";
            }
            return nameIndicies;
        }

        private static string[] ViewCapsules(string[] capsules, int totalCapsuleAvail)
        {
            Console.WriteLine("Please enter in the capsule you want to check: ");
            string input = ValidateAll(Console.ReadLine(), totalCapsuleAvail);
            int checkNum = int.Parse(input);

            int countBelow5 = 10 - checkNum;
            int countCapsuleTotal = checkNum - (totalCapsuleAvail - 10);

            if (checkNum > 0 && checkNum < 6)
            {
                       
                for (int i = 0; i <= checkNum + countBelow5; i++)
                {
                    Console.WriteLine($"{i + 1}: {capsules[i]} ");
                }
            }
            else if (checkNum > (totalCapsuleAvail-5) && checkNum <= totalCapsuleAvail)
            {
                for (int i = checkNum - countCapsuleTotal - 1; i < totalCapsuleAvail; i++)
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

        private static string[] CheckIn(string[] assignCapsule, int totalCapsuleAvail)
        {
            Console.WriteLine("Guest Name: ");
            string guestName = Console.ReadLine();
            Console.WriteLine($"Capsule #[1-{totalCapsuleAvail}]: ");
            string roomInput = ValidateAll((Console.ReadLine()), totalCapsuleAvail);
            int checkRoom = int.Parse(roomInput)-1;
            bool isEmpty = true;
            while (isEmpty)
            {
                if (assignCapsule[checkRoom] == "unoccupied")
                {
                    assignCapsule[checkRoom] = guestName;
                    Console.WriteLine($"Capsule is empty. {guestName} is booked in capsule# {checkRoom + 1}");
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

        private static string[] CheckOut(string[] clearCapsule, int totalCapsuleAvail)
        {
            bool isOccupied = true; 

            Console.WriteLine("Which capsule are you checking out?");
            // validate if input is an int
            string input = ValidateAll((Console.ReadLine()), totalCapsuleAvail);
            // parse string to int type
            int checkRoom = int.Parse(input)-1;
            
            while (isOccupied)
            {
                    // array index [5] 
                if(clearCapsule[checkRoom] == "unoccupied")
                {
                    Console.WriteLine("Error, this capsule is already unoccupied. Please enter another capsule number: ");
                    checkRoom = int.Parse(Console.ReadLine());
                }
                else
                {
                    string holdName = clearCapsule[checkRoom];
                    clearCapsule[checkRoom] = "unoccupied";
                    Console.WriteLine($"{holdName + 1} is checked out from capsule #{checkRoom + 1}.");
                    isOccupied = false;
                }

            }

            return clearCapsule;
        }

        private static string SelectFromMenu()
        {
            Console.WriteLine(@"Welcome to Capsule-Capsule.
===========================
");
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
       
        private static bool IsAllCapsulesAvailable(string[] check)
        {
            string first = "unoccupied";
            for(int i = 1; i < check.Length; i++)
                if(check[i] != first)
                {
                    return false;
                }
            return true;
        }

        
    }

}
