namespace work10
{
    internal class Node
    {
        public Node? left, right;
        public int val;
        public Node(int _val, Node? _left = null, Node? _right = null)
        {
            left = _left;
            right = _right;
            val = _val;
        }
    }

    internal class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DFS(createTree(), 4));
        }

        static bool DFS(Node[] tree, int search_val)
        {
            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();

            stack.Push(tree[0]);
            while (stack.Count > 0)
            {
                Node n = stack.Pop();
                visited.Add(n);
                //Console.WriteLine(n.val);
                if (n.val == search_val)
                    return true;

                if (n.left != null && !visited.Contains(n.left))
                    stack.Push(n.left);
                if (n.right != null && !visited.Contains(n.right))
                    stack.Push(n.right);
            }
            return false;
        }

        static Node[] createTree()
        {
            Node[] nodes = new Node[10];
            nodes[9] = new Node(7);
            nodes[8] = new Node(8);
            nodes[7] = new Node(9);
            nodes[6] = new Node(6);
            nodes[5] = new Node(0);
            nodes[4] = new Node(1, nodes[9]);
            nodes[3] = new Node(4, nodes[7], nodes[8]);
            nodes[2] = new Node(5, nodes[5], nodes[6]);
            nodes[1] = new Node(3, nodes[3], nodes[4]);
            nodes[0] = new Node(2, nodes[1], nodes[2]);

            return nodes;
        }
    }
}