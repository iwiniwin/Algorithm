/*
题目名称：
栈的压入、弹出序列

题目描述：
输入两个整数序列，第一个序列表示栈的压入顺序，请判断第二个序列是否可能为该栈的弹出顺序。
假设压入栈的所有数字均不相等。
例如序列1,2,3,4,5是某栈的压入顺序，序列4,5,3,2,1是该压栈序列对应的一个弹出序列，
但4,3,5,1,2就不可能是该压栈序列的弹出序列。（注意：这两个序列的长度是相等的）

代码结构：
class Solution
{
    public bool IsPopOrder(int[] pushV, int[] popV)
    {
        // write code here
    }
}
*/
using System;
namespace IsPopOrder {

    class Solution {

        public bool IsPopOrder(int[] pushV, int[] popV)
        {
            return false;
        }

        public void Test() {
            
            int[] pushV = new int[]{1, 2, 3, 4, 5};

            int[] popV = new int[]{4, 5, 3, 2, 1};
            popV = new int[]{4, 3, 5, 1, 2};

            Console.WriteLine(IsPopOrder(pushV, popV));
        }
    }
}
