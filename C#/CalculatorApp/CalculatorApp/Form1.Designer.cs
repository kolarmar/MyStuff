namespace CalculatorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.equalsButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.numberSevenButton = new System.Windows.Forms.Button();
            this.numberEightButton = new System.Windows.Forms.Button();
            this.numberNineButton = new System.Windows.Forms.Button();
            this.numberFourButton = new System.Windows.Forms.Button();
            this.numberFiveButton = new System.Windows.Forms.Button();
            this.numberSixButton = new System.Windows.Forms.Button();
            this.numberOneButton = new System.Windows.Forms.Button();
            this.numberTwoButton = new System.Windows.Forms.Button();
            this.numberThreeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.numberZeroButton = new System.Windows.Forms.Button();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.ansButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // equalsButton
            // 
            this.equalsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.equalsButton.Location = new System.Drawing.Point(90, 390);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(154, 67);
            this.equalsButton.TabIndex = 11;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = false;
            this.equalsButton.Click += new System.EventHandler(this.equalsButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(250, 390);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(74, 67);
            this.plusButton.TabIndex = 12;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(250, 317);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(74, 67);
            this.minusButton.TabIndex = 13;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(250, 244);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(74, 67);
            this.multiplyButton.TabIndex = 14;
            this.multiplyButton.Text = "×";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // divideButton
            // 
            this.divideButton.Location = new System.Drawing.Point(250, 171);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(74, 67);
            this.divideButton.TabIndex = 15;
            this.divideButton.Text = "÷";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new System.EventHandler(this.divideButton_Click);
            // 
            // numberSevenButton
            // 
            this.numberSevenButton.Location = new System.Drawing.Point(10, 171);
            this.numberSevenButton.Name = "numberSevenButton";
            this.numberSevenButton.Size = new System.Drawing.Size(74, 67);
            this.numberSevenButton.TabIndex = 25;
            this.numberSevenButton.Text = "7";
            this.numberSevenButton.UseVisualStyleBackColor = true;
            this.numberSevenButton.Click += new System.EventHandler(this.numberSevenButton_Click);
            // 
            // numberEightButton
            // 
            this.numberEightButton.Location = new System.Drawing.Point(90, 171);
            this.numberEightButton.Name = "numberEightButton";
            this.numberEightButton.Size = new System.Drawing.Size(74, 67);
            this.numberEightButton.TabIndex = 26;
            this.numberEightButton.Text = "8";
            this.numberEightButton.UseVisualStyleBackColor = true;
            this.numberEightButton.Click += new System.EventHandler(this.numberEightButton_Click);
            // 
            // numberNineButton
            // 
            this.numberNineButton.Location = new System.Drawing.Point(170, 171);
            this.numberNineButton.Name = "numberNineButton";
            this.numberNineButton.Size = new System.Drawing.Size(74, 67);
            this.numberNineButton.TabIndex = 27;
            this.numberNineButton.Text = "9";
            this.numberNineButton.UseVisualStyleBackColor = true;
            this.numberNineButton.Click += new System.EventHandler(this.numberNineButton_Click);
            // 
            // numberFourButton
            // 
            this.numberFourButton.Location = new System.Drawing.Point(10, 244);
            this.numberFourButton.Name = "numberFourButton";
            this.numberFourButton.Size = new System.Drawing.Size(74, 67);
            this.numberFourButton.TabIndex = 22;
            this.numberFourButton.Text = "4";
            this.numberFourButton.UseVisualStyleBackColor = true;
            this.numberFourButton.Click += new System.EventHandler(this.numberFourButton_Click);
            // 
            // numberFiveButton
            // 
            this.numberFiveButton.Location = new System.Drawing.Point(90, 244);
            this.numberFiveButton.Name = "numberFiveButton";
            this.numberFiveButton.Size = new System.Drawing.Size(74, 67);
            this.numberFiveButton.TabIndex = 23;
            this.numberFiveButton.Text = "5";
            this.numberFiveButton.UseVisualStyleBackColor = true;
            this.numberFiveButton.Click += new System.EventHandler(this.numberFiveButton_Click);
            // 
            // numberSixButton
            // 
            this.numberSixButton.Location = new System.Drawing.Point(170, 244);
            this.numberSixButton.Name = "numberSixButton";
            this.numberSixButton.Size = new System.Drawing.Size(74, 67);
            this.numberSixButton.TabIndex = 24;
            this.numberSixButton.Text = "6";
            this.numberSixButton.UseVisualStyleBackColor = true;
            this.numberSixButton.Click += new System.EventHandler(this.numberSixButton_Click);
            // 
            // numberOneButton
            // 
            this.numberOneButton.Location = new System.Drawing.Point(10, 317);
            this.numberOneButton.Name = "numberOneButton";
            this.numberOneButton.Size = new System.Drawing.Size(74, 67);
            this.numberOneButton.TabIndex = 19;
            this.numberOneButton.Text = "1";
            this.numberOneButton.UseVisualStyleBackColor = true;
            this.numberOneButton.Click += new System.EventHandler(this.numberOneButton_Click);
            // 
            // numberTwoButton
            // 
            this.numberTwoButton.Location = new System.Drawing.Point(90, 317);
            this.numberTwoButton.Name = "numberTwoButton";
            this.numberTwoButton.Size = new System.Drawing.Size(74, 67);
            this.numberTwoButton.TabIndex = 20;
            this.numberTwoButton.Text = "2";
            this.numberTwoButton.UseVisualStyleBackColor = true;
            this.numberTwoButton.Click += new System.EventHandler(this.numberTwoButton_Click);
            // 
            // numberThreeButton
            // 
            this.numberThreeButton.Location = new System.Drawing.Point(170, 317);
            this.numberThreeButton.Name = "numberThreeButton";
            this.numberThreeButton.Size = new System.Drawing.Size(74, 67);
            this.numberThreeButton.TabIndex = 21;
            this.numberThreeButton.Text = "3";
            this.numberThreeButton.UseVisualStyleBackColor = true;
            this.numberThreeButton.Click += new System.EventHandler(this.numberThreeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(170, 98);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(153, 67);
            this.clearButton.TabIndex = 28;
            this.clearButton.Text = "AC";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // numberZeroButton
            // 
            this.numberZeroButton.Location = new System.Drawing.Point(10, 390);
            this.numberZeroButton.Name = "numberZeroButton";
            this.numberZeroButton.Size = new System.Drawing.Size(74, 67);
            this.numberZeroButton.TabIndex = 29;
            this.numberZeroButton.Text = "0";
            this.numberZeroButton.UseVisualStyleBackColor = true;
            this.numberZeroButton.Click += new System.EventHandler(this.numberZeroButton_Click);
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.AutoSize = true;
            this.errorMessageLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.errorMessageLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.errorMessageLabel.Location = new System.Drawing.Point(12, 9);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(0, 20);
            this.errorMessageLabel.TabIndex = 30;
            // 
            // mainTextBox
            // 
            this.mainTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainTextBox.Location = new System.Drawing.Point(10, 29);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(311, 40);
            this.mainTextBox.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(90, 98);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(74, 67);
            this.deleteButton.TabIndex = 32;
            this.deleteButton.Text = "del";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ansButton
            // 
            this.ansButton.Location = new System.Drawing.Point(12, 98);
            this.ansButton.Name = "ansButton";
            this.ansButton.Size = new System.Drawing.Size(74, 67);
            this.ansButton.TabIndex = 33;
            this.ansButton.Text = "Ans";
            this.ansButton.UseVisualStyleBackColor = true;
            this.ansButton.Click += new System.EventHandler(this.ansButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 465);
            this.Controls.Add(this.ansButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.errorMessageLabel);
            this.Controls.Add(this.numberZeroButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.numberSevenButton);
            this.Controls.Add(this.numberEightButton);
            this.Controls.Add(this.numberNineButton);
            this.Controls.Add(this.numberFourButton);
            this.Controls.Add(this.numberFiveButton);
            this.Controls.Add(this.numberSixButton);
            this.Controls.Add(this.numberOneButton);
            this.Controls.Add(this.numberTwoButton);
            this.Controls.Add(this.numberThreeButton);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.equalsButton);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(350, 512);
            this.MinimumSize = new System.Drawing.Size(350, 512);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button equalsButton;
        private Button plusButton;
        private Button minusButton;
        private Button multiplyButton;
        private Button divideButton;
        private Button numberSevenButton;
        private Button numberEightButton;
        private Button numberNineButton;
        private Button numberFourButton;
        private Button numberFiveButton;
        private Button numberSixButton;
        private Button numberOneButton;
        private Button numberTwoButton;
        private Button numberThreeButton;
        private Button clearButton;
        private Button numberZeroButton;
        private Label errorMessageLabel;
        private TextBox mainTextBox;
        private Button deleteButton;
        private Button ansButton;
    }
}