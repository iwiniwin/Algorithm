/*
题目名称：
重建二叉树

题目描述：
输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。
假设输入的前序遍历和中序遍历的结果中都不含重复的数字。
例如输入前序遍历序列{1,2,4,7,3,5,6,8}和中序遍历序列{4,7,2,1,5,3,8,6}，则重建二叉树并返回。

代码结构：
class Solution
{
    public TreeNode ReConstructBinaryTree(int[] pre, int[] tin)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace ReConstructBinaryTree {

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
        /// 解法
        /// 基本思路：
        /// 前序遍历是先根节点再左右节点。所以前序序列的第一个节点一定是根节点
        /// 中序遍历是先左节点，再根节点，再右节点。那么在中序序列中找到根节点以后，
        /// 根节点左边的元素为左子树中序序列，根节点右边的元素为右子树中序序列
        /// 根据左右子树的元素数量，可以再在前序序列中分别找出左右子树的前序序列
        /// 再递归重构左右子树即可
        /// 举个例子，比如中序序列{4,7,2,1,5,3,8,6}，前序序列{1,2,4,7,3,5,6,8}，根节点是1。
        /// 那么A的左子树是由1左边的中序序列{4,7,2}构成的二叉树A1，
        /// A的右子树是由1右边的中序序列{5,3,8,6}构成的二叉树A2。
        /// 因为A1的中序序列是{4,7,2}，元素个数是3，所以A的前序序列中，
        /// 根节点1后面的三个元素即{2,4,7}就是A1的前序序列。
        /// 所以A2的前序序列就是{2,4,7}后面的所有元素，即{3,5,6,8}
        /// 到现在，我们已经把已知A的前序序列和中序序列求A的问题，转换为已知A1的前序中序序列求A1，已知A2的前序中序序列求A2的问题。
        /// 继续递归下去，就可以重建出这颗二叉树了。
        /// 前中后序遍历介绍 https://www.cnblogs.com/iwiniwin/p/10793652.html
        /// </summary>

        public TreeNode ReConstructBinaryTree(int[] pre, int preLeft, int preRight, int[] tin, int tinLeft, int tinRight){
            if(preLeft > preRight || tinLeft > tinRight) return null;
            TreeNode node = new TreeNode(pre[preLeft]);
            for(int i = 0; i <= tinRight - tinLeft; i ++){
                if(tin[i + tinLeft] == pre[preLeft]){
                    node.left = ReConstructBinaryTree(pre, preLeft + 1, preLeft + i, tin, tinLeft, tinLeft + i - 1);
                    node.right = ReConstructBinaryTree(pre, preLeft + i + 1, preRight, tin, tinLeft + i + 1, tinRight);
                    break;
                }
            }
            return node;
        }

        public TreeNode ReConstructBinaryTree(int[] pre, int[] tin)
        {
            return ReConstructBinaryTree(pre, 0, pre.Length - 1, tin, 0, tin.Length - 1);
        }

        public void Print(TreeNode head){
            if (head == null){
                Console.WriteLine("null");
                return ;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(head);
            while(queue.Count > 0){
                int count = queue.Count;
                for(int i = 0; i < count; i++){
                    TreeNode node = queue.Dequeue();
                    Console.Write(node.val + " ");;
                    if(node.left != null) queue.Enqueue(node.left);
                    if(node.right != null) queue.Enqueue(node.right);
                }
                Console.WriteLine();
            }
        }

        public void Test() {

            int[] pre = new int[]{1,2,4,7,3,5,6,8};
            int[] tin = new int[]{4,7,2,1,5,3,8,6};

            pre = new int[]{0};
            tin = new int[]{0};

            pre = new int[]{0, 1};
            tin = new int[]{1, 0};
            
            Print(ReConstructBinaryTree(pre, tin));
        }
    }
}
