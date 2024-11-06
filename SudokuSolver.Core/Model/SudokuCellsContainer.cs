using System.Text;

namespace SudokuSolver.Core.Model
{
	public abstract class SudokuCellsContainer
	{
		private readonly int _containerSize;

		public int RowCount => _containerSize;
		public int ColumnCount => _containerSize;

		//row, column
		private int?[][] _cells;

		protected SudokuCellsContainer(int containerSize)
		{
			_containerSize = containerSize;
			_cells = new int?[containerSize][];

			for (int i = 0; i < _containerSize; i++)
			{
				_cells[i] = new int?[containerSize];
			}
		}

		public void SetRowValues(int rowIndex,int?[] rowValues) 
		{
			if (rowValues.Length != _containerSize) 
			{
				throw new ArgumentException("Invalid values");
			}

			rowValues.CopyTo(_cells[rowIndex], 0);
		}

		public void SetCellValue(int rowIndex, int columnIndex, int? value) 
		{
			_cells[rowIndex][columnIndex] = value;
		}

		protected static bool CheckIfNumbersNotRepeating(IEnumerable<int?> cells)
		{
			var cellsWithValues = cells.Where(x => x.HasValue).Select(x => x!.Value).ToArray();

			return cellsWithValues.Length.Equals(cellsWithValues.Distinct().Count());
		}

		public int?[] GetColumnCells(int columnIndex)
		{
			return _cells.Select(row => row[columnIndex]).ToArray();
		}

		public int?[] GetRowCells(int rowIndex)
		{
			return _cells[rowIndex];
		}

		public abstract bool IsValid();

		public bool HasEmptyFields()
		{
			var result = false;

			foreach (var row in _cells)
			{
				foreach (var cell in row)
				{
					if (!cell.HasValue)
					{
						result = true;
					}
				}
			}

			return result;
		}

		public bool IsCompleted()
		{
			return IsValid() && !HasEmptyFields();
		}

		public string PrettyPrint()
		{
			var sb = new StringBuilder();

			for (var i = 0; i < _containerSize; i++)
			{
				var rowCells = GetRowCells(i);

				foreach (var cell in rowCells)
				{
					var cellValue=cell.HasValue? cell.Value.ToString() : " ";

					sb.Append($"[{cellValue}]");
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}
