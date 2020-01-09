/*
题目名称：
二叉搜索树的第k个结点

题目描述：
给定一棵二叉搜索树，请找出其中的第k小的结点。
例如，（5，3，7，2，4，6，8）中，按结点数值大小顺序第三小结点的值为4。

代码结构：
class Solution
{
    public TreeNode KthNode(TreeNode pRoot, int k)
    {
        // write code here
    }
}

补充：
二叉搜索树（Binary Search Tree）定义：
1. 可以是空树
2. 若不是空树
    若它的左子树不空，则左子树所有节点的值均小于它的根节点的值
    若它的右子树不空，则右子树所有节点的值均大于它的根节点的值
    它的左，右子树也分别为二叉搜索树
*/
using System;
using System.Text;
using System.Collections.Generic;
namespace KthNode {

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
        /// 根据二叉搜索树定义，采用中序遍历（先左节点，再根节点，再右节点）
        /// 找到的第k个节点，就是第k小的节点
        /// </summary>

        int index = 0;
        public TreeNode KthNode(TreeNode pRoot, int k)
        {
            if(pRoot != null){
                TreeNode node = KthNode(pRoot.left, k);
                if(node != null){
                    return node;
                }
            
                index ++;
                if(index == k){
                    return pRoot;
                }

                node = KthNode(pRoot.right, k);
                if(node != null){
                    return node;
                }
            }
            return null;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 中序遍历的非递归实现，利用辅助栈，优先入栈左节点，再入栈 出栈节点的右节点
        /// 每次出栈，相当于找到一个节点，找到的第k个节点即为第k小的节点
        /// </summary>

        public TreeNode KthNode2(TreeNode pRoot, int k)
        {
            if(pRoot == null) return null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(pRoot);
            TreeNode node = pRoot.left;
            while(stack.Count > 0 || node != null){
                if(node == null){
                    node = stack.Pop();
                    if(--k == 0){
                        return node;
                    }
                    node = node.right;
                }else{
                    stack.Push(node);
                    node = node.left;
                }
            }
            return null;
        }

        public void Test() {
            TreeNode pRoot = null;
            pRoot = new TreeNode(5);
            pRoot.left = new TreeNode(3);
            pRoot.right = new TreeNode(7);
            pRoot.left.left = new TreeNode(2);
            pRoot.left.right = new TreeNode(4);
            pRoot.right.left = new TreeNode(6);
            pRoot.right.right = new TreeNode(8);

            // TreeNode node = KthNode(pRoot, 1);
            TreeNode node = KthNode2(pRoot, 5);
            if(node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
