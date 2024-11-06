using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core.Model
{
	public class SudokuDiagram : SudokuCellsContainer
	{
		public SudokuDiagram() : base(9)
		{
		}

		public override bool IsValid()
		{
			throw new NotImplementedException();
		}

	}
}
