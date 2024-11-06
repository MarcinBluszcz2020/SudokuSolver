﻿namespace SudokuSolver.Core.Model
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

		public int?[] GetColumnCells(int index)
		{
			return _cells.Select(row => row[index]).ToArray();
		}

		public int?[] GetRowCells(int index)
		{
			return _cells[index];
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
	}
}