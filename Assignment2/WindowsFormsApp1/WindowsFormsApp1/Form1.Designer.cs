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
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPersonalNumber;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtSoldItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ListBox lstResults;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPersonalNumber = new System.Windows.Forms.TextBox();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtSoldItems = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();

            this.SuspendLayout();

            // TextBoxes
            this.txtName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Size = new System.Drawing.Size(200, 20);
            // Set default placeholder text
            this.txtName.Text = "Namn";
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);


            this.txtPersonalNumber.Location = new System.Drawing.Point(20, 50);
            this.txtPersonalNumber.Size = new System.Drawing.Size(200, 20);
            this.txtPersonalNumber.Text = "Personnummer";
            this.txtPersonalNumber.ForeColor = System.Drawing.Color.Gray;
            this.txtPersonalNumber.Enter += new System.EventHandler(this.txtPersonalNumber_Enter);
            this.txtPersonalNumber.Leave += new System.EventHandler(this.txtPersonalNumber_Leave);

            this.txtDistrict.Location = new System.Drawing.Point(20, 80);
            this.txtDistrict.Size = new System.Drawing.Size(200, 20);
            this.txtDistrict.Text = "Distrikt";
            this.txtDistrict.ForeColor = System.Drawing.Color.Gray;
            this.txtDistrict.Enter += new System.EventHandler(this.txtDistrict_Enter);
            this.txtDistrict.Leave += new System.EventHandler(this.txtDistrict_Leave);

            this.txtSoldItems.Location = new System.Drawing.Point(20, 110);
            this.txtSoldItems.Size = new System.Drawing.Size(200, 20);
            this.txtSoldItems.Text = "Antal sålda artiklar";
            this.txtSoldItems.ForeColor = System.Drawing.Color.Gray;
            this.txtSoldItems.Enter += new System.EventHandler(this.txtSoldItems_Enter);
            this.txtSoldItems.Leave += new System.EventHandler(this.txtSoldItems_Leave);
            // Add Button
            this.btnAdd.Location = new System.Drawing.Point(20, 140);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Lägg till";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Sort Button
            this.btnSort.Location = new System.Drawing.Point(130, 140);
            this.btnSort.Size = new System.Drawing.Size(100, 30);
            this.btnSort.Text = "Sortera";
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);

            // ListBox for Results
            this.lstResults.Location = new System.Drawing.Point(20, 180);
            this.lstResults.Size = new System.Drawing.Size(300, 200);

            // Form settings
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPersonalNumber);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.txtSoldItems);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lstResults);
            this.Text = "Säljkårs Hantering";

            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}

