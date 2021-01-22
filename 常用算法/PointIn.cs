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
        /// </summary>
        /// <param name="x">点的横坐标</param>
        /// <param name="y">点的纵坐标</param>
        /// <param name="circleX">圆圆心的横坐标</param>
        /// <param name="circleY">圆圆心的纵坐标</param>
        /// <param name="CircleRadius">圆的半径</param>
        public bool PointInCircle(double x, double y, double circleX, double circleY, double CircleRadius) {
            return false;
        }

        /// <summary>
        /// 判断点是否在某一环形区域内
        /// </summary>
        /// <param name="x">点的横坐标</param>
        /// <param name="y">点的纵坐标</param>
        /// <param name="circleX">圆圆心的横坐标</param>
        /// <param name="circleY">圆圆心的纵坐标</param>
        /// <param name="innerRadius">内圆的半径</param>
        /// <param name="outerRadius">外圆的半径</param>
        public bool PointInRing(double x, double y, double circleX, double circleY, double innerRadius, double outerRadius) {
            return false;
        }

        /// <summary>
        /// 判断点是否在某一扇形区域内
        /// </summary>
        /// <param name="x">点的横坐标</param>
        /// <param name="y">点的纵坐标</param>
        /// <param name="sectorX">扇形圆心的横坐标</param>
        /// <param name="sectorY">扇形圆心的纵坐标</param>
        /// <param name="sectorRadius">扇形半径</param>
        /// <param name="sectorAngle">扇形的角度</param>
        /// <param name="sectorDirectionX">扇形方向的横坐标</param>
        /// <param name="sectorDirectionY">扇形方向的纵坐标</param>
        public bool PointInSector(double x, double y, double sectorX, double sectorY, double sectorRadius, double sectorAngle, double sectorDirectionX, double sectorDirectionY) {
            return false;
        }

        /// <summary>
        /// 判断点是否在某一矩形区域内
        /// </summary>
        public bool PointInRect(double x, double y) {
            return false;
        }

        /// <summary>
        /// 判断点是否在某一多边形区域内
        /// </summary>
        public bool PointInPolygon(double x, double y, double[,] polygonPoints) {
            return false;
        }

        public void Test() {
            PointInRect(1, 2);
            Console.WriteLine("ret");
        }
    }
}
