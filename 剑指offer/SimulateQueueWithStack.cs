/*
题目名称：
用两个栈实现队列

题目描述：
用两个栈来实现一个队列，完成队列的Push和Pop操作。 队列中的元素为int类型。

代码结构：
class Solution
{
    public void push(int node) 
    {
        
    }
    public int pop() 
    {
    
    }
}
*/
using System;
using System.Collections.Generic;
namespace SimulateQueueWithStack {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 队列的特性是先进先出，而栈的特性是先进后出，可以发现他们的顺序刚好是相反的。
        /// 那么自然就想到相反的相反的就是对的顺序了
        /// 举个例子，仍然是往栈A中依次插入1，2，3，4，此时它的弹出顺序是4，3，2，1。
        /// 若再将这个弹出顺序4，3，2，1，依次插入到栈B中，此时栈B的弹出顺序就是1，2，3，4，
        /// 对于最开始插入的1，2，3，4序列刚好满足了先进先出的特性。
        /// 栈和队列的介绍 https://www.cnblogs.com/iwiniwin/p/10793651.html
        /// </summary>

        Stack<int> pushStack = new Stack<int>();
        Stack<int> popStack = new Stack<int>();

        public void Push(int node) 
        {
            pushStack.Push(node);
        }

        public int Pop() 
        {
            if(popStack.Count == 0){
                while(pushStack.Count > 0){
                    popStack.Push(pushStack.Pop());
                }
            }
            return popStack.Pop();
        }

        public void Test() {

            Push(1);
            Push(2);
            Console.WriteLine(Pop());
            Push(3);
            Console.WriteLine(Pop());
            Push(4);
            Push(5);
            Console.WriteLine(Pop());
            Console.WriteLine(Pop());
            Console.WriteLine(Pop());
        }
    }
}
