/*
题目名称：
二叉搜索树的第k个结点

题目描述：
给定一棵二叉搜索树，请找出其中的第k小的结点。
例如，（5，3，7，2，4，6，8）中，按结点数值大小顺序第三小结点的值为4。

代码结构：
class Solution
{
    public TreeNode KthNode(TreeNode pRoot, int k)
    {
        // write code here
    }
}
*/
using System;
using System.Text;
using System.Collections.Generic;
namespace KthNode {

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int x)
        {
            val = x;
        }
    }

    class Solution {

        public TreeNode KthNode(TreeNode pRoot, int k)
        {
            return null;
        }

        public void Test() {
            TreeNode pRoot = new TreeNode(0);
            
            TreeNode node = KthNode(pRoot, 1);
            if(node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
