using System;
using System.Collections.Generic;
using System.Text;

namespace PathConverter.Models
{
    /// <summary>
    /// Represents a Cursor using an X and Y coordinate
    /// </summary>
    public class Cursor
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Creates a new cursor at Coordinates (0,0)
        /// </summary>
        public Cursor()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Creates a new cursor at the specified coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Cursor(int x, int y)
        {
            X = x;
            Y = y;
        }   
    }

    public static class Extensions
    {
        /// <summary>
        /// Moves the cursor by the specified change in x and y
        /// </summary>
        /// <param name="cursor">The cursor to be moved</param>
        /// <param name="dx">change in x cooordinate</param>
        /// <param name="dy">change in y coordinate</param>
        /// <returns></returns>
        public static Cursor MoveCursor(this Cursor cursor, int dx, int dy)
        {
            cursor.X += dx;
            cursor.Y += dy;

            return cursor;
        }

        /// <summary>
        /// Moves the cursor up by the 1, Allows for keyboard wraparound
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Moves the cursor down by 1, allows for keyboard wraparound
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Moves the cursor left by 1, allows for keyboard wraparound
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Moves the cursor right by 1, allows for keyboard wraparound
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
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
