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
https://leetcode-cn.com/problems/median-of-two-sorted-arrays/

官方题解：
https://leetcode-cn.com/problems/median-of-two-sorted-arrays/solution/xun-zhao-liang-ge-you-xu-shu-zu-de-zhong-wei-s-114/
*/
using System;
using System.Collections.Generic;
namespace FindMedianSortedArrays {

    class Solution {

        /// <summary>
        /// 解法1，二分查找
        /// 基本思路：
        /// 如果对复杂度的要求中有log，通常都需要用到二分查找
        /// 这道题求取两个有序数组的中位数可以转换成寻找两个有序数组的第k小的数，其中k为(m + n) / 2 或者 (m + n ) / 2 + 1
        /// 假设两个有序数组A和B，要找到第k个元素，可以先比较A[k / 2 - 1] = Ai和B[k / 2 - 1] = Bj
        /// 比Ai和Bj小的元素总和最多有 (k / 2 - 1) + (k / 2 - 1) = k - 2个元素，所以这k - 2个元素一定不会是第k小的元素，都是可以舍弃的
        /// 如果Ai < Bj，那么Ai顶多就是第k - 1小的数，也可以舍弃，即Ai以及Ai前的元素都可以舍弃
        /// 如果Bj < Ai，那么Bj顶多就是第k - 1小的数，也可以舍弃，即Bj以及Bj前的元素都可以舍弃
        /// </summary>

        public double FindMedianSortedArraysImpl(int[] nums1, int i, int[] nums2, int j, int k) {
            if(nums1 == null || nums1.Length == 0 || i >= nums1.Length) return nums2[j + k - 1];
            if(nums2 == null || nums2.Length == 0 || j >= nums2.Length) return nums1[i + k - 1];
            if(k == 1) return Math.Min(nums1[i], nums2[j]);
            int index = k / 2 - 1; 
            if(i + index >= nums1.Length) index = nums1.Length - i - 1;
            if(j + index >= nums2.Length) index = nums2.Length - j - 1;
            k = k - index - 1;
            if(nums1[i + index] <= nums2[j + index])
                return FindMedianSortedArraysImpl(nums1, i + index + 1, nums2, j, k);
            else
                return FindMedianSortedArraysImpl(nums1, i, nums2, j + index + 1, k);
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int k = (nums1?.Length ?? 0) + (nums2?.Length ?? 0);
            if((k & 1) == 1)
                return FindMedianSortedArraysImpl(nums1, 0, nums2, 0, k / 2 + 1);
            else
                return (FindMedianSortedArraysImpl(nums1, 0, nums2, 0, k / 2) + FindMedianSortedArraysImpl(nums1, 0, nums2, 0, k / 2 + 1)) / 2;
        }

        public void Test() {
            int[] nums1 = new int[]{1, 2};
            // nums1 = new int[]{1, 3};
            // nums1 = new int[]{1, 4, 7};
            // nums1 = new int[]{1};
            // nums1 = null;

            int[] nums2 = new int[]{3, 4};
            // nums2 = new int[]{2};
            // nums2 = new int[]{4};
            // nums2 = new int[]{2, 7, 9};
            // nums2 = new int[]{2, 3, 4, 5, 6};
            // nums2 = null;

            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        }
    }
}
