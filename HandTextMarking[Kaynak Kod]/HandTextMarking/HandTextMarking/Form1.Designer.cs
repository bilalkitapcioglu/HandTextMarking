namespace HandTextMarking
{
    partial class FormAna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAna));
            this.textBox = new System.Windows.Forms.TextBox();
            this.contextMenuStripIsaretle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.isaretleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tümünüİsaretleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisaAktar = new System.Windows.Forms.Button();
            this.contextMenuStripIsaretle.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.ContextMenuStrip = this.contextMenuStripIsaretle;
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // contextMenuStripIsaretle
            // 
            this.contextMenuStripIsaretle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isaretleToolStripMenuItem,
            this.tümünüİsaretleToolStripMenuItem});
            this.contextMenuStripIsaretle.Name = "contextMenuStripIsaretle";
            resources.ApplyResources(this.contextMenuStripIsaretle, "contextMenuStripIsaretle");
            // 
            // isaretleToolStripMenuItem
            // 
            this.isaretleToolStripMenuItem.Name = "isaretleToolStripMenuItem";
            resources.ApplyResources(this.isaretleToolStripMenuItem, "isaretleToolStripMenuItem");
            this.isaretleToolStripMenuItem.Click += new System.EventHandler(this.isaretleToolStripMenuItem_Click);
            // 
            // tümünüİsaretleToolStripMenuItem
            // 
            this.tümünüİsaretleToolStripMenuItem.Name = "tümünüİsaretleToolStripMenuItem";
            resources.ApplyResources(this.tümünüİsaretleToolStripMenuItem, "tümünüİsaretleToolStripMenuItem");
            this.tümünüİsaretleToolStripMenuItem.Click += new System.EventHandler(this.tümünüİsaretleToolStripMenuItem_Click);
            // 
            // btnDisaAktar
            // 
            resources.ApplyResources(this.btnDisaAktar, "btnDisaAktar");
            this.btnDisaAktar.Name = "btnDisaAktar";
            this.btnDisaAktar.UseVisualStyleBackColor = true;
            this.btnDisaAktar.Click += new System.EventHandler(this.btnDisaAktar_Click);
            // 
            // FormAna
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDisaAktar);
            this.Controls.Add(this.textBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormAna";
            this.Resize += new System.EventHandler(this.FormAna_Resize);
            this.contextMenuStripIsaretle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnDisaAktar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIsaretle;
        private System.Windows.Forms.ToolStripMenuItem isaretleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tümünüİsaretleToolStripMenuItem;
    }
}

