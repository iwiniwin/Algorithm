/*
题目名称：
数组中出现次数超过一半的数字

题目描述：
数组中有一个数字出现的次数超过数组长度的一半，请找出这个数字。
例如输入一个长度为9的数组{1,2,3,2,2,2,5,4,2}。由于数字2在数组中出现了5次，超过数组长度的一半，因此输出2。
如果不存在则输出0。

代码结构：
class Solution
{
    public int MoreThanHalfNum_Solution(int[] numbers)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace MoreThanHalfNum {
    class Solution {

        /*解法1
        基本思路：
        利用Dictinary记录每个元素的出现次数，如果该元素出现次数大于数组的一半则输出
        */
        public int MoreThanHalfNum_Solution(int[] numbers)
        {
            if (numbers == null) return 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(int i in numbers){
                if (dic.ContainsKey(i)){
                    dic[i] ++;
                }else{
                    dic.Add(i, 1);
                }
                if (dic[i] > numbers.Length / 2){
                    return i;
                }
            }
            return 0;
        }

        /*解法2
        基本思路：
        如果存在元素的数量大于数组的一半，那么排序后，数组中间的那个数一定是该元素。
        比如{1,2,2,2,2,2,3,4,5}
        排序后再判断数组中间的那个数出现次数是否大于数组长度的一半
        */
        public int MoreThanHalfNum_Solution2(int[] numbers)
        {
            if (numbers != null && numbers.Length > 0){
                Array.Sort(numbers);
                int num = numbers[numbers.Length / 2];
                int count = 0;
                foreach(int i in numbers){
                    if (i == num){
                        count ++;
                    }
                }
                if (count > numbers.Length / 2){
                    return num;
                }
            }
            return 0;
        }

        /*解法3
        阵地攻守
        */
        public int MoreThanHalfNum_Solution3(int[] numbers)
        {
            return 0;
        }

        public void Test() {
            int[] numbers = new int[]{1,2,3,2,2,2,5,4,2};
            // int[] numbers = null;
            // numbers = null;
            numbers = new int[]{1, 3, 3};
            // Console.WriteLine(MoreThanHalfNum_Solution(numbers));
            Console.WriteLine(MoreThanHalfNum_Solution2(numbers));
        }
    }
}
