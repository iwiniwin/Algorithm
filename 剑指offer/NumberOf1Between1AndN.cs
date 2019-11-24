/*
题目名称：
整数中1出现的次数（从1到n整数中1出现的次数）

题目描述：
求出1~13的整数中1出现的次数,并算出100~1300的整数中1出现的次数？
为此他特别数了一下1~13中包含1的数字有1、10、11、12、13因此共出现6次,但是对于后面问题他就没辙了。
ACMer希望你们帮帮他,并把问题更加普遍化,
可以很快的求出任意非负整数区间中1出现的次数（从1 到 n 中1出现的次数）。

代码结构：
class Solution
{
    public int NumberOf1Between1AndN_Solution(int n)
    {
        // write code here
    }
}
*/
using System;
namespace NumberOf1Between1AndN {
    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 逐一考察1~n的每一个数里有多少个1。每个数字可以通过对10求余来判断最后一位是否为1
        /// 时间复杂度是n*ln(n)
        /// </summary>
        public int NumberOf1Between1AndN_Solution(int n)
        {
            int count = 0;
            for(int i = 1; i < n + 1; i ++){
                int m = i;
                while(m > 0){
                    if(m % 10 == 1){
                        count ++;
                    }
                    m = m / 10;
                }
            }
            return count;
        }

        /// <summary>
        /// 解法2，数学归纳法
        /// 首先来看每个数字的个位是1的情况
        /// 以0-9为一个阶段会包含一个1，包含x个完整阶段就包含x个1。
        /// 对非完整阶段，比如6，显然如果这个数小于1就包含0个，大于等于1就包含1个
        /// 因此公式是：n / 10 * 1 + (n % 10) < 1 ? 0 : 1 
        /// 再来看十位
        /// 以0-99为一个阶段，十位上会包含10个1（10 - 19）
        /// 对于非完整阶段，假设为m，如果m小于10就是0个，m大于等于10且小于19就是m - 10 + 1，m大于19就是10
        /// 再来看百位
        /// 以0-999为一个阶段，百位上会包含100个1（100 - 199）
        /// 对于非完整阶段，假设为m，如果m小于100就是0个，m大于等于100且小于199就是m - 100 + 1，m大于199就是100
        /// 千位，万位等等以此类推，总结公式就是
        /// 以i表示位数
        /// count(i) = n / (i * 10) * i + f(n % (i * 10))
        /// f(mod) = if(mod < i) return 0 elseif mod < (2 * i -1)  return mod - i + 1 else return i
        /// 对于f(mod)中的if else同样可以再进行归纳
        /// f(mod) = (0和mod - i + 1中的较大值)和i中的较小值
        /// </summary>
        public int NumberOf1Between1AndN_Solution2(int n)
        {
            int count = 0;
            for(int i = 1; i <= n; i = i * 10){
                count += n / (i * 10) * i + Math.Min(Math.Max(0, n % (i * 10) - i + 1), i);
            }
            return count;
        }

        public void Test() {
            Console.WriteLine(NumberOf1Between1AndN_Solution(11));
            Console.WriteLine(NumberOf1Between1AndN_Solution2(1));
        }

    }
}
