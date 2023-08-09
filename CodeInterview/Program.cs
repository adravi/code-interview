//  You will need to implement a function that takes in two date ranges 
// and returns the overlap of those date ranges as a new date range. If there is no overlap, an exception should be thrown.
// Make no assumptions about the order of the date ranges that are passed into the function.

// input1 : 2023-08-01 - 2023-08-30
// input2 : 2023-09-02 - 2023-09-21
// overlap: No overlap!

var dateRange1 = new DateTime[] { new DateTime(2023, 08, 01), new DateTime(2023, 08, 30) };
var dateRange2 = new DateTime[] { new DateTime(2023, 08, 01), new DateTime(2023, 08, 15) };
var overlapRange = OverlapCalculator.Run(dateRange1, dateRange2);

Console.WriteLine($"\nTestCase 1) Overlap Range: {overlapRange[0]:yyyy-MM-dd} - {overlapRange[1]:yyyy-MM-dd}\n");
