/*
题目名称：
1到n中1的出现次数

题目描述：
给定一个整数n，返回从1到n的数字中1出现的个数。
例如：
n=5,1∼n为1, 2, 3, 4, 5。1,2,3,4,5。那么1出现了1次，所以返回1。
n=11,1∼n为1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11。
1,2,3,4,5,6,7,8,9,10,11。那么1出现的次数为1(出现1次)，10(出现1次)，11(有两个1，所以出现了2次)，所以返回4。

题目描述：
输入一个整数N。

输出描述:
输出一个整数表示答案

备注:
1<=N<=pow(10, 13)
*/

/// <summary>
/// 解题算法分析请参考 剑指offer/NumberOf1Between1AndN.cs
/// </summary>
using System;
namespace NumberOf1From1ToN {
    class Solution {

        /// <summary>
        /// 注意这里需要使用long类型，因为1<=N<=pow(10, 13)，超出了int类型的范围
        /// </summary>
        public long NumberOf1From1ToN(long n){
            long count = 0;
            for(long i = 1; i <= n; i = i *10){
                count += n / (i * 10) * i + Math.Min(Math.Max(0, n % (i * 10) - i + 1), i);
            }
            return count;
        }

        public static void Test() {
            string input = Console.ReadLine();
            long n = long.Parse(input);
            Solution s = new Solution();
            Console.WriteLine(s.NumberOf1From1ToN(n));
        }

    }
}