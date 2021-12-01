
namespace Zakirova
{
    partial class FormTruckParking
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
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.button_parkingMod = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Take = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trWheel = new System.Windows.Forms.ComboBox();
            this.ornwheels = new System.Windows.Forms.ComboBox();
            this.groupBoxCheck = new System.Windows.Forms.GroupBox();
            this.buttonPlaceCheck = new System.Windows.Forms.Button();
            this.maskedTextBoxPlaces = new System.Windows.Forms.MaskedTextBox();
            this.labelplace = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(666, 450);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // button_parkingMod
            // 
            this.button_parkingMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_parkingMod.Location = new System.Drawing.Point(666, 32);
            this.button_parkingMod.Name = "button_parkingMod";
            this.button_parkingMod.Size = new System.Drawing.Size(122, 62);
            this.button_parkingMod.TabIndex = 2;
            this.button_parkingMod.Text = "Припарковать самосвал";
            this.button_parkingMod.UseVisualStyleBackColor = true;
            this.button_parkingMod.Click += new System.EventHandler(this.button_parkingMod_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_Take);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(666, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать самосвал";
            // 
            // button_Take
            // 
            this.button_Take.Location = new System.Drawing.Point(26, 49);
            this.button_Take.Name = "button_Take";
            this.button_Take.Size = new System.Drawing.Size(76, 25);
            this.button_Take.TabIndex = 2;
            this.button_Take.Text = "Забрать";
            this.button_Take.UseVisualStyleBackColor = true;
            this.button_Take.Click += new System.EventHandler(this.button_Take_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(53, 23);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(68, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место:";
            // 
            // trWheel
            // 
            this.trWheel.FormattingEnabled = true;
            this.trWheel.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.trWheel.Location = new System.Drawing.Point(666, 212);
            this.trWheel.Name = "trWheel";
            this.trWheel.Size = new System.Drawing.Size(121, 21);
            this.trWheel.TabIndex = 4;
            this.trWheel.Text = "Сколько колес?";
            // 
            // ornwheels
            // 
            this.ornwheels.FormattingEnabled = true;
            this.ornwheels.Items.AddRange(new object[] {
            "орнамент 1",
            "орнамент 2",
            "орнамент 3"});
            this.ornwheels.Location = new System.Drawing.Point(666, 239);
            this.ornwheels.Name = "ornwheels";
            this.ornwheels.Size = new System.Drawing.Size(121, 21);
            this.ornwheels.TabIndex = 5;
            this.ornwheels.Text = "Какой орнамент?";
            // 
            // groupBoxCheck
            // 
            this.groupBoxCheck.Controls.Add(this.buttonPlaceCheck);
            this.groupBoxCheck.Controls.Add(this.maskedTextBoxPlaces);
            this.groupBoxCheck.Controls.Add(this.labelplace);
            this.groupBoxCheck.Location = new System.Drawing.Point(668, 302);
            this.groupBoxCheck.Name = "groupBoxCheck";
            this.groupBoxCheck.Size = new System.Drawing.Size(118, 90);
            this.groupBoxCheck.TabIndex = 6;
            this.groupBoxCheck.TabStop = false;
            this.groupBoxCheck.Text = "Проверка мест";
            // 
            // buttonPlaceCheck
            // 
            this.buttonPlaceCheck.Location = new System.Drawing.Point(24, 56);
            this.buttonPlaceCheck.Name = "buttonPlaceCheck";
            this.buttonPlaceCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaceCheck.TabIndex = 2;
            this.buttonPlaceCheck.Text = "Проверить";
            this.buttonPlaceCheck.UseVisualStyleBackColor = true;
            this.buttonPlaceCheck.Click += new System.EventHandler(this.buttonPlaceCheck_Click);
            // 
            // maskedTextBoxPlaces
            // 
            this.maskedTextBoxPlaces.Location = new System.Drawing.Point(56, 26);
            this.maskedTextBoxPlaces.Name = "maskedTextBoxPlaces";
            this.maskedTextBoxPlaces.Size = new System.Drawing.Size(43, 20);
            this.maskedTextBoxPlaces.TabIndex = 1;
            // 
            // labelplace
            // 
            this.labelplace.AutoSize = true;
            this.labelplace.Location = new System.Drawing.Point(6, 29);
            this.labelplace.Name = "labelplace";
            this.labelplace.Size = new System.Drawing.Size(42, 13);
            this.labelplace.TabIndex = 0;
            this.labelplace.Text = "Место:";
            // 
            // FormTruckParking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxCheck);
            this.Controls.Add(this.ornwheels);
            this.Controls.Add(this.trWheel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_parkingMod);
            this.Controls.Add(this.pictureBoxParking);
            this.Name = "FormTruckParking";
            this.Text = "FormTruckParking";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxCheck.ResumeLayout(false);
            this.groupBoxCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button button_parkingMod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Take;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox trWheel;
        private System.Windows.Forms.ComboBox ornwheels;
        private System.Windows.Forms.GroupBox groupBoxCheck;
        private System.Windows.Forms.Button buttonPlaceCheck;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlaces;
        private System.Windows.Forms.Label labelplace;
    }
}