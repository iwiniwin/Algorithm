/*
算法名称：
哈夫曼Huffman

算法描述：
哈夫曼树，是最优二叉树。给定n个权值作为n个叶子节点，构造一棵二叉树，若树的带权路径长度达到最小，则这棵树被称为哈夫曼树
哈夫曼算法具有贪心选择性质与最优子结构
哈夫曼编码就是哈夫曼树在电讯通信中的应用之一，可以通过哈夫曼树设计总长最短的二进制前缀编码。
电文中的某个字符即对应哈夫曼树的某个叶子节点，每个字符的编码即为从根节点到每个叶子节点的路径上得到的0,1序列。（比如走了左子树则记0，走右子树则记1）

补充：
为了保证解码的唯一性，要求任意字符的编码都不能是另一字符编码的前缀，这种编码称为前缀编码，哈夫曼编码就是一种前缀编码
*/
using System;
using System.Collections.Generic;
namespace Huffman {

    class Solution {

        public class TreeNode : IComparable<TreeNode>
        {
            public float weight;  // 权重
            public char symbol;          // 符合
            public TreeNode left;
            public TreeNode right;
            public TreeNode (float x)
            {
                weight = x;
            }
            public TreeNode (float x, char c)
            {
                weight = x;
                symbol = c;
            }
            public int CompareTo(TreeNode other) {
                int ret = this.weight.CompareTo(other.weight);
                // 这里是为了使SortedSet可以存放权重相同的节点。（SortedSet默认是会过滤重复值的元素的）
                if(ret == 0)
                    return this.GetHashCode().CompareTo(other.GetHashCode());
                return ret;
            }
            public Dictionary<char, string> CodingMap {
                get {
                    Dictionary<char, string> map = new Dictionary<char, string>();
                    caculateCodingMap(this, map, "");
                    return map;
                }
            }
            // 计算哈夫曼树的带权路径长度，WPL（Weighted Path Length of Tree）
            public float WPL {
                get {
                    return caculateWpl(this, 0);
                }
            }
            // 计算哈夫曼树中对应字符的编码（默认规则是，走左子树编码加0，走右子树编码加1）
            private float caculateWpl(TreeNode node, int depth) {
                if(node == null) return 0.0f;
                if(node.left != null || node.right != null) {
                    return caculateWpl(node.left, depth + 1) + caculateWpl(node.right, depth + 1);
                }
                return node.weight * depth;
            }
            private void caculateCodingMap(TreeNode node, Dictionary<char, string> map, string str) {
                if(node == null) return;
                if(node.left == null || node.right == null) {
                    map.Add(node.symbol, str);
                    return;
                }
                caculateCodingMap(node.left, map, str + "0");
                caculateCodingMap(node.right, map, str + "1");
            }
        }

        /// <summary>
        /// 基本思路：
        /// 假设有n个权值，则构造出来的哈夫曼树有n个叶子节点。n个权值分别设为w1,w2,...wn，则哈夫曼树的构造规则为
        /// 1. 将w1,w2,...wn看成是有n棵树的森林（每棵树仅有一个节点）
        /// 2. 在森林中选出两个根节点的权值最小的树合并，作为一棵新树的左、右子树，且新树的根节点权值为其左右子树根节点权值之和
        /// 3. 从森林中删除选取的两棵树，并将新树加入森林
        /// 4. 重复2、3步骤，直到森林中只剩下一棵树为止，该树即为所求的哈夫曼树
        /// </summary>

        public TreeNode HuffmanTree(float[] weights, char[] symbols = null) {
            if(weights == null || weights.Length <= 0) return null;
            SortedSet<TreeNode> set = new SortedSet<TreeNode>();
            for(int i = 0; i < weights.Length; i ++) {
                TreeNode node = new TreeNode(weights[i]);
                set.Add(node);
                if(symbols != null)
                    node.symbol = symbols[i];
            }

            while(set.Count > 1) {
                TreeNode left = set.Min;
                set.Remove(left);
                TreeNode right = set.Min;
                set.Remove(right);

                TreeNode root = new TreeNode(left.weight + right.weight);
                root.left = left;
                root.right = right;
                set.Add(root);
            }
            
            return set.Min;
        }

        // 层次遍历打印哈夫曼树
        public void Print(TreeNode root) {
            Console.WriteLine("huffman tree:");
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if(root != null)
                queue.Enqueue(root);
            while(queue.Count > 0) {
                int count = queue.Count;
                for(int i = 0; i < count; i ++) {
                    TreeNode node = queue.Dequeue();
                    Console.Write(node.symbol + "_" + node.weight + " ");
                    if(node.left != null)
                        queue.Enqueue(node.left);
                    if(node.right != null)
                        queue.Enqueue(node.right);
                }
                Console.WriteLine();
            }
        }

        public void Test() {
            char[] symbols = new char[]{'A', 'B', 'C', 'D', 'E'};
            float[] weights = new float[]{2, 3, 4, 5, 4};

            TreeNode tree = HuffmanTree(weights, symbols);

            Print(tree);

            Console.WriteLine("huffman tree wpl:");
            Console.WriteLine(tree.WPL);

            Console.WriteLine("huffman tree coding map:");
            foreach (var item in tree.CodingMap)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
