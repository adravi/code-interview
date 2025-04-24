// https://www.algoexpert.io/questions/two-number-sum 
// array = [3, 5, -4, 8, 11, 1, -1, 6]
// targetSum = 10

public class TwoNumSum {

    // Create a hash-set using the array as input and referencing each element as 'num'
    public static (int, int) Run(int[] array, int targetSum)
    {
        var nums = new HashSet<int>();
        for (var i=0; i < array.Length; i++)
        {
            nums.Add(array[i]);
        }

        foreach(var num in nums)
        {
            var reciprocate = targetSum - num;

            if (nums.Contains(reciprocate) && reciprocate != num)
            {
                return (num, reciprocate);
            }
        }

        return (-1, -1);
    }
}