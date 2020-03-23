/*
题目名称：
替换空格

题目描述：
请实现一个函数，将一个字符串中的每个空格替换成“%20”。
例如，当字符串为We Are Happy.则经过替换之后的字符串为We%20Are%20Happy。

代码结构：
class Solution
{
    public string ReplaceSpace(string str)
    {
        // write code here
    }
}
*/
using System;
using System.Text;
namespace ReplaceSpace {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 这道题比较简单，就是遍历该字符串每一个字符进行复制，遇到空格就复制成%20
        /// 这里针对C#语言使用了StringBuilder，在频繁改动字符串时，相比直接使用string类型，减少了内存开销
        /// </summary>

        public string ReplaceSpace(string str)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length ; i ++)
            {
                if(str[i] == ' '){
                    builder.Append("%20");
                }else{
                    builder.Append(str[i]);
                }
            }
            return builder.ToString();
        }

        public void Test() {

            string str = "We Are Happy";
            str = " We   Are Happy ";

            Console.WriteLine(ReplaceSpace(str));
        }
    }
}
