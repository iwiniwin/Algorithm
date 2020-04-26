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
using System.Collections.Generic;
namespace StackWithMin {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 使用一个辅助栈来保存最小元素
        /// 每次入栈时，如果元素小于等于辅助栈栈顶元素，就入辅助栈
        /// 每次出栈时，如果出栈元素也是辅助栈栈顶元素，则辅助栈也出栈
        /// 这样可以保证辅助栈的栈顶元素一直是最小元素
        /// </summary>

        Stack<int> stack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        public void push(int node) 
        {
            stack.Push(node);
            if(minStack.Count == 0)
                minStack.Push(node);
            else if(node <= minStack.Peek())
                minStack.Push(node);
        }

        public void pop() 
        {
            int node = stack.Pop();
            if(node == minStack.Peek())
                minStack.Pop();
        }

        public int top() 
        {
            return stack.Peek();
        }

        public int min() 
        {
            return minStack.Peek();
        }
        
        public void Test() {

            push(3);
            push(2);
            pop();
            push(1);
            push(1);
            pop();

            Console.WriteLine(min());
        }
    }
}
