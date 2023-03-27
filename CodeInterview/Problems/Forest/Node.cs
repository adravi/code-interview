namespace CodeInterview.Problems.Forest;

class Node
{
    public string? Id { get; set; }
    public string? Father { get; set; }
    public HashSet<string> Children { get; set; }
}