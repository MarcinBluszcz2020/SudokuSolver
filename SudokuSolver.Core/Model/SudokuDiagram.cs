namespace SudokuSolver.Core.Model
{
	public class SudokuDiagram : SudokuCellsContainer
	{
		public SudokuDiagram() : base(9)
		{
		}

		public override bool IsValid()
		{
			for (int i = 0; i < 9; i++)
			{
				var rowCells = GetRowCells(i);
				var columnCells = GetColumnCells(i);

				var valid = CheckIfNumbersNotRepeating(rowCells) && CheckIfNumbersNotRepeating(columnCells);

				if (!valid)
				{
					return false;
				}
			}

			for (var row = 0; row < 3; row++)
			{
				for (var column = 0; column < 3; column++)
				{
					var diagramBox = GetDiagramBox(row, column);

					if (!diagramBox.IsValid())
					{
						return false;
					}
				}
			}

			return true;
		}

		public SudokuDiagramBox GetDiagramBox(int row, int column)
		{
			if (row > 2 || column > 2)
			{
				throw new ArgumentException("Invalid paramenters");
			}

			var diagramBox = new SudokuDiagramBox();

			var diagramRowStartIndex = row * 3;
			var diagramColumnCellsToSkip = column * 3;

			for (int boxRowIndex = 0; boxRowIndex < 3; boxRowIndex++)
			{
				var diagramRowIndex = diagramRowStartIndex + boxRowIndex;

				var diagramRowCells = GetRowCells(diagramRowIndex);

				var boxRowCells = diagramRowCells.Skip(diagramColumnCellsToSkip).Take(3).ToArray();

				for (int boxColumnIndex = 0; boxColumnIndex < 3; boxColumnIndex++)
				{
					diagramBox.SetCellValue(boxRowIndex, boxColumnIndex, boxRowCells[boxColumnIndex]);
				}
			}

			return diagramBox;
		}
	}
}
