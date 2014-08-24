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
			this._gamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(144)))), ((int)(((byte)(88)))));
			this._gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._gamePanel.Location = new System.Drawing.Point(2, 1);
			this._gamePanel.Name = "_gamePanel";
			this._gamePanel.Size = new System.Drawing.Size(1269, 688);
			this._gamePanel.TabIndex = 0;
			this._gamePanel.World = null;
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 689);
			this.Controls.Add(this._gamePanel);
			this.Name = "GameForm";
			this.ShowIcon = false;
			this.Text = "AIssignment (Press G to toggle grid. Press F12 for goal driven behavior debug tex" +
    "t)";
			this.ResumeLayout(false);

		}

		#endregion

		private GamePanel _gamePanel;
	}
}