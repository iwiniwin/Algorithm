/*
题目名称：
按之字形顺序打印二叉树

题目描述：
请实现一个函数按照之字形打印二叉树，
即第一行按照从左到右的顺序打印，第二层按照从右至左的顺序打印，第三行按照从左到右的顺序打印，其他行以此类推。

代码结构：
class Solution
{
    public List<List<int>> Print(TreeNode pRoot)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintTree {

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

        public List<List<int>> Print(TreeNode pRoot)
        {
            List<List<int>> lists = new List<List<int>>();
            List<int> list = new List<int>();
            list.Add(0);
            lists.Add(list);
            return lists;
        }

        public void Dump(List<List<int>> lists) {
            foreach(List<int> list in lists){
                foreach(int i in list){
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public void Test() {
            TreeNode pRoot = null;
            pRoot = new TreeNode(0);
            pRoot.left = new TreeNode(1);
            pRoot.left.left = new TreeNode(2);
            pRoot.left.right = new TreeNode(3);
            pRoot.right = new TreeNode(1);
            pRoot.right.right = new TreeNode(2);
            pRoot.right.left = new TreeNode(3);

            Dump(Print(pRoot));
        }
    }
}
