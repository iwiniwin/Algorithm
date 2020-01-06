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

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 层次遍历，利用一个辅助队列，队列中依次保存二叉树每一层的所有节点
        /// 根据tag标记位判断每一层是从左到右还是从右到左
        /// </summary>

        public List<List<int>> Print(TreeNode pRoot)
        {
            List<List<int>> lists = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(pRoot);
            bool tag = false;
            while(queue.Count > 0){
                int count = queue.Count;
                tag = !tag;
                List<int> list = new List<int>();
                for(int i = 0; i < count; i ++){
                    TreeNode node = queue.Dequeue();
                    if(node != null){
                        if(tag){
                            list.Add(node.val);
                        }else{
                            list.Insert(0, node.val);
                        }
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }
                if(list.Count > 0){
                    lists.Add(list);
                }
            }
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
            pRoot.right = new TreeNode(4);
            pRoot.right.left = new TreeNode(5);
            pRoot.right.right = new TreeNode(6);
            pRoot.right.right.left = new TreeNode(7);
            pRoot.right.right.right = new TreeNode(8);
            
            Dump(Print(pRoot));
        }
    }
}
