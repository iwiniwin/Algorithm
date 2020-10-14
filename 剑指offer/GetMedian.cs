/*
题目名称：
数据流中的中位数

题目描述：
如何得到一个数据流中的中位数？
如果从数据流中读出奇数个数值，那么中位数就是所有数值排序之后位于中间的数值。
如果从数据流中读出偶数个数值，那么中位数就是所有数值排序之后中间两个数的平均值。
我们使用Insert()方法读取数据流，使用GetMedian()方法获取当前读取数据的中位数。

代码结构：
class Solution
{
    public void Insert(int num)
    {
        // write code here
    }

    public double GetMedian()
    {
        // write code here
    }
}
*/
using System;
namespace GetMedian {

    public class TreeNode {
        public TreeNode left;
        public TreeNode right;
        public int val;
        public TreeNode(int x){
            val = x;
        }
    }

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 插入时，动态构建二叉搜索树，小于根节点值的放到左子树，大于等于根节点值的放到右子树
        /// 获取中位数时查找儿叉搜索树即可
        /// </summary>

        TreeNode root = null;
        int count = 0;
        int index = 0;
        public void Insert(int num)
        {
            count ++;
            if(root == null){
                root = new TreeNode(num);
                return;
            }
            TreeNode node = root;
            while(true){
                if(num < node.val){
                    if(node.left == null || node.left.val < num){
                        TreeNode temp = node.left;
                        node.left = new TreeNode(num);
                        node.left.left = temp;
                        return;
                    }
                    node = node.left;
                }else{
                    if(node.right == null || node.right.val > num){
                        TreeNode temp = node.right;
                        node.right = new TreeNode(num);
                        node.right.right = temp;
                        return;
                    }
                    node = node.right;
                }
            }
        }

        public TreeNode GetKthNode(TreeNode pRoot, int k){
            if(pRoot != null && k > 0){
                TreeNode node = GetKthNode(pRoot.left, k);
                if(node != null){
                    return node;
                }
                index ++;
                if(index == k){
                    return pRoot;
                }
                node = GetKthNode(pRoot.right, k);
                if(node != null){
                    return node;
                }
            }
            return null;
        }

        public double GetMedian()
        {
            index = 0;
            if(count > 0){
                int median = count / 2 + 1 ;
                TreeNode node = GetKthNode(root, median);
                if((count & 1) == 0){
                    index = 0;
                    TreeNode last = GetKthNode(root, median - 1);
                    return (last.val + node.val) / 2.0d;
                }else{
                    return node.val;
                }
            }
            return 0;
        }

        /// <summary>
        /// TODO 利用优先队列，构建两个堆，大顶堆和小顶堆
        /// </summary>

        public void Test() {

            Insert(1);
            Insert(3);
            Insert(4);
            Insert(1);

            Console.WriteLine(GetMedian());
        }
    }
}
