/*
题目名称：
数组中只出现一次的数字

题目描述：
一个整型数组里除了两个数字之外，其他的数字都出现了两次。请写程序找出这两个只出现一次的数字。

代码结构：
//num1,num2分别为长度为1的数组。传出参数
//将num1[0],num2[0]设置为返回结果
class Solution
{
    public void FindNumsAppearOnce(int[] array, int[] num1, int[] num2)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace FindNumsAppearOnce {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 遍历数组，统计每个数字出现的次数，然后返回出现次数等于1的数字
        /// </summary>

        public void FindNumsAppearOnce(int[] array, int[] num1, int[] num2)
        {
            if(array == null){
                return;
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for(int i = 0; i < array.Length; i ++){
                if(dic.ContainsKey(array[i])){
                    dic[array[i]] ++;
                }else{
                    dic[array[i]] = 1;
                }
            }
            bool flag = false;
            foreach(KeyValuePair<int, int> pair in dic){
                if(pair.Value == 1){
                    if (!flag){
                        num1[0] = pair.Key;
                        flag = true;
                    }else{
                        num2[0] = pair.Key;
                    }
                }
            }
        }

        public void Test() {

            int[] array = new int[]{};
            // array = null;
            // array = new int[]{1, 2, 3, 3, 2, 4, 4, 5};
            // array = new int[]{1, 2, 2, 1, 3, 4, 4, 5, 6, 5};
            array = new int[]{1, 2};


            int[] num1 = new int[1];
            int[] num2 = new int[1];
            FindNumsAppearOnce(array, num1, num2);

            Console.WriteLine(num1[0]);
            Console.WriteLine(num2[0]);
        }
    }
}
