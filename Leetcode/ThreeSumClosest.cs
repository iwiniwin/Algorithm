/*
题目名称：
最接近的三数之和

题目描述：
给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。
返回这三个数的和。假定每组输入只存在唯一答案。

示例：
输入：nums = [-1,2,1,-4], target = 1
输出：2
解释：与 target 最接近的和是 2 (-1 + 2 + 1 = 2) 。

提示：
3 <= nums.length <= 10^3
-10^3 <= nums[i] <= 10^3
-10^4 <= target <= 10^4

代码结构：
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {

    }
}

题目链接：
https://leetcode-cn.com/problems/3sum-closest/
*/
using System;
using System.Collections.Generic;
namespace ThreeSumClosest {

    class Solution {

        public int ThreeSumClosest(int[] nums, int target) {
            return 0;
        }

        public void Test() {
            int[] nums = new int[]{-1, 2, 1, -4};
            int target = 1;
            
            Console.WriteLine(ThreeSumClosest(nums, target));
        }
    }
}
