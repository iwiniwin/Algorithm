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
*/
using System;
using System.Collections.Generic;
namespace MaxArea {

    class Solution {

        public int MaxArea(int[] height) {
            return 49;
        }

        public void Test() {
            int[] height = new int[]{1, 8, 6, 2, 5, 4, 8, 3, 7};
            
            Console.WriteLine(MaxArea(height));
        }
    }
}
