using CodeInterview.DataStructures;
using CodeInterview.Problems.Staircase;

//  You will need to implement a function that takes in two date ranges 
// and returns the overlap of those date ranges as a new date range. If there is no overlap, an exception should be thrown.
// Make no assumptions about the order of the date ranges that are passed into the function.

// input1 : 2023-08-01 - 2023-08-30
// input2 : 2023-09-02 - 2023-09-21
// overlap: No overlap!

// var dateRange1 = new DateTime[] { new DateTime(2023, 08, 01), new DateTime(2023, 08, 30) };
// var dateRange2 = new DateTime[] { new DateTime(2023, 08, 01), new DateTime(2023, 08, 15) };
// var overlapRange = OverlapCalculator.Run(dateRange1, dateRange2);

// Console.WriteLine($"\nTestCase 1) Overlap Range: {overlapRange[0]:yyyy-MM-dd} - {overlapRange[1]:yyyy-MM-dd}\n");

///////////////////////////////////////////////////////////////////////////

// Console.WriteLine("Mr. Anderson...welcome back");
// var counter = 5;
// for (var i=0; i<counter; i++) 
// {
//     Console.WriteLine($"The counter is: {i + 1}");
// }

///////////////////////////////////////////////////////////////////////////

// var num = 0;
// while (num < 7)
// {
//     Console.WriteLine($"The counter is {num}");
//     num++;
// }

///////////////////////////////////////////////////////////////////////////

// PrintSomething(num);
// void PrintSomething(int something)
// {
//     Console.WriteLine($"Time to print something: {something}");
// }

// Console.WriteLine("Let's print an array of nums");
// var nums = new int[] {1, 2, 3};
// Console.WriteLine(string.Join(", ", nums));

///////////////////////////////////////////////////////////////////////////

// var matrix = new int[,] 
// { 
//     {1, 2, 3, 7},
//     {4, 5, 6, 7},
//     {7, 8, 9, 7},
// };

// var rows = matrix.GetLength(0);
// var cols = matrix.GetLength(1);

// for (var i = 0; i < rows; i++)
// {
//     for (var j = 0; j < cols; j++)
//     {
//         Console.Write($"{matrix[i,j]} ");
//     }
//     Console.WriteLine();
// }

///////////////////////////////////////////////////////////////////////////

// Console.WriteLine(ValidAnagram.Run("anagram", "nagaram"));

///////////////////////////////////////////////////////////////////////////

// var array = new int[] {3, 5, -4, 8, 11, 1, -1, 6};
// Console.WriteLine(TwoNumSum.Run(array, 10));



Console.WriteLine(Staircase.Steps(6));