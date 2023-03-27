using System.Text.RegularExpressions;

namespace CodeInterview.Problems;

public class SeatsManager
{
    /*
     * This problem was actually easier than Prob2 but I struggled with a little piece of the solution:
     * Separate the numeric part of the alphabetical part of a seat-key, such as 50H. I needed to come up with the right regex
     *
     * For each row, we want to accomodate the max number of families possible, which is 2
     * [ ][*][*]  [*][*][*][*] [*][*][ ]
     *
     * If the taken seats don't allow to so, then we should at least try to accomodate 1. There are 3 ways of doing so
     * [ ][*][*]  [*][*][ ][ ] [ ][ ][ ]
     *
     * [ ][ ][ ]  [*][*][*][*] [ ][ ][ ]
     *
     * [ ][ ][ ]  [ ][ ][*][*] [*][*][ ]
     *
     * The best approach I found, was to actually build a bi-dimensional array of bools, with each value
     * indicating if a seat is taken. A SeatsTakenMatrix. Because of this, the solution has a spacial complexity of O(N*10)
     * Once the matrix is initialized, we use the string `s` to mark the seats that 'taken'
     * We directly use a parsed coordinate (x,y) to find the relevant cell we want to mark. No need to explore the whole matrix
     *
     * Now we can directly ask for the possible configurations described above in each row.
     * We never had to explore the whole matrix. The number of operations is fixed for each row from 1 to N
     *
     * What helps us greatly in this problem, is that the number of columns in the matrix is fixed: The letters ABCDEFGHJK
     *
     */

    private const string Letters = "ABCDEFGHJK";
    private readonly Regex regex = new Regex(@"(\d+)([A-Z]+)");
    private bool[,] TakenSeatsMatrix;

    // Sol O(N)
    public int Solution(int rows, string taken)
    {
        // The letter `I` is omitted in Column Letter for unknown reasons (problem statement)
        if (taken.Contains('I'))
        {
            throw new ArgumentException("Invalid seat key contains `I`");
        }

        // No seats are taken, all the seats are available
        if (string.IsNullOrWhiteSpace(taken))
        {
            return (rows * 2);
        }

        // Create the matrix with all values initialized as False
        TakenSeatsMatrix = new bool[rows, Letters.Length];
        var seatKeys = taken.Split(' ');
        MarkTakenSeats(rows, seatKeys);

        // For each row, explore the 2 possible configurations and accumulate them
        var maxNumFamilies = 0;
        for (var i = 0; i < rows; i++)
        {
            maxNumFamilies += AccomodateFamiliesInRow(i);
        }

        return maxNumFamilies;
    }

    // Use the coordinates of each seat-key to set the value of (x,y) as true
    // So in the TakenSeatsMatrix[x,y] = true, it means that seat is taken
    private void MarkTakenSeats(int rows, string[] seatKeys)
    {
        foreach (var seatKey in seatKeys)
        {
            var (x, y) = ParseToCoordinate(seatKey);

            if ((x < 0) || (x >= rows))
            {
                throw new ArgumentException($"Index for coordinate X cannot be less than 0 or greater than {rows - 1}");
            }

            if ((y < 0) || (y >= Letters.Length))
            {
                throw new ArgumentException($"Index for coordinate Y cannot be less than 0 or greater than {Letters.Length - 1}");
            }

            TakenSeatsMatrix[x, y] = true;
        }
    }

    // Separate the numeric part from the letter in the seat key and transform to (x,y) coordinate
    private (int, int) ParseToCoordinate(string seatKey)
    {
        var match = regex.Match(seatKey);

        var number = match.Groups[1].Value;
        var letter = match.Groups[2].Value;

        var x = (int.Parse(number) - 1);
        var y = Letters.IndexOf(letter);

        return (x, y);
    }

    // Try config possibilities number and return the biggest one
    private int AccomodateFamiliesInRow(int rowIndex)
    {
        // Config 1: Two families seated across islands
        var config1Counter = 0;

        // Try to accomodate in island first half
        if (TakenSeatsMatrix[rowIndex, 1] == false &&
            TakenSeatsMatrix[rowIndex, 2] == false &&
            TakenSeatsMatrix[rowIndex, 3] == false &&
            TakenSeatsMatrix[rowIndex, 4] == false)
        {
            config1Counter++;
        }

        // Try to accomodate in island second half
        if (TakenSeatsMatrix[rowIndex, 5] == false &&
            TakenSeatsMatrix[rowIndex, 6] == false &&
            TakenSeatsMatrix[rowIndex, 7] == false &&
            TakenSeatsMatrix[rowIndex, 8] == false)
        {
            config1Counter++;
        }

        // Config 2: One family in center island
        var config2Counter = 0;
        if (TakenSeatsMatrix[rowIndex, 3] == false &&
            TakenSeatsMatrix[rowIndex, 4] == false &&
            TakenSeatsMatrix[rowIndex, 5] == false &&
            TakenSeatsMatrix[rowIndex, 6] == false)
        {
            config2Counter++;
        }

        return Math.Max(config1Counter, config2Counter);
    }
    
}