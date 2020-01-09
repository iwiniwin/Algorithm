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

    class Solution {

        public void Insert(int num)
        {
            // write code here
        }

        public double GetMedian()
        {
            return 0;
        }

        public void Test() {

            Insert(1);
            Insert(2);
            Insert(3);

            Console.WriteLine(GetMedian());
        }
    }
}
