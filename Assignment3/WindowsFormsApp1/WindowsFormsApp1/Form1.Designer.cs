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
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Deklarera kontrollerna
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPersonalNumber;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuRegister;
        private System.Windows.Forms.ToolStripMenuItem menuExit;

        /// <summary>
        /// Required method for Designer support – do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtPersonalNumber = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();

            this.SuspendLayout();

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(50, 50);
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.Text = "Förnamn";
            this.txtFirstName.ForeColor = System.Drawing.Color.Gray;
            this.txtFirstName.Enter += new System.EventHandler(this.txtFirstName_Enter);
            this.txtFirstName.Leave += new System.EventHandler(this.txtFirstName_Leave);

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(50, 80);
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.Text = "Efternamn";
            this.txtLastName.ForeColor = System.Drawing.Color.Gray;
            this.txtLastName.Enter += new System.EventHandler(this.txtLastName_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.txtLastName_Leave);

            // txtPersonalNumber
            this.txtPersonalNumber.Location = new System.Drawing.Point(50, 110);
            this.txtPersonalNumber.Size = new System.Drawing.Size(200, 20);
            this.txtPersonalNumber.Text = "Personnummer (YYMMDD-XXXX)";
            this.txtPersonalNumber.ForeColor = System.Drawing.Color.Gray;
            this.txtPersonalNumber.Enter += new System.EventHandler(this.txtPersonalNumber_Enter);
            this.txtPersonalNumber.Leave += new System.EventHandler(this.txtPersonalNumber_Leave);

            // btnCheck
            this.btnCheck.Location = new System.Drawing.Point(270, 110);
            this.btnCheck.Size = new System.Drawing.Size(100, 30);
            this.btnCheck.Text = "Kontrollera";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(270, 150);
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.Text = "Avsluta";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // txtResult
            this.txtResult.Location = new System.Drawing.Point(50, 200);
            this.txtResult.Size = new System.Drawing.Size(320, 80);
            this.txtResult.Multiline = true;
            this.txtResult.ReadOnly = true;

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuRegister,
                this.menuExit
            });

            // menuRegister
            this.menuRegister.Text = "Registrera person";
            this.menuRegister.Click += new System.EventHandler(this.menuRegister_Click);

            // menuExit
            this.menuExit.Text = "Avsluta";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

            // Form1 inställningar
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtPersonalNumber);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "Personnummerkontroll";
            this.ClientSize = new System.Drawing.Size(420, 320);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
