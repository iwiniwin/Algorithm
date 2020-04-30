/*
题目名称：
二叉搜索树与双向链表

题目描述：
输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的双向链表。
要求不能创建任何新的结点，只能调整树中结点指针的指向。

代码结构：
class Solution
{
    public TreeNode Convert(TreeNode pRootOfTree)
    {
        // write code here
    }
}

补充：
二叉搜索树（Binary Search Tree）定义：
1. 可以是空树
2. 若不是空树
    若它的左子树不空，则左子树所有节点的值均小于它的根节点的值
    若它的右子树不空，则右子树所有节点的值均大于它的根节点的值
    它的左，右子树也分别为二叉搜索树   
*/
using System;
using System.Collections.Generic;
namespace Convert {

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

        public TreeNode Convert(TreeNode pRootOfTree)
        {
            return pRootOfTree;
        }

        public void Print(TreeNode root){
            TreeNode node = null;
            while(root != null){
                Console.Write(root.val + " ");
                node = root;
                root = root.right;
            }
            Console.WriteLine();
            while(node != null){
                Console.Write(node.val);
                node = node.left;
            }
        }

        public void Test() {
            
            TreeNode pRootOfTree = new TreeNode(1);
            pRootOfTree.left = new TreeNode(2);
            pRootOfTree.right = new TreeNode(3);
           
            Print(Convert(pRootOfTree));
        }
    }
}
