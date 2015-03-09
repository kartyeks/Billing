using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCA.Communication
{
    /// <summary>
    /// The node in the tree. Which has the Row ID and Cells
    /// </summary>
    public class NodeData
    {
        public int id;
        public Object[] cell;
    }

    /// <summary>
    /// The list of nodes which will be loaded on the tree
    /// </summary>
    public class Node
    {
        public NodeData[] rows;
    }

    /// <summary>
    /// The object which contains all the elements of tree.
    /// </summary>
    public class JTreeObject
    {
        public String datatype;
        public Node datastr;
        public int height;
        public int width;
        public String[] colNames;
        public ColumnModel[] colModel;
        public String treeGridModel;
        public String pager;
        public bool treeGrid;
        public String ExpandColumn;
        public bool ExpandColClick;
        public String caption;
        public String[] treeIcons;
    }

    /// <summary>
    /// The interface which will be implemented by the class which will be loaded in to tree
    /// </summary>
    public interface JTreeDataObject
    {
        int GetID();
        int GetParentID();
        String GetName();
        bool GetLeaf();
    }

    /// <summary>
    /// The root node. Which has the default root value
    /// </summary>
    public class RootNode : JTreeDataObject
    {
        private String _RootName;

        public RootNode(String RootName)
        {
            _RootName = RootName;
        }


        #region JTreeDataObject Members

        public int GetID()
        {
            return 0;
        }

        public int GetParentID()
        {
            return -1;
        }

        public string GetName()
        {
            return _RootName;
        }

        public bool GetLeaf()
        {
            return false;
        }

        #endregion
    }

    /// <summary>
    /// The actual tree node.It has the childs
    /// </summary>
    public class TreeNode
    {
        private JTreeDataObject _Data;
        private List<TreeNode> _Childs;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Data">Takes the internal data object for the node</param>
        public TreeNode(JTreeDataObject Data)
        {
            _Data = Data;
            _Childs = new List<TreeNode>();
        }

        /// <summary>
        /// Add child node
        /// </summary>
        /// <param name="Node"></param>
        public void AddNodes(TreeNode Node)
        {
            _Childs.Add(Node);
        }

        /// <summary>
        /// get the actual data
        /// </summary>
        /// <returns>Returns the node data</returns>
        public JTreeDataObject GetData()
        {
            return _Data;
        }

        /// <summary>
        /// Get all the childnodes
        /// </summary>
        /// <returns>Array of childs</returns>
        public TreeNode[] GetChildNodes()
        {
            List<TreeNode> AllChilds = new List<TreeNode>();

            AllChilds.AddRange(_Childs);

            foreach (TreeNode Child in _Childs)
            {
                AllChilds.AddRange(Child.GetChildNodes());
            }

            return AllChilds.ToArray();
        }
    }

    /// <summary>
    /// The class which takes all the data and create the final JQuery Tree object
    /// </summary>
    public class JTreeBuilder
    {
        private Dictionary<int, TreeNode> _MapTree;
        private Dictionary<int, int> _MapLevel;
        private String _RootName;
        private String _Caption;
        private Dictionary<int, String> _NodeSet = new Dictionary<int, string>();
        private TreeNode _RootNode;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="RootName">The root node name</param>
        /// <param name="Caption">The caption for the tree</param>
        public JTreeBuilder(String RootName, String Caption)
        {
            _RootName = RootName;
            _Caption = Caption;
            _MapTree = new Dictionary<int, TreeNode>();
            _MapLevel = new Dictionary<int, int>();

            //Root node will be created automatically. All the nodes will be childs for the root node
            _RootNode = new TreeNode(new RootNode(RootName));

            //Add the node to the map
            _MapTree.Add(_RootNode.GetData().GetID(), _RootNode);
        }

        /// <summary>
        /// Add a new row
        /// </summary>
        /// <param name="Data">Row data</param>
        public void Add(JTreeDataObject Data)
        {
            TreeNode Node = new TreeNode(Data);

            _MapTree.Add(Data.GetID(), Node);

            //Add the nodes to the parent. 
            if (_MapTree.ContainsKey(Data.GetParentID()))
            {
                _MapTree[Data.GetParentID()].AddNodes(Node);
            }

        }

        /// <summary>
        /// Add new rows
        /// </summary>
        /// <param name="Data">Array of row data</param>
        public void Add(JTreeDataObject[] Data)
        {
            foreach (JTreeDataObject Tree in Data)
            {
                Add(Tree);
            }
        }

        /// <summary>
        /// Takes all the nodes and creates the final object
        /// </summary>
        /// <returns></returns>
        public JTreeObject GetTreeObject()
        {
            JTreeObject JTree = new JTreeObject();

            JTree.datastr = new Node();

            JTree.datatype = "jsonstring";
            JTree.height = 100;
            JTree.width = 150;
            JTree.colNames = new String[] { "ID", _Caption };
            JTree.treeGridModel = "adjacency";
            JTree.pager = "#ptreegrid";
            JTree.treeGrid = true;
            JTree.ExpandColumn = "desc";
            JTree.ExpandColClick = true;
            JTree.caption = _Caption;
            JTree.treeIcons = new String[] { "leaf", "ui-icon-document-b" };

            JTree.datastr.rows = new NodeData[_MapTree.Count];

            List<NodeData> ListNode = new List<NodeData>();

            _NodeSet = new Dictionary<int, string>();

            // Get the root node and build the tree
            ListNode.AddRange(GetJNode(_MapTree[0]));

            JTree.datastr.rows = ListNode.ToArray();

            return JTree;
        }

        /// <summary>
        /// Constructs the tree. Get the details for the current node and get all the details for the childs
        /// </summary>
        /// <param name="Node">Tree Node Object</param>
        /// <returns></returns>
        private List<NodeData> GetJNode(TreeNode Node)
        {
            List<NodeData> ListNode = new List<NodeData>();

            // Get current node object
            JTreeDataObject Tmp = Node.GetData();


            //There are chances to add the same node details by processing its own and by its parent. 
            //So we have to check,if already processed no need to store the details
            if (!_NodeSet.ContainsKey(Tmp.GetID()))
            {
                NodeData JNode = new NodeData();
                JNode.id = Tmp.GetID();
                JNode.cell = new Object[6];
                JNode.cell[0] = Tmp.GetID();
                JNode.cell[1] = Tmp.GetName();
                JNode.cell[2] = GetLevel(Tmp.GetParentID());
                JNode.cell[3] = Tmp.GetParentID();
                JNode.cell[4] = Tmp.GetLeaf();
                JNode.cell[5] = false;

                ListNode.Add(JNode);

                _NodeSet.Add(Tmp.GetID(), "");
            }

            // Process the child nodes
            foreach (TreeNode Child in Node.GetChildNodes())
            {
                ListNode.AddRange(GetJNode(Child));
            }

            return ListNode;
        }

        /// <summary>
        /// Find the level of the node
        /// </summary>
        /// <param name="ParentID">Parent ID of a node.</param>
        /// <returns></returns>
        public int GetLevel(int ParentID)
        {
            if (ParentID < 0)
            {
                return 0;
            }
            else
            {
                int Level;

                //If the level has been found already use the same
                if (_MapLevel.ContainsKey(ParentID))
                {
                    _MapLevel.TryGetValue(ParentID, out Level);
                }
                else
                {
                    //Find the parent ID and increase by 2. This will give the level
                    JTreeDataObject Parent = _MapTree[ParentID].GetData();

                    Level = GetLevel(Parent.GetParentID()) + 1;

                    _MapLevel.Add(Parent.GetID(), Level);
                }

                return Level;
            }

        }
    }
}
