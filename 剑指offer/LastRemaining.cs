/*
题目名称：
孩子们的游戏(圆圈中最后剩下的数)

题目描述：
每年六一儿童节,牛客都会准备一些小礼物去看望孤儿院的小朋友,今年亦是如此。
HF作为牛客的资深元老,自然也准备了一些小游戏。
其中,有个游戏是这样的:首先,让小朋友们围成一个大圈。然后,他随机指定一个数m,让编号为0的小朋友开始报数。
每次喊到m-1的那个小朋友要出列唱首歌,然后可以在礼品箱中任意的挑选礼物,并且不再回到圈中
从他的下一个小朋友开始,继续0...m-1报数....这样下去....直到剩下最后一个小朋友,可以不用表演
并且拿到牛客名贵的“名侦探柯南”典藏版(名额有限哦!!^_^)。
请你试着想下,哪个小朋友会得到这份礼品呢？(注：小朋友的编号是从0到n-1)

如果没有小朋友，请返回-1

代码结构：
class Solution
{
    public int LastRemaining_Solution(int n, int m)
    {
        // write code here
    }
}
*/
using System;
namespace LastRemaining {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 约瑟夫环问题，遍历到数组末尾时再从头开始遍历，模拟环
        /// 使用array数组记录每个编号是否被移除 0表示未移除 -1表示移除
        /// while循环不断遍历array数组，直到所有元素值都为-1，表示全部被移除
        /// 最后一个被移除的元素就是要找的小朋友
        /// </summary>

        public int LastRemaining_Solution(int n, int m)
        {
            int[] array = new int[n];
            int count = 0, temp = 0;
            int index = 0;
            while(count < n){
                if(index == n){
                    index = 0;
                }
                if(array[index] == 0){
                    if(temp == m - 1){
                        array[index] = -1;
                        temp = 0;
                        count ++;
                    }else{
                        temp ++;
                    }
                }
                index ++;
            }
            return index - 1;
        }


        public void Test() {

            int n = 1;
            // n = 0;
            // n = 5;
            // n = 6;

            int m = 1;
            // m = 2;
            // m = 3;

            Console.WriteLine(LastRemaining_Solution(n, m));
        }
    }
}
