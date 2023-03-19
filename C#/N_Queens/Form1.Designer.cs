namespace N_Queens
{
    partial class MainForm
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.GameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NextTurnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AllSolutionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NextButton = new System.Windows.Forms.Button();
            this.NumberPicker = new System.Windows.Forms.NumericUpDown();
            this.QueensNumberLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenu,
            this.AboutMenu});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(616, 28);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // GameMenu
            // 
            this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameMenu,
            this.NextTurnMenu,
            this.AllSolutionsMenu,
            this.toolStripMenuItem1,
            this.QuitMenu});
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(62, 24);
            this.GameMenu.Text = "Game";
            // 
            // NewGameMenu
            // 
            this.NewGameMenu.Name = "NewGameMenu";
            this.NewGameMenu.Size = new System.Drawing.Size(228, 26);
            this.NewGameMenu.Text = "New game";
            this.NewGameMenu.Click += new System.EventHandler(this.NewGameMenu_Click);
            // 
            // NextTurnMenu
            // 
            this.NextTurnMenu.Enabled = false;
            this.NextTurnMenu.Name = "NextTurnMenu";
            this.NextTurnMenu.Size = new System.Drawing.Size(228, 26);
            this.NextTurnMenu.Text = "Next turn";
            this.NextTurnMenu.Click += new System.EventHandler(this.NextTurnMenu_Click);
            // 
            // AllSolutionsMenu
            // 
            this.AllSolutionsMenu.Name = "AllSolutionsMenu";
            this.AllSolutionsMenu.Size = new System.Drawing.Size(228, 26);
            this.AllSolutionsMenu.Text = "All solutions number";
            this.AllSolutionsMenu.Click += new System.EventHandler(this.AllSolutionsMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // QuitMenu
            // 
            this.QuitMenu.Name = "QuitMenu";
            this.QuitMenu.Size = new System.Drawing.Size(228, 26);
            this.QuitMenu.Text = "Quit";
            this.QuitMenu.Click += new System.EventHandler(this.QuitMenu_Click);
            // 
            // AboutMenu
            // 
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(64, 24);
            this.AboutMenu.Text = "About";
            this.AboutMenu.Click += new System.EventHandler(this.AboutMenu_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(419, 89);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(186, 31);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next Solution";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // NumberPicker
            // 
            this.NumberPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberPicker.Location = new System.Drawing.Point(559, 42);
            this.NumberPicker.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.NumberPicker.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumberPicker.Name = "NumberPicker";
            this.NumberPicker.Size = new System.Drawing.Size(46, 27);
            this.NumberPicker.TabIndex = 2;
            this.NumberPicker.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // QueensNumberLabel
            // 
            this.QueensNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QueensNumberLabel.AutoSize = true;
            this.QueensNumberLabel.Location = new System.Drawing.Point(419, 44);
            this.QueensNumberLabel.Name = "QueensNumberLabel";
            this.QueensNumberLabel.Size = new System.Drawing.Size(116, 20);
            this.QueensNumberLabel.TabIndex = 3;
            this.QueensNumberLabel.Text = "Queens number:";
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.Location = new System.Drawing.Point(12, 42);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(392, 392);
            this.MainPanel.TabIndex = 4;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 445);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.QueensNumberLabel);
            this.Controls.Add(this.NumberPicker);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(634, 492);
            this.Name = "MainForm";
            this.Text = "N Queens Solver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip Menu;
        private ToolStripMenuItem GameMenu;
        private ToolStripMenuItem NewGameMenu;
        private ToolStripMenuItem NextTurnMenu;
        private ToolStripMenuItem AllSolutionsMenu;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem QuitMenu;
        private ToolStripMenuItem AboutMenu;
        private Button NextButton;
        private NumericUpDown NumberPicker;
        private Label QueensNumberLabel;
        private Panel MainPanel;
    }
}