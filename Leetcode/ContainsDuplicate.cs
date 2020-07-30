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
*/
using System;
using System.Collections.Generic;
namespace ContainsDuplicate {

    class Solution {

        public bool ContainsDuplicate(int[] nums) {
            return true;
        }

        public void Test() {
            int[] nums = new int[]{1, 2, 3, 1};
            
            Console.WriteLine(ContainsDuplicate(nums));
        }
    }
}
