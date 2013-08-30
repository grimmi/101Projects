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
            links.Add(new KeyValuePair<int, int>(2, 5));            
            links.Add(new KeyValuePair<int, int>(2, 4));
            links.Add(new KeyValuePair<int, int>(3, 4));
            links.Add(new KeyValuePair<int, int>(4, 5));

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

    class Node
    {
        public int id { get; set; }
        public List<Node> neighbours { get; set; }

        public Node(int id)
        {
            neighbours = new List<Node>();
            this.id = id;
        }

        public bool Equals(Node n)
        {
            if (n.id == this.id)
            {
                return true;
            }
            return false;
        }

        public bool hasNeighbour(Node n)
        {
            return hasNeighbour(n.id);
        }

        public bool hasNeighbour(int id)
        {
            bool hasNeighbour = false;
            foreach (Node n in neighbours)
            {
                if (n.id == id)
                {
                    hasNeighbour = true;
                    break;
                }
            }
            return hasNeighbour;
        }

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

    class Graph
    {
        public Node start { get; set; }
        List<Node> visited;

        public Graph()
        {
            start = null;
            visited = new List<Node>();
        }

        public void createFromLinks(List<KeyValuePair<int, int>> links)
        {
            //Console.WriteLine("createFromLinks...\r\n--------------");
            foreach (KeyValuePair<int,int> kvp in links)
            {
                Node tmpNode = new Node(kvp.Key);
                Node tmpNeighbour = new Node(kvp.Value);
                //Console.WriteLine("pair: {0},{1}", kvp.Key, kvp.Value);
                if (start != null)
                {
                    Node tNode = getNodeById(tmpNode.id);
                    if (tNode != null)
                    {
                        if (!tNode.hasNeighbour(tmpNeighbour))
                        {
                            //Console.WriteLine("Add Neighbour {0} to {1}...", tmpNeighbour.id, tNode.id);
                            tNode.neighbours.Add(tmpNeighbour);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Node found for {0}", tmpNode.id);
                    }
                }
                else
                {
                    start = tmpNode;
                    start.neighbours.Add(tmpNeighbour);
                }
            }
        }

        public bool inGraph(Node n)
        {
            bool found = false;
            if (getNodeById(n.id) != null)
            {
                found = true;
            }
            return found;
        }

        public Node getNodeById(int id)
        {
            visited = new List<Node>();
            //Console.WriteLine("getNodeById(int {0})", id);
            if (start != null)
            {
                if (start.id == id)
                {
                    return start;
                }
                else
                {
                    return getNodeById(start, id);
                }
            }
            return null;
        }

        public Node getNodeById(Node n, int id)
        {
            //Console.WriteLine("getNodeById({0},{1})", n.id, id);
            if (!visited.Contains(n))
            {
                visited.Add(n);
                foreach (Node neighbour in n.neighbours)
                {
                    //Console.WriteLine("Neighbour: {0}, Target-Id: {1}", neighbour.id, id);
                    if (neighbour.id == id)
                    {
                        return neighbour;
                    }
                }
                foreach (Node neighbour2 in n.neighbours)
                {
                    return getNodeById(neighbour2, id);
                }
            }
            return null;
        }
    }
}
