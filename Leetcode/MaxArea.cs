/*
题目名称：
盛最多水的容器

题目描述：
给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。
在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。
找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

说明：
你不能倾斜容器，且 n 的值至少为 2。

示例：
输入：[1,8,6,2,5,4,8,3,7]
输出：49

代码结构：
public class Solution {
    public int MaxArea(int[] height) {

    }
}

题目链接：
https://leetcode-cn.com/problems/container-with-most-water/

官方题解：
https://leetcode-cn.com/problems/container-with-most-water/solution/sheng-zui-duo-shui-de-rong-qi-by-leetcode-solution/
*/
using System;
using System.Collections.Generic;
namespace MaxArea {

    class Solution {

        /// <summary>
        /// 解法，双指针
        /// 基本思路：
        /// 使用左指针i指向数组左边界，使用右指针j指向数组右边界
        /// i,j就表示容器可能的边界，通过不断移动i，j，找出i，j构成容器的最大容量
        /// 那么i，j应该怎样移动呢
        /// 当height[i] < height[j]时，i应该向右移动。
        /// 原因是，此时的容器容量是 area = min(height[i], height[j]) * (j - i) = height[i] * (j - i)
        /// 如果i不动，j向左移动，则容量只会比area小，因为 (j - i)变小了，而 min(height[i], height[j]) 仍然是小于等于 height[i]
        /// 即无论怎么移动右指针，得到的容器容量都小于移动前容器的容量，也就是说，这个左指针对应的数不会作为容器的边界了，可以丢弃
        /// 同理当height[i] > height[j]时，j应该向左移动。
        /// 当height[i] == height[j]时，移动i还是移动j都是一样的
        /// </summary>

        public int MaxArea(int[] height) {
            int ans = 0;
            int i = 0, j = height.Length - 1;
            while(i < j){
                int area = (j - i) * Math.Min(height[i], height[j]);
                if(area > ans) ans = area;
                if(height[i] < height[j])
                    i ++;
                else
                    j --;
            }
            return ans;
        }

        public void Test() {
            int[] height = new int[]{1, 8, 6, 2, 5, 4, 8, 3, 7};
            // height = new int[]{2, 4};
            // height = new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 9};
            // height = new int[]{7, 9, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            // height = new int[]{5, 1, 1, 3, 1, 1, 1, 1, 1, 20, 9};
            
            Console.WriteLine(MaxArea(height));
        }
    }
}
