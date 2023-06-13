namespace Desktop
{
    partial class Main
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
        private void InitializeComponent()
        {
            this.Home = new System.Windows.Forms.Label();
            this.LoggedInUser = new System.Windows.Forms.Label();
            this.LogOut = new System.Windows.Forms.Button();
            this.usersDataGrid = new System.Windows.Forms.DataGridView();
            this.CreateUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Home
            // 
            this.Home.AutoSize = true;
            this.Home.Location = new System.Drawing.Point(12, 9);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(40, 15);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            // 
            // LoggedInUser
            // 
            this.LoggedInUser.AutoSize = true;
            this.LoggedInUser.Location = new System.Drawing.Point(638, 9);
            this.LoggedInUser.Name = "LoggedInUser";
            this.LoggedInUser.Size = new System.Drawing.Size(38, 15);
            this.LoggedInUser.TabIndex = 1;
            this.LoggedInUser.Text = "label1";
            // 
            // LogOut
            // 
            this.LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.LogOut.Location = new System.Drawing.Point(703, 5);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(75, 23);
            this.LogOut.TabIndex = 2;
            this.LogOut.Text = "LogOut";
            this.LogOut.UseVisualStyleBackColor = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // usersDataGrid
            // 
            this.usersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGrid.Location = new System.Drawing.Point(12, 73);
            this.usersDataGrid.Name = "usersDataGrid";
            this.usersDataGrid.RowTemplate.Height = 25;
            this.usersDataGrid.Size = new System.Drawing.Size(540, 150);
            this.usersDataGrid.TabIndex = 3;
            this.usersDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // CreateUser
            // 
            this.CreateUser.Location = new System.Drawing.Point(12, 44);
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Size = new System.Drawing.Size(75, 23);
            this.CreateUser.TabIndex = 4;
            this.CreateUser.Text = "Create User";
            this.CreateUser.UseVisualStyleBackColor = true;
            this.CreateUser.Click += new System.EventHandler(this.CreateUser_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateUser);
            this.Controls.Add(this.usersDataGrid);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.LoggedInUser);
            this.Controls.Add(this.Home);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Home;
        private Label LoggedInUser;
        private Button LogOut;
        private DataGridView usersDataGrid;
        private Button CreateUser;
    }
}