/*
题目名称：
丑数

题目描述：
把只包含质因子2、3和5的数称作丑数（Ugly Number）。
例如6、8都是丑数，但14不是，因为它包含质因子7。 
习惯上我们把1当做是第一个丑数。求按从小到大的顺序的第N个丑数。

代码结构：
class Solution
{
    public int GetUglyNumber_Solution(int index)
    {
        // write code here
    }
}
*/
using System;
namespace GetUglyNumber {
    class Solution {

        public int GetUglyNumber_Solution(int index)
        {
            return index;
        }

        public void Test() {
            int index = 3;

            Console.WriteLine(GetUglyNumber_Solution(index));
        }
    }
}
