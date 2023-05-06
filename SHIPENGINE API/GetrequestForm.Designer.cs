namespace SHIPENGINE_API
{
    partial class getRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getRequestForm));
            this.urlTexbox = new System.Windows.Forms.TextBox();
            this.requestbutton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.engineApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ssApiSecretTextBox = new System.Windows.Forms.TextBox();
            this.ssAPIkeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addSeUrlButton = new System.Windows.Forms.Button();
            this.addSsUrlButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.shipengineResponseBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlTexbox
            // 
            this.urlTexbox.Location = new System.Drawing.Point(3, 29);
            this.urlTexbox.Name = "urlTexbox";
            this.urlTexbox.Size = new System.Drawing.Size(371, 20);
            this.urlTexbox.TabIndex = 0;
            // 
            // requestbutton1
            // 
            this.requestbutton1.Location = new System.Drawing.Point(3, 608);
            this.requestbutton1.Name = "requestbutton1";
            this.requestbutton1.Size = new System.Drawing.Size(371, 45);
            this.requestbutton1.TabIndex = 1;
            this.requestbutton1.Text = "REQUEST";
            this.requestbutton1.UseVisualStyleBackColor = true;
            this.requestbutton1.Click += new System.EventHandler(this.requestbutton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 558);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter your API Key";
            // 
            // engineApiKeyTextBox
            // 
            this.engineApiKeyTextBox.Location = new System.Drawing.Point(3, 574);
            this.engineApiKeyTextBox.Name = "engineApiKeyTextBox";
            this.engineApiKeyTextBox.Size = new System.Drawing.Size(371, 20);
            this.engineApiKeyTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter your api credentials";
            // 
            // ssApiSecretTextBox
            // 
            this.ssApiSecretTextBox.Location = new System.Drawing.Point(76, 487);
            this.ssApiSecretTextBox.Name = "ssApiSecretTextBox";
            this.ssApiSecretTextBox.Size = new System.Drawing.Size(298, 20);
            this.ssApiSecretTextBox.TabIndex = 6;
            // 
            // ssAPIkeyTextBox
            // 
            this.ssAPIkeyTextBox.Location = new System.Drawing.Point(76, 461);
            this.ssAPIkeyTextBox.Name = "ssAPIkeyTextBox";
            this.ssAPIkeyTextBox.Size = new System.Drawing.Size(298, 20);
            this.ssAPIkeyTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "API Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "API Secret:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 537);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "SHIPENGINE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "SHIPSTATION";
            // 
            // addSeUrlButton
            // 
            this.addSeUrlButton.Location = new System.Drawing.Point(3, 55);
            this.addSeUrlButton.Name = "addSeUrlButton";
            this.addSeUrlButton.Size = new System.Drawing.Size(98, 23);
            this.addSeUrlButton.TabIndex = 12;
            this.addSeUrlButton.Text = "Engine Request";
            this.addSeUrlButton.UseVisualStyleBackColor = true;
            this.addSeUrlButton.Click += new System.EventHandler(this.addSeUrlButton_Click);
            // 
            // addSsUrlButton
            // 
            this.addSsUrlButton.Location = new System.Drawing.Point(276, 55);
            this.addSsUrlButton.Name = "addSsUrlButton";
            this.addSsUrlButton.Size = new System.Drawing.Size(98, 23);
            this.addSsUrlButton.TabIndex = 13;
            this.addSsUrlButton.Text = "Station Request";
            this.addSsUrlButton.UseVisualStyleBackColor = true;
            this.addSsUrlButton.Click += new System.EventHandler(this.addSsUrlButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "ENTER YOUR ENDPOINT";
            // 
            // shipengineResponseBox
            // 
            this.shipengineResponseBox.Location = new System.Drawing.Point(380, 8);
            this.shipengineResponseBox.Name = "shipengineResponseBox";
            this.shipengineResponseBox.Size = new System.Drawing.Size(525, 645);
            this.shipengineResponseBox.TabIndex = 16;
            this.shipengineResponseBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "label form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // getRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 657);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shipengineResponseBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addSsUrlButton);
            this.Controls.Add(this.addSeUrlButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ssAPIkeyTextBox);
            this.Controls.Add(this.ssApiSecretTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.engineApiKeyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.requestbutton1);
            this.Controls.Add(this.urlTexbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "getRequestForm";
            this.Text = "GET REQUEST";
            this.Load += new System.EventHandler(this.requestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTexbox;
        private System.Windows.Forms.Button requestbutton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox engineApiKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ssApiSecretTextBox;
        private System.Windows.Forms.TextBox ssAPIkeyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addSeUrlButton;
        private System.Windows.Forms.Button addSsUrlButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox shipengineResponseBox;
        private System.Windows.Forms.Button button1;
    }
}

