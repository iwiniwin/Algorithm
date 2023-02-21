/*
题目名称：
数组中重复的数字

题目描述：
在一个长度为n的数组里的所有数字都在0到n-1的范围内。
数组中某些数字是重复的，但不知道有几个数字是重复的。也不知道每个数字重复几次。
请找出数组中任意一个重复的数字。 
例如，如果输入长度为7的数组[2,3,1,0,2,5,3]，那么对应的输出是2或者3。存在不合法的输入的话输出-1

代码结构：
class Solution {
    public int duplicate (List<int> numbers) {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace Duplicate {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用长度为n的辅助数组记录每个数字的出现次数
        /// </summary>

        public int Duplicate(List<int> numbers)
        {
            if (numbers == null){
                return -1;
            }
            int[] array = new int[numbers.Count];
            for(int i = 0; i < numbers.Count; i ++){
                if(++ array[numbers[i]] > 1){
                    return numbers[i];
                }
            }
            return -1;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 不使用辅助数组，利用原数组保存遍历的信息
        /// 当一个数字被访问后，将该数字作为下标位置上的数减去数组的长度（使这个数一定小于0）
        /// 之后再遇到相同的数字时，发现对应的下标位置上的数已经小于0，则说明出现了重复元素
        /// </summary>

        public int Duplicate2(List<int> numbers)
        {
            if (numbers == null){
                return -1;
            }
            for(int i = 0; i < numbers.Count; i ++){
                int num = numbers[i] < 0 ? numbers[i] + numbers.Count : numbers[i];
                if(numbers[num] < 0){
                    return num;
                }
                numbers[num] -= numbers.Count;
            }
            return -1;
        }

        /// <summary>
        /// 解法3
        /// 基本思路：
        /// 不使用辅助数组
        /// 每访问到一个数字，判断这个数字与其下标是否相等，若不相等，则将该数字与以该数字值为下标的位置上的数字进行交换
        /// 如果要交换的两个数字相等，则找到了重复数字
        /// 可以理解为，让每个数字都在以其值为下标的位置上，如果有重复的数字，那它的位置一定会被重复值占领
        /// </summary>

        public int Duplicate3(List<int> numbers)
        {
            if (numbers == null){
                return -1;
            }
            for(int i = 0; i < numbers.Count; i ++){
                while(i != numbers[i]){
                    int temp = numbers[numbers[i]];
                    if(numbers[i] == temp){
                        return numbers[i];
                    }
                    numbers[numbers[i]] = numbers[i];
                    numbers[i] = temp;
                }
            }
            return -1;
        }

        public void Test() {

            List<int> numbers = new List<int>{2,3,1,0,2,5,3};
            // numbers = null;
            // numbers = new List<int>{};
            // numbers = new List<int>{0};
            // numbers = new List<int>{0, 0};
            // numbers = new List<int>{0, 2, 3, 3, 2};

            Console.WriteLine(Duplicate(numbers));
            // Console.WriteLine(Duplicate2(numbers));
            // Console.WriteLine(Duplicate3(numbers));
        }
    }
}
