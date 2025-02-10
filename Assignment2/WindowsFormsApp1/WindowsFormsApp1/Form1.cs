using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO; // Required for file operations


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Salesperson> salespeople = new List<Salesperson>();

        public Form1()
        {
            InitializeComponent();
        }

        // Placeholder Text for txtName
        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Namn")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Namn";
                txtName.ForeColor = Color.Gray;
            }
        }

        // Placeholder Text for txtPersonalNumber
        private void txtPersonalNumber_Enter(object sender, EventArgs e)
        {
            if (txtPersonalNumber.Text == "Personnummer")
            {
                txtPersonalNumber.Text = "";
                txtPersonalNumber.ForeColor = Color.Black;
            }
        }

        private void txtPersonalNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonalNumber.Text))
            {
                txtPersonalNumber.Text = "Personnummer";
                txtPersonalNumber.ForeColor = Color.Gray;
            }
        }

        // Placeholder Text for txtDistrict
        private void txtDistrict_Enter(object sender, EventArgs e)
        {
            if (txtDistrict.Text == "Distrikt")
            {
                txtDistrict.Text = "";
                txtDistrict.ForeColor = Color.Black;
            }
        }

        private void txtDistrict_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDistrict.Text))
            {
                txtDistrict.Text = "Distrikt";
                txtDistrict.ForeColor = Color.Gray;
            }
        }

        // Placeholder Text for txtSoldItems
        private void txtSoldItems_Enter(object sender, EventArgs e)
        {
            if (txtSoldItems.Text == "Antal sålda artiklar")
            {
                txtSoldItems.Text = "";
                txtSoldItems.ForeColor = Color.Black;
            }
        }

        private void txtSoldItems_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoldItems.Text))
            {
                txtSoldItems.Text = "Antal sålda artiklar";
                txtSoldItems.ForeColor = Color.Gray;
            }
        }

        // Button Click Event to Add Salesperson
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text == "Namn" ||
                string.IsNullOrWhiteSpace(txtPersonalNumber.Text) || txtPersonalNumber.Text == "Personnummer" ||
                string.IsNullOrWhiteSpace(txtDistrict.Text) || txtDistrict.Text == "Distrikt" ||
                !int.TryParse(txtSoldItems.Text, out int soldItems))
            {
                MessageBox.Show("Vänligen fyll i alla fält korrekt!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Salesperson sp = new Salesperson(txtName.Text, txtPersonalNumber.Text, txtDistrict.Text, soldItems);
            salespeople.Add(sp);

            //lstResults.Items.Add($"{sp.Name}, {sp.PersonalNumber}, {sp.District}, {sp.SoldItems} artiklar");

            // Clear input fields
            txtName.Text = "Namn";
            txtName.ForeColor = Color.Gray;
            txtPersonalNumber.Text = "Personnummer";
            txtPersonalNumber.ForeColor = Color.Gray;
            txtDistrict.Text = "Distrikt";
            txtDistrict.ForeColor = Color.Gray;
            txtSoldItems.Text = "Antal sålda artiklar";
            txtSoldItems.ForeColor = Color.Gray;
        }

        // Button Click Event to Sort and Display Salespeople
        private void btnSort_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            // Sort salespeople by number of sold items (descending)
            var sortedList = salespeople.OrderByDescending(sp => sp.SoldItems).ToList();

            // Count sellers per level
            int level1 = sortedList.Count(sp => sp.SoldItems < 50);
            int level2 = sortedList.Count(sp => sp.SoldItems >= 50 && sp.SoldItems <= 99);
            int level3 = sortedList.Count(sp => sp.SoldItems >= 100 && sp.SoldItems <= 199);
            int level4 = sortedList.Count(sp => sp.SoldItems >= 200);




            string fileName = "SalesReport.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Display number of sellers in each level
                lstResults.Items.Add("\nNamn Persnr Distrikt Antal:");
                writer.WriteLine("\nNamn Persnr Distrikt Antal:");
                foreach (var sp in sortedList)
                {
                    if (sp.SoldItems < 50)
                    {
                        string output = $"{sp.Name}, {sp.PersonalNumber}, {sp.District}, {sp.SoldItems} artiklar";
                        lstResults.Items.Add(output);
                        writer.WriteLine(output);
                    }
                }
                if (level1 > 0)
                {
                    string levelOutput = $"{level1} säljare har nått nivå 1: under 50 artiklar";
                    lstResults.Items.Add(levelOutput);
                    writer.WriteLine(levelOutput);
                }
                foreach (var sp in sortedList)
                {
                    if (50 <= sp.SoldItems && sp.SoldItems < 100)
                    {
                        string output = $"{sp.Name}, {sp.PersonalNumber}, {sp.District}, {sp.SoldItems} artiklar";
                        lstResults.Items.Add(output);
                        writer.WriteLine(output);
                    }
                }
                if (level2 > 0)
                {
                    string levelOutput = $"{level2} säljare har nått nivå 2: 50-99 artiklar";
                    lstResults.Items.Add(levelOutput);
                    writer.WriteLine(levelOutput);
                }
                foreach (var sp in sortedList)
                {
                    if (100 <= sp.SoldItems && sp.SoldItems < 200)
                    {
                        string output = $"{sp.Name}, {sp.PersonalNumber}, {sp.District}, {sp.SoldItems} artiklar";
                        lstResults.Items.Add(output);
                        writer.WriteLine(output);
                    }
                }

                if (level3 > 0)
                {
                    string levelOutput = $"{level3} säljare har nått nivå 3: 100-199 artiklar";
                    lstResults.Items.Add(levelOutput);
                    writer.WriteLine(levelOutput);
                }
                foreach (var sp in sortedList)
                {
                    if (200 <= sp.SoldItems)
                    {
                        string output = $"{sp.Name}, {sp.PersonalNumber}, {sp.District}, {sp.SoldItems} artiklar";
                        lstResults.Items.Add(output);
                        writer.WriteLine(output);

                    }
                }

                if (level4 > 0)
                {
                    string levelOutput = $"{level4} säljare har nått nivå 4: över 199 artiklar";
                    lstResults.Items.Add(levelOutput);
                    writer.WriteLine(levelOutput);
                }
                MessageBox.Show($"Resultatet har sparats i filen {fileName}", "Fil sparad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Class to Store Salesperson Information
        public class Salesperson
        {
            public string Name { get; set; }
            public string PersonalNumber { get; set; }
            public string District { get; set; }
            public int SoldItems { get; set; }

            public Salesperson(string name, string personalNumber, string district, int soldItems)
            {
                Name = name;
                PersonalNumber = personalNumber;
                District = district;
                SoldItems = soldItems;
            }
        }
    }
}
