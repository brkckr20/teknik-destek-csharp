namespace Talepler.Forms
{
    partial class TaleplerDetayliRapor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bekleyenlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamamlananlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iptalEdilenlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelOlarakAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1253, 677);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bekleyenlerToolStripMenuItem,
            this.tamamlananlarToolStripMenuItem,
            this.iptalEdilenlerToolStripMenuItem,
            this.excelOlarakAktarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // bekleyenlerToolStripMenuItem
            // 
            this.bekleyenlerToolStripMenuItem.Name = "bekleyenlerToolStripMenuItem";
            this.bekleyenlerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bekleyenlerToolStripMenuItem.Text = "Bekleyenler";
            this.bekleyenlerToolStripMenuItem.Click += new System.EventHandler(this.bekleyenlerToolStripMenuItem_Click);
            // 
            // tamamlananlarToolStripMenuItem
            // 
            this.tamamlananlarToolStripMenuItem.Name = "tamamlananlarToolStripMenuItem";
            this.tamamlananlarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tamamlananlarToolStripMenuItem.Text = "Tamamlananlar";
            this.tamamlananlarToolStripMenuItem.Click += new System.EventHandler(this.tamamlananlarToolStripMenuItem_Click);
            // 
            // iptalEdilenlerToolStripMenuItem
            // 
            this.iptalEdilenlerToolStripMenuItem.Name = "iptalEdilenlerToolStripMenuItem";
            this.iptalEdilenlerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iptalEdilenlerToolStripMenuItem.Text = "İptal Edilenler";
            this.iptalEdilenlerToolStripMenuItem.Click += new System.EventHandler(this.iptalEdilenlerToolStripMenuItem_Click);
            // 
            // excelOlarakAktarToolStripMenuItem
            // 
            this.excelOlarakAktarToolStripMenuItem.Name = "excelOlarakAktarToolStripMenuItem";
            this.excelOlarakAktarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.excelOlarakAktarToolStripMenuItem.Text = "Excel Olarak Aktar";
            this.excelOlarakAktarToolStripMenuItem.Click += new System.EventHandler(this.excelOlarakAktarToolStripMenuItem_Click);
            // 
            // TaleplerDetayliRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 677);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TaleplerDetayliRapor";
            this.Text = "Talepler Detaylı Rapor";
            this.Load += new System.EventHandler(this.TaleplerDetayliRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bekleyenlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamamlananlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iptalEdilenlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelOlarakAktarToolStripMenuItem;
    }
}