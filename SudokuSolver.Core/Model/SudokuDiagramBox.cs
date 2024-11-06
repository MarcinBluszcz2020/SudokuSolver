namespace SudokuSolver.Core.Model
{
	public class SudokuDiagramBox : SudokuCellsContainer
	{
		public SudokuDiagramBox() : base(3)
		{
		}

		public override bool IsValid()
		{
			var cells = new List<int?>();

			for (int i = 0; i < 3; i++)
			{
				var rowCells = GetRowCells(i);

				cells.AddRange(rowCells);
			}

			var cellsWithValues = cells.Where(x => x.HasValue).Select(x => x!.Value).ToArray();

			return cellsWithValues.Length.Equals(cellsWithValues.Distinct().Count());
		}
	}
}
