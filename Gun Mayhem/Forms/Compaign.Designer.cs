namespace Gun_Mayhem.Forms
{
	partial class Compaign
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
			this.BulletTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// PlayerLoop
			// 
			this.PlayerLoop.Enabled = true;
			this.PlayerLoop.Interval = 200;
			this.PlayerLoop.Tick += new System.EventHandler(this.PlayerLoop_Tick);
			// 
			// BulletTimer
			// 
			this.BulletTimer.Enabled = true;
			this.BulletTimer.Tick += new System.EventHandler(this.BulletTimer_Tick);
			// 
			// Compaign
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = global::Gun_Mayhem.Properties.Resources.Map2BG;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1178, 744);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Compaign";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Compaign";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Compaign_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer PlayerLoop;
		private System.Windows.Forms.Timer BulletTimer;
	}
}