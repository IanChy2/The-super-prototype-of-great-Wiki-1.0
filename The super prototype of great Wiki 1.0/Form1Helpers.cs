using System;

internal static class Form1Helpers
{
    private static readonly int rows = 12;
    private static readonly int columns = 4;
    private static string[,] definitionsArray = new string[rows, columns];

    // 9.1: Create a global 2D string array
    // DefinitionsArray is already declared above.

    // 9.2: Create an ADD button that will store the information from the 4 text boxes into the 2D array
    static void AddDefinition()
    {
        // Implement adding a definition to the array
    }

    // 9.5: Create a CLEAR method to clear the four text boxes so a new definition can be added
    static void ClearFields()
    {
        // Implement clearing the input fields
    }

    // 9.4: Create a DELETE button that removes all the information from a single entry of the array
    static void DeleteDefinition()
    {
        // Implement deleting a definition from the array
    }

    // 9.8: Create a display method that will show Name and Category in a ListView
    static void DisplayDefinitions()
    {
        // Implement displaying definitions in a ListView
    }

    // 9.3: Create an EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
    static void EditDefinition()
    {
        // Implement editing a definition in the array
    }

    // 9.11: Create a LOAD button that will read the information from a binary file into the 2D array
    static void LoadDefinitionsFromFile()
    {
        // Implement loading definitions from a binary file
    }

    //static void Main(string[] args)
    //{
    //    bool exit = false;

    //    while (!exit)
    //    {
    //        Console.WriteLine("Dictionary Management App");
    //        Console.WriteLine("1. Add Definition");
    //        Console.WriteLine("2. Edit Definition");
    //        Console.WriteLine("3. Delete Definition");
    //        Console.WriteLine("4. Clear Fields");
    //        Console.WriteLine("5. Sort Definitions");
    //        Console.WriteLine("6. Search Definition");
    //        Console.WriteLine("7. Display Definitions");
    //        Console.WriteLine("8. Load Definitions from File");
    //        Console.WriteLine("9. Save Definitions to File");
    //        Console.WriteLine("10. Exit");
    //        Console.Write("Select an option (1-10): ");

    //        int choice;
    //        if (int.TryParse(Console.ReadLine(), out choice))
    //        {
    //            switch (choice)
    //            {
    //                case 1:
    //                    AddDefinition();
    //                    break;
    //                case 2:
    //                    EditDefinition();
    //                    break;
    //                case 3:
    //                    DeleteDefinition();
    //                    break;
    //                case 4:
    //                    ClearFields();
    //                    break;
    //                case 5:
    //                    SortDefinitions();
    //                    break;
    //                case 6:
    //                    SearchDefinition();
    //                    break;
    //                case 7:
    //                    DisplayDefinitions();
    //                    break;
    //                case 8:
    //                    LoadDefinitionsFromFile();
    //                    break;
    //                case 9:
    //                    SaveDefinitionsToFile();
    //                    break;
    //                case 10:
    //                    exit = true;
    //                    break;
    //                default:
    //                    Console.WriteLine("Invalid option. Please try again.");
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid input. Please enter a number.");
    //        }
    //    }
    //}

    // 9.10: Create a SAVE button so the information from the 2D array can be written into a binary file
    static void SaveDefinitionsToFile()
    {
        // Implement saving definitions to a binary file
    }

    // 9.7: Write the code for a Binary Search for the Name in the 2D array
    static void SearchDefinition()
    {
        // Implement binary search to find a definition in the array
    }

    // 9.9: Create a method so the user can select a definition (Name) from the ListView and all the information is displayed
    static void SelectDefinitionFromListView()
    {
        // Implement selecting a definition from the ListView
    }

    // 9.6: Write the code for a Bubble Sort method to sort the 2D array by Name ascending
    static void SortDefinitions()
    {
        // Implement a bubble sort algorithm to sort the array
    }
}