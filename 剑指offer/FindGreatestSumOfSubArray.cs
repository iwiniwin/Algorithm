/*
题目名称：
连续子数组的最大和

题目描述：
HZ偶尔会拿些专业问题来忽悠那些非计算机专业的同学。今天测试组开完会后,他又发话了:
在古老的一维模式识别中,常常需要计算连续子向量的最大和,当向量全为正数的时候,问题很好解决。
但是,如果向量中包含负数,是否应该包含某个负数,并期望旁边的正数会弥补它呢？
例如:{6,-3,-2,7,-15,1,2,2},连续子向量的最大和为8(从第0个开始,到第3个为止)。
给一个数组，返回它的最大连续子序列的和，你会不会被他忽悠住？(子向量的长度至少是1)

代码结构：
class Solution
{
    public int FindGreatestSumOfSubArray(int[] array)
    {
        // write code here
    }
}
*/
using System;
namespace FindGreatestSumOfSubArray {
    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 依次遍历数组元素，是否吸收前面的元素作为连续子数组的前缀的标准是，它们的和是否为正数
        /// 例如当遍历到元素A时
        /// 判断元素A前面的元素和是否是正数，是正数，则加上A对最终的结果产生积极影响，保留前面的元素
        /// 否则丢弃前面的元素直接从A开始继续寻找最大和。
        /// </summary>
        public int FindGreatestSumOfSubArray(int[] array)
        {
            if(array == null || array.Length == 0){
                return 0;
            }
            int max = array[0];
            int sum = max;
            for(int i = 1; i < array.Length; i ++){
                if(sum < 0){
                    sum = array[i];
                }else{
                    sum += array[i];
                }
                if(sum > max){
                    max = sum;
                }
            }
            return max;
        }

        /// <summary>
        /// 解法2，动态规划
        /// 基本思路：
        /// 可以这样理解，假设前n-1个连续元素最大和为x，
        /// 那前n个连续元素最大和就是x加最后一个元素值和最后一个元素值中的较大值
        /// F(n) = max(F(n -1) + array[n], array[n])，这里的array[n]表示数组末尾元素的值
        /// 注意这里的F(n)，并不表示最终结果。最终结果应该是F(1),F(2)..F(n)中的较大值
        /// </summary>
        public int FindGreatestSumOfSubArray2(int[] array)
        {
            if(array == null || array.Length == 0){
                return 0;
            }
            int f = array[0], m = f;
            for(int i = 1; i < array.Length; i ++){
                f = (f + array[i]) > array[i] ? (f + array[i]) : array[i];
                m = m > f ? m : f;
            }
            return m;
        }

        public void Test() {
            int[] array = new int[]{6,-3,-2,7,-15,1,2,6};
            array = new int[]{-9, -8, 2, -1, 3};
            // array = null;

            // Console.WriteLine(FindGreatestSumOfSubArray(array));
            Console.WriteLine(FindGreatestSumOfSubArray2(array));
        }

    }
}
