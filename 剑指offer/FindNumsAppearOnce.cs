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

        /// <summary>
        /// 解法2，异或运算
        /// 基本思路：
        /// 利用异或运算的性质，两个相同的数字异或为0，任何数字和0异或都是其本身
        /// 题目提到除了两个只出现一次的数字A,B以外，其他数字都出现了两次，那么将数组中的所有元素进行异或运算
        /// 得到的结果ret一定就是A,B异或的值（根据上面两条异或的性质）
        /// 对于这个结果ret的二进制值按位遍历，找到第一个1所在的位置，记为index（这个1表示的是A,B中不同的位）
        /// 再遍历一次数组，根据每个元素的二进制index位置是否为1，进行分组。
        /// 每两个相同的元素一定都分在了一组，A，B一定不在一组
        /// 然后再对这两组元素按照最开始的思路依次异或，得到的值一定就是A和B
        /// </summary>

        public void FindNumsAppearOnce2(int[] array, int[] num1, int[] num2)
        {
            if(array == null){
                return;
            }
            int ret = 0;
            foreach(int i in array){
                ret ^= i;
            }
            int index = 0;
            while(ret > 0 && (ret & 1) == 0){
                ret >>= 1;
                index ++;
            }
            foreach(int i in array){
                if((i >> index & 1) == 1){
                    num1[0] ^= i;
                }else{
                    num2[0] ^= i;
                }
            }
        }

        public void Test() {

            int[] array = new int[]{};
            // array = null;
            array = new int[]{1, 2, 3, 3, 2, 4, 4, 5};
            // array = new int[]{1, 2, 2, 1, 3, 4, 4, 5, 6, 5};
            // array = new int[]{1, 2};


            int[] num1 = new int[1];
            int[] num2 = new int[1];
            // FindNumsAppearOnce(array, num1, num2);
            FindNumsAppearOnce2(array, num1, num2);

            Console.WriteLine(num1[0]);
            Console.WriteLine(num2[0]);
        }
    }
}
