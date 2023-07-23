namespace Gun_Mayhem.Forms
{
	partial class Map1
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
			this.components = new System.ComponentModel.Container();
			this.PlayerLoop = new System.Windows.Forms.Timer(this.components);
			this.BulletsTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// PlayerLoop
			// 
			this.PlayerLoop.Enabled = true;
			this.PlayerLoop.Interval = 200;
			this.PlayerLoop.Tick += new System.EventHandler(this.PlayerLoop_Tick);
			// 
			// BulletsTimer
			// 
			this.BulletsTimer.Enabled = true;
			this.BulletsTimer.Tick += new System.EventHandler(this.BulletsTimer_Tick);
			// 
			// Map1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackgroundImage = global::Gun_Mayhem.Properties.Resources.Map1BG;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1178, 744);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Map1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Map1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Map1_FormClosed);
			this.Load += new System.EventHandler(this.Map1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer PlayerLoop;
		private System.Windows.Forms.Timer BulletsTimer;
	}
}