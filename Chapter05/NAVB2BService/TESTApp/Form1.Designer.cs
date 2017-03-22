namespace TESTApp
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
            this.btnInsertOrder = new System.Windows.Forms.Button();
            this.btnB2B = new System.Windows.Forms.Button();
            this.btnGetPrice = new System.Windows.Forms.Button();
            this.btnGetPriceNAV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInsertOrder
            // 
            this.btnInsertOrder.Location = new System.Drawing.Point(16, 55);
            this.btnInsertOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsertOrder.Name = "btnInsertOrder";
            this.btnInsertOrder.Size = new System.Drawing.Size(273, 28);
            this.btnInsertOrder.TabIndex = 0;
            this.btnInsertOrder.Text = "TEST Insert Order";
            this.btnInsertOrder.UseVisualStyleBackColor = true;
            this.btnInsertOrder.Click += new System.EventHandler(this.btnInsertOrder_Click);
            // 
            // btnB2B
            // 
            this.btnB2B.Location = new System.Drawing.Point(16, 91);
            this.btnB2B.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnB2B.Name = "btnB2B";
            this.btnB2B.Size = new System.Drawing.Size(273, 28);
            this.btnB2B.TabIndex = 1;
            this.btnB2B.Text = "TEST B2B Set PWD";
            this.btnB2B.UseVisualStyleBackColor = true;
            this.btnB2B.Click += new System.EventHandler(this.btnB2B_Click);
            // 
            // btnGetPrice
            // 
            this.btnGetPrice.Location = new System.Drawing.Point(16, 127);
            this.btnGetPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetPrice.Name = "btnGetPrice";
            this.btnGetPrice.Size = new System.Drawing.Size(273, 28);
            this.btnGetPrice.TabIndex = 2;
            this.btnGetPrice.Text = "TEST Lettura Prezzo";
            this.btnGetPrice.UseVisualStyleBackColor = true;
            this.btnGetPrice.Click += new System.EventHandler(this.btnGetPrice_Click);
            // 
            // btnGetPriceNAV
            // 
            this.btnGetPriceNAV.Location = new System.Drawing.Point(16, 185);
            this.btnGetPriceNAV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetPriceNAV.Name = "btnGetPriceNAV";
            this.btnGetPriceNAV.Size = new System.Drawing.Size(321, 28);
            this.btnGetPriceNAV.TabIndex = 3;
            this.btnGetPriceNAV.Text = "TEST Lettura Prezzo (call diretta WS NAV)";
            this.btnGetPriceNAV.UseVisualStyleBackColor = true;
            this.btnGetPriceNAV.Click += new System.EventHandler(this.btnGetPriceNAV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.btnGetPriceNAV);
            this.Controls.Add(this.btnGetPrice);
            this.Controls.Add(this.btnB2B);
            this.Controls.Add(this.btnInsertOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInsertOrder;
        private System.Windows.Forms.Button btnB2B;
        private System.Windows.Forms.Button btnGetPrice;
        private System.Windows.Forms.Button btnGetPriceNAV;
    }
}

