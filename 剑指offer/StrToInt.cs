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

        public int StrToInt(string str)
        {
            return 123;
        }

        public void Test() {

            string str = "123";

            Console.WriteLine(StrToInt(str));
        }
    }
}
