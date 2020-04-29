/*
题目名称：
二叉树中和为某一值的路径

题目描述：
输入一颗二叉树的根节点和一个整数，打印出二叉树中结点值的和为输入整数的所有路径。
路径定义为从树的根结点开始往下一直到叶结点所经过的结点形成一条路径。

代码结构：
class Solution
{
    public List<List<int>> FindPath(TreeNode root, int expectNumber)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace FindPath {

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
        /// 通过定义成员变量list记录在递归过程中经过的每一个节点
        /// 当找到根节点时，且路径上的节点和值等于目标值时，则找到一条路径
        /// 算法的重点在于当递归经过一个节点将其加入到list中后
        /// 递归回溯以后再使用RemoveAt方法将其移除进行回退
        /// </summary>

        private List<List<int>> pathList = new List<List<int>>();
        private List<int> list = new List<int>();

        public List<List<int>> FindPath(TreeNode root, int expectNumber)
        {
            if(root != null && root.val <= expectNumber){
                list.Add(root.val);
                expectNumber -= root.val;
                if(expectNumber == 0 && root.left == null && root.right == null){
                    pathList.Add(new List<int>(list));
                }
                FindPath(root.left, expectNumber);
                FindPath(root.right, expectNumber);
                list.RemoveAt(list.Count - 1);
            }
            return pathList;
        }

        public void Print(List<List<int>> lists){
            if(lists == null){
                Console.WriteLine("null");
                return;
            }
            foreach (List<int> list in lists)
            {
                foreach (int item in list)
                {
                    Console.Write(item + " ");   
                }
                Console.WriteLine();
            }
        }

        public void Test() {
            
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(0);
            root.left.right = new TreeNode(1);
            root.left.left = new TreeNode(0);
            root.right = new TreeNode(1);
            root.right.right = new TreeNode(0);
            // root = null;

            int expectNumber = 2;

            Print(FindPath(root, expectNumber));
        }
    }
}
