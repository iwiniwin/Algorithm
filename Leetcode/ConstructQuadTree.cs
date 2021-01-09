/*
题目名称：
建立四叉树

题目描述：
给你一个 n * n 矩阵 grid ，矩阵由若干 0 和 1 组成。请你用四叉树表示该矩阵 grid 。
你需要返回能表示矩阵的 四叉树 的根结点。
注意，当 isLeaf 为 False 时，你可以把 True 或者 False 赋值给节点，两种值都会被判题机制 接受 
我们可以按以下步骤为二维区域构建四叉树：
如果当前网格的值相同（即，全为 0 或者全为 1），将 isLeaf 设为 True ，将 val 设为网格相应的值，并将四个子节点都设为 Null 然后停止。
如果当前网格的值不同，将 isLeaf 设为 False， 将 val 设为任意值，然后如下图所示，将当前网格划分为四个子网格。
使用适当的子网格递归每个子节点。

示例：
输入：grid = [[0,1],[1,0]]
输出：[[0,1],[1,0],[1,1],[1,1],[1,0]]

代码结构：
public class Solution {
    public Node Construct(int[][] grid) {
        
    }
}

题目链接：
https://leetcode-cn.com/problems/construct-quad-tree/
*/
using System;
using System.Collections.Generic;
namespace ConstructQuadTree {

    public class Node {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }
        
        public Node(bool _val, bool _isLeaf) {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }
        
        public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    class Solution {

        /// <summary>
        /// 解法，递归
        /// 基本思路：
        /// 首先判断矩阵中的所有值是否相等，如果相等，则为叶子节点，直接返回
        /// 否则
        ///     1. 提取矩阵的上左部分，重复上述步骤，计算上左节点
        ///     1. 提取矩阵的上右部分，重复上述步骤，计算上右节点
        ///     1. 提取矩阵的下左部分，重复上述步骤，计算下左节点
        ///     1. 提取矩阵的下右部分，重复上述步骤，计算上右节点
        /// </summary>

        public Node Construct(int[][] grid) {
            return ConstructImple(grid, 0, grid[0].Length - 1, 0, grid.Length - 1);
        }

        public Node ConstructImple(int[][] grid, int left, int right, int top, int bottom) {
            if(left > right || top > bottom) return null;
            if(IsLeaf(grid, left, right, top, bottom)) {
                return new Node(grid[top][left] == 1 ? true : false, true);
            }
            int delta = (right - left) / 2;
            Node node = new Node(true, false);
            node.topLeft = ConstructImple(grid, left, left + delta, top, top + delta);
            node.topRight = ConstructImple(grid, left + delta + 1, right, top, top + delta);
            node.bottomLeft = ConstructImple(grid, left, left + delta, top + delta + 1, bottom);
            node.bottomRight = ConstructImple(grid, left + delta + 1, right, top + delta + 1, bottom);
            return node;
        }

        public bool IsLeaf(int[][] grid, int left, int right, int top, int bottom) {
            int ret = grid[top][left];
            for(int i = top; i <= bottom; i ++) {
                for(int j = left; j <= right; j ++) {
                    if(grid[i][j] != ret) {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Print(Node root) {
            Console.Write("[");
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0) {
                Node node = queue.Dequeue();
                if(node == null) {
                    Console.Write("null");
                }else{
                    Console.Write("[" + (node.isLeaf ? 1 : 0) + "," + (node.val ? 1 : 0) + "]");
                    queue.Enqueue(node.topLeft);
                    queue.Enqueue(node.topRight);
                    queue.Enqueue(node.bottomLeft);
                    queue.Enqueue(node.bottomRight);
                }
                if(queue.Count > 0)
                    Console.Write(",");
            }
            Console.WriteLine("]");
        }

        public void Test() {
            int[][] grid = new int[][]{
                new int[]{0, 1},
                new int[]{1, 0}
            };

            // grid = new int[][]{
            //     new int[]{0}
            // };

            // grid = new int[][]{
            //     new int[]{1, 1, 1, 1, 0, 0, 0, 0},
            //     new int[]{1, 1, 1, 1, 0, 0, 0, 0},
            //     new int[]{1, 1, 1, 1, 1, 1, 1, 1},
            //     new int[]{1, 1, 1, 1, 1, 1, 1, 1},
            //     new int[]{1, 1, 1, 1, 0, 0, 0, 0},
            //     new int[]{1, 1, 1, 1, 0, 0, 0, 0},
            //     new int[]{1, 1, 1, 1, 0, 0, 0, 0},
            //     new int[]{1, 1, 1, 1, 0, 0, 0, 0},
            // };

            // grid = new int[][]{
            //     new int[]{1, 1},
            //     new int[]{1, 1}
            // };

            // grid = new int[][]{
            //     new int[]{1, 1, 0, 0},
            //     new int[]{1, 1, 0, 0},
            //     new int[]{0, 0, 1, 1},
            //     new int[]{0, 0, 1, 1}
            // };

            // grid = new int[][]{
            //     new int[]{1, 1, 0, 0},
            //     new int[]{0, 0, 1, 1},
            //     new int[]{1, 1, 0, 0},
            //     new int[]{0, 0, 1, 1}
            // };
            
            Print(Construct(grid));
        }
    }
}
