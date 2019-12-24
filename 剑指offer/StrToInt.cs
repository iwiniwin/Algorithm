/*
题目名称：
把字符串转换成整数

题目描述：
将一个字符串转换成一个整数，要求不能使用字符串转换整数的库函数。 
数值为0或者字符串不是一个合法的数值则返回0

输入描述：
输入一个字符串,包括数字字母符号,可以为空

输出描述：
如果是合法的数值表达则返回该数字，否则返回0

代码结构：
class Solution
{
    public int StrToInt(string str)
    {
        // write code here
    }
}
*/
using System;
namespace StrToInt {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 按顺序遍历字符串，判断每个字符是否是合法数字字符（在'0'-'9'之间）
        /// 如果都是合法字符，计算出所表示的数值
        /// 注意需要处理int类型的越界问题
        /// </summary>

        public int StrToInt(string str)
        {
            if (str == null){
                return 0;
            }
            int num = 0, step = 1;
            for(int i = str.Length - 1; i >= 0; i --){
                int n = (int)str[i] - 48;
                if (n >= 0 && n <= 9){
                    num += step * n;
                    if(num < 0 && ((num - 1) < 0 || i == 0)){
                        return 0;
                    }
                    step *= 10;
                }else if(i == 0){
                    if (str[i] == '-'){
                        num = -num;
                    }else if(str[i] != '+' || num < 0){
                        return 0;
                    }
                }else{
                    return 0;
                }
            }
            return num;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 和解法1一样的思路，只是精简了代码，同时使用了位运算提高效率
        /// (ret << 1) + (ret << 3) = ret * 2 + ret * 8 = ret * 10
        /// str[i] & 0x0f 取str[i]的后四位，'0'-'9'的后四位正好是0 - 9
        /// </summary>

        public int StrToInt2(string str) {
            if (str == null || str.Length == 0){
                return 0;
            }
            int sign = str[0] == '-' ? -1 : 1;
            int ret = 0;
            for(int i = (str[0] == '+' || str[0] == '-') ? 1 : 0; i < str.Length; i ++){
                if (!(str[i] >= '0' && str[i] <= '9')) return 0;
                ret = (ret << 1) + (ret << 3) + (str[i] & 0x0f);
                if (ret < 0 && (!(ret == int.MinValue && str[0] == '-'))) return 0;
            }
            return sign * ret;
        }

        public void Test() {

            string str = "123";
            // str = "";
            // str = null;
            // str = "+125";
            // str = "-26";
            // str = "12a";
            // str = "0";
            // str = "-2147483649";
            // str = "2147483649";
            // str = "-2147483648";
            // str = "+2147483648";
            // str = "2147483648";

            // Console.WriteLine(StrToInt(str));
            Console.WriteLine(StrToInt2(str));
        }
    }
}
