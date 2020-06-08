/*
题目名称：
两数之和

题目描述：
给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。

示例：
给定 nums = [2, 7, 11, 15], target = 9
因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]

代码结构：
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
    }
}
*/
using System;
namespace TwoSum {

    class Solution {

        public int[] TwoSum(int[] nums, int target) {
            return new int[]{0, 1};
        }

        public void Print(int[] nums){
            Console.WriteLine(nums[0]);
            Console.WriteLine(nums[1]);
        }

        public void Test() {
            int[] nums = new int[]{2, 7, 11, 15};
            int target = 9;

            Print(TwoSum(nums, target));
        }
    }
}
