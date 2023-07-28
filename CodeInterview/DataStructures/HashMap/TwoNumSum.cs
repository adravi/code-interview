namespace CodeInterview.DataStructures;

public class TwoNumSum
{
    public static bool Run(string first, string second)
    {
        if (first.Length != second.Length)
        {
            return false;
        }

        var letterMap = new Dictionary<char, int>();

        foreach (var c in second)
        {
            if (!letterMap.ContainsKey(c))
            {
                letterMap.Add(c, 1);
            }
            else
            {
                letterMap[c] += 1;
            }
        }

        foreach (var c in first)
        {
            if (!letterMap.ContainsKey(c) || letterMap[c] < 1)
            {
                return false;
            }
            else
            {
                letterMap[c] -= 1;
            }
        }

        return true;
    }
}