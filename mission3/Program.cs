// Boston Underwood
// Section 001
// Mission 3 - Food Bank Inventory Management

using mission3;
public class Program
{

    private static void Main(string[] args)
    {
        // Initialize run variable and the list to store food items 
        List<FoodItem> foodItemList = new List<FoodItem>();
        int Choice = 0;
        bool run = true;

        // Welcome users
        Console.WriteLine("Welcome to Spencer's Food Bank!");

        while (run)
        {
            while (true)
            {
                // Print out menu 
                Console.WriteLine("\nChoose an option from the following menu:");
                Console.WriteLine("1. Add a food item");
                Console.WriteLine("2. Delete a food item");
                Console.WriteLine("3. Print the current food items");
                Console.WriteLine("4. Exit\n");
                string input = (Console.ReadLine());

                // Checks to make sure user input is a valid menu choice
                if ((int.TryParse(input, out Choice)))
                {
                    if ((Int32.Parse(input) > 0) && (Int32.Parse(input) < 5))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid menu choice. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }


            }

            // Option 1: Add Food Item 
            if (Choice == 1)
            {
                Console.WriteLine("\nWhat food would you like to add?");
                string addFoodName = Console.ReadLine();

                // Category Input controlling with error handling
                bool catCheck = false;
                FoodCategory foodCategory = default;

                while (!catCheck)
                {
                    Console.WriteLine(
                        "\nWhat type of food would you like to add? A list of possible categories are below:");
                    Console.WriteLine("Fruit, Vegetable, Dairy, Meat, Grain, Snack, Beverage");
                    string addCategory = Console.ReadLine();

                    if (Enum.TryParse<FoodCategory>(addCategory, true, out foodCategory))
                    {
                        catCheck = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid category. Please use one of the listed categories.");
                    }
                }

                // Quantity input (positive only)
                int addQuantity = 0;
                Console.WriteLine("\nHow many units are there?");
                addQuantity = int.Parse(Console.ReadLine());

                while (addQuantity < 1)
                {
                    Console.WriteLine("Invalid quantity. Must be greater than 0.");
                    Console.WriteLine("How many units are there?");
                    addQuantity = int.Parse(Console.ReadLine());
                }

                // Date input with exception handling
                bool validDate = false;
                DateOnly addExpDate = default;


                while (!validDate)
                {
                    Console.WriteLine("\nWhat is the expiration date? (In the form yyyy-mm-dd)");
                    string sExpDate = Console.ReadLine();
                    if (DateOnly.TryParse(sExpDate, out addExpDate))
                    {
                        validDate = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date. Please use the format yyyy-mm-dd.");
                    }
                }

                // Create the new FoodItem and add it to the foodItemsList
                FoodItem newFood = new FoodItem(addFoodName, foodCategory, addQuantity, addExpDate);
                foodItemList.Add(newFood);

                // Print Success Statement
                Console.WriteLine($"\nNew food item added: {newFood}");
            }

            
            
            // Option 2: Delete a food item
            if (Choice == 2)
            {
 
                // Ask user which food item to delete
                bool validFood = false;
                
                while (!validFood)
                {
                    // Print the list of food items in the food bank
                    Console.WriteLine("\nHere is a list of all food items: ");
                    for (int i = 1; i <= foodItemList.Count; i++)
                    {
                        Console.WriteLine($"{i}. {foodItemList[i-1]}");
                    }

                    Console.WriteLine("\nPlease select while food item you would like to delete from the list above:");
                    int deleteFoodItem = Convert.ToInt32(Console.ReadLine());
                    
                    if ((deleteFoodItem > 0) && (deleteFoodItem <= foodItemList.Count))
                    {
                        Console.WriteLine($"\nFood item deleted: {foodItemList[deleteFoodItem - 1]}");
                        foodItemList.RemoveAt(deleteFoodItem - 1);
                        validFood = true;
                    }
                    else
                    {
                        Console.WriteLine("\nFood item could not be deleted. Please enter a valid number.");
                    }
                }
            }

            if (Choice == 3)
            {
                Console.WriteLine("\nHere is a list of all food items: ");
                for (int i = 1; i <= foodItemList.Count; i++)
                {
                    Console.WriteLine($"{i}. {foodItemList[i-1]}");
                }
            }

            if (Choice == 4)
            {
                Console.WriteLine("\nThanks for visiting Spencer's Food Bank! Have a good day!");
                run = false;
            }
        }
    }
}
