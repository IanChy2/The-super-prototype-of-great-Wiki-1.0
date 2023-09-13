using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace The_super_prototype_of_great_Wiki_1._0
{
    partial class Form1
    {
        private static readonly int rows = 12;
        private static readonly int columns = 4;
        private static string[,] definitionsArray = new string[rows, columns];

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Dictionary Management App");
                Console.WriteLine("1. Add Definition");
                Console.WriteLine("2. Edit Definition");
                Console.WriteLine("3. Delete Definition");
                Console.WriteLine("4. Clear Fields");
                Console.WriteLine("5. Sort Definitions");
                Console.WriteLine("6. Search Definition");
                Console.WriteLine("7. Display Definitions");
                Console.WriteLine("8. Load Definitions from File");
                Console.WriteLine("9. Save Definitions to File");
                Console.WriteLine("10. Exit");
                Console.Write("Select an option (1-10): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddDefinition();
                            break;
                        case 2:
                            EditDefinition();
                            break;
                        case 3:
                            DeleteDefinition();
                            break;
                        case 4:
                            ClearFields();
                            break;
                        case 5:
                            SortDefinitions();
                            break;
                        case 6:
                            SearchDefinition();
                            break;
                        case 7:
                            DisplayDefinitions();
                            break;
                        case 8:
                            LoadDefinitionsFromFile();
                            break;
                        case 9:
                            SaveDefinitionsToFile();
                            break;
                        case 10:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        // 9.1: Create a global 2D string array
        // DefinitionsArray is already declared above.

        // 9.2: Create an ADD button that will store the information from the 4 text boxes into the 2D array
        static void AddDefinition()
        {
            Console.WriteLine("Adding a new definition:");

            // Get user input for the definition fields
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Example: ");
            string example = Console.ReadLine();

            // Find an empty slot in the array to store the definition
            int rowIndex = FindEmptyRow();
            if (rowIndex == -1)
            {
                Console.WriteLine("No more space in the array to add a new definition.");
                return;
            }

            // Store the definition in the array
            definitionsArray[rowIndex, 0] = name;
            definitionsArray[rowIndex, 1] = category;
            definitionsArray[rowIndex, 2] = description;
            definitionsArray[rowIndex, 3] = example;

            Console.WriteLine("Definition added successfully.");
        }

        // Helper method to find an empty row in the array
        static int FindEmptyRow()
        {
            for (int row = 0; row < rows; row++)
            {
                if (string.IsNullOrEmpty(definitionsArray[row, 0]))
                {
                    return row;
                }
            }
            return -1; // No empty row found
        }


        // 9.3: Create an EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        static void EditDefinition()
        {
            Console.WriteLine("Editing a definition:");

            // Get user input for the Name of the definition to edit
            Console.Write("Enter Name to edit: ");
            string nameToEdit = Console.ReadLine();

            // Find the index of the definition with the matching Name
            int rowIndex = FindRowIndexByName(nameToEdit);

            if (rowIndex == -1)
            {
                Console.WriteLine("Definition not found.");
                return;
            }

            // Get user input for the new values
            Console.Write("Enter new Category: ");
            string newCategory = Console.ReadLine();
            Console.Write("Enter new Description: ");
            string newDescription = Console.ReadLine();
            Console.Write("Enter new Example: ");
            string newExample = Console.ReadLine();

            // Update the definition in the array
            definitionsArray[rowIndex, 1] = newCategory;
            definitionsArray[rowIndex, 2] = newDescription;
            definitionsArray[rowIndex, 3] = newExample;

            Console.WriteLine("Definition updated successfully.");
        }

        // Helper method to find the row index by Name
        static int FindRowIndexByName(string nameToFind)
        {
            for (int row = 0; row < rows; row++)
            {
                if (definitionsArray[row, 0] == nameToFind)
                {
                    return row;
                }
            }
            return -1; // Name not found
        }


        // 9.4: Create a DELETE button that removes all the information from a single entry of the array
        static void DeleteDefinition()
        {
            Console.Write("Enter the Name to delete: ");
            string nameToDelete = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                if (definitionsArray[row, 0] == nameToDelete)
                {
                    // Delete the definition by setting all columns to null
                    for (int col = 0; col < columns; col++)
                    {
                        definitionsArray[row, col] = null;
                    }
                    Console.WriteLine("Definition deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Definition not found.");
        }

        // 9.5: Create a CLEAR method to clear the four text boxes so a new definition can be added
        static void ClearFields()
        {
            Array.Clear(definitionsArray, 0, definitionsArray.Length);
            Console.WriteLine("Fields cleared.");
        }

        // 9.6: Write the code for a Bubble Sort method to sort the 2D array by Name ascending
        static void SortDefinitions()
        {
            // Implement a bubble sort algorithm to sort the array by Name
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (definitionsArray[j, 0] != null && definitionsArray[j + 1, 0] != null)
                    {
                        if (string.Compare(definitionsArray[j, 0], definitionsArray[j + 1, 0]) > 0)
                        {
                            // Swap rows if the Name is out of order
                            for (int col = 0; col < columns; col++)
                            {
                                string temp = definitionsArray[j, col];
                                definitionsArray[j, col] = definitionsArray[j + 1, col];
                                definitionsArray[j + 1, col] = temp;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Definitions sorted by Name.");
        }

        // 9.7: Write the code for a Binary Search for the Name in the 2D array
        static void SearchDefinition()
        {
            Console.Write("Enter the Name to search: ");
            string nameToSearch = Console.ReadLine();

            int left = 0;
            int right = rows - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (definitionsArray[mid, 0] != null)
                {
                    int compareResult = string.Compare(definitionsArray[mid, 0], nameToSearch);
                    if (compareResult == 0)
                    {
                        result = mid;
                        break;
                    }
                    else if (compareResult < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    // Skip null rows
                    mid = FindNextNonNullRow(mid);
                    if (mid == -1)
                    {
                        break;
                    }
                    if (string.Compare(definitionsArray[mid, 0], nameToSearch) == 0)
                    {
                        result = mid;
                        break;
                    }
                    else if (string.Compare(definitionsArray[mid, 0], nameToSearch) < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            if (result != -1)
            {
                Console.WriteLine($"Definition found at index {result}");
                // Display the definition here
            }
            else
            {
                Console.WriteLine("Definition not found.");
            }
        }

        // Helper method to find the index of the next non-null row
        static int FindNextNonNullRow(int startIndex)
        {
            for (int row = startIndex; row < rows; row++)
            {
                if (definitionsArray[row, 0] != null)
                {
                    return row;
                }
            }
            return -1; // No non-null row found
        }

        // 9.8: Create a display method that will show Name and Category in a ListView
        static void DisplayDefinitions()
        {
            Console.WriteLine("Displaying Definitions:");
            for (int row = 0; row < rows; row++)
            {
                if (definitionsArray[row, 0] != null)
                {
                    Console.WriteLine($"Name: {definitionsArray[row, 0]}, Category: {definitionsArray[row, 1]}");
                }
            }
        }

        // 9.9: Create a method so the user can select a definition (Name) from the ListView and all the information is displayed
        static void SelectDefinitionFromListView()
        {
            Console.Write("Enter the Name to select: ");
            string nameToSelect = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                if (definitionsArray[row, 0] == nameToSelect)
                {
                    // Display the selected definition
                    Console.WriteLine($"Name: {definitionsArray[row, 0]}");
                    Console.WriteLine($"Category: {definitionsArray[row, 1]}");
                    Console.WriteLine($"Description: {definitionsArray[row, 2]}");
                    Console.WriteLine($"Example: {definitionsArray[row, 3]}");
                    return;
                }
            }

            Console.WriteLine("Definition not found.");
        }

        // 9.10: Create a SAVE button so the information from the 2D array can be written into a binary file
        static void SaveDefinitionsToFile()
        {
            Console.Write("Enter the file name to save: ");
            string fileName = Console.ReadLine();

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    // Write definitions to the file
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < columns; col++)
                        {
                            if (definitionsArray[row, col] != null)
                            {
                                writer.Write(definitionsArray[row, col]);
                            }
                            else
                            {
                                writer.Write(""); // Write empty string for null values
                            }
                        }
                    }
                }

                Console.WriteLine("Definitions saved to file.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: Unable to save definitions to file.");
            }
        }

        // 9.11: Create a LOAD button that will read the information from a binary file into the 2D array
        static void LoadDefinitionsFromFile()
        {
            Console.Write("Enter the file name to load: ");
            string fileName = Console.ReadLine();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    // Read definitions from the file
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < columns; col++)
                        {
                            definitionsArray[row, col] = reader.ReadString();
                        }
                    }
                }

                Console.WriteLine("Definitions loaded from file.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: Unable to load definitions from file.");
            }
        }
    }
}