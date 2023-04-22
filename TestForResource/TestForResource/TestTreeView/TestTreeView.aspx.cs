using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestTreeView
{
    public partial class TestTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 创建根节点
                TreeNode rootNode = new TreeNode("根节点");

                // 创建子节点
                TreeNode childNode1 = new TreeNode("子节点1");
                TreeNode childNode2 = new TreeNode("子节点2");

                // 将子节点添加到根节点
                rootNode.ChildNodes.Add(childNode1);
                rootNode.ChildNodes.Add(childNode2);


                TreeNode grandChildNode = new TreeNode("孙节点");
                childNode1.ChildNodes.Add(grandChildNode);

                // 绑定节点数据到TreeView控件
                TreeView1.Nodes.Add(rootNode);
            }
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TreeView1.SelectedNode != null)
            {
                Label1.Text = "选中的节点是：" + TreeView1.SelectedNode.Text;
            }
            else
            {
                Label1.Text = "没有选中的节点。";
            }
        }

        protected void TreeView1_NodeClick(object sender, TreeNodeEventArgs e)
        {
            Label1.Text = "你点击了节点：" + e.Node.Text;
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            Label1.Text = "你点击了节点：" + e;
        }
    }
}