using System;
using System.IO;
using System.Collections.Generic;

namespace PathConverter
{
    class Program
    {
        private static string InputFile = Path.Combine(Environment.CurrentDirectory + "\\" + "input.txt");
        private static string OutputFile = Path.Combine(Environment.CurrentDirectory + "\\" + "output.txt");

        private static List<List<char>> RemoteKeyMapping = new List<List<char>> {
            new List<char> {'A', 'B', 'C', 'D', 'E', 'F'},
            new List<char> {'G', 'H', 'I', 'J', 'K', 'L'},
            new List<char> {'M', 'N', 'O', 'P', 'Q', 'R'},
            new List<char> {'S', 'T', 'U', 'V', 'W', 'X'},
            new List<char> {'Y', 'Z', '1', '2', '3', '4'},
            new List<char> {'5', '6', '7', '8', '9', '0'},
        };

        private static char UpInput = 'U';
        private static char DownInput = 'D';
        private static char LeftInput = 'L';
        private static char RightInput = 'R';
        private static char SpaceInput = 'S';
        private static char SelectInput = '*';

        static void Main(string[] args)
        {
            var outputText = DetermineMessage();

            using (var writer = File.CreateText(OutputFile)) {
                writer.WriteLine(outputText);
            }
        }

        private static string DetermineMessage() {
            var outputText = "";
            using (var streamReader = File.OpenText(InputFile)) {
                var col = 0;
                var row = 0;
                while (streamReader.Peek() > 0) {
                    var inputChar = (char)streamReader.Read();
                    
                    //Reset Row and Col and Go to new line in output text
                    if (inputChar == '\n') {
                        row = 0;
                        col = 0;
                        outputText += "\n";
                    }

                    //Navigate Remote
                    if (inputChar == UpInput) {
                        if (row == 0) {
                            row = RemoteKeyMapping.Count - 1;
                        }
                        else {
                            row--;
                        }
                    }
                    else if (inputChar == DownInput) {
                        if (row == RemoteKeyMapping.Count - 1) {
                            row = 0;
                        }
                        else {
                            row++;
                        }
                    }
                    else if (inputChar == LeftInput) {
                        if (col == 0) {
                            col = RemoteKeyMapping[row].Count - 1;
                        }
                        else {
                            col--;    
                        }
                    }
                    else if (inputChar == RightInput) {
                        if (col == RemoteKeyMapping[row].Count - 1) {
                            col = 0;
                        }
                        else {
                            col++;
                        }
                    }
                    //Character Input
                    else if (inputChar == SpaceInput) {
                        outputText += " ";
                    }
                    else if (inputChar == SelectInput) {
                        outputText += RemoteKeyMapping[row][col];
                    }
                }
            }

            return outputText;
        }
    }
}
