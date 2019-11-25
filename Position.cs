using System;
namespace Labb2
{
    public class Position
    {
        public int xPos;
        public int yPos;

        public Position(int x, int y)
        {
            this.xPos = Math.Abs(x);
            this.yPos = Math.Abs(y);
        }

        public double Length()
        {
            var c = Math.Sqrt(xPos * xPos + yPos * yPos);
            return c;
        }

        public bool Equals(Position p)
        {
            if (p.xPos == xPos && p.yPos == yPos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Position Clone()
        {
            Position newPosition = new Position(x: xPos, y: yPos);
            return newPosition;
        }

        public override string ToString()
        {
            return $"{xPos} : {yPos}";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            if (p1.Length() >= p2.Length())
            {
                if (p1.xPos > p2.xPos)
                {
                    return true;
                }
                return false;
            }
            return false;

        }

        public static bool operator <(Position p1, Position p2)
        {

            return true;
        }

        public static Position operator +(Position p1, Position p2)
        {
            var newX = p1.xPos + p2.xPos;
            var newY = p1.yPos + p2.yPos;
            return new Position(newX, newY);
        }
        public static Position operator -(Position p1, Position p2)
        {
            var newX = p1.xPos - p2.xPos;
            var newY = p1.yPos - p2.yPos;
            return new Position(newX, newY);
        }
        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.xPos - p2.xPos, 2) + Math.Pow(p1.yPos - p2.yPos, 2));
        }
    }
}
