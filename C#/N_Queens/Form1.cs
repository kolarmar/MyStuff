namespace N_Queens
{
    using NPR = N_Queens.Properties.Resources;

    public enum QueenSymbol { Circle, Cross, Rectangle };
    public partial class MainForm : Form
    {
        private int queens;
        private Solver solver;
        private bool found;
        private int[] solution;
        public MainForm()
        {
            InitializeComponent();
        }

        private void UseResources()
        {
            GameMenu.Text = NPR.Game;
            NewGameMenu.Text = NPR.New_game;
        }

        private void StartSolver()
        {
            queens = (int)NumberPicker.Value;
            solver = new Solver(queens);
        }

        private void SetTitle(int queens, int numOfSolutions)
        {
            Text = $"Problem of {queens} queens" +
                $" {numOfSolutions} solutions shown";
        }


        private void AboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("N Queens Solver\n" +
                            "Developed by Kolish Solutions s.r.o. 2023", "About");
        }

        private void QuitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", "Question",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void NewGameMenu_Click(object sender, EventArgs e)
        {
            StartSolver();
            SetTitle(queens, solver.NumberOfSolutions);
            (NextTurnMenu.Enabled, NextButton.Enabled, found)
                = (true, true, false);
            MainPanel.Invalidate();
        }

        private void NextTurnMenu_Click(object sender, EventArgs e)
        {
            found = solver.FindNextSolution(out solution);
            if (!found)
            {
                MessageBox.Show("There are no more solutions.", "That's it",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                (NextTurnMenu.Enabled, NextButton.Enabled) = (false, false);
            }
            MainPanel.Invalidate();
            SetTitle(queens, solver.NumberOfSolutions);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            NextTurnMenu_Click(sender, e);
        }

        private void AllSolutionsMenu_Click(object sender, EventArgs e)
        {
            DisableForm();
            int queensTemp = (int)NumberPicker.Value;
            Solver solverTemp = new Solver(queensTemp);
            MessageBox.Show($"There are {solverTemp.Solutions.Count()} solutions" +
                $" in total", "All solutions",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            EnableForm();
        }

        private void DisableForm()
        {
            (NextButton.Enabled, NextTurnMenu.Enabled,
             NumberPicker.Enabled, Menu.Enabled)
                = (false, false, false, false);
        }

        private void EnableForm()
        {
            (NumberPicker.Enabled, Menu.Enabled) = (true, true);

            if (solver != null)
            {
                (NextButton.Enabled, NextTurnMenu.Enabled) = (true, true);
            }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (found)
            {
                Pen pen = new Pen(Color.Black);
                pen.Width = 1;

                float deltaX = MainPanel.Width / queens;
                float deltaY = MainPanel.Height / queens;

                DrawChessboard(graphics, pen, deltaX, deltaY);
                DrawQueens(graphics, pen, deltaX, deltaY);

            }
            else
            {
                graphics.Clear(Color.White);
            }
        }

        private void DrawChessboard(Graphics graphics, Pen pen,
                                    float deltaX, float deltaY)
        {
            for (int i = 1; i < queens; i++) 
            {
                graphics.DrawLine(pen, i * deltaX, 0,
                    i * deltaX, MainPanel.Height);
                graphics.DrawLine(pen, 0, i * deltaY,
                    MainPanel.Width, i * deltaY);
            }
        }

        private void DrawQueens(Graphics graphics, Pen pen,
                                float deltaX, float deltaY)
        {
            pen.Color = Color.Brown;
            pen.Width = 6;
            for (int i = 0; i < queens; i++)
            {
                graphics.DrawEllipse(pen, i * deltaX + deltaX / 6,
                                solution[i] * deltaY + deltaY / 6,
                                2 * deltaX / 3, 2 * deltaY / 3);
            }
        }

        private void MainPanel_Resize(object sender, EventArgs e)
        {
            MainPanel.Invalidate();
        }
    }
}