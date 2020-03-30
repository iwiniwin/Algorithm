/*
算法名称：
堆排序

时间复杂度：O(n*log(2, n))

空间复杂度：O(1)

最好情况：
O(n*log(2, n))

最坏情况：
O(n*log(2, n))，它的最坏情况接近于平均性能

稳定性：不稳定

优点：在最坏情况下性能优于快速排序。由于在直接选择排序的基础上利用了比较结果形成堆。效率提高很大。

缺点：不稳定，初始建堆所需比较次数较多，因此记录数较少时不宜采用
*/
using System;
namespace HeapSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 对一组待排序列的元素，首先将它们按照堆的定义排成一个序列，常称为建堆，从而输出堆顶的最大或最小元素。
        /// 然后对剩余的元素再建堆，常称为重新调整成堆，即可得到次大（次小）元素，如此反复进行，直到全部元素排成有序序列为止。
        /// 
        /// 如何建堆：首先将待排序列画成一颗完全二叉树，然后把得到的完全二叉树再转换成堆。
        /// 从最后一个分支节点开始（n/2取下限的节点）,依次将所有以分支节点为根的二叉树调整成堆，
        /// 当这个过程持续到根节点时，整个二叉树就调整成了堆，即建堆完成。
        /// 
        /// 如何调整堆：假设被调整的分支节点为A，它的左孩子为B，右孩子为C。
        /// 那么当A开始进行堆调整时，以B和以C为根的二叉树都已经为堆。
        /// 如果节点A的值大于B和C的值（以大顶堆为例），那么以A为根的二叉树已经是堆。
        /// 如果A节点的值小于B节点或C节点的值，那么节点A与值最大的那个孩子变换位置。
        /// 此时需要将A继续与和它交换的那个孩子的原来的两个孩子进行比较，依次类推，直到节点A向下渗透到适当的位置为止。
        /// 
        /// 如果要从小到大排序，则使用大顶堆，如果要从大到小排序，则使用小顶堆。原因是堆顶元素需要交换到序列尾部
        /// </summary>

        public void HeapSort(int[] array){
            // 建堆
            for(int i = array.Length / 2 - 1; i >= 0; i --){
                BuildHeap(array, i, array.Length - 1);
            }
            // 调整堆
            for(int i = array.Length - 1; i > 0; i --){
                Swap(array, 0, i);
                BuildHeap(array, 0, i - 1);
            }
        }

        public void BuildHeap(int[] array, int left, int right){
            int target = array[left];
            for(int i = 2 * left + 1; i <= right; i = 2 * i + 1){
                if(i < right && array[i + 1] > array[i]){
                    i ++;
                }
                if(target >= array[i]){
                    break;
                }
                array[left] = array[i];
                left = i; 
            }
            array[left] = target;
        }

        public void Swap(int[] array, int i, int j){
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public void Test() {

            int[] array = new int[]{3, 4, 2, 1};
            array = new int[]{0, 0, 0, 1, 1, 1, -1, -1, 0, -1};
            // array = new int[]{1, 2};
            // array = new int[]{2, 1};
            // array = new int[]{3};

            HeapSort(array);

            Print(array);
        }

        public void Print(int[] array){
            foreach (int item in array)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
    }
}
