namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.TextBox txtPaid;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.Label lblResult;

		private void InitializeComponent()
		{
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtPaid = new System.Windows.Forms.TextBox();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.lblResult = new System.Windows.Forms.Label();

			this.SuspendLayout();

			// TextBox för pris
			this.txtPrice.Location = new System.Drawing.Point(50, 30);
			this.txtPrice.Size = new System.Drawing.Size(100, 20);
			this.txtPrice.Text = "Ange pris";
			this.txtPrice.ForeColor = System.Drawing.Color.Gray;
			this.txtPrice.Enter += new System.EventHandler(this.txtPrice_Enter);
			this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);

			// TextBox för betalt belopp
			this.txtPaid.Location = new System.Drawing.Point(50, 60);
			this.txtPaid.Size = new System.Drawing.Size(100, 20);
			this.txtPaid.Text = "Betalt belopp";
			this.txtPaid.ForeColor = System.Drawing.Color.Gray;
			this.txtPaid.Enter += new System.EventHandler(this.txtPaid_Enter);
			this.txtPaid.Leave += new System.EventHandler(this.txtPaid_Leave);

			// Button för att beräkna växel
			this.btnCalculate.Location = new System.Drawing.Point(50, 90);
			this.btnCalculate.Size = new System.Drawing.Size(100, 30);
			this.btnCalculate.Text = "Beräkna växel";
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

			// Label för att visa resultatet
			this.lblResult.Location = new System.Drawing.Point(50, 130);
			this.lblResult.Size = new System.Drawing.Size(300, 150);
			this.lblResult.Text = "Växel tillbaka:";

			// Form inställningar
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 300);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.txtPaid);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.lblResult);
			this.Text = "Växelberäknare";

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
	}
}

