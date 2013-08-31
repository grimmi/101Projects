using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Graph from links - Create a program that will create a graph or network from a series of links.
 * Erste Version: 29.08.2013
 */

namespace graph_from_links
{
    class Program
    {
        static void Main(String[] args)
        {
            List<KeyValuePair<int, int>> links = new List<KeyValuePair<int, int>>();
            links.Add(new KeyValuePair<int, int>(1, 2));
            links.Add(new KeyValuePair<int, int>(1, 3));
            links.Add(new KeyValuePair<int, int>(1, 4));
            links.Add(new KeyValuePair<int, int>(2, 5));            
            links.Add(new KeyValuePair<int, int>(2, 4));
            links.Add(new KeyValuePair<int, int>(3, 4));
            links.Add(new KeyValuePair<int, int>(4, 5));
            links.Add(new KeyValuePair<int, int>(4, 1));

            Graph g = new Graph();
            g.createFromLinks(links);
            g.start.print();
            Node zwei = g.getNodeById(2);
            zwei.print();
            Node drei = g.getNodeById(3);
            drei.print();
            Node vier = g.getNodeById(4);
            vier.print();
            Console.ReadKey();
        }

    }

    /*
     * A graph consists of n Nodes which have itself n 'neighbours'
     * A Node has only its id as field
     */
    class Node
    {
        public int id { get; set; }
        public List<Node> neighbours { get; set; }

        public Node(int id)
        {
            neighbours = new List<Node>();
            this.id = id;
        }

        // Equals-Method for Nodes - two nodes are the same if their ids are equal
        public bool Equals(Node n)
        {
            if (n.id == this.id)
            {
                return true;
            }
            return false;
        }


        // entry method for hasNeighbour(int id) - we want to be able to search with both id and Node
        public bool hasNeighbour(Node n)
        {
            return hasNeighbour(n.id);
        }

        // search method for neighbours of a node
        public bool hasNeighbour(int id)
        {
            bool hasNeighbour = false;
            // just run through all the neighbours an set the flag to true if one of the neighbours has the right id
            foreach (Node n in neighbours)
            {
                if (n.id == id)
                {
                    // if we found the correct neighbour we break out of the loop
                    hasNeighbour = true;
                    break;
                }
            }
            return hasNeighbour;
        }

        // custom output method
        public void print()
        {
            Console.WriteLine("Node {0}:", this.id);
            Console.WriteLine("Neighbours:");
            foreach (Node n in neighbours)
            {
                Console.WriteLine("- Node {0}", n.id);
            }
            Console.WriteLine("--------------------");
        }
    }

    /*
     * A Graph consists of n Nodes which are linked through their neighbours
     * One node (usually the first to be inserted) is marked as 'start' to have an entry point to the graph
     * A List<Node> visited is used to track which Nodes were visited while iterating over the graph, so we don't check the same Node twice
     */
    class Graph
    {
        public Node start { get; set; }
        List<Node> visited;

        public Graph()
        {
            start = null;
            visited = new List<Node>();
        }

        // method to create the graph from a list of KeyValuePairs<int,int>
        public void createFromLinks(List<KeyValuePair<int, int>> links)
        {
            foreach (KeyValuePair<int,int> kvp in links)
            {
                // since a Node only has an id, we just take the ints and make Nodes out of those
                Node tmpNode = new Node(kvp.Key);
                Node tmpNeighbour = new Node(kvp.Value);
                if (start != null)
                {
                    // get the Node in the graph, if it exists (two Nodes are the same if their ids match)
                    Node tNode = getNodeById(tmpNode.id);
                    if (tNode != null)
                    {
                        // if the Node already exists in the graph and doesn't have the neighbour declared in the current KeyValuePair, we add that neighbour
                        if (!tNode.hasNeighbour(tmpNeighbour))
                        {
                            tNode.neighbours.Add(tmpNeighbour);
                        }
                    }
                    // the Node doesn't exist in the graph - at the moment, we need the Nodes to be inserted in a way that this doesn't occur,
                    // i.e. a Node is only inserted as a neighbour of an already existing Node
                    else
                    {
                        Console.WriteLine("No Node found for {0}", tmpNode.id);
                    }
                }
                // if the graph is empty, we set the current Node as 'start' and add the value of the KeyValuePair as its neighbour
                else
                {
                    start = tmpNode;
                    start.neighbours.Add(tmpNeighbour);
                }
            }
        }

        // method to check whether a Node exists in the graph (a Node exists if there is a Node with a matching id)
        public bool inGraph(Node n)
        {
            bool found = false;
            if (getNodeById(n.id) != null)
            {
                found = true;
            }
            return found;
        }

        // get a Node by supplying the id
        // entry method for recursive method getNodeById(Node n, int id) - see below
        public Node getNodeById(int id)
        {
            // clear the visited list from earlier iterations
            visited = new List<Node>();
            if (start != null)
            {
                // check the start Node first - sometimes we're lucky ;)
                if (start.id == id)
                {
                    return start;
                }
                else
                {
                    // if it isn't the start node, start traversing the graph
                    return getNodeById(start, id);
                }
            }
            return null;
        }

        // get the Node to a supplied id
        // recursive method (entry method above)
        public Node getNodeById(Node n, int id)
        {
            // only check Nodes that are not already in visited - no need to check twice
            if (!visited.Contains(n))
            {
                // mark this Node as visited
                visited.Add(n);
                // run through the neighbours and check their ids
                foreach (Node neighbour in n.neighbours)
                {
                    if (neighbour.id == id)
                    {
                        // if we find it, return it
                        return neighbour;
                    }
                }
                // if we don't find it, run the neighbours' neighbours
                foreach (Node neighbour2 in n.neighbours)
                {
                    return getNodeById(neighbour2, id);
                }
            }
            // nothing? -> return null
            return null;
        }
    }
}
