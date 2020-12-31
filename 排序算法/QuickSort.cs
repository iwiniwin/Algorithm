/*
算法名称：
快速排序

时间复杂度：O(n*log(2, n))

空间复杂度：O(log(2, n))，递归深度，递归使用的栈空间，以2为底n的对数

最好情况：
O(n*log(2, n)) 每次划分的结果都是左右两个分区大小相等时

最坏情况：
O(n ^ 2) 当选择的分界点一直是最大元素或最小元素时，退化为冒泡排序

稳定性：不稳定，因为将元素移动到分界点两边时，会打乱原本相等元素的顺序

优点：极快

缺点：不稳定

优化：
当待排序列是部分有序时，固定选取枢轴使快排效率低下，要缓解这种情况，可以引入随机选取枢轴
当待排序列长度分割到一定大小后，使用插入排序，因为对于很小和部分有序的数组，直接插入排序效率更好
算法中调用两次QuickSortImpl进行递归，其实第二次可以使用循环代替，改为 left = pivot + 1
*/
using System;
namespace QuickSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 每次从数组中选择一个目标元素（这里默认选择首元素）做为分界点
        /// 将数组中小于分界点的元素都移动到分界点左边
        /// 将数组中大于分界点的元素都移动到分界点右边
        /// 这样，每经过一趟排序，分界点都找到了它应该在的位置，然后以同样的方式递归处理左右两边的数组
        /// 直到每一个元素都做为分界点找到了自己的位置，即排序完成
        /// </summary>

        public void QuickSort(int[] array){
            QuickSortImpl(array, 0, array.Length - 1);
        }

        public void QuickSortImpl(int[] array, int left, int right){
            if(left >= right) return;
            int pivot = Partition(array, left, right);
            QuickSortImpl(array, left, pivot - 1);
            QuickSortImpl(array, pivot + 1, right);
        }

        public int Partition(int[] array, int left, int right){
            int target = array[left];
            while(left < right){
                while(right > left && array[right] >= target){
                    right --;
                }
                if(right > left){
                    array[left] = array[right];
                    left ++; 
                }
                while(left < right && array[left] <= target){
                    left ++;
                }
                if(left < right){
                    array[right] = array[left];
                    right --;
                }
            }
            array[left] = target;
            return left;
        }

        public void Test() {

            int[] array = new int[]{0, 3, 2, 4};
            // array = new int[]{0, 0, 1, 0, 0};
            // array = new int[]{-1, 6, 3, 2, 4, 0, 9};

            QuickSort(array);

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
