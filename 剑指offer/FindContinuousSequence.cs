/*
题目名称：
和为S的连续正数序列

题目描述：
小明很喜欢数学,有一天他在做数学作业时,要求计算出9~16的和,他马上就写出了正确答案是100。
但是他并不满足于此,他在想究竟有多少种连续的正数序列的和为100(至少包括两个数)。
没多久,他就得到另一组连续正数和为100的序列:18,19,20,21,22。
现在把问题交给你,你能不能也很快的找出所有和为S的连续正数序列? Good Luck!

输出描述:
输出所有和为S的连续正数序列。序列内按照从小至大的顺序，序列间按照开始数字从小到大的顺序

代码结构：
using System.Collections.Generic;
class Solution
{
    public List<List<int>> FindContinuousSequence(int sum)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace FindContinuousSequence {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用双指针，构造一个“窗口”，计算这个窗口内的元素之和（公式：(首+尾)*个数/2 ）
        /// 如果和等于sum，则将窗口内的元素加入到列表中，同时窗口整体右移，寻找下一个和等于sum的窗口
        /// 如果和小于sum，则right指针右移，增大窗口内的元素之和
        /// 如果和大于sum，则left指针右移，减小窗口内的元素之和
        /// </summary>

        public List<List<int>> FindContinuousSequence(int sum) {
            List<List<int>> lists = new List<List<int>>();
            int left =  1, right = 2;
            while(left < right && right < sum){
                int cur = (left + right) * (right - left + 1) / 2;
                if(cur == sum){
                    List<int> list = new List<int>();
                    for(int i = left; i <= right; i ++){
                        list.Add(i);
                    }
                    lists.Add(list);
                    left ++;
                    right ++;
                }else if(cur < sum){
                    right ++;
                }else{
                    left ++;
                }
            }
            return lists;
        }

        public void Print(List<List<int>> lists) {
            foreach(List<int> list in lists){
                foreach(int i in list){
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public void Test() {

            int sum = 100;
            // sum = 102;
            // sum = 1;

            List<List<int>> lists = FindContinuousSequence(sum);
            Print(lists);
        }
    }
}
