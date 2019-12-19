/*
题目名称：
扑克牌顺子

题目描述：
LL今天心情特别好,因为他去买了一副扑克牌,发现里面居然有2个大王,2个小王(一副牌原本是54张^_^)...
他随机从中抽出了5张牌,想测测自己的手气,看看能不能抽到顺子,如果抽到的话,他决定去买体育彩票,嘿嘿！！
“红心A,黑桃3,小王,大王,方片5”,“Oh My God!”不是顺子.....
LL不高兴了,他想了想,决定大\小 王可以看成任何数字,并且A看作1,J为11,Q为12,K为13。
上面的5张牌就可以变成“1,2,3,4,5”(大小王分别看作2和4),“So Lucky!”。LL决定去买体育彩票啦。 
现在,要求你使用这幅牌模拟上面的过程,然后告诉我们LL的运气如何， 如果牌能组成顺子就输出true，否则就输出false。为了方便起见,你可以认为大小王是0。

代码结构：
class Solution
{
    public bool IsContinuous(int[] numbers)
    {
        // write code here
    }
}
*/
using System;
namespace IsContinuous {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 先将数组进行排序，同时计算0的个数
        /// 遍历排序后的数组，要满足，不能有相同元素，不连续元素用0足够补
        /// </summary>

        public void Swap(int[] array, int i, int j){
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public bool IsContinuous(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0){
                return false;
            }

            int count = 0;
            for(int i = 0; i < numbers.Length; i ++){
                int index = i;
                for(int j = i + 1; j < numbers.Length; j ++){
                    if (numbers[j] < numbers[index]){
                        index = j;
                    }
                }
                if(numbers[index] == 0){
                    count ++;
                }
                Swap(numbers, i, index);
            }

            for(int i = count; i < numbers.Length - 1; i ++){
                int minus = numbers[i + 1] - numbers[i];
                if(minus != 1){
                    if(minus == 0){
                        return false;
                    }else if((minus - 1) <= count){
                        count -= (minus - 1);
                    }else{
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 满足如下条件的牌可以组成顺子：
        /// 1. 除0以外，没有重复的牌
        /// 2. 除0以外，统计最大牌和最小牌，最大牌-最小牌的差值要小于牌的总数
        /// </summary>

        public bool IsContinuous2(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0){
                return false;
            }
            int[] array = new int[14];
            int max = -1, min = 14;
            for(int i = 0; i < numbers.Length; i ++){
                array[numbers[i]] ++;
                if(numbers[i] == 0){
                    continue;
                }
                if(array[numbers[i]] > 1){
                    return false;
                }
                if(numbers[i] > max){
                    max = numbers[i];
                }
                if(numbers[i] < min){
                    min = numbers[i];
                }
            }
            if(max - min < numbers.Length){
                return true;
            }
            return false;
        }

        public void Test() {

            int[] numbers = new int[]{1, 3, 0, 0, 5};
            // numbers = null;
            // numbers = new int[]{};
            // numbers = new int[]{0};
            // numbers = new int[]{1, 2, 3, 0, 6};
            // numbers = new int[]{1, 2, 3, 0, 6, 0};
            // numbers = new int[]{1, 2, 3, 4, 4};
            // numbers = new int[]{1, 2, 3, 4, 4, 0, 0};
            // numbers = new int[]{1, 2, 3, 4, 6};

            // Console.WriteLine(IsContinuous(numbers));
            Console.WriteLine(IsContinuous2(numbers));
        }
    }
}
