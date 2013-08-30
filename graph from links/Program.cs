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
            foreach (KeyValuePair<int,int> kvp in links)
            {
                Node tmpNode = new Node(kvp.Key);
                Node tmpNeighbour = new Node(kvp.Value);
                if (start != null)
                {
                    Node tNode = getNodeById(tmpNode.id);
                    if (!tNode.hasNeighbour(tmpNeighbour))
                    {
                        tNode.neighbours.Add(tmpNeighbour);
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
            if (start != null)
            {
                if (start.id == id)
                {
                    visited.Add(start);
                    return start;
                }
                else
                {
                    Node found = null;
                    foreach (Node n in start.neighbours)
                    {
                        Node tmp = getNodeById(n,id);
                        if (tmp != null)
                        {
                            found = tmp; 
                        }
                    }
                    return found;
                }
            }
            return null;
        }

        public Node getNodeById(Node n, int id)
        {
            if (!visited.Contains(n))
            {
                visited.Add(n);
                foreach (Node neighbour in n.neighbours)
                {
                    if (neighbour.id == id)
                    {
                        return neighbour;
                    }
                    else
                    {
                        foreach (Node neigh in n.neighbours)
                        {
                            return getNodeById(neigh, id);
                        }
                    }
                }
            }
            return null;
        }
    }
}
