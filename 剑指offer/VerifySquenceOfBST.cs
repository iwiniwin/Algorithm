/*
题目名称：
二叉搜索树的后序遍历序列

题目描述：
输入一个非空整数数组，判断该数组是不是某二叉搜索树的后序遍历的结果。
如果是则输出Yes,否则输出No。假设输入的数组的任意两个数字都互不相同。

代码结构：
class Solution
{
    public bool VerifySquenceOfBST(int[] sequence)
    {
        // write code here
    }
}
*/
using System;
namespace VerifySquenceOfBST {

    class Solution {

        public bool VerifySquenceOfBST(int[] sequence)
        {
            return false;
        }

        public void Test() {
            
            int[] sequence = new int[]{1, 2, 3};

            Console.WriteLine(VerifySquenceOfBST(sequence));
        }
    }
}
