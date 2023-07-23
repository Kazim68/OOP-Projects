namespace Gun_Mayhem
{
	partial class StartScreen
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.CampainBtn = new System.Windows.Forms.Button();
			this.MultiplayerBtn = new System.Windows.Forms.Button();
			this.EndlessSurvivalBtn = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.OldLace;
			this.tableLayoutPanel1.BackgroundImage = global::Gun_Mayhem.Properties.Resources.StartScreenBG;
			this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.34295F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.12564F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.44652F));
			this.tableLayoutPanel1.Controls.Add(this.CampainBtn, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.MultiplayerBtn, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.EndlessSurvivalBtn, 1, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.84536F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60481F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.32258F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1178, 744);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// CampainBtn
			// 
			this.CampainBtn.BackColor = System.Drawing.Color.Transparent;
			this.CampainBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CampainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CampainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CampainBtn.ForeColor = System.Drawing.Color.BlueViolet;
			this.CampainBtn.Location = new System.Drawing.Point(384, 264);
			this.CampainBtn.Name = "CampainBtn";
			this.CampainBtn.Size = new System.Drawing.Size(396, 79);
			this.CampainBtn.TabIndex = 0;
			this.CampainBtn.Text = "Campaign";
			this.CampainBtn.UseVisualStyleBackColor = false;
			this.CampainBtn.Click += new System.EventHandler(this.CampainBtn_Click);
			// 
			// MultiplayerBtn
			// 
			this.MultiplayerBtn.BackColor = System.Drawing.Color.Transparent;
			this.MultiplayerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MultiplayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MultiplayerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MultiplayerBtn.ForeColor = System.Drawing.Color.ForestGreen;
			this.MultiplayerBtn.Location = new System.Drawing.Point(384, 349);
			this.MultiplayerBtn.Name = "MultiplayerBtn";
			this.MultiplayerBtn.Size = new System.Drawing.Size(396, 72);
			this.MultiplayerBtn.TabIndex = 1;
			this.MultiplayerBtn.Text = "Multiplayer";
			this.MultiplayerBtn.UseVisualStyleBackColor = false;
			this.MultiplayerBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// EndlessSurvivalBtn
			// 
			this.EndlessSurvivalBtn.BackColor = System.Drawing.Color.Transparent;
			this.EndlessSurvivalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EndlessSurvivalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EndlessSurvivalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EndlessSurvivalBtn.ForeColor = System.Drawing.Color.Red;
			this.EndlessSurvivalBtn.Location = new System.Drawing.Point(384, 427);
			this.EndlessSurvivalBtn.Name = "EndlessSurvivalBtn";
			this.EndlessSurvivalBtn.Size = new System.Drawing.Size(396, 78);
			this.EndlessSurvivalBtn.TabIndex = 2;
			this.EndlessSurvivalBtn.Text = "Endless Survival";
			this.EndlessSurvivalBtn.UseVisualStyleBackColor = false;
			this.EndlessSurvivalBtn.Click += new System.EventHandler(this.EndlessSurvivalBtn_Click);
			// 
			// StartScreen
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1178, 744);
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.Name = "StartScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StartScreen";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartScreen_FormClosed);
			this.Load += new System.EventHandler(this.StartScreen_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button CampainBtn;
		private System.Windows.Forms.Button MultiplayerBtn;
		private System.Windows.Forms.Button EndlessSurvivalBtn;
	}
}

