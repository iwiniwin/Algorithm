/*
题目名称：
数组中重复的数字

题目描述：
在一个长度为n的数组里的所有数字都在0到n-1的范围内。
数组中某些数字是重复的，但不知道有几个数字是重复的。也不知道每个数字重复几次。
请找出数组中任意一个重复的数字。 
例如，如果输入长度为7的数组{2,3,1,0,2,5,3}，那么对应的输出是第一个重复的数字2。

代码结构：
class Solution
{
    public bool duplicate(int[] numbers, int[] duplication)
    {
        // write code here
    }
}
*/
using System;
namespace Duplicate {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用长度为n的辅助数组记录每个数字的出现次数
        /// </summary>

        public bool Duplicate(int[] numbers, int[] duplication)
        {
            if (numbers == null){
                return false;
            }
            int[] array = new int[numbers.Length];
            for(int i = 0; i < numbers.Length; i ++){
                if(++ array[numbers[i]] > 1){
                    duplication[0] = numbers[i];
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 不使用辅助数组，利用原数组保存遍历的信息
        /// 当一个数字被访问后，将该数字作为下标位置上的数减去数组的长度（使这个数一定小于0）
        /// 之后再遇到相同的数字时，发现对应的下标位置上的数已经小于0，则说明出现了重复元素
        /// </summary>

        public bool Duplicate2(int[] numbers, int[] duplication)
        {
            if (numbers == null){
                return false;
            }
            for(int i = 0; i < numbers.Length; i ++){
                int num = numbers[i] < 0 ? numbers[i] + numbers.Length : numbers[i];
                if(numbers[num] < 0){
                    duplication[0] = num;
                    return true;
                }
                numbers[num] -= numbers.Length;
            }
            return false;
        }

        public void Test() {

            int[] numbers = new int[]{2,3,1,0,2,5,3};
            // numbers = null;
            // numbers = new int[]{};
            // numbers = new int[]{0};
            // numbers = new int[]{0, 0};

            int[] duplication = new int[1];

            // Console.WriteLine(Duplicate(numbers, duplication));
            Console.WriteLine(Duplicate2(numbers, duplication));
            
            Console.WriteLine(duplication[0]);
        }
    }
}
