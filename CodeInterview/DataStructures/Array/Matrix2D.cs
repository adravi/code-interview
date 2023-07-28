namespace CodeInterview.DataStructures;

public class Matrix2D
{
    public static void Run()
    {
        int[,] matrix = new int[,] 
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 10, 11, 0 }
        };
        
        var ROWS = matrix.GetLength(0);
        var COLS = matrix.GetLength(1);

        Console.WriteLine($"Rows: {ROWS}");
        Console.WriteLine($"Cols: {COLS}");

        for (var i = 0; i < ROWS; i++)
        {
            for (var j = 0; j < COLS; j++)
            {
                // [{i}, {j}]
                Console.Write($"[{matrix[i, j]}]");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}