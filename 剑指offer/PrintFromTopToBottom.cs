/*
题目名称：
从上往下打印二叉树

题目描述：
从上往下打印出二叉树的每个节点，同层节点从左至右打印。

代码结构：
class Solution
{
    public List<int> PrintFromTopToBottom(TreeNode root)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintFromTopToBottom {

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

        public List<int> PrintFromTopToBottom(TreeNode root)
        {
            return null;
        }

        public void Print(List<int> list){
            if(list == null){
                Console.WriteLine("null");
                return;
            }
            foreach(int item in list)
                Console.WriteLine(item);
        }

        public void Test() {
            
            TreeNode root = new TreeNode(1);

            Print(PrintFromTopToBottom(root));
        }
    }
}
