namespace PictText
{
	partial class Visor
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lnkImagen = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(522, 425);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lnkImagen
			// 
			this.lnkImagen.AutoSize = true;
			this.lnkImagen.Location = new System.Drawing.Point(13, 444);
			this.lnkImagen.Name = "lnkImagen";
			this.lnkImagen.Size = new System.Drawing.Size(55, 13);
			this.lnkImagen.TabIndex = 1;
			this.lnkImagen.TabStop = true;
			this.lnkImagen.Text = "linkLabel1";
			this.lnkImagen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkImagen_LinkClicked);
			// 
			// Visor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 468);
			this.Controls.Add(this.lnkImagen);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Visor";
			this.Text = "Visor";
			this.Load += new System.EventHandler(this.Visor_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel lnkImagen;
	}
}