using System;

namespace Algorithm
{
    /// <summary>
    /// 排序算法汇总 模块
    /// 所有排序算法均是以从小到大为例的
    /// </summary>
    class SortProgram
    {
        public static void Test()
        {
            // new BubbleSort.Solution().Test();                                  // 冒泡排序
            // new QuickSort.Solution().Test();                                   // 冒泡排序
            // new SimpleInsertionSort.Solution().Test();                         // 简单插入排序
            // new ShellSort.Solution().Test();                                   // 希尔排序
            // new SimpleSelectionSort.Solution().Test();                         // 简单选择排序
            // new HeapSort.Solution().Test();                                    // 堆排序
            // new MergeSort.Solution().Test();                                   // 归并排序
            new RadixSort.Solution().Test();                                   // 基数排序
        }
    }
}
