/*
算法名称：
判断点是否在某一区域内

算法描述：
判断点是否在某一区域内。比如圆形区域，环形区域，扇形区域，矩形区域，甚至是多边形区域。
常用于在游戏开发中判断攻击技能是否命中目标
*/
using System;
using System.Collections.Generic;
namespace PointIn {

    class Solution {
        
        /// <summary>
        /// 判断点是否在某一圆形区域内
        /// 基本思路：
        /// 计算目标点到圆圆心的距离，距离小于圆的半径则在圆内
        /// 直接计算圆半径的平方来比较大小，可以避免开平方操作
        /// </summary>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="circleX">圆圆心的横坐标</param>
        /// <param name="circleY">圆圆心的纵坐标</param>
        /// <param name="CircleRadius">圆的半径</param>
        public bool PointInCircle(double x, double y, double circleX, double circleY, double CircleRadius) {
            return Math.Pow(circleX - x, 2) + Math.Pow(circleY - y, 2) <= Math.Pow(CircleRadius, 2);
        }

        /// <summary>
        /// 判断点是否在某一环形区域内
        /// 基本思路：
        /// 计算目标点到圆圆心的距离，距离大于内圆的半径同时小于外圆的半径，则在环形区域内
        /// </summary>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="circleX">圆圆心的横坐标</param>
        /// <param name="circleY">圆圆心的纵坐标</param>
        /// <param name="innerRadius">内圆的半径</param>
        /// <param name="outerRadius">外圆的半径</param>
        public bool PointInRing(double x, double y, double circleX, double circleY, double innerRadius, double outerRadius) {
            double distance = Math.Pow(circleX - x, 2) + Math.Pow(circleY - y, 2);
            return distance >= Math.Pow(innerRadius, 2) && distance <= Math.Pow(outerRadius, 2);
        }

        /// <summary>
        /// 判断点是否在某一扇形区域内
        /// 基本思路：
        /// 首先判断目标点是否在以扇形半径为半径的圆内，如果不在园内，则也一定不在扇形内
        /// 然后判断目标点到扇形圆心的方向与扇形中轴线方向的夹角是否小于扇形的角度的一半值，如果小于，则说明在扇形区域内
        /// </summary>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="sectorX">扇形圆心的横坐标</param>
        /// <param name="sectorY">扇形圆心的纵坐标</param>
        /// <param name="sectorRadius">扇形半径</param>
        /// <param name="sectorHalfAngle">扇形的角度的一半值</param>
        /// <param name="sectorDirectionX">扇形中轴线方向的横坐标</param>
        /// <param name="sectorDirectionY">扇形中轴线方向的纵坐标</param>
        public bool PointInSector(double x, double y, double sectorX, double sectorY, double sectorRadius, double sectorHalfAngle, double sectorDirectionX, double sectorDirectionY) {
            if(!PointInCircle(x, y, sectorX, sectorY, sectorRadius)) return false;
            if(sectorHalfAngle >= 180) return true;  // 扇形实际上就是圆
            double directionX = x - sectorX, directionY = y - sectorY;
            Normalize(ref directionX, ref directionY);
            Normalize(ref sectorDirectionX, ref sectorDirectionY);
            return Dot(directionX, directionY, sectorDirectionX, sectorDirectionY) >= Math.Cos(Math.PI / 180 * sectorHalfAngle);
        }

        /// <summary>
        /// 判断点是否在某一矩形区域内
        /// 基本思路：
        /// 判断一个点是否在目标区域内，可以转换为判断一个点是否在矩形的上下两条边之内以及左右两条边之内
        /// 判断一个点是否在两条线段之间，可以利用叉乘
        /// 引目标点到一条线段A的一个顶点生成一条线段C1，计算A与C的叉乘。根据叉乘（|A|*|C1|*sin(a)）正负，可得知目标点是在线段A的顺时针方向还是逆时针方向
        /// 同理引目标点到线段B的一个顶点生成线段C2，通过叉乘判断目标点是在线段B的顺时针方向还是逆时针方向
        /// 结合目标点对于线段A和线段B的方向，即可得出目标点是否在线段A和线段B之间
        /// </summary>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="rectPoints">矩形区域的四个顶点坐标，定义顺序为左上，右上，右下，左下</param>
        /// <returns></returns>
        public bool PointInRect(double x, double y, double[,] rectPoints) {
            if(rectPoints.GetLength(0) != 4 || rectPoints.GetLength(1) != 2)
                throw new ArgumentException("rectPoints must be an array of 4 points");

            return ModCrossVector(rectPoints[1, 0] - rectPoints[0, 0], rectPoints[1, 1] - rectPoints[0, 1], x - rectPoints[0, 0], y - rectPoints[0, 1])
                * ModCrossVector(rectPoints[3, 0] - rectPoints[2, 0], rectPoints[3, 1] - rectPoints[2, 1], x - rectPoints[2, 0], y - rectPoints[2, 1]) >= 0
                && ModCrossVector(rectPoints[0, 0] - rectPoints[3, 0], rectPoints[0, 1] - rectPoints[3, 1], x - rectPoints[3, 0], y - rectPoints[3, 1])
                * ModCrossVector(rectPoints[2, 0] - rectPoints[1, 0], rectPoints[2, 1] - rectPoints[1, 1], x - rectPoints[1, 0], y - rectPoints[1, 1]) >= 0;
        }
        
        /// <summary>
        /// 判断点是否在某一多边形区域内
        /// 算法思路：
        /// 以目标点为端点向水平方向发射射线，统计该射线与多边形每条边的交点数。如果为奇数，则目标点在多边形内，为偶数，则目标在多边形外
        /// 特殊情况：
        /// 1. 当射线与多边形的某个顶点（即多边形中两条相邻边的公共交点）相交时，如果该点是其所属边上纵坐标较大的顶点，则计数，否则忽略。（主要避免公共顶点被计算两次以及处理凹多边形的情况）
        /// 2. 如果射线和多边形某条边重合，则这条边忽略不计
        /// </summary>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="polygonPoints">多边形的各个顶点坐标</param>
        public bool PointInPolygon(double x, double y, double[,] polygonPoints) {
            if(polygonPoints.GetLength(0) < 3 || polygonPoints.GetLength(1) != 2)
                throw new ArgumentException("polygonPoints is an array of at least 3 points");
            bool flag = false;
            for(int i = 0; i < polygonPoints.GetLength(0); i ++) {
                double p1x = polygonPoints[i, 0], p1y = polygonPoints[i, 1];  // 多边形某条边的一个端点
                int index = i == polygonPoints.GetLength(0) - 1 ? 0 : i + 1;
                double p2x = polygonPoints[index, 0], p2y = polygonPoints[index, 1];  // // 多边形某条边的另一个端点
                if(p1y != p2y) {  // 过滤水平边
                    double min = Math.Min(p1y, p2y), max = Math.Max(p1y, p2y);
                    if(y >= min && y < max && x <= (p2x - (p2x - p1x) / (p2y - p1y) * (p2y - y))) {
                        flag = !flag;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        public void Normalize(ref double x, ref double y) {
            double mod = Math.Sqrt(x * x + y * y); 
            x = x / mod;
            y = y / mod;
        }

        /// <summary>
        /// 计算向量的点积
        /// </summary>
        public double Dot(double x1, double y1, double x2, double y2) {
            return x1 * x2 + y1 * y2;
        }

        /// <summary>
        /// 计算两个向量叉乘得到的新向量的模
        /// </summary>
        public double ModCrossVector(double x1, double y1, double x2, double y2) {
            return x1 * y2 - x2 * y1;
        }

        public void Test() {
            double x = 2, y = 1;
            Console.WriteLine(PointInCircle(x, y, 1, 3, 2));

            Console.WriteLine(PointInRing(x, y, 1, 3, 2, 3));

            Console.WriteLine(PointInSector(x, y, 1, 3, 3, 60, 1, -1));
            // Console.WriteLine(PointInSector(x, y, 1, 3, 3, 60, 1, 1));
            // Console.WriteLine(PointInSector(x, y, 1, 3, 3, 60, -1, 1));
            // Console.WriteLine(PointInSector(x, y, 1, 3, 3, 60, -1, -1));

            double[,] rectPoints = new double[,]{
                {0, 3},
                {3, 3},
                {3, 0},
                {0, 0}
            };
            Console.WriteLine(PointInRect(x, y, rectPoints));

            // rectPoints = new double[,]{
            //     {0, 1},
            //     {3, 3},
            //     {4, 2},
            //     {1, 0}
            // };
            // Console.WriteLine(PointInRect(x, y, rectPoints));

            // rectPoints = new double[,]{
            //     {0, 1},
            //     {3, 3},
            //     {4, 2},
            //     {1, 0}
            // };
            // Console.WriteLine(PointInRect(3, 1, rectPoints));

            double[,] polygonPoints = new double[,]{
                {0, 0},
                {1, 3},
                {1, 0}
            };
            Console.WriteLine(PointInPolygon(x, y, polygonPoints));

            // polygonPoints = new double[,]{
            //     {1, 0},
            //     {1, 1},
            //     {2, 3},
            //     {3, 1},
            //     {2, 0}
            // };
            // Console.WriteLine(PointInPolygon(x, y, polygonPoints));

            // polygonPoints = new double[,]{
            //     {1, 0},
            //     {1, 1},
            //     {2, 3},
            //     {2, 0}
            // };
            // Console.WriteLine(PointInPolygon(x, y, polygonPoints));
        }
    }
}
