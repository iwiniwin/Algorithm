/*
算法名称：
A*寻路算法

算法描述：
A*寻路算法是启发式探索的一个典型实践。在寻路的过程中，给每个节点绑定一个估计值（即启发式），
在对节点的遍历过程中时采取估计值优先原则，估计值更优的节点会被优先遍历。
*/
using System;
using System.Collections.Generic;
namespace AStar {

    class Unit {
        public float g;
        public float h;
        public int x;
        public int y;
        public Unit parent;

        public Unit(int x, int y) {
            this.x = x;
            this.y = y;
            g = 0;
            h = 0;
        }
    }

    class Solution {

        public float StraightWieght {get; set;} = 1.0f;
        public float ObliqueWieght {get; set;} = 1.4f;
        public bool EnableOblique {get; set;} = false;
        public bool EnableCorner {get; set;} = false;

        private Dictionary<string, Unit> mOpenList = new Dictionary<string, Unit>();
        private Dictionary<string, Unit> mCloseList = new Dictionary<string, Unit>();
        private Dictionary<string, Unit> mBlocks = new Dictionary<string, Unit>();

        private int[,] offsets = new int[8, 2] {
            {-1, 0}, {1, 0}, {0, -1}, {0, 1},
            {-1, -1}, {1, -1}, {1, 1}, {-1, 1}
        };

        private void Reset(Unit start, Unit[] blocks) {
            mOpenList.Clear();
            mOpenList.Add(Key(start), start);
            mCloseList.Clear();
            mBlocks.Clear();
            foreach(var unit in blocks){
                mBlocks.Add(Key(unit), unit);
            }
        }

        /// <summary>
        /// 基本思路：
        /// 1. 将初始节点放入到open列表中
        /// 2. 判断open列表。如果为空，则搜索失败。如果open列表中存在目标节点，则搜索成功。
        /// 3. 从open列表中取出F值最小的节点作为当前节点，并将其加入到close列表中
        /// 4. 计算当前节点相邻的所有可到达节点，生成一组子节点。对于每个子节点：
        ///     4.1. 如果该节点在close列表中，则丢弃它
        ///     4.2. 如果该节点在open列表中，则检查其通过当前节点计算得到的F值是否更小，如果更小则更新其F值，并将其父节点设置为当前节点
        ///     4.3. 如果该节点不在open列表中，则将其加入到open列表，并计算F值，设置其父节点为当前节点
        /// 5. 转到2步骤
        /// </summary>

        public List<Unit> Navigate(Unit start, Unit end, Unit size, Unit[] blocks) {
            Reset(start, blocks);
            while(mOpenList.Count > 0) {
                string endKey = Key(end);
                if(mOpenList.ContainsKey(endKey)) {
                    return GetPath(mOpenList[endKey]);
                }
                Unit cur = GetNextUnit();
                string key = Key(cur);
                mOpenList.Remove(key);
                mCloseList.Add(key, cur);
                List<Unit> units = GetNearUnits(cur, size);
                foreach(var unit in units) {
                    Estimate(cur, unit, end);
                    string unitKey = Key(unit);
                    if(mOpenList.ContainsKey(unitKey)) {
                        if(unit.g < mOpenList[unitKey].g) 
                            mOpenList[unitKey] = unit;
                    }else{
                        mOpenList.Add(unitKey, unit);
                    }
                }
            }
            return null;
        }

        private Unit GetNextUnit() {
            Unit next = null;
            foreach(var unit in mOpenList.Values) {
                if(next == null || (unit.g + unit.h) < (next.g + next.h))
                    next = unit;
            }
            return next;
        }

        private List<Unit> GetPath(Unit end) {
            List<Unit> list = new List<Unit>();
            Unit unit = end;
            while(unit != null) {
                list.Add(unit);
                unit = unit.parent;
            }
            list.Reverse();
            return list;
        }

        private List<Unit> GetNearUnits(Unit cur, Unit size) {
            List<Unit> list = new List<Unit>();
            int count = EnableOblique ? 8 : 4;
            for(int i = 0; i < count; i ++) {
                int x = cur.x + offsets[i, 0], y = cur.y + offsets[i, 1];
                string key = Key(x, y);
                if(mBlocks.ContainsKey(key) || mCloseList.ContainsKey(key))
                    continue;
                if(x >= 0 && x < size.x && y >= 0 && y < size.y) {
                    if(i >= 4 && !EnableCorner && (mBlocks.ContainsKey(Key(cur.x, y)) || mBlocks.ContainsKey(Key(x, cur.y))))
                        continue;
                    list.Add(new Unit(x, y));
                }
            }
            return list;
        }

        private void Estimate(Unit cur, Unit unit, Unit end) {
            unit.g = Math.Abs(cur.x - unit.x) + Math.Abs(cur.y - unit.y) > 1 ? ObliqueWieght : StraightWieght;
            unit.h = (Math.Abs(end.x - unit.x) + Math.Abs(end.y - unit.y)) * StraightWieght;
            unit.parent = cur;
        }

        private string Key(int x, int y) {
            return x + "*" + y;
        }

        private string Key(Unit unit) {
            return Key(unit.x, unit.y);
        }

        public void Test() {
            List<Unit> path = Navigate(new Unit(3, 3), new Unit(7, 3), new Unit(8, 6), new Unit[]{new Unit(5, 2), new Unit(5, 3), new Unit(5, 4)});

            foreach(var u in path) {
                Console.WriteLine(u.x + "    " + u.y);
            }

            
        }
    }
}
