using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    public class SortedPosList
    {
        public List<Position> positionList = new List<Position>();
        private Position position;
        public SortedPosList()
        {
        }

        public override string ToString()
        {
            return string.Join(", ", positionList);
        }

        public int Count()
        {
            return positionList.Count;
        }

        public void Add(Position pos)
        {
            positionList.Add(pos);
            positionList.Sort((x, y) => x.Length().CompareTo(y.Length()));
        }

        public bool Remove(Position pos)
        {
            for (int i = 0; i < positionList.Count; i++)
            {
                if (pos.xPos == positionList[i].xPos && pos.yPos == positionList[i].yPos)
                {
                    positionList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList clonedList = new SortedPosList();
            foreach (var pos in positionList)
            {
                var newpos = pos.Clone();
                clonedList.Add(newpos);
            }
            return clonedList;
        }
        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList newCircleList = Clone();
            foreach (var pos in positionList)
            {
                if (Math.Pow(pos.xPos - centerPos.xPos, 2) + Math.Pow(pos.yPos - centerPos.yPos, 2) > Math.Pow(radius, 2))
                {
                    newCircleList.Remove(pos);
                }
            }
            return newCircleList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {

            for (int i = 0; i < sp2.Count(); i++)
            {
                sp1.Add(sp2[i]);
            }
            return sp1;
        }

        public static SortedPosList operator -(SortedPosList a, SortedPosList b)
        {
            var list = a.Clone();

            for (int i = 0; i < a.Count(); i++)
            {
                for (int y = 0; y < b.Count(); y++)
                {
                    if (a[i].xPos == b[y].xPos && a[i].yPos == b[y].yPos)
                    {
                        list.Remove(a[i]);
                    }
                }
            }
            return list;
        }

        public Position this[int i]
        {
            get { return positionList[i]; }
        }
    }
}
