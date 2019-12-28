/*
题目名称：
表示数值的字符串

题目描述：
请实现一个函数用来判断字符串是否表示数值（包括整数和小数）。
例如，字符串"+100","5e2","-123","3.1416"和"-1E-16"都表示数值。 
但是"12e","1a3.14","1.2.3","+-5"和"12e+4.3"都不是。

代码结构：
class Solution
{
    public bool isNumeric(char[] str)
    {
        // write code here
    }
}
*/
using System;
namespace IsNumeric {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 根据数值字符串标准判断，每个字符满足如下条件
        /// 1. 字符是'0'-'9'
        /// 2. 字符是'+'或'-'，只能出现在首位或'e'/'E'的后面
        /// 2. 字符是'e'/'E'，只能出现一次，且不能在首尾
        /// 2. 字符是'.'，只能出现一次，且不能在首位（可以在尾部），且不能在'e'/'E'之后出现
        /// </summary>

        public bool IsNumeric(char[] str)
        {
            if(str == null || str.Length == 0) return false;
            int dotCount = 0, eCount = 0;
            for(int i = 0; i < str.Length; i ++){
                if(str[i] >= '0' && str[i] <= '9') continue;
                if(str[i] == '+' || str[i] == '-'){
                    if(i == 0 || (i > 0 && (str[i - 1] == 'e' || str[i - 1] == 'E'))) continue;
                }
                if((str[i] == 'e' || str[i] == 'E') && i > 0 && i < str.Length - 1 && eCount == 0){
                    eCount ++;
                    continue;
                }
                if(str[i] == '.' && i > 0 && i < str.Length && eCount == 0 && dotCount == 0){
                    dotCount ++;
                    continue;
                }
                return false;
            }
            return true;
        }

        public void Test() {

            char[] str = new char[]{'1', '.', '2', '.', '3'};
            // str = new char[]{'+', '1', '2'};
            // str = new char[]{'5', 'e', '2'};
            // str = new char[]{'3', '.', '1', '4'};
            // str = new char[]{'-', '1', 'E', '-', '5'};
            // str = new char[]{'1', '2', 'e'};
            // str = new char[]{'1', '2', 'e', '+', '4', '.', '3'};
            // str = new char[]{'1', 'a', '3', '.', '4'};

            Console.WriteLine(IsNumeric(str));
        }
    }
}
