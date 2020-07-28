/*
题目名称：
除自身以外数组的乘积

题目描述：
给你一个长度为 n 的整数数组 nums，其中 n > 1，返回输出数组 output ，其中 output[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积。

示例 1：
输入: [1,2,3,4]
输出: [24,12,8,6]

提示：
题目数据保证数组之中任意元素的全部前缀元素和后缀（甚至是整个数组）的乘积都在 32 位整数范围内。

说明: 
请不要使用除法，且在 O(n) 时间复杂度内完成此题。

进阶：
你可以在常数空间复杂度内完成这个题目吗？（ 出于对空间复杂度分析的目的，输出数组不被视为额外空间。）

代码结构：
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

    }
}

题目链接：
https://leetcode-cn.com/problems/product-of-array-except-self/
*/
using System;
using System.Collections.Generic;
namespace ProductExceptSelf {

    class Solution {

        public int[] ProductExceptSelf(int[] nums) {
            return nums;
        }

        public void Print(int[] nums) {
            foreach (int item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void Test() {
            int[] nums = new int[]{1, 2, 3, 4};
            
            Print(ProductExceptSelf(nums));
        }
    }
}
