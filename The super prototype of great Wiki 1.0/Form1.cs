using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    namespace The_super_prototype_of_great_Wiki_1._0
    {
        public partial class Form1 : Form
        {
        //private static readonly int rows = 12;
        //private static readonly int columns = 4;
        //private string[,] definitionsArray = new string[rows, columns];

        public Form1()
        {
            InitializeComponent();
        }

        //private int FindEmptyRow()
        //{
        //    for (int row = 0; row < rows; row++)
        //    {
        //        if (string.IsNullOrEmpty(definitionsArray[row, 0]))
        //        {
        //            return row;
        //        }
        //    }
        //    return -1; // No empty row found
        //}

        //private int FindRowIndexByName(string nameToFind)
        //{
        //    for (int row = 0; row < rows; row++)
        //    {
        //        if (definitionsArray[row, 0] == nameToFind)
        //        {
        //            return row;
        //        }
        //    }
        //    return -1; // Name not found
        //}

        //private void AddButton_Click(object sender, EventArgs e)
        //{
        //    string name = NameTextBox.Text;
        //    string category = CategoryTextBox.Text;
        //    string description = DescriptionTextBox.Text;
        //    string example = ExampleTextBox.Text;

        //    // Find an empty slot in the array to store the definition
        //    int rowIndex = FindEmptyRow();
        //    if (rowIndex == -1)
        //    {
        //        MessageBox.Show("No more space in the array to add a new definition.");
        //        return;
        //    }

        //    // Store the definition in the array
        //    definitionsArray[rowIndex, 0] = name;
        //    definitionsArray[rowIndex, 1] = category;
        //    definitionsArray[rowIndex, 2] = description;
        //    definitionsArray[rowIndex, 3] = example;

        //    // Clear the input fields
        //    NameTextBox.Text = "";
        //    CategoryTextBox.Text = "";
        //    DescriptionTextBox.Text = "";
        //    ExampleTextBox.Text = "";

        //    MessageBox.Show("Definition added successfully.");
        //}

        //private void EditButton_Click(object sender, EventArgs e)
        //{
        //    string nameToEdit = NameTextBox.Text;

        //    // Find the index of the definition with the matching Name
        //    int rowIndex = FindRowIndexByName(nameToEdit);

        //    if (rowIndex == -1)
        //    {
        //        MessageBox.Show("Definition not found.");
        //        return;
        //    }

        //    string newCategory = CategoryTextBox.Text;
        //    string newDescription = DescriptionTextBox.Text;
        //    string newExample = ExampleTextBox.Text;

        //    // Update the definition in the array
        //    definitionsArray[rowIndex, 1] = newCategory;
        //    definitionsArray[rowIndex, 2] = newDescription;
        //    definitionsArray[rowIndex, 3] = newExample;

        //    // Clear the input fields
        //    NameTextBox.Text = "";
        //    CategoryTextBox.Text = "";
        //    DescriptionTextBox.Text = "";
        //    ExampleTextBox.Text = "";

        //    MessageBox.Show("Definition updated successfully.");
        //}

        //private void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    string nameToDelete = NameTextBox.Text;

        //    for (int row = 0; row < rows; row++)
        //    {
        //        if (definitionsArray[row, 0] == nameToDelete)
        //        {
        //            // Delete the definition by setting all columns to null
        //            for (int col = 0; col < columns; col++)
        //            {
        //                definitionsArray[row, col] = null;
        //            }

        //            // Clear the input fields
        //            NameTextBox.Text = "";
        //            CategoryTextBox.Text = "";
        //            DescriptionTextBox.Text = "";
        //            ExampleTextBox.Text = "";

        //            MessageBox.Show("Definition deleted successfully.");
        //            return;
        //        }
        //    }

        //    MessageBox.Show("Definition not found.");
        //}

        //private void ClearButton_Click(object sender, EventArgs e)
        //{
        //    // Clear the input fields
        //    NameTextBox.Text = "";
        //    CategoryTextBox.Text = "";
        //    DescriptionTextBox.Text = "";
        //    ExampleTextBox.Text = "";
        //}

        //private void SortButton_Click(object sender, EventArgs e)
        //{
        //    // Implement a bubble sort algorithm to sort the array by Name
        //    // (Similar to the code provided earlier in the console application)
        //    // Make sure to update the display after sorting if necessary.
        //}

        //private void SearchButton_Click(object sender, EventArgs e)
        //{
        //    string nameToSearch = NameTextBox.Text;

        //    int rowIndex = FindRowIndexByName(nameToSearch);

        //    if (rowIndex != -1)
        //    {
        //        // Display the found definition in the input fields
        //        CategoryTextBox.Text = definitionsArray[rowIndex, 1];
        //        DescriptionTextBox.Text = definitionsArray[rowIndex, 2];
        //        ExampleTextBox.Text = definitionsArray[rowIndex, 3];
        //    }
        //    else
        //    {
        //        // Clear the input fields
        //        CategoryTextBox.Text = "";
        //        DescriptionTextBox.Text = "";
        //        ExampleTextBox.Text = "";

        //        MessageBox.Show("Definition not found.");
        //    }
        //}

        //private void DisplayButton_Click(object sender, EventArgs e)
        //{
        //    // Implement the logic to display definitions in a list view or other control
        //}

        //private void LoadButton_Click(object sender, EventArgs e)
        //{
        //    // Implement the logic to load definitions from a file into the definitionsArray
        //    // (Similar to the code provided earlier in the console application)
        //}

        //private void SaveButton_Click(object sender, EventArgs e)
        //{
        //    // Implement the logic to save definitions from the definitionsArray into a file
        //    // (Similar to the code provided earlier in the console application)
        //}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(889, 458);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
      }
    }
