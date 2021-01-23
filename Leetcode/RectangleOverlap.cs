/*
题目名称：
矩形重叠

题目描述：
矩形以列表 [x1, y1, x2, y2] 的形式表示，其中 (x1, y1) 为左下角的坐标，(x2, y2) 是右上角的坐标。矩形的上下边平行于 x 轴，左右边平行于 y 轴。
如果相交的面积为正 ，则称两矩形重叠。需要明确的是，只在角或边接触的两个矩形不构成重叠。
给出两个矩形 rec1 和 rec2 。如果它们重叠，返回 true；否则，返回 false 。

示例1：
输入：rec1 = [0,0,2,2], rec2 = [1,1,3,3]
输出：true

示例2：
输入：rec1 = [0,0,1,1], rec2 = [1,0,2,1]
输出：false

示例3：
输入：rec1 = [0,0,1,1], rec2 = [2,2,3,3]
输出：false

代码结构：
public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {

    }
}

题目链接：
https://leetcode-cn.com/problems/rectangle-overlap/
*/
using System;
using System.Collections.Generic;
namespace RectangleOverlap {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 反向思维，检查两个矩形的位置，如果这两个矩形不重叠，则矩形1可能在矩形的左侧，上侧，右侧，或者下侧
        /// 如果第一个矩形在第二个矩形的左侧且不重叠，则矩形1的右下角横坐标必须小于等于矩形2左上角的横坐标
        /// 同理，可判断上侧，右侧，以及下侧
        /// 如果这些条件两个矩形没有一个满足的，就说明两个矩形重叠
        /// </summary>
        public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
            // left top right bottom
            return !(rec1[2] <= rec2[0] || rec1[1] >= rec2[3] || rec1[0] >= rec2[2] || rec1[3] <= rec2[1] || 
                rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3]);
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 如果两个矩形重叠，则两个矩形的水平边，投影到x轴以后的两条线段也一定重合
        /// 如果两个矩形重叠，则两个矩形的垂直边，投影到y轴以后的两条线段也一定重合
        /// 所以最终将问题转换为求解两条线段是否重合的问题
        /// </summary>
        public bool IsRectangleOverlap2(int[] rec1, int[] rec2) {
            return Math.Max(rec1[0], rec2[0]) < Math.Min(rec1[2], rec2[2]) &&
                Math.Max(rec1[1], rec2[1]) < Math.Min(rec1[3], rec2[3]);
        }

        public void Test() {
            int[] rec1 = new int[]{0, 0, 2, 2};
            int[] rec2 = new int[]{1, 1, 3, 3};

            rec1 = new int[]{0, 0, 1, 1};
            rec2 = new int[]{1, 0, 2, 1};

            // rec1 = new int[]{0, 0, 2, 2};
            // rec2 = new int[]{2, 2, 3, 3};

            // Console.WriteLine(IsRectangleOverlap(rec1, rec2));
            Console.WriteLine(IsRectangleOverlap2(rec1, rec2));
        }
    }
}
