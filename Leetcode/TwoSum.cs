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

题目链接：
https://leetcode-cn.com/problems/two-sum/
*/
using System;
using System.Collections.Generic;
namespace TwoSum {

    class Solution {

        /// <summary>
        /// 解法1，暴力法
        /// 基本思路：
        /// 直接遍历数组每个元素，查找和是target的两个元素的下标
        /// </summary>

        public int[] TwoSum(int[] nums, int target) {
            int[] ret = new int[2];
            for(int i = 0; i < nums.Length; i ++){
                ret[0] = i;
                for(int j = i + 1; j < nums.Length; j ++){
                    if(nums[j] + nums[ret[0]] == target){
                        ret[1] = j;
                        return ret;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 空间换时间，利用hash表记录每个元素与下标之间的映射
        /// 遍历数组的过程中将已经遍历过的元素存入hash表中
        /// 后续的遍历再利用hash表中的记录来判断是否存在对应解
        /// </summary>

        public int[] TwoSum2(int[] nums, int target) {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i ++){
                int value = target - nums[i];
                if(dic.ContainsKey(value)){
                    return new int[]{dic[value], i};
                }
                dic[nums[i]] = i;
            }
            return null;
        }

        public void Print(int[] nums){
            if(nums == null){
                Console.WriteLine("null");
                return;
            }
            Console.WriteLine(nums[0]);
            Console.WriteLine(nums[1]);
        }

        public void Test() {
            int[] nums = new int[]{2, 7, 11, 15};
            // nums = new int[]{3, 2, 4};
            // nums = new int[]{3, 3, 4};
            
            int target = 9;
            // target = 22;
            // target = 66;
            // target = 6;

            // Print(TwoSum(nums, target));
            Print(TwoSum2(nums, target));
        }
    }
}
