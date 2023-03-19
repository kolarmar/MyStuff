namespace N_Queens
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Utility methods
        private void StartSolver()
        {
            int queens = (int)NumberPicker.Value;
            Solver solver = new Solver(queens);
        }

        private void SetTitle(int queens, int numOfSolutions)
        {
            Text = $"Problem of {queens} has {numOfSolutions} solutions.";
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
    }
}