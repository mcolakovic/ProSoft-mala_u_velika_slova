
namespace KorisnickiInterfejs
{
    partial class FrmPoruke
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
            this.btnSend = new System.Windows.Forms.Button();
            this.rbPoruke = new System.Windows.Forms.RichTextBox();
            this.txtPoruka = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(417, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rbPoruke
            // 
            this.rbPoruke.Location = new System.Drawing.Point(12, 43);
            this.rbPoruke.Name = "rbPoruke";
            this.rbPoruke.Size = new System.Drawing.Size(501, 217);
            this.rbPoruke.TabIndex = 4;
            this.rbPoruke.Text = "";
            // 
            // txtPoruka
            // 
            this.txtPoruka.Location = new System.Drawing.Point(12, 15);
            this.txtPoruka.Name = "txtPoruka";
            this.txtPoruka.Size = new System.Drawing.Size(399, 22);
            this.txtPoruka.TabIndex = 3;
            // 
            // FrmPoruke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 272);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rbPoruke);
            this.Controls.Add(this.txtPoruka);
            this.Name = "FrmPoruke";
            this.Text = "FrmPoruke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rbPoruke;
        private System.Windows.Forms.TextBox txtPoruka;
    }
}