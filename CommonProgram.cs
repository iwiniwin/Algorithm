using System;

namespace Algorithm
{
    /// <summary>
    /// 常用算法 模块
    /// </summary>
    class CommonProgram
    {
        public static void Test()
        {
            
            // new KMP.Solution().Test();                           // KMP模式匹配算法
            // new AStar.Solution().Test();                         // A*寻路算法
            new Huffman.Solution().Test();                       // 哈夫曼算法
        }
    }
}
