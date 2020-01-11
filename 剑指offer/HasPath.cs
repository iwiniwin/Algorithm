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

        public bool HasPath(string matrix, int rows, int cols, string path)
        {
            return true;
        }
    
        public void Test() {

            string matrix = "abcesfcsadee";
            int rows = 3;
            int cols = 4;
            string path = "bcced";

            Console.WriteLine(HasPath(matrix, rows, cols, path));
        }
    }
}
