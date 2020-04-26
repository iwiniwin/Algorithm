/*
题目名称：
包含min函数的栈

题目描述：
定义栈的数据结构，请在该类型中实现一个能够得到栈中所含最小元素的min函数（时间复杂度应为O（1））。
注意：保证测试中不会当栈为空的时候，对栈调用pop()或者min()或者top()方法。

代码结构：
class Solution
{
    public void push(int node) 
    {
        
    }
    public void pop() 
    {
    
    }
    public int top() 
    {
    
    }
    public int min() 
    {
    
    }
}
*/
using System;
namespace StackWithMin {

    class Solution {

        public void push(int node) 
        {
            
        }

        public void pop() 
        {
        
        }

        public int top() 
        {
            return 0;
        }

        public int min() 
        {
            return 0;
        }
        
        public void Test() {

            push(3);
            push(4);
            pop();
            push(3);

            Console.WriteLine(min());
        }
    }
}
