namespace ISGPAI.Game
{
	partial class GameForm
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
			this._gamePanel = new ISGPAI.Game.GamePanel();
			this.SuspendLayout();
			// 
			// _gamePanel
			// 
			this._gamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._gamePanel.BackColor = System.Drawing.Color.White;
			this._gamePanel.Location = new System.Drawing.Point(12, 12);
			this._gamePanel.Name = "_gamePanel";
			this._gamePanel.Size = new System.Drawing.Size(928, 545);
			this._gamePanel.TabIndex = 0;
			this._gamePanel.World = null;
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(952, 569);
			this.Controls.Add(this._gamePanel);
			this.Name = "GameForm";
			this.Text = "GameForm";
			this.ResumeLayout(false);

		}

		#endregion

		private GamePanel _gamePanel;
	}
}