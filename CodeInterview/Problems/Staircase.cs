namespace CodeInterview.Problems.Staircase;
/*
You are climbing a staircase. It takes n steps to reach the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
 
Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
 
Constraints:
1 <= n <= 45

------------------------------------------------------------------------------------------------------
Input: n = 4
Output: 5

1) 1 1 1 1
2) 1 1 2
3) 1 2 1
4) 2 1 1
5) 2 2

------------------------------------------------------------------------------------------------------
Input: n = 5
Output: 8

1) 1 1 1 1 1
2) 1 1 1 2
3) 1 1 2 1
4) 1 2 1 1
5) 2 1 1 1
6) 1 2 2
7) 2 1 2
8) 2 2 1

------------------------------------------------------------------------------------------------------
Input: n = 6
Output: 13

1) 1 1 1 1 1 1
2) 1 1 1 1 2
3) 1 1 1 2 1
4) 1 1 2 1 1
5) 1 2 1 1 1
6) 2 1 1 1 1
7) 1 1 2 2 
8) 2 2 1 1
9) 1 2 1 2
0) 2 1 2 1
1) 2 1 1 2
2) 1 2 2 1
3) 2 2 2

------------------------------------------------------------------------------------------------------

F(2) = 2
F(3) = 3
F(4) = 5
F(5) = 8
f(6) = 13

*/

public class Staircase 
{
    public static int Steps(int n)
    {
        if (n == 2)
        {
            return 2;
        }
        else if (n == 3)
        {
            return 3;
        }

        return Steps(n-1) + Steps(n-2);
    }
}