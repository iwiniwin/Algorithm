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
using System.Collections.Generic;
namespace GetUglyNumber {
    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 丑数只包含因子2,3,5（除1以外），所以除1外的所有丑数都可以用2x * 3y * 5z表示
        /// 问题的关键在于如何按照从小到大的顺序获取丑数
        /// 显然的是每获取到一个丑数x，我们都可以通过2x，3x, 5x算出三个新的丑数，但是新算出的丑数和之前已经算出的丑数的大小不好比较
        /// 我们可以分三个队列来解决这个问题，分别是乘2，乘3，乘5的队列
        /// 通过乘以2得到的丑数都放到乘2的队列中，乘3和乘5的同理，这样单看每个队列中的丑数一定是从小到大排列的
        /// 此时这个三个队列头中的最小值就是整个待排丑数中的最小值，也就是我们要获取的下一个丑数值
        /// 下面的代码是利用q2,q3,q5一直表示各自队列的头被计算出来时使用的丑数的索引
        /// </summary>
        
        public int GetUglyNumber_Solution(int index)
        {
            if(index <= 0){
                return 0;
            }
            List<int> list = new List<int>(){1};
            int q2 = 0, q3 = 0, q5 = 0;
            for(int i = 1; i < index; i ++){
                int num = Math.Min(list[q2] * 2, Math.Min(list[q3] * 3, list[q5] * 5));
                if(list[q2] * 2 == num){
                    q2 ++;
                }
                if(list[q3] * 3 == num){
                    q3 ++;
                }
                if(list[q5] * 5 == num){
                    q5 ++;
                }
                list.Add(num);
            }
            return list[index - 1];
        }

        public void Test() {
            int index = 7;
            // index = 11;

            Console.WriteLine(GetUglyNumber_Solution(index));
        }
    }
}
