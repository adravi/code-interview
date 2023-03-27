namespace CodeInterview.Problems;

public class AdjacentSegments
{
    /*
     * * For this problem, I was actually over complicating my solution by trying to use a Dictionary<int, int>
     * * to easily access the number of segments found for a given sum
     * *
     * * The key to the solution, is what pairs are we comparing among each other
     * *
     * * Assume: [A, B, C, D, E, F]
     * * Given the pair (A,B)
     * * I made the mistake of first, only comparing non-intersecting adjacent segments: (C,D) (E,F)
     * * The problem is that, regarding (A,B), non intersecting segments to inspect are actually:   (C,D) (D,E) (E,F)
     * *
     * * -------------------------------------------------------------------------------------------------------------------------
     * *
     * * Assume: [A, B, C, D, E, F]
     * * Given the pair (A,B) = SUM
     * *
     * * (A,B) | Inspect (C,D)
     * *         If (C,D)  DOES match SUM,   this segment is relevant. We don't want to intersect it
     * *                                     move the index by 2, so we inspect (E,F)
     * *
     * *         If (C,D) DOESN'T match SUM, this segment is not relevant for our current inspection. No problem intersecting it
     * *                                     move the index by 1, so we inspect (D,E)
     * */


    // Sol O(n^2)
    public static int Run(int[] A)
    {
        var maxSegments = 0;

        for (var i = 0; i < (A.Length - 1); i++)
        {
            var sum = A[i] + A[i + 1];

            var j = i + 2;
            var numSegments = 1;

            while (j < (A.Length - 1))
            {
                if (A[j] + A[j + 1] == sum)
                {
                    // Segment with sum found!
                    // Move index 2 positions, so the next pair doesn't collide!
                    numSegments++;
                    j += 2;
                }
                else
                {
                    // Segment with diff sum.
                    // We can advance 1 position without intersecting a pair of interest
                    j += 1;
                }
            }

            maxSegments = Math.Max(maxSegments, numSegments);
        }

        return maxSegments;
    }
}