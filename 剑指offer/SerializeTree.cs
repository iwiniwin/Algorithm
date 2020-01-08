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

        /// <summary>
        /// 解法1，层次遍历
        /// 基本思路：
        /// 序列化，利用一个辅助队列，遍历树，队列中依次保存二叉树每一层的所有节点
        /// 空节点使用'#'表示，节点之间通过'!'分隔
        /// 反序列化，与序列化相同的遍历方式构造树
        /// </summary>

        public string Serialize(TreeNode root)
        {
            StringBuilder builder = new StringBuilder();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0){
                int count = queue.Count;
                for(int i = 0; i < count; i ++){
                    TreeNode node = queue.Dequeue();
                    if(node == null){
                        builder.Append("#");
                    }else{
                        builder.Append(node.val);
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                    builder.Append("!");
                }
            }
            return builder.ToString();
        }

        public TreeNode Deserialize(string str)
        {
            if (str == null) return null;
            string[] arr = str.Split("!");
            if (arr.Length <= 0 || arr[0] == "#") return null;
            TreeNode root = new TreeNode(int.Parse(arr[0]));
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int index = 0;
            while(queue.Count > 0){
                int count = queue.Count;
                for(int i = 0; i < count; i ++){
                    TreeNode node = queue.Dequeue();
                    if(++index >= arr.Length){
                        return root;
                    }
                    if(arr[index] != "#"){
                        node.left = new TreeNode(int.Parse(arr[index]));
                        queue.Enqueue(node.left);
                    }

                    if(++index >= arr.Length){
                        return root;
                    }

                    if(arr[index] != "#"){
                        node.right = new TreeNode(int.Parse(arr[index]));
                        queue.Enqueue(node.right);
                    }
                }
            }
            return root;
        }

        /// <summary>
        /// 解法2，先序遍历
        /// 基本思路：
        /// 先序遍历，递归，序列化字符串
        /// 利用int[]数组，引用类型，记录index值，按照先序遍历规则反序列化字符串
        /// </summary>

        public string Serialize2(TreeNode root)
        {
            if(root == null){
                return "#!";
            }
            return root.val + "!" + Serialize2(root.left) + Serialize2(root.right);
        }

        public TreeNode Deserialize2Impl(string[] arr, int[] indices) {
            if(arr[indices[0]] == "#"){
                return null;
            }
            TreeNode node = new TreeNode(int.Parse(arr[indices[0]]));
            indices[0] ++;
            node.left = Deserialize2Impl(arr, indices);
            indices[0] ++;
            node.right = Deserialize2Impl(arr, indices);
            return node;
        }

        public TreeNode Deserialize2(string str)
        {
            if(str == null || str.Length == 0) {
                return null;
            }
            return Deserialize2Impl(str.Split("!"), new int[]{0});
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
            pRoot.right.right.right.left = new TreeNode(9);
            
            // string str = Serialize(pRoot);
            string str = Serialize2(pRoot);
            Console.WriteLine(str);

            // TreeNode node = Deserialize(str);
            TreeNode node = Deserialize2(str);

            // str = Serialize(node);
            str = Serialize2(node);
            Console.WriteLine(str);

        }
    }
}
