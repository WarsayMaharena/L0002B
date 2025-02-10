using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void txtPrice_Enter(object sender, EventArgs e)
		{
			if (txtPrice.Text == "Ange pris")
			{
				txtPrice.Text = "";
				txtPrice.ForeColor = Color.Black;
			}
		}

		private void txtPrice_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtPrice.Text))
			{
				txtPrice.Text = "Ange pris";
				txtPrice.ForeColor = Color.Gray;
			}
		}

		private void txtPaid_Enter(object sender, EventArgs e)
		{
			if (txtPaid.Text == "Betalt belopp")
			{
				txtPaid.Text = "";
				txtPaid.ForeColor = Color.Black;
			}
		}

		private void txtPaid_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtPaid.Text))
			{
				txtPaid.Text = "Betalt belopp";
				txtPaid.ForeColor = Color.Gray;
			}
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtPrice.Text, out int price) && int.TryParse(txtPaid.Text, out int paid))
			{
				if (paid < price)
				{
					MessageBox.Show("Betalt belopp är för lågt!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				int change = paid - price;
				lblResult.Text = "Växel tillbaka:\n" + CalculateChange(change);
			}
			else
			{
				MessageBox.Show("Ange giltiga heltal!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private string CalculateChange(int change)
		{
			int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
			string[] names = { "femhundralapp", "tvåhundralapp", "hundralapp", "femtiolapp", "tjugolapp", "tiokrona", "femkrona", "enkrona" };

			string result = "";
			for (int i = 0; i < denominations.Length; i++)
			{
				int count = change / denominations[i];
				if (count > 0)
				{
					result += $"{count} {names[i]}{(count > 1 ? "ar" : "")}\n";
					change %= denominations[i];
				}
			}
			return result;
		}
	}
}