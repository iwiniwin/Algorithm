/*
题目名称：
序列化二叉树

题目描述：
请实现两个函数，分别用来序列化和反序列化二叉树

二叉树的序列化是指：把一棵二叉树按照某种遍历方式的结果以某种格式保存为字符串，
从而使得内存中建立起来的二叉树可以持久保存。
序列化可以基于先序、中序、后序、层序的二叉树遍历方式来进行修改，
序列化的结果是一个字符串，序列化时通过 某种符号表示空节点（#），以 ！ 表示一个结点值的结束（value!）。

二叉树的反序列化是指：根据某种遍历顺序得到的序列化字符串结果str，重构二叉树。

代码结构：
class Solution
{
    public string Serialize(TreeNode root)
    {
        // write code here
    }
    public TreeNode Deserialize(string str)
    {
        // write code here
    }
}
*/
using System;
using System.Text;
using System.Collections.Generic;
namespace SerializeTree {

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

        public string Serialize(TreeNode root)
        {
            return null;
        }

        public TreeNode Deserialize(string str)
        {
            return null;
        }

        public void Print(TreeNode node) {

        }

        public void Test() {
            TreeNode pRoot = null;
            pRoot = new TreeNode(0);
            pRoot.left = new TreeNode(1);
            pRoot.left.left = new TreeNode(2);
            pRoot.left.right = new TreeNode(3);
            pRoot.right = new TreeNode(4);
            pRoot.right.left = new TreeNode(5);
            pRoot.right.right = new TreeNode(6);
            pRoot.right.right.left = new TreeNode(7);
            pRoot.right.right.right = new TreeNode(8);
            
            string str = Serialize(pRoot);
            Console.WriteLine(str);

            TreeNode node = Deserialize(str);
            Print(node);

            Console.WriteLine("-------------------------------");

            str = Serialize(node);
            Console.WriteLine(str);

            node = Deserialize(str);
            Print(node);
        }
    }
}
