using System;

namespace PathConverter
{
    /*
     * Representation of a key pad.
     * Stores the current position of the cursor and
     * returns values on a Select command
     */
    public class KeyPad
    {
        // The keypad that the path will follow
        // This doesn't change for this implementation, so
        // create only once
        private static readonly char[,] keyPad = new char[6, 6]
        {
            {'A', 'B', 'C', 'D', 'E', 'F'},
            {'G', 'H', 'I', 'J', 'K', 'L'},
            {'M', 'N', 'O', 'P', 'Q', 'R'},
            {'S', 'T', 'U', 'V', 'W', 'X'},
            {'Y', 'Z', '1', '2', '3', '4'},
            {'5', '6', '7', '8', '9', '0'}
        };
        
        // The current position on the keypad
        private int X { get; set; } = 0;
        private int Y { get; set; } = 0;

        // The size of the keypad
        // If later we want to use different keypads, these sizes will
        // be set after the custom keypad is created.
        //
        // Note that the array is stored (height, width)
        // It doesn't matter for this implementation, but if this expanded,
        // we have to be sure we don't get them backwards when setting them.
        private int width = 6;
        private int height = 6;

        // Moves the selection around the keypad based on an input command
        public void Move(char command)
        {
            switch(command)
            {
                case char c when c == Commands.UP:
                    Y = Wrap(Y - 1, height);
                    return;
                case char c when c == Commands.DOWN:
                    Y = Wrap(Y + 1, height);
                    return;
                case char c when c == Commands.LEFT:
                    X = Wrap(X - 1, width);
                    return;
                case char c when c == Commands.RIGHT:
                    X = Wrap(X + 1, width);
                    return;
                default:
                    // An unexpected character was encountered, so exit application
                    Console.WriteLine($"Malformed input in KeyPad.Move: {command}");
                    Environment.Exit(-1);
                    return;
            }
        }

        // Keeps the movements from going out of the array bounds by
        // wrapping them to opposite edge
        private int Wrap(int n, int bounds)
        {
            if (n >= bounds)
                return 0;
            else if (n < 0)
                return bounds - 1;
            else
                return n;
        }

        // Returns the character at the current position.
        public char Select()
        {
            // The array is stored (height, width) so we need to flip
            // X, Y from the usual way we think of x,y coordinates.
            return keyPad[Y, X];
        }
    }
}
