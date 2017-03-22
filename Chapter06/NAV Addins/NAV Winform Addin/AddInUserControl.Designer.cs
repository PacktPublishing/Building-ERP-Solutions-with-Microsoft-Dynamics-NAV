namespace NAV_Winform_Addin
{
    partial class AddInUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ODPListBox = new System.Windows.Forms.ListBox();
            this.txtODPBarcode = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ODPListBox
            // 
            this.ODPListBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ODPListBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ODPListBox.FormattingEnabled = true;
            this.ODPListBox.ItemHeight = 23;
            this.ODPListBox.Location = new System.Drawing.Point(0, 0);
            this.ODPListBox.Margin = new System.Windows.Forms.Padding(4);
            this.ODPListBox.Name = "ODPListBox";
            this.ODPListBox.Size = new System.Drawing.Size(422, 349);
            this.ODPListBox.TabIndex = 1;
            // 
            // txtODPBarcode
            // 
            this.txtODPBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtODPBarcode.Location = new System.Drawing.Point(430, 79);
            this.txtODPBarcode.Name = "txtODPBarcode";
            this.txtODPBarcode.Size = new System.Drawing.Size(233, 56);
            this.txtODPBarcode.TabIndex = 2;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(430, 154);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(233, 54);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // AddInUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtODPBarcode);
            this.Controls.Add(this.ODPListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddInUserControl";
            this.Size = new System.Drawing.Size(685, 366);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ODPListBox;
        private System.Windows.Forms.TextBox txtODPBarcode;
        private System.Windows.Forms.Button btnRegister;
    }
}
