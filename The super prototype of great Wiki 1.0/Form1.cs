using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    namespace The_super_prototype_of_great_Wiki_1._0
    {
        public partial class Form1 : Form
        {
        private static readonly int rows = 12;
        private static readonly int columns = 4;
        private TextBox CategoryTextBox;
        private TextBox DescriptionTextBox;
        private TextBox ExampleTextBox;
        private TextBox NameTextBox;
        private Label LabelName;
        private ListView ListViewDefinitions;
        private ColumnHeader name;
        private ColumnHeader category;
        private ToolTip toolTip1;
        private IContainer components;
        private Button AddButton;
        private Button EditButton;
        private Button DeleteButton;
        private Button ClearButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button SortButton;
        private Button SearchButton;
        private Button DisplayButton;
        private Button LoadButton;
        private Button SaveButton;
        private string[,] definitionsArray = new string[rows, columns];

        public Form1()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            NameTextBox.Clear();
            CategoryTextBox.Clear();
            DescriptionTextBox.Clear();
            ExampleTextBox.Clear();
        }

        public int BinarySearch(string searchTerm)
        {
            int left = 0, right = definitionsArray.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                int comparisonResult = String.Compare(definitionsArray[middle, 0], searchTerm);

                if (comparisonResult == 0)
                {
                    return middle;
                }
                else if (comparisonResult < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;  // searchTerm was not found
        }


        
        public void Sort()
        {
            for (int i = 0; i < definitionsArray.Length - 1; i++)
            {
                for (int j = i + 1; j < definitionsArray.Length; j++)
                {
                    if (String.Compare(definitionsArray[i, 0], definitionsArray[j, 0]) > 0)
                    {
                        Swap(i, j);
                    }
                }
            }
        }

        private int FindEmptyRow()
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

        private int FindRowIndexByName(string nameToFind)
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

        private void Display()
        {
            //TO DO: add method to display in ListViewDefinitions
            // Clear existing items in the ListView
            ListViewDefinitions.Items.Clear();

            // Iterate through the definitionsArray and add each definition to the ListView
            for (int row = 0; row < rows; row++)
            {
                if (!string.IsNullOrEmpty(definitionsArray[row, 0]))
                {
                    string name = definitionsArray[row, 0];
                    string category = definitionsArray[row, 1];

                    // Create a ListViewItem to represent the definition
                    ListViewItem item = new ListViewItem(new[] { name, category });

                    // Add the ListViewItem to the ListView
                    ListViewDefinitions.Items.Add(item);
                }
            }
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string category = CategoryTextBox.Text;
            string description = DescriptionTextBox.Text;
            string example = ExampleTextBox.Text;

            // Find an empty slot in the array to store the definition
            int rowIndex = FindEmptyRow();
            if (rowIndex == -1)
            {
                MessageBox.Show("No more space in the array to add a new definition.");
                return;
            }

            // Store the definition in the array
            definitionsArray[rowIndex, 0] = name;
            definitionsArray[rowIndex, 1] = category;
            definitionsArray[rowIndex, 2] = description;
            definitionsArray[rowIndex, 3] = example;

            // Clear the input fields
            Clear();

            MessageBox.Show("Definition added successfully.");
        }
        private void EditButton_Click_1(object sender, EventArgs e)
        {
            string nameToEdit = NameTextBox.Text;

            // Find the index of the definition with the matching Name
            int rowIndex = FindRowIndexByName(nameToEdit);

            if (rowIndex == -1)
            {
                MessageBox.Show("Definition not found.");
                return;
            }

            string newCategory = CategoryTextBox.Text;
            string newDescription = DescriptionTextBox.Text;
            string newExample = ExampleTextBox.Text;

            // Update the definition in the array
            definitionsArray[rowIndex, 1] = newCategory;
            definitionsArray[rowIndex, 2] = newDescription;
            definitionsArray[rowIndex, 3] = newExample;

            // Clear the input fields
            Clear();

            MessageBox.Show("Definition updated successfully.");
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            string nameToDelete = NameTextBox.Text;

            for (int row = 0; row < rows; row++)
            {
                if (definitionsArray[row, 0] == nameToDelete)
                {
                    // Delete the definition by setting all columns to null
                    for (int col = 0; col < columns; col++)
                    {
                        definitionsArray[row, col] = null;
                    }

                    // Clear the input fields
                    Clear();

                    MessageBox.Show("Definition deleted successfully.");
                    return;
                }
            }

            MessageBox.Show("Definition not found.");
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            // Clear the input fields
            Clear();
        }

        private void SortButton_Click_1(object sender, EventArgs e)
        {
            // Call the Sort method to sort the definitionsArray
            Sort();

            // After sorting, update the display to show the sorted definitions
            Display();
        }

        private void Swap(int row1, int row2)
        {
            // Swap definitionsArray elements at the specified indices
            for (int col = 0; col < columns; col++)
            {
                string temp = definitionsArray[row1, col];
                definitionsArray[row1, col] = definitionsArray[row2, col];
                definitionsArray[row2, col] = temp;
            }
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            //fix this later to search from a new Search Textbox
            string nameToSearch = NameTextBox.Text;

            int rowIndex = FindRowIndexByName(nameToSearch);

            if (rowIndex != -1)
            {
                // Display the found definition in the input fields
                CategoryTextBox.Text = definitionsArray[rowIndex, 1];
                DescriptionTextBox.Text = definitionsArray[rowIndex, 2];
                ExampleTextBox.Text = definitionsArray[rowIndex, 3];
            }
            else
            {
                // Clear the input fields
                Clear();

                MessageBox.Show("Definition not found.");
            }
        }

        private void DisplayButton_Click_1(object sender, EventArgs e)
        {
            // Clear existing items in the ListView
            ListViewDefinitions.Items.Clear();

            // Iterate through the definitionsArray and add each definition to the ListView
            for (int row = 0; row < rows; row++)
            {
                if (!string.IsNullOrEmpty(definitionsArray[row, 0]) && !string.IsNullOrEmpty(definitionsArray[row, 1]))
                {
                    string name = definitionsArray[row, 0];
                    string category = definitionsArray[row, 1];

                    // Create a ListViewItem to represent the definition
                    ListViewItem item = new ListViewItem(new[] { name, category });

                    // Add the ListViewItem to the ListView
                    ListViewDefinitions.Items.Add(item);
                }
            }
        }

        private void LoadButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary Files|*.dat|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        // Read the number of rows and columns from the file
                        int fileRows = reader.ReadInt32();
                        int fileColumns = reader.ReadInt32();

                        // Check if the file structure matches your expectations
                        if (fileRows != rows || fileColumns != columns)
                        {
                            MessageBox.Show("File format is not compatible with this application.");
                            return;
                        }

                        // Read the definitions data into the definitionsArray
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < columns; col++)
                            {
                                definitionsArray[row, col] = reader.ReadString();
                            }
                        }

                        // Display a success message
                        MessageBox.Show("Definitions loaded successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading definitions: " + ex.Message);
                }
            }
        }
        

        private void SaveButton_Click_1(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ExampleTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.ListViewDefinitions = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SortButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DisplayButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.Location = new System.Drawing.Point(360, 86);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(100, 22);
            this.CategoryTextBox.TabIndex = 0;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(360, 147);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 22);
            this.DescriptionTextBox.TabIndex = 1;
            // 
            // ExampleTextBox
            // 
            this.ExampleTextBox.Location = new System.Drawing.Point(360, 212);
            this.ExampleTextBox.Name = "ExampleTextBox";
            this.ExampleTextBox.Size = new System.Drawing.Size(100, 22);
            this.ExampleTextBox.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(360, 276);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 22);
            this.NameTextBox.TabIndex = 3;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(49, 85);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(44, 16);
            this.LabelName.TabIndex = 4;
            this.LabelName.Text = "Name";
            // 
            // ListViewDefinitions
            // 
            this.ListViewDefinitions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.category});
            this.ListViewDefinitions.HideSelection = false;
            this.ListViewDefinitions.Location = new System.Drawing.Point(501, 85);
            this.ListViewDefinitions.Name = "ListViewDefinitions";
            this.ListViewDefinitions.Size = new System.Drawing.Size(308, 319);
            this.ListViewDefinitions.TabIndex = 5;
            this.ListViewDefinitions.UseCompatibleStateImageBehavior = false;
            this.ListViewDefinitions.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 130;
            // 
            // category
            // 
            this.category.Text = "Category";
            this.category.Width = 188;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(144, 85);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.Add_Click_1);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(144, 147);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click_1);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(144, 211);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click_1);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(144, 276);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(144, 335);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(75, 23);
            this.SortButton.TabIndex = 13;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click_1);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(144, 391);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 14;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click_1);
            // 
            // DisplayButton
            // 
            this.DisplayButton.Location = new System.Drawing.Point(242, 85);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(75, 23);
            this.DisplayButton.TabIndex = 15;
            this.DisplayButton.Text = "Display";
            this.DisplayButton.UseVisualStyleBackColor = true;
            this.DisplayButton.Click += new System.EventHandler(this.DisplayButton_Click_1);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(242, 147);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 16;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(242, 210);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(889, 458);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.DisplayButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ExampleTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.ListViewDefinitions);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
    }
