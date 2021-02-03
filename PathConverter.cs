using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PathConverter
{
    /// <summary>
    /// Windows form used to convert a given path of keys to text.
    /// Users input search terms using a television remote. The arrow buttons are used to navigate a grid of letters 
    /// until a letter is selected. The letters are organized as follows:
    ///     ABCDEF
    ///     GHIJKL
    ///     MNOPQR
    ///     STUVWX
    ///     YZ1234
    ///     567890
    /// 
    /// This program accepts a flat file as input.  Each line is a new key path.
    /// Key paths consist of a string of characters where:
    ///     U = up
    ///     D = down
    ///     L = left
    ///     R = right
    ///     S = space
    ///     * = select
    ///     
    /// Key paths always start at the upper left corner, i.e. 'A'
    /// The output is written out to a new file specified by the user
    /// 
    /// Sample Input
    ///     DDDR* UU* LLLU* SDD* DLL* UU* U* RRD* SURRR* LLDD* LLL* DRR* RRRU* SUULL* DDLLL* LLLD* SUULL* DDL* LLU* RRR* UUR* L* SDDL* RD* UUUR* DDR* SRRD* UU* LLLU* SDR* RU* UUR* L* SDDRRR* DDL* LLU*
    ///
    /// Sample Output
    ///     THE QUICK BROWN FOX JUMPED OVER THE LAZY DOG
    /// </summary>
    public partial class PathConverter : Form
    {
        // multidimensional array holding the remote keys
        string[,] remoteKeys = new string[6, 6] {{ "A", "B", "C", "D", "E", "F"}, { "G", "H", "I", "J", "K", "L"},
                                        { "M", "N", "O", "P", "Q", "R"}, { "S", "T", "U", "V", "W", "X"},
                                        { "Y", "Z", "1", "2", "3", "4"}, { "5", "6", "7", "8", "9", "0"}};

        // holds the current position (row and column)
        private int currentRow, currentCol = 0;

        public PathConverter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used to load the input file text box with what is selected from the OpenFileDialog
        /// </summary>
        private void brwsInputButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                inputFileTextBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Used to load the output file text box with what is selected from the OpenFileDialog
        /// </summary>
        private void brwsOutputButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                outputFileTextBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Runs the conversion process on the input keys and outputs the converted text to a file.
        /// </summary>
        private void convertButton_Click(object sender, EventArgs e)
        {
            // clear the output text box
            outputTextBox.Text = string.Empty;

            // holds the input text from the file
            string inputText = String.Empty;
            try
            {
                // open the input file and read in the contents to inputText
                inputText = File.ReadAllText(inputFileTextBox.Text);
            }
            catch (IOException ex)
            {
                // output the error to the output text box
                outputTextBox.Text += ex.ToString() + "\n";
            }

            // if there was no text read in, just return
            if (String.IsNullOrEmpty(inputText))
            {
                // display to the user that there was not text to convert
                outputTextBox.Text += "There was nothing to convert from the input file." + "\n";
                return;
            }
  
            // split out the text for each new line
            string[] keyPaths = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> outputText = new List<string>();

            // loop through the lines in the input file
            foreach (string keyPath in keyPaths)
            {
                // if there is anything to convert
                if (keyPath.Length > 0)
                {
                    // add the converted text to outputText
                    outputText.Add(ConvertPath(keyPath));
                }
            }

            // if there is anything to output
            if (outputText.Count > 0)
            {
                try
                {
                    // open the output file and write out the contents.  This will erase the contents of the file
                    File.WriteAllLines(outputFileTextBox.Text, outputText.ToArray());
                }
                catch (IOException ex)
                {
                    // output the error to the output text box
                    outputTextBox.Text += ex.ToString() + "\n"; 
                }

                // display the converted string
                outputTextBox.Text += string.Join("\r\n", outputText);
            }
        }
        /// <summary>
        /// Converts the given keyPath characters to text based on the contents of the remoteKeys array
        /// </summary>
        /// <param name="keyPath">the keyPath to convert</param>
        /// <returns>string representing the keyPath</returns>
        private string ConvertPath(string keyPath)
        {
            // reset the current row and columns
            currentRow = currentCol = 0;

            // if there is nothing to convert, return an empty string
            if (String.IsNullOrEmpty(keyPath))
                return String.Empty;

            StringBuilder convertedPath = new StringBuilder();

            // loop through each character in the keyPath
            for (int i = 0; i < keyPath.Length; i++)
            {
                // determine the character
                switch (keyPath[i])
                {
                    // UP
                    case 'U':
                        // make sure we are not going out of row bounds
                        if (currentRow == 0)
                            currentRow = 5;
                        else
                            currentRow -= 1;
                        break;
                    // DOWN
                    case 'D':
                        // make sure we are not going out of row bounds
                        if (currentRow == 5)
                            currentRow = 0;
                        else
                            currentRow += 1;
                        break;
                    // LEFT
                    case 'L':
                        // make sure we are not going out of column bounds
                        if (currentCol == 0)
                            currentCol = 5;
                        else
                            currentCol -= 1;
                        break;
                    // RIGHT
                    case 'R':
                        // make sure we are not going out of column bounds
                        if (currentCol == 5)
                            currentCol = 0;
                        else
                            currentCol += 1;
                        break;
                    // SPACE
                    case 'S':
                        // add a space character
                        convertedPath.Append(" ");
                        break;
                    // ENTER
                    case '*':
                        // enter the selected character at the current position
                        convertedPath.Append(remoteKeys[currentRow, currentCol]);
                        break;
                    // ignore all other characters
                    default:
                        break;
                }
            }

            // return the converted string
            return convertedPath.ToString();
        }
    }
}
