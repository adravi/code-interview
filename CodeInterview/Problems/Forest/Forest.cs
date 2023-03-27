namespace CodeInterview.Problems.Forest;

class Forest
{
    public HashSet<string> RootNodeIds { get; set; }
    public Dictionary<string, Node> AncestryMap { get; set; }
}