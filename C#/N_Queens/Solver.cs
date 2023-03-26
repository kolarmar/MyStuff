using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Queens
{
    internal class Solver
    {
        private readonly int N;
        private readonly int[] solution;
        public int NumberOfSolutions { get; private set; } = 0;

        public IEnumerable<int[]> Solutions
        {
            get
            {
                while (FindNextSolution(out int[] p))
                {
                    yield return p;
                }
            }
        }

        public Solver(int n)
        {
            N = n;
            solution = new int[n];
            for (int i = 0; i < n; i++)
            {
                solution[i] = -1;
            }
        }

        private bool IsSafe(int row, int col)
        {
            Application.DoEvents();
            if (col == 0) return true;

            var (returnValue, j) = (true, 0);
            while (returnValue && (j < col))
            {
                returnValue = (solution[j] != row) &&
                    (solution[col - j - 1] != row - j - 1) &&
                    (solution[col - j - 1] != row + j + 1);
                if (!returnValue) return false;
                j++;
            }
            return true;
        }

        private int FindNextSafeRow(int row, int col)
        {
            while (++row < N)
            {
                if (IsSafe(row, col)) break;
            }
            return row;
        }

        private int[] SolveFromCol(int col)
        {
            int row;
            while (col > -1)
            {
                row = FindNextSafeRow(solution[col], col);
                if (row < N)
                {
                    solution[col++] = row;
                    if (col == N) return solution;
                }
                else solution[col--] = -1;
            }
            return null;
        }

        public bool FindNextSolution(out int[] returnValue)
        {
            returnValue = NumberOfSolutions == 0 ?
                      SolveFromCol(0) : SolveFromCol(N - 1);
            if (returnValue != null)
            {
                NumberOfSolutions++;
            }
            return returnValue != null;

        }

        public void FindAllSolutions()
        {
            while (FindNextSolution(out int[] p)) ;
        }

    }
}
