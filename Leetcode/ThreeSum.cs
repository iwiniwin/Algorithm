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

官方题解：
https://leetcode-cn.com/problems/3sum/solution/san-shu-zhi-he-by-leetcode-solution/
*/
using System;
using System.Collections.Generic;
namespace ThreeSum {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 题目要求是不可重复的三元组，例如为了避免重复的 a + b + c = 0 和 b + c + a = 0
        /// 只要要求a <= b <= c，即可，所以首先对数组进行排序，
        /// 按从小到大的顺序，三重循环枚举所有的三元组
        /// 注意排序无法解决重复元素的情况，还需要额外处理，每次循环如果当前元素与上次元素相同，则可以直接跳过
        /// 当第一层循环确定a时
        /// 第二层循环确定b时，当第三层循环确定c后，满足a + b + c = 0，找到一个三元组
        /// 继续第二层循环，向右找，此时的b'一定大于b（因为是从小到大的顺序）
        /// 那么根据b' > b，想要满足a + b' + c' = 0，则c'必须小于c，即c'一定在c的左边
        /// 所以后两层循环可以变成双指针遍历，b是从左到右查找，c是从右到左查找，从而将时间复杂度由O(n^2)降为O(n)
        /// </summary>

        public IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> lists = new List<IList<int>>();
            Array.Sort(nums);
            for(int i = 0; i < nums.Length; i ++){
                if(i > 0 && nums[i] == nums[i - 1]) continue;
                int k = nums.Length - 1;
                for(int j = i + 1; j < nums.Length; j ++){
                    if(j > i + 1 && nums[j] == nums[j - 1]) continue;
                    while(k > j && nums[j] + nums[k] + nums[i] > 0)
                        k --;
                    if(k == j) break;
                    if(nums[j] + nums[k] + nums[i] == 0)
                        lists.Add(new List<int>(){nums[i], nums[j], nums[k]});
                }
            }
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
            // nums = new int[]{};
            // nums = new int[]{0, 0};
            // nums = new int[]{0, 0 , 0, 0};
            // nums = new int[]{2, 1 , -1, 0, -2, -1};
            
            Print(ThreeSum(nums));
        }
    }
}
