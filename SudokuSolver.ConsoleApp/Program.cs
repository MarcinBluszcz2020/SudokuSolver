namespace SudokuSolver.ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var sudokuDiagram = GetBeginnerDiagram();

			var prettyPrint = sudokuDiagram.PrettyPrint();

			Console.WriteLine(prettyPrint);

			Console.WriteLine("end!");
			Console.ReadLine();
		}

		private static Core.Model.SudokuDiagram GetBeginnerDiagram()
		{
			var sudokuDiagram = new Core.Model.SudokuDiagram();

			sudokuDiagram.SetRowValues(0, new int?[] { null, 6, null, 4, null, 2, 1, null, 5 });
			sudokuDiagram.SetRowValues(1, new int?[] { null, null, null, 9, 7, null, null, 2, null });
			sudokuDiagram.SetRowValues(2, new int?[] { 1, null, 2, null, 8, null, null, 3, 7 });

			sudokuDiagram.SetRowValues(3, new int?[] { null, null, 5, null, 1, 4, null, null, 3 });
			sudokuDiagram.SetRowValues(4, new int?[] { null, 2, null, null, null, null, null, 7, null });
			sudokuDiagram.SetRowValues(5, new int?[] { 9, null, null, 3, 5, null, 6, null, null });

			sudokuDiagram.SetRowValues(6, new int?[] { 8, 1, null, null, 4, null, 2, null, 9 });
			sudokuDiagram.SetRowValues(7, new int?[] { null, 9, null, null, 2, 5, null, null, null });
			sudokuDiagram.SetRowValues(8, new int?[] { 2, null, 3, 8, null, 9, null, 4, null });


			return sudokuDiagram;
		}
	}
}
