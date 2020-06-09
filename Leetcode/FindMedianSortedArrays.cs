/*
题目名称：
寻找两个正序数组的中位数

题目描述：
给定两个大小为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。
请你找出这两个正序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。
你可以假设 nums1 和 nums2 不会同时为空。

示例1：
nums1 = [1, 3]
nums2 = [2]
则中位数是 2.0

示例2：
nums1 = [1, 2]
nums2 = [3, 4]
则中位数是 (2 + 3)/2 = 2.5

代码结构：
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {

    }
}

题目链接：
https://leetcode-cn.com/problems/two-sum/
*/
using System;
using System.Collections.Generic;
namespace FindMedianSortedArrays {

    class Solution {

        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            return 0;
        }

        public void Test() {
            int[] nums1 = new int[]{1, 2};
            int[] nums2 = new int[]{3, 4};

            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        }
    }
}
