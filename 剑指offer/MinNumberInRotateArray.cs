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

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 对于有序数组的查找问题，首先想到的就是二分查找。
        /// 本题是非递减数组的旋转数组，仍具有一定的顺序性，所以稍微修改一下二分查找仍然可以解题
        /// 旋转数组可以看成是由左右两个递增数组组成
        /// 通过将right指向的元素与middle指向的元素比较
        /// 如果小于，则说明middle处于左边的递增数组，left = middle + 1，搜寻范围右移
        /// 如果大于，则说明middle处于右边的递增数组，right = middle，搜寻范围左移
        /// 如果等于，此时并不能判断到底处于左边还是右边，可以看成是顺序性丢失了，此时right -- ，二分查找退化为普通顺序遍历
        /// 二分查找介绍 https://www.cnblogs.com/iwiniwin/p/10793650.html
        /// </summary>

        public int MinNumberInRotateArray2(int[] rotateArray){
            if(rotateArray.Length == 0) return 0;
            int left = 0, right = rotateArray.Length - 1;
            while(left < right){
                int middle = (right + left) / 2;
                if(rotateArray[right] < rotateArray[middle]){
                    left = middle + 1;
                }else if(rotateArray[right] > rotateArray[middle]){
                    right = middle;
                }else{
                    right --;
                }
            }
            return rotateArray[left];
        }

        public void Test() {

            int[] rotateArray = new int[]{1, 2, 3, 4, 0};
            rotateArray = new int[]{};
            rotateArray = new int[]{3, 4, 5, 5, 5, 6, 6, 1, 1, 2};
            // rotateArray = new int[]{3, 4, 5, 5, 2, 2};
            // rotateArray = new int[]{1, 2, 1};
            // rotateArray = new int[]{1, 0};
            // rotateArray = new int[]{1};
            // rotateArray = new int[]{10,1,10,10,10};
            rotateArray = new int[]{10,10,10,1,10,10};

            // Console.WriteLine(MinNumberInRotateArray(rotateArray));
            Console.WriteLine(MinNumberInRotateArray2(rotateArray));
        }
    }
}
