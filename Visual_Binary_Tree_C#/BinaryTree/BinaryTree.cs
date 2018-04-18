using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
       class Node
        {
            public Node lchilde;
            public Node rchilde;
            public double data;
        }
        private Node root;
        private string treeStr;
        private bool ltr = true;
        private bool rtl = false;
        private string foundValue;
        private int counter = 0;
        private Node act;
        private Boolean control = false;
        private double[] nodes = new double[100];
        private int addNodesPosition = 0;
        private string treePrint;
        private string[] treeStructure;
        private int treeStructureHelper = 0;
        private string both;
        private double largest;
        private double smallest;
        private Boolean min = true;
        private Boolean max = true;
        private Node temp = new Node();

        public string leftToRigth()
        {
            if (ltr == false)
            {
                ltr = true;
                rtl = false;
            }

            return "Left-to-Right active";
        }

       

        public int getTreeHelper()
        {
            return treeStructureHelper;
        }
        public string[] getPrintOrder()
        {
            return treeStructure;
        }
        public string getHeigth()
        {
            return findHeight(root) + "";
        }

        private int findHeight(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(findHeight(node.lchilde), findHeight(node.rchilde));
        }

       /* private int findHeight(Node aNode)
        {
            if (aNode == null)
            {
                return -1;
            }

            int lefth = findHeight(aNode.lchilde);
            int righth = findHeight(aNode.rchilde);

            if (lefth > righth)
            {
                return lefth + 1;
            }
            else
            {
                return righth + 1;
            }
        }*/

        public double delete(double number)
        {
            act = new Node();
            
            getSelectedNode(root, number);
            Console.WriteLine("Selected node value : " + act.data);
            double re = act.data;
            if (act.data == 0)
                act = null;
            deleteNode(ref root, re);
            return re;
        }

        private bool isRoot(Node n)
        {
            return (n.data == root.data);
        }

        private Node deleteNode(ref Node root, double data)
        {
            if (root == null)
                return root;
            else if (data < root.data)
                root.lchilde = deleteNode(ref root.lchilde, data);
            else if (data > root.data)
                root.rchilde = deleteNode(ref root.rchilde, data);
            else
            {   //case 1: No child
                if(root.lchilde == null && root.rchilde == null)
                {
                    root = null;
                    return null;
                }//Case 2: One Child
                else if(root.lchilde == null)
                {
                    Node temp = root;
                    root = root.rchilde;
                    return root;
                }//Case 3: 2 child
                else
                {
                    if (root.rchilde == null)//if no more right child of root
                    {
                        root = root.lchilde;
                        return root;
                    }
                    else
                    {
                        Node temp = FindMin(root.rchilde);
                        root.data = temp.data;
                        root.rchilde = deleteNode(ref root.rchilde, temp.data);
                    }
                    
                }
            }
            return root;
        }
        public double findLargest()
        {
            double t = 0;
            if (root != null)
                t = FindMax(root).data;
                //t = FindLargest(root).data;
            return t;
        }
        public string findMinAndMax()
        {
            min = true;
            max = true;
            smallest = 0;
            largest = 0;
            both = smallest + ","+largest;
            if (root != null)
            {
                finBoth(root);
                both = smallest + "," + largest;
            }
                
            return both;
        }

        private void finBoth(Node r)
        {
                smallest = FindMin(r).data;
                //largest = FindLargest(r).data;
                largest = FindMax(r).data;
        }
        //Function to find minimum in a tree. 
        private Node FindLargest(Node r)
        {
            while (r.rchilde != null)
            {
                r = r.rchilde;
            }
            return r;
        }

        public double findMinimum()
        {
            double t = 0;
            if(root != null)
                t = FindMin(root).data;
            return t;

        }

        private Node FindMax(Node r)
        {

            if (r == null)
                return null;
            else if(r.rchilde == null)
                return r;
            else
                return FindMax(r.rchilde);
        }
        //Function to find minimum in a tree. 
      /*  private Node FindMin(Node r)
        {
            while (r.lchilde != null)
            {
                r = r.lchilde;
            }
            return r;
        }*/

        private Node FindMin(Node r)
        {
            if (r == null)
                return null;
            else if (r.lchilde == null)
                return r;
            else
                return FindMin(r.lchilde);
        }

        public int countNodes()
        {
            counter = 0;
            count(root);
            return counter;

        }
        public double getRoot()
        {
            double value = 0;
            if(root != null)
                value = root.data;

            return value;
            
        }

        private void getSelectedNode(Node nod, double number)
        {
            if (nod != null)
            {
                getSelectedNode(nod.lchilde, number);
                if (nod.data == number)
                {
                    
                    act.data = nod.data;
                    act.lchilde = nod.lchilde;
                    act.rchilde = nod.rchilde;
                    Console.WriteLine("Found " + nod.data);
                }
                getSelectedNode(nod.rchilde, number);
            }

        }

        private void count(Node root)
        {
            if (root != null)
            {
                count(root.lchilde);
                counter++;
                count(root.rchilde);
            }
        }
        public string searchNode(double number)
        {
            foundValue = "";
            searchForNode(root, number);
            control = false;
            return foundValue;
        }
        private void searchForNode(Node root, double numb)
        {
            if(root != null)
            {
                searchForNode(root.lchilde, numb);
                if (root.data == numb)
                {
                    Console.Write(root.data + " ");
                    foundValue  =  "Found " + root.data;
                    control = true;
                }
                searchForNode(root.rchilde, numb);
            }
            if(control == false)
                foundValue = "Can't find " + numb;
        }

        public string rigthtoLeft()
        {
            if (rtl == false)
            {
                rtl = true;
                ltr = false;
            }
                
            return "Rigth-to-Left active";
        }
        public string getTree()
        {
            return treeStr;
        }
        private bool isRootEmpty(Node r)
        {
            return (r == null);
        }

        public void searchPostOrder()//postorder
        {
            treeStr = "";
            recursivepostorder(root);
        }
        private void recursivepostorder(Node root)
        {
            if (root != null)
            {
                if(ltr)
                {
                    recursivepostorder(root.lchilde);
                    recursivepostorder(root.rchilde);
                    Console.Write(root.data + " ");
                    treeStr += root.data + " , ";
                }
                else
                {
                    recursivepostorder(root.rchilde);
                    recursivepostorder(root.lchilde);
                    Console.Write(root.data + " ");
                    treeStr += root.data + " , ";
                }
                
            }

        }

        public void searchPreOrder()//preorder
        {
            treeStr = "";
            recursivepreorder(root);
        }
        private void recursivepreorder(Node root)
        {
            if (root != null)
            {
                if(ltr)
                {
                    Console.Write(root.data + " ");
                    treeStr += root.data + " , ";
                    recursivepreorder(root.lchilde);
                    recursivepreorder(root.rchilde);
                }
                else
                {
                    Console.Write(root.data + " ");
                    treeStr += root.data + " , ";
                    recursivepreorder(root.rchilde);
                    recursivepreorder(root.lchilde);
                   
                }
                
                
            }

        }
        public double[] getValues()
        {
            addNodesPosition = 0;
            getOrder(root);
            return nodes;
        }

        private void getOrder(Node root)
        {
            if (root != null)
            {
                getOrder(root.lchilde);
                //add to array
                nodes[addNodesPosition] = root.data;
                addNodesPosition++;
                getOrder(root.rchilde);
            }
        }
        public void searchInorder()//inorder
        {
            treeStr = "";
            recursiveInorder(root);
        }
        private void recursiveInorder(Node root)
        {
            if (root != null)
            {
                if(ltr)
                {
                    recursiveInorder(root.lchilde);
                    Console.Write(root.data + " ");
                    treeStr += root.data + " , ";
                    recursiveInorder(root.rchilde);
                }
                else
                {
                    recursiveInorder(root.rchilde);
                    Console.Write(root.data + " ");
                    treeStr += root.data + " , ";
                    recursiveInorder(root.lchilde);
                }
               
            }

        }
        public void insert(double data)
        {
            treeStructureHelper = 0;
            treeStructure = new string[countNodes() +1];
            treePrint = "";
            Node n = new Node();
            n.data = data;
            Insert(n, ref root);
        }
        public string getTreePrint()
        {
            treePrint = "";
            treePrint += "Right\n";
            printBinaryTree(root, 1);
            treePrint += "Left\n";
            return treePrint;
        }
        private void Insert(Node node, ref Node tree)
        {
            if (tree == null)                          // Found a leaf?    
            {
                tree = node;
                Console.WriteLine("Root added");// Found it! Add the new node as the new leaf.
                treePrint += "Root added\n";
                //treeStructure[treeStructureHelper] = "Root added";
                //treeStructureHelper++;
            }
            else
            {     
                if (node.data == tree.data)              // already inserted   
                {
                    Console.WriteLine("Duplicate key");
                    treePrint += "Duplicated value\n";
                    treeStructure[treeStructureHelper] = "Duplicated value";
                    treeStructureHelper++;
                }
                else if(node.data < tree.data)
                {
                   // Node left = tree.lchilde;
                    Insert(node, ref tree.lchilde);              // Keep moving down the left side.            
                   // tree.lchilde = left;
                    Console.WriteLine("Insert -> left");
                    treePrint += "Insert -> left\n";
                    treeStructure[treeStructureHelper] = "Insert -> left";
                    treeStructureHelper++;
                }        
                else        
                {
                   // Node right = tree.rchilde;
                    Insert(node, ref tree.rchilde);            // Keep moving down the right side.            
                   // tree.rchilde= right;
                    Console.WriteLine("Insert -> rigth");
                    treePrint += "Insert -> rigth\n";
                    treeStructure[treeStructureHelper] = "Insert -> rigth";
                    treeStructureHelper++;
                }
            }
        }

         private void printBinaryTree(Node root, int level)
         {
             if (root == null)
                 return;
             printBinaryTree(root.rchilde, level + 1);
             if (level != 0)
             {
                
                 for (int i = 0; i < level - 1; i++)
                {
                    Console.Write("|\t");
                    treePrint += "|\t";
                }
                 if(root.data == getRoot())
                    treePrint += "|-------" + root.data + "----------------------------------------------------------------------------------------ROOT-------------------------------------------------------------------------------------------------------\n";
                 else
                    treePrint += "|-------" + root.data + "\n";
                Console.WriteLine("|-------" + root.data);
             }
             else
            {
                treePrint += root.data + "\n";
                Console.WriteLine(root.data);
            }
                 
             printBinaryTree(root.lchilde, level + 1);
         }
       
    }
}
