/*
题目名称：
矩阵中的路径

题目描述：
请设计一个函数，用来判断在一个矩阵中是否存在一条包含某字符串所有字符的路径。
路径可以从矩阵中的任意一个格子开始，每一步可以在矩阵中向左，向右，向上，向下移动一个格子。
如果一条路径经过了矩阵中的某一个格子，则该路径不能再进入该格子。 
例如 a b c e s f c s a d e e 矩阵中包含一条字符串"bcced"的路径，
但是矩阵中不包含"abcb"路径，因为字符串的第一个字符b占据了矩阵中的第一行第二个格子之后，
路径不能再次进入该格子。

代码结构：
class Solution
{
    public bool hasPath(string matrix, int rows, int cols, string path)
    {
        // write code here
    }
}
*/
using System;
namespace HasPath {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 将matrix字符串转换为多维数组，分别以数组的每个元素为起点，判断路径是否存在
        /// 从起点开始按上下左右的顺序搜索，已经经过的元素标记为-1
        /// 如果此路不通，则回溯到上一层，并还原标记位
        /// </summary>

        public bool HasPathImpl(int[,] arr, int row, int col, string path, int index) {
            if(index >= path.Length){
                return true;
            }
            if(row < 0 || row >= arr.GetLength(0) || col < 0 || col >= arr.GetLength(1)){
                return false;
            }
            if(arr[row, col] == path[index]){
                int temp = arr[row, col];
                arr[row, col] = -1;
                bool ret = HasPathImpl(arr, row, col + 1, path, index + 1) || HasPathImpl(arr, row, col - 1, path, index + 1)
                    || HasPathImpl(arr, row + 1, col, path, index + 1) || HasPathImpl(arr, row - 1, col, path, index + 1);
                arr[row, col] = temp;
                return ret;
            }
            return false;
        }

        public bool HasPath(string matrix, int rows, int cols, string path)
        {
            int[,] arr = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = matrix[i * cols + j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bool ret = HasPathImpl(arr, i, j, path, 0);
                    if(ret){
                        return true;
                    }
                }
            }
            return false;
        }
    
        public void Test() {

            string matrix = "abcesfcsadee";
            int rows = 3;
            int cols = 4;
            string path = "bcced";
            // path = "abcb";
            // path = "bfb";

            Console.WriteLine(HasPath(matrix, rows, cols, path));
        }
    }
}
