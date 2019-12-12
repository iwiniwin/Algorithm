/*
题目名称：
平衡二叉树

题目描述：
输入一棵二叉树，判断该二叉树是否是平衡二叉树。

代码结构：
class Solution
{
    public bool IsBalanced_Solution(TreeNode pRoot)
    {
        // write code here
    }
}

补充：
平衡二叉树定义：
1. 可以是空树
2. 假如不是空树，任何一个节点的左子树与右子树都是平衡二叉树，并且高度之差的绝对值不超过1
*/
using System;
namespace IsBalanced {

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

        /// <summary>
        /// 解法，递归
        /// 基本思路：
        /// 按照平衡二叉树的定义，递归计算左右子树的高度差是否大于1来判断是否是平衡二叉树
        /// 如果发现某棵树的左右子树高度差大于1，即不是平衡二叉树，则直接返回-1，终止递归
        /// </summary>

        public int TreeDepth(TreeNode node){
            if(node == null){
                return 0;
            }
            int left = TreeDepth(node.left);
            if(left == - 1){
                return -1;
            }
            int right = TreeDepth(node.right);
            if(right == - 1){
                return -1;
            }
            if(Math.Abs(left - right) > 1){
                return -1;
            }
            return left > right ? left + 1 : right + 1;
        }

        public bool IsBalanced_Solution(TreeNode pRoot)
        {
            if(TreeDepth(pRoot) == -1){
                return false;
            }
            return true;
        }

        public void Test() {
            TreeNode node = new TreeNode(1);
            // node = null;
            node.left = new TreeNode(2);
            node.left.left = new TreeNode(3);
            node.right = new TreeNode(4);
            node.right.right = new TreeNode(5);
            // node.right.right.right = new TreeNode(6);
            node.right.right.left = new TreeNode(7); 

            Console.WriteLine(IsBalanced_Solution(node));
        }
    }
}
