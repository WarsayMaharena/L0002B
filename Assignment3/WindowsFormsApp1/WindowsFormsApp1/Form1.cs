using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // --- Hantering av platshållartext i textfälten ---
        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "Förnamn")
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.Text = "Förnamn";
                txtFirstName.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "Efternamn")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                txtLastName.Text = "Efternamn";
                txtLastName.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtPersonalNumber_Enter(object sender, EventArgs e)
        {
            if (txtPersonalNumber.Text == "Personnummer (YYMMDD-XXXX)")
            {
                txtPersonalNumber.Text = "";
                txtPersonalNumber.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtPersonalNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonalNumber.Text))
            {
                txtPersonalNumber.Text = "Personnummer (YYMMDD-XXXX)";
                txtPersonalNumber.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // --- Klickhändelser ---
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Hämta inmatade värden och trimma extra mellanslag
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string personalNumber = txtPersonalNumber.Text.Trim();

            // Kontrollera att användaren verkligen matat in något (och inte bara platshållartext)
            if (firstName == "Förnamn" || lastName == "Efternamn" ||
                personalNumber == "Personnummer (YYMMDD-XXXX)" ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(personalNumber))
            {
                MessageBox.Show("Vänligen fyll i alla fält!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Skapa ett Person-objekt
            Person person = new Person(firstName, lastName, personalNumber);

            // Kontrollera om personnumret är giltigt
            if (!person.IsValidPersonalNumber())
            {
                txtResult.Text = "Felaktigt personnummer!";
            }
            else
            {
                txtResult.Text = $"Namn: {person.FirstName} {person.LastName}\n" +
                                 $"Personnummer: {person.PersonalNumber}\n" +
                                 $"Kön: {person.GetGender()}";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuRegister_Click(object sender, EventArgs e)
        {
            // Här kan du t.ex. rensa formuläret eller visa en instruktion.
            txtFirstName.Text = "Förnamn";
            txtFirstName.ForeColor = System.Drawing.Color.Gray;
            txtLastName.Text = "Efternamn";
            txtLastName.ForeColor = System.Drawing.Color.Gray;
            txtPersonalNumber.Text = "Personnummer (YYMMDD-XXXX)";
            txtPersonalNumber.ForeColor = System.Drawing.Color.Gray;
            txtResult.Clear();

            MessageBox.Show("Fyll i formuläret och klicka på 'Kontrollera' för att validera personuppgifterna.",
                "Registrera person", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // --- Person-klassen ---
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        public Person(string firstName, string lastName, string personalNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
        }

        /// <summary>
        /// Validates the personal number using the 21‐algorithm.
        /// The algorithm:
        /// 1. Removes any hyphens and spaces.
        /// 2. If the resulting string has 12 digits (i.e. includes century),
        ///    it uses the last 10 digits.
        /// 3. Multiplies the digits alternately by 2 and 1 (starting with 2 for the first digit).
        /// 4. If a product is greater than 9, its digits are summed.
        /// 5. The total sum must be divisible by 10.
        /// </summary>
        /// <returns>true if valid; otherwise, false.</returns>
        public bool IsValidPersonalNumber()
        {
            // Remove hyphen and spaces.
            string cleanNumber = PersonalNumber.Replace("-", "").Replace(" ", "");

            // If input is 12 digits, assume it includes the century and take the last 10 digits.
            if (cleanNumber.Length == 12)
                cleanNumber = cleanNumber.Substring(2);

            // The personal number must have exactly 10 digits now.
            if (cleanNumber.Length != 10)
                return false;

            int sum = 0;

            // Loop through each digit.
            for (int i = 0; i < 10; i++)
            {
                if (!char.IsDigit(cleanNumber[i]))
                    return false;

                int digit = cleanNumber[i] - '0';
                // Multiply with 2 for even index positions (starting at 0) and 1 for odd.
                int weight = (i % 2 == 0) ? 2 : 1;
                int product = digit * weight;

                // If the product is two-digit, add its digits (e.g., 14 becomes 1+4=5).
                if (product > 9)
                    product = (product / 10) + (product % 10);

                sum += product;
            }

            // The number is valid if the sum is divisible by 10.
            return sum % 10 == 0;
        }

        /// <summary>
        /// Determines the gender based on the personal number.
        /// Assumes that the 9th digit (index 8) in the 10-digit personal number (after removing hyphens)
        /// indicates gender (odd = Man, even = Kvinna).
        /// </summary>
        /// <returns>"Man", "Kvinna", or "Okänt" if the format is invalid.</returns>
        public string GetGender()
        {
            // Remove hyphen and spaces.
            string cleanNumber = PersonalNumber.Replace("-", "").Replace(" ", "");

            // Handle 12-digit input by taking the last 10 digits.
            if (cleanNumber.Length == 12)
                cleanNumber = cleanNumber.Substring(2);

            if (cleanNumber.Length != 10)
                return "Okänt";

            // The 9th digit (index 8) determines the gender.
            int genderDigit = cleanNumber[8] - '0';
            return (genderDigit % 2 == 0) ? "Kvinna" : "Man";
        }
    }
}
