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

        public bool IsNumeric(char[] str)
        {
            return true;
        }

        public void Test() {

            char[] str = new char[]{'1', '.', '2', '.', '3'};

            Console.WriteLine(IsNumeric(str));
        }
    }
}
