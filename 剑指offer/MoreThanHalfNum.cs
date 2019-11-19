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
        基本思路：
        类似于阵地攻守，
        第一个数字作为第一个士兵，守阵地 count = 1
        遇到相同数字：count++
        遇到不同数字：count--，即遇到敌人
        当遇到count = 0的情况，这表示该士兵阵亡，使用下一个数字代替
        如果一个元素的数量超过数组长度的一半，则它的数量应该比其他剩余元素数量之和还要多，则剩下的那个数字就是该元素
        最后再加一次循环，判断该元素数量是否查过数组长度的一半即可
        */
        public int MoreThanHalfNum_Solution3(int[] numbers)
        {
            if (numbers != null && numbers.Length > 0){
                int count = 0;
                int num = 0;
                foreach(int i in numbers){
                    if (count == 0){
                        num = i;
                        count = 1;
                    }else
                    {
                        if(i == num){
                            count ++;
                        }else{
                            count --;
                        }
                    }
                }
                count = 0;
                foreach (int i in numbers)
                {
                    if (i == num) {
                        count ++;
                    }
                }
                if (count > numbers.Length / 2) {
                    return num;
                }
            }
            return 0;
        }

        public void Test() {
            int[] numbers = new int[]{1,2,3,2,2,2,5,4,2};
            // numbers = null;
            // numbers = new int[]{0, 1, 0};
            // Console.WriteLine(MoreThanHalfNum_Solution(numbers));
            // Console.WriteLine(MoreThanHalfNum_Solution2(numbers));
            // Console.WriteLine(MoreThanHalfNum_Solution3(numbers));
        }
    }
}
