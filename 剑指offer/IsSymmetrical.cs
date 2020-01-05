/*
题目名称：
对称的二叉树

题目描述：
请实现一个函数，用来判断一颗二叉树是不是对称的。
注意，如果一个二叉树同此二叉树的镜像是同样的，定义其为对称的。

代码结构：
class Solution
{
    public bool isSymmetrical(TreeNode pRoot)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace IsSymmetrical {

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
        /// 解法1，递归
        /// 基本思路：
        /// 判断一棵二叉树是否是对称的，就是递归判断它的左右子树是否是对称
        /// 1. 左子树的val是否等于右子树的val
        /// 2. 左子树的左子树是否和右子树的右子树对称
        /// 3. 左子树的右子树是否和右子树的左子树对称
        /// </summary>

        public bool IsSymmetricalImpl(TreeNode root1, TreeNode root2){
            if(root1 == null && root2 == null){
                return true;
            }
            if(root1 != null && root2 != null && root1.val == root2.val){
                return IsSymmetricalImpl(root1.left, root2.right) && IsSymmetricalImpl(root1.right, root2.left);
            }
            return false;
        }

        public bool IsSymmetrical(TreeNode pRoot)
        {
            if(pRoot != null){
                return IsSymmetricalImpl(pRoot.left, pRoot.right);
            }
            return true;
        }

        /// <summary>
        /// 解法2，BFS
        /// 基本思路：
        /// 广度优先搜索，每次左子树和右子树成对入队，成对出队
        /// 出队时，比较这一对，记为left，right
        /// 1. 都为空，继续
        /// 2. 一个为空一个不为空，返回false
        /// 3. 都不为空，比较val，不相等返回false
        /// 4. val相等，继续入队(left.left，right.right), (left.right, right.left)
        /// </summary>

        public bool IsSymmetrical2(TreeNode pRoot)
        {
            if(pRoot == null){
                return true;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(pRoot.left);
            queue.Enqueue(pRoot.right);
            while(queue.Count > 0){
                TreeNode left = queue.Dequeue();
                TreeNode right = queue.Dequeue();
                if(left == null && right == null){
                    continue;
                }
                if(left != null && right != null && left.val == right.val){
                    queue.Enqueue(left.left);
                    queue.Enqueue(right.right);
                    queue.Enqueue(left.right);
                    queue.Enqueue(right.left);
                }else{
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 解法3，DFS
        /// 基本思路：
        /// 深度优先搜索，基本思路与BFS类似，只是使用栈保存成对的节点
        /// </summary>

        public bool IsSymmetrical3(TreeNode pRoot)
        {
            if(pRoot == null){
                return true;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(pRoot.left);
            stack.Push(pRoot.right);
            while(stack.Count > 0){
                TreeNode left = stack.Pop();
                TreeNode right = stack.Pop();
                if(left == null && right == null){
                    continue;
                }
                if(left == null || right == null){
                    return false;
                }
                if(left.val != right.val){
                    return false;
                }
                stack.Push(left.left);
                stack.Push(right.right);
                stack.Push(left.right);
                stack.Push(right.left);
            }
            return true;
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

            // Console.WriteLine(IsSymmetrical(pRoot));
            // Console.WriteLine(IsSymmetrical2(pRoot));
            Console.WriteLine(IsSymmetrical3(pRoot));
        }
    }
}
