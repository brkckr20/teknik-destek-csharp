namespace Talepler
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
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.taleplerGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talepGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmanVeKullanıcılarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new Talepler.CustomTabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taleplerGirişiToolStripMenuItem,
            this.departmanVeKullanıcılarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1505, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // taleplerGirişiToolStripMenuItem
            // 
            this.taleplerGirişiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.talepGirişiToolStripMenuItem});
            this.taleplerGirişiToolStripMenuItem.Name = "taleplerGirişiToolStripMenuItem";
            this.taleplerGirişiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.taleplerGirişiToolStripMenuItem.Text = "İşlemler";
            // 
            // talepGirişiToolStripMenuItem
            // 
            this.talepGirişiToolStripMenuItem.Name = "talepGirişiToolStripMenuItem";
            this.talepGirişiToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.talepGirişiToolStripMenuItem.Text = "Talep Girişi";
            this.talepGirişiToolStripMenuItem.Click += new System.EventHandler(this.talepGirişiToolStripMenuItem_Click);
            // 
            // departmanVeKullanıcılarToolStripMenuItem
            // 
            this.departmanVeKullanıcılarToolStripMenuItem.Name = "departmanVeKullanıcılarToolStripMenuItem";
            this.departmanVeKullanıcılarToolStripMenuItem.Size = new System.Drawing.Size(154, 20);
            this.departmanVeKullanıcılarToolStripMenuItem.Text = "Departman ve Kullanıcılar";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(160, 35);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(15, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1505, 652);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 676);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extreme Talepler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem taleplerGirişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmanVeKullanıcılarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talepGirişiToolStripMenuItem;
        private CustomTabControl tabControl1;
    }
}

