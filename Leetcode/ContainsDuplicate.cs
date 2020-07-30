/*
题目名称：
存在重复元素

题目描述：
给定一个整数数组，判断是否存在重复元素。
如果任意一值在数组中出现至少两次，函数返回 true 。如果数组中每个元素都不相同，则返回 false 。

示例 1:
输入: [1,2,3,1]
输出: true

示例 2:
输入: [1,2,3,4]
输出: false

示例 3:
输入: [1,1,1,3,3,4,3,2,4,2]
输出: true

代码结构：
public class Solution {
    public bool ContainsDuplicate(int[] nums) {

    }
}

题目链接：
https://leetcode-cn.com/problems/contains-duplicate/

补充：
本题目除了利用哈希表和朴素的线性查找（双层循环直接查找）外，还可以先对数组进行排序，如果有重复元素，排序后一定是相邻的
*/
using System;
using System.Collections.Generic;
namespace ContainsDuplicate {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 利用哈希表
        /// 这里使用C#的HashSet，基于散列值，插入元素非常快，不包含重复项，插入重复元素时会返回false
        /// </summary>

        public bool ContainsDuplicate(int[] nums) {
            HashSet<int> set = new HashSet<int>();
            for(int i = 0; i < nums.Length; i ++){
                if(set.Add(nums[i]) == false)
                    return true;
            }
            return false;
        }

        public void Test() {
            int[] nums = new int[]{1, 2, 3, 1};
            // nums = new int[]{1, 2, 3, 4};
            // nums = new int[]{1, 1, 1, 3, 3, 4, 3, 2, 4, 2};

            Console.WriteLine(ContainsDuplicate(nums));
        }
    }
}
