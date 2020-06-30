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

官方题解：
https://leetcode-cn.com/problems/3sum-closest/solution/zui-jie-jin-de-san-shu-zhi-he-by-leetcode-solution/
*/
using System;
using System.Collections.Generic;
namespace ThreeSumClosest {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 暴力解法，遍历所有的三数组合，找出最接近target的值
        /// 可以AC，没有超出时间限制，但时间复杂度较高O(n ^ 3)
        /// </summary>

        public int ThreeSumClosest(int[] nums, int target) {
            int ret = 0, diff = int.MaxValue;
            for(int i = 0; i < nums.Length - 2; i ++){
                for(int j = i + 1; j < nums.Length - 1; j ++){
                    for(int k = j + 1; k < nums.Length; k ++){
                        int sum = nums[i] + nums[j] + nums[k];
                        int abs = Math.Abs(sum - target);
                        if(abs < diff){
                            ret = sum;
                            diff = abs;
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 解法2，排序+双指针
        /// 基本思路：
        /// 这道题与ThreeSum.cs三数之和是类似的
        /// 首先需要对数组进行排序，因为对于没有任何规律的数组而言只能采用暴力解法，没有优化的空间
        /// 在枚举第一个元素之后，假设位置为i，则使左指针指向i + 1即左边界，使用右指针指向数组长度-1，即右边界
        /// 1. 如果a + b + c = target，则可以直接返回target，已经找到最接近的三数之和了
        /// 2. 如果a + b + c > target，则右指针向左移动，因为右指针右边的数据是逐渐增大的，
        ///    右边的元素显然会使三数之和更大于target，所以右边的数据都可以不用考虑了
        /// 3. 如果a + b + c < target，则左指针向右移动，因为左指针左边的数据是逐渐减小的，
        ///    左边的元素显然会使三数之和更小于target，所以左边的数据都可以不用考虑了
        /// 实际上双指针的思路，就是利用三数之和与target的关系，选择抛弃左边界还是右边界的元素，从而减少枚举范围
        /// </summary>

        public int ThreeSumClosest2(int[] nums, int target) {
            int ret = nums[0] + nums[1] + nums[2];
            Array.Sort(nums);
            for(int n = 0; n < nums.Length; n ++){
                if(n > 0 && nums[n] == nums[n - 1])
                    continue;
                int i = n + 1, j = nums.Length - 1;
                while(i < j){
                    int sum = nums[i] + nums[j] + nums[n];
                    if(sum == target)
                        return sum;
                    if(Math.Abs(sum - target) < Math.Abs(ret - target))
                        ret = sum;
                    if(sum > target){
                        j --;
                    }else{
                        i ++;
                    }
                }
            }
            return ret;
        }

        public void Test() {
            int[] nums = new int[]{-1, 2, 1, -4};
            // nums = new int[]{0, 0, 0};


            int target = 1;
            // target = 5;
            // target = -4;
            
            Console.WriteLine(ThreeSumClosest(nums, target));
            Console.WriteLine(ThreeSumClosest2(nums, target));
        }
    }
}
