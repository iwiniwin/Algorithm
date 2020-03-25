/*
题目名称：
旋转数组的最小数字

题目描述：
把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。
输入一个非递减排序的数组的一个旋转，输出旋转数组的最小元素。
例如数组{3,4,5,1,2}为{1,2,3,4,5}的一个旋转，该数组的最小值为1。
NOTE：给出的所有元素都大于0，若数组大小为0，请返回0。

代码结构：
class Solution
{
    public int minNumberInRotateArray(int[] rotateArray)
    {
        // write code here
    }
}
*/
using System;
namespace MinNumberInRotateArray {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 对于非减数组来说，数组左边的元素一定小于等于数组右边的元素。
        /// 当对非减数组进行旋转后（把数组最开始的元素搬到末尾），
        /// 则在遍历过程中可能会出现左边的元素反而小于右边的元素，当第一次出现这种情况时，
        /// 一定是原非减数组的开头，即整个数组的最小元素。
        /// </summary>

        public int MinNumberInRotateArray(int[] rotateArray)
        {
            for(int i = 0; i < rotateArray.Length - 1; i ++){
                if(rotateArray[i] > rotateArray[i + 1]){
                    return rotateArray[i + 1];
                }
            }
            return rotateArray.Length == 0 ? 0 : rotateArray[rotateArray.Length - 1];
        }

        public void Test() {

            int[] rotateArray = new int[]{1, 2, 3, 4, 0};
            rotateArray = new int[]{};
            rotateArray = new int[]{3, 4, 5, 5, 5, 6, 6, 1, 1, 2};
            rotateArray = new int[]{3, 4, 5, 5, 2, 2};
            rotateArray = new int[]{1, 2, 1};

            Console.WriteLine(MinNumberInRotateArray(rotateArray));
        }
    }
}
