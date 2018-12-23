using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConnorsGroupCodeSolution
{
    class Program
    {

        // please enter input and output file paths here
        private static string inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "input.txt");
        private static string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt");

        // define constants
        public const int WRITE_CHUNK_SIZE = 2048;
        public const string SPACE_SEPERATOR = " ";

        static void Main(string[] args) {

            // initialize string builder to store the converted text
            StringBuilder convertedKeyPathText = new StringBuilder();
            // initialize remote control object to simulate actions done with a remote
            RemoteControl remote = new RemoteControl();

            // create a file stream to read in the file, and automatically dispose the stream at the end of
            // the using statement block
            using (StreamReader sr = new StreamReader(inputFile, Encoding.Default)) {

                // read in each instruction sequence delimited by '*'  
                foreach (string instructionSequence in ReadUntilMatch(sr, RemoteControl.CHARACTER_DELIMITER)) {
                    // for each character in the instruction sequence
                    foreach (char nextChar in instructionSequence) {
                        // if is the character is for whitespace
                        if (nextChar.Equals(RemoteControl.SPACE_SEPERATOR_CODE)) {
                            // append the space seperator
                            convertedKeyPathText.Append(SPACE_SEPERATOR);
                        }
                        // if the character is a control character
                        else if (char.IsControl(nextChar)) {
                            // reset remote values
                            remote.Clear();
                            // append the character
                            convertedKeyPathText.Append(nextChar);
                        }
                        // if the character is for a move
                        else {
                            remote.processMove(nextChar);
                        }
                    }
                    // append the key path translated character value to output string
                    convertedKeyPathText.Append(remote.getPathCharacterValue());
                    // write out the converted key path text in chunks as not to consume too much main memory
                    // but also to not initiate too many disk writes 
                    if (convertedKeyPathText.Length > WRITE_CHUNK_SIZE) {
                        // create file if it doesn't exist, write text, then close the file
                        // note: this will overwrite an existing file with the same name
                        File.AppendAllText(outputFile, convertedKeyPathText.ToString());
                        // clear the string builder
                        convertedKeyPathText.Clear();
                    }
                }
            }

            // finish writing any remaining text less than or equal to the chunk size
            File.AppendAllText(outputFile, convertedKeyPathText.ToString());

            convertedKeyPathText.Clear();
            remote.Clear();
        }

        /// <summary>
        /// This is a utility function to read from the specified stream until
        /// there is a token match.
        /// </summary>
        /// <param name="textReader">the stream to read</param>
        /// <param name="token">the token to match</param>
        /// <returns> an enumerable instruction sequence</returns>
        public static IEnumerable<string> ReadUntilMatch(TextReader textReader, char token) {

            StringBuilder readInChars = new StringBuilder();
            // while there are more characters to read
            while (textReader.Peek() >= 0) {
                // read the next character
                char c = (char)textReader.Read();
                // if there is a match
                if (c.Equals(token)) {
                    // return the enumerator
                    yield return readInChars.ToString();
                    // clear the read in characters
                    readInChars.Clear();
                    // repeat
                    continue;
                }
                // append the unmatched read in character
                readInChars.Append(c);
            }
        }


    }

    /// <summary>
    /// Represents a remote control and handles related operations
    /// </summary>
    class RemoteControl
    {
        // define constants
        public const char CHARACTER_DELIMITER = '*';
        public const char SPACE_SEPERATOR_CODE = 'S';

        private static Position currentPosition;

        // default constructor
        public RemoteControl() {
            currentPosition = new Position();
        }

        // alternate constructor, if dependency injection is desired
        public RemoteControl(Position altPosition) {
            currentPosition = altPosition;
        }

        private static string[,] remoteKeyValues = new string[,] {
            {"A","B","C","D","E","F"},
            {"G","H","I","J","K","L"},
            {"M","N","O","P","Q","R"},
            {"S","T","U","V","W","X"},
            {"Y","Z","1","2","3","4"},
            {"5","6","7","8","9","0"},
        };

        /// <returns>Current character value of performed instruction sequence</returns>
        public string getPathCharacterValue() {
            return remoteKeyValues[currentPosition.X, currentPosition.Y];
        }

        /// <summary>
        /// Processes the remote's input. Assumes {'U', 'D', 'L', 'R'} are the only valid alphabet characters.
        /// </summary>
        /// <param name="characterCode">U', 'D', 'L', or 'R'</param>
        /// <returns>the current Position</returns>
        /// <exception cref="ArgumentException">If an invalid character is entered.</exception>
        public Position processMove(char characterCode) {

            switch (characterCode) {
                case 'U':
                    currentPosition.X--;
                    break;
                case 'D':
                    currentPosition.X++;
                    break;
                case 'L':
                    currentPosition.Y--;
                    break;
                case 'R':
                    currentPosition.Y++;
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} is not a valid alphabet character.", characterCode));
            }


            int gridSideLength = remoteKeyValues.GetLength(0);

            // wrap x value within legal bounds
            int x = currentPosition.X;
            if (currentPosition.X < 0) {
                x = gridSideLength + x;
            }
            else if (currentPosition.X > 5) {
                x = x - gridSideLength;
            }
            // wrap y value within legal bounds
            int y = currentPosition.Y;
            if (y < 0) {
                y = gridSideLength + y;
            }
            else if (y > 5) {
                y = y - gridSideLength;
            }

            currentPosition.X = x;
            currentPosition.Y = y;

            return currentPosition;
        }

        /// <summary>
        /// Resets the remote's current position
        /// </summary>
        public void Clear() {
            currentPosition.X = 0;
            currentPosition.Y = 0;
        }

    }
    /// <summary>
    /// Represents the remote's current position
    /// </summary>
    class Position
    {
        private int x = 0;
        private int y = 0;

        public int X {
            get {
                return x;
            }

            set {
                x = value;
            }
        }

        public int Y {
            get {
                return y;
            }

            set {
                y = value;
            }
        }
    }
}
