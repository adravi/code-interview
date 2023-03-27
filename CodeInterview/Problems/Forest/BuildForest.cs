namespace CodeInterview.Problems.Forest;

public class CreateForest
{
    /*
     ** AncestryMap
     ** <key, <id, father, [children collection]>>
  
     ** 1) (cat, lion)
     ** 2) (cat, panther)
 
     ** <cat, <cat, null, [panther, lion]>
     ** <panther, <panther, cat, []>>
     ** <lion, <lion, cat, []>>
  
     ** --
  
     ** 3) (mammal, cat)
  
     ** <cat, <mammal, [panther, lion]>
     ** <panther, <cat, []>>
     ** <lion, <cat, []>>
     ** <mammal, <null, [cat]>>
    */
    
    public void Run()
    {
        {
            var pairs = new List<(string, string)>
            {
                ("Cat", "Panther"),
                ("Cat", "Lion"),
                ("Lifeform", "Mammal"),
                ("Virus", "Covid"),
                ("Fish", "Shark"),
                ("Mammal", "Cat"),
                ("Lifeform", "Fish"), // Up to this pair, the forest is built correctly
                ("Shark", "Cat") // This pair will force an exception
            };

            var forest = ConvertPairsToForest(pairs);

            PrintForest(forest);       
        }
    }
    
    private Forest ConvertPairsToForest(List<(string, string)> pairs)
    {
        {
            var ancestryMap = new Dictionary<string, Node>();

            // All the root nodes have no father | Node.Father = null
            var rootNodeIds = new HashSet<string?>();

            foreach (var (key, value) in pairs)
            {
                // New father - children relationship
                if (!ancestryMap.ContainsKey(key))
                {
                    // Add <(key), Node{ Children[value]}> | We dont know the father 
                    ancestryMap.Add(key, new Node
                    {
                        Id = key,
                        Father = null,
                        Children = new HashSet<string> { value }
                    });
                }
                else
                {                    
                    // Validate father
                    ValidateFather(ancestryMap, key, value);

                    var existingNode = ancestryMap[key];

                    // Add children 
                    existingNode.Children.Add(value);
                
                }

                var node = ancestryMap[key];

                // Add reverse relationship for children - father | We dont know the children
                if (!ancestryMap.ContainsKey(value))
                {
                    ancestryMap.Add(value, new Node
                    {
                        Id = value,
                        Father = key,
                        Children = new HashSet<string>()
                    });
                }
                else
                {
                    // Validate father
                    ValidateFather(ancestryMap, key, value);

                    var existingNode = ancestryMap[value];

                    // Add father
                    existingNode.Father = key;
                }

                // If at the end of the assignments, the father of this node points to null, this is a potential root node
                if (node.Father == null)
                {
                    rootNodeIds.Add(node.Id);                        
                }

                // Inspect that at the end of assignments, all the potential root nodes are still fatherless
                // Since we are removing an element of a collection while iterating it, we iterate it backwards
                for (var i = rootNodeIds.Count-1; i >= 0; i--)
                {
                    var rootNodeId = rootNodeIds.ElementAt(i);
                    var rootNode = ancestryMap[rootNodeId];

                    if (rootNode.Father != null)
                    {
                        rootNodeIds.Remove(rootNodeId);
                    }
                }
            }

            return new Forest
            {
                RootNodeIds = rootNodeIds,
                AncestryMap = ancestryMap
            };
        }
    }
    
    private void ValidateFather(Dictionary<string, Node> ancestryMap, string fatherCandidateId, string? nodeId)
    {
        // If there is no entry in the map for the inspected node, its parenthood cannot be validated
        if (!ancestryMap.ContainsKey(nodeId))
        {
            return;
        }

        var node = ancestryMap[nodeId];

        if (node.Father != null && node.Father != fatherCandidateId)
        {
            throw new Exception($"Node {node.Id} has father {node.Father} and conflicts with pair ({fatherCandidateId}, {nodeId})");
        }
    }

    private void PrintForest(Forest forest)
    {
        foreach (var rootNodeKey in forest.RootNodeIds)
        {
            // Trees are separated by an empty line
            Console.WriteLine();
            var node = forest.AncestryMap[rootNodeKey];
            PrintNode(forest.AncestryMap, node, 1);
        }
    }
    
    private void PrintNode(Dictionary<string, Node> ancestryMap, Node node, int depth)
    {
        // Children nodes indentation
        for (var i = 0; i < depth; i++)
        {
            if (i == 0)
            {
                Console.Write("\n");
            }

            Console.Write("  ");
        }

        Console.Write($"{node.Id}");

        foreach (var childrenNodeId in node.Children)
        {
            var childrenNode = ancestryMap[childrenNodeId];
            PrintNode(ancestryMap, childrenNode, depth + 1);
        }
    }
}