/*
题目名称：
三数之和

题目描述：
给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有满足条件且不重复的三元组。
注意：答案中不可以包含重复的三元组。

示例：
给定数组 nums = [-1, 0, 1, 2, -1, -4]，
满足要求的三元组集合为：
[
  [-1, 0, 1],
  [-1, -1, 2]
]

代码结构：
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {

    }
}

题目链接：
https://leetcode-cn.com/problems/3sum/
*/
using System;
using System.Collections.Generic;
namespace ThreeSum {

    class Solution {

        public IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> lists = new List<IList<int>>(){
                new List<int>(){1, 2, 3},
                new List<int>(){4, 5, 6},
            };
            return lists;
        }

        public void Print(IList<IList<int>> lists){
            foreach(IList<int> list in lists){
                foreach(int i in list){
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public void Test() {
            int[] nums = new int[]{-1, 0, 1, 2, -1, -4};
            
            Print(ThreeSum(nums));
        }
    }
}
