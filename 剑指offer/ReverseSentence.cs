/*
题目名称：
翻转单词顺序列

题目描述：
牛客最近来了一个新员工Fish，每天早晨总是会拿着一本英文杂志，写些句子在本子上。
同事Cat对Fish写的内容颇感兴趣，有一天他向Fish借来翻看，但却读不懂它的意思。
例如，“student. a am I”。
后来才意识到，这家伙原来把句子单词的顺序翻转了，正确的句子应该是“I am a student.”。
Cat对一一的翻转这些单词顺序可不在行，你能帮助他么？

代码结构：
class Solution
{
    public string ReverseSentence(string str)
    {
        // write code here
    }
}
*/
using System;
namespace ReverseSentence {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用Split函数将字符串根据" "拆分成多个子字符串，翻转子字符串的顺序，然后再用Join函数通过" "连接起来
        /// </summary>

        public void Reverse(string[] array, int m, int n){
            for(int i = m, j = n; i < j; i++, j--){
                string temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public string ReverseSentence(string str)
        {
            if (str == null){
                return null;
            }
            string[] strs = str.Split(" ");
            Reverse(strs, 0, strs.Length - 1);
            return string.Join(" ", strs);
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 一个一个字符处理，用tmp保存' '之前的字符串，遇到' '之后，将tmp添加到结果的前面
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public string ReverseSentence2(string str)
        {
            if (str == null){
                return null;
            }
            string ret = "", tmp = "";
            for(int i = 0; i < str.Length; i ++){
                if(str[i] == ' '){
                    ret = ' ' + tmp + ret;
                    tmp = "";
                }else{
                    tmp += str[i];
                }
            }
            ret = tmp + ret;
            return ret;
        }

        public void Test() {

            string str = "student. a am I";
            // str = "";
            // str = "am I";
            // str = "am ";
            // str = null;

            // Console.WriteLine(ReverseSentence(str));
            Console.WriteLine(ReverseSentence2(str));
        }
    }
}
