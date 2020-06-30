﻿using System;

namespace Algorithm
{
    /// <summary>
    /// Leetcode算法题目 模块
    /// </summary>
    class LeetcodeProgram
    {
        public static void Test()
        {
            
            // new TwoSum.Solution().Test();                           // 两数之和
            // new FindMedianSortedArrays.Solution().Test();           // 寻找两个正序数组的中位数
            // new LongestPalindrome.Solution().Test();                // 最长回文子串
            // new Atoi.Solution().Test();                             // 字符串转换整数 (atoi)
            // new LongestCommonPrefix.Solution().Test();              // 最长公共前缀
            // new ThreeSum.Solution().Test();                         // 三数之和
            new ThreeSumClosest.Solution().Test();                  // 最接近的三数之和
        }
    }
}