using System;
using System.Collections.Generic;
using System.Text;

namespace PathConverter.Models
{
    public class Cursor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cursor()
        {
            X = 0;
            Y = 0;
        }

        public Cursor(int x, int y)
        {
            X = x;
            Y = y;
        }       
    }

    public static class Extensions
    {
        public static Cursor KeyUp(this Cursor cursor)
        {
            if (cursor.Y == 0)
            {
                cursor.Y = 5;
            }
            else
            {
                cursor.Y -= 1;
            }

            return cursor;
        }

        public static Cursor KeyDown(this Cursor cursor)
        {
            if (cursor.Y == 5)
            {
                cursor.Y = 0;
            }
            else
            {
                cursor.Y += 1;
            }

            return cursor;
        }

        public static Cursor KeyLeft(this Cursor cursor)
        {
            if (cursor.X == 0)
            {
                cursor.X = 5;
            }
            else
            {
                cursor.X -= 1;
            }

            return cursor;
        }

        public static Cursor KeyRight(this Cursor cursor)
        {
            if (cursor.X == 5)
            {
                cursor.X = 0;
            }
            else
            {
                cursor.X += 1;
            }

            return cursor;
        }
    }
}
