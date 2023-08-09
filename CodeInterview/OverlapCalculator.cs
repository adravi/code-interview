static class OverlapCalculator
{
    public static DateTime[] Run(DateTime[] dateRange1, DateTime[] dateRange2)
    {
        var dateRange1Start = dateRange1[0];
        var dateRange1End = dateRange1[1];

        var dateRange2Start = dateRange2[0];
        var dateRange2End = dateRange2[1];

        if (dateRange1Start > dateRange2End || dateRange2Start > dateRange1End)
        {
            // No possible overlap
            throw new Exception("No overlap!");
        }

        // Find the Time - Left limit of overlap range
        var leftEdge = (dateRange1Start <= dateRange2Start) ? dateRange2Start : dateRange1Start;
       
        // Find the Time - Right limit of overlap range
        var rightEdge = (dateRange1End <= dateRange2End) ? dateRange1End : dateRange2End;

        return new DateTime[] { leftEdge, rightEdge };
    }
}