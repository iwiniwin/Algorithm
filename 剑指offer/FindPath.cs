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

        public List<List<int>> FindPath(TreeNode root, int expectNumber)
        {
            return null;
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

            int expectNumber = 2;

            Print(FindPath(root, expectNumber));
        }
    }
}
