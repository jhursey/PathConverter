//___________________________________________________________________________________________
//+++++					File:		PathConverter.cpp									+++++
//++++++				Creator:	Jaden Bridges									   ++++++
//+++++					Purpose:	To host the conversion from the key paths			+++++
//++++++							obtained from the remotes to readable text		   ++++++
//___________________________________________________________________________________________

#include "PathConverter.h"

// Keyboard layout defined by the client.
// Assuming the rows are the same size and the columns are the same size,
//		the layout can be changed here in the event of an update.
char keyboardLayout[6][6] = {	
								{'A', 'B', 'C', 'D', 'E', 'F'},
								{'G', 'H', 'I', 'J', 'K', 'L'},
								{'M', 'N', 'O', 'P', 'Q', 'R'},
								{'S', 'T', 'U', 'V', 'W', 'X'},
								{'Y', 'Z', '1', '2', '3', '4'},
								{'5', '6', '7', '8', '9', '0'}
							};

PathConverter::PathConverter(){}
PathConverter::~PathConverter(){}

//-------------------------------------------------------------------------------------------
// \\\\\				Function:	convertPathToText									/////
// /////				Arguments:	a vector of vectors containing each					\\\\\
// \\\\\							button pressed in the form of characters			/////
// /////				Return:		a vector of strings containing each line			\\\\\
// \\\\\							of key paths converted into readable text			/////
// /////				Purpose:	To convert each key path into readable				\\\\\
// \\\\\							text.												/////
//-------------------------------------------------------------------------------------------
vector<string> PathConverter::convertPathToText(vector<vector<char>> paths)
{
	vector<string> converted_text;

	// For each key path,
	for (int i = 0; i < (int)paths.size(); i++)
	{
		// reset keyboard indexes and line of converted text
		int key_i = 0;
		int key_j = 0;
		string single_text = "";

		// For each button pressed in a key path,
		for (int j = 0; j < (int)paths[i].size(); j++)
		{
			// identify which button was pressed
			// increment/decrement the indexes of the key on the keyboard based on the remote key pressed

			if (paths[i][j] == 'U')
			{
				key_i = key_i - 1;
				// if key_i becomes negative, add the number of rows to start back at the bottom
				// of the keyboard.
				if (key_i < 0)
				{
					key_i += (sizeof(keyboardLayout)/sizeof(keyboardLayout[i]));
				}
			}
			else if (paths[i][j] == 'D')
			{
				key_i = (key_i + 1) % (sizeof(keyboardLayout)/sizeof(keyboardLayout[i]));
			}
			else if (paths[i][j] == 'L')
			{
				key_j = key_j - 1;
				// if key_j becomes negative, add the number of columns to start back at the right side
				// of the keyboard.
				if (key_j < 0)
				{
					key_j += sizeof(keyboardLayout[i]);
				}
			}
			else if (paths[i][j] == 'R')
			{
				key_j = (key_j + 1) % sizeof(keyboardLayout[i]);
			}

			// append a space if 'S' was entered
			else if (paths[i][j] == 'S')
			{
				single_text.append(" ");
			}

			// append the letter depending on where the key_i and key_j indexes are located on the keyboard
			else if (paths[i][j] == '\\' && paths[i][j + 1] == '*')
			{
				single_text.push_back(keyboardLayout[key_i][key_j]);
				j++;
			}
			else
			{
				cerr << "ERROR: Unrecognized button \"" << paths[i][j] << "\" detected!" << endl;
			}
		}
		converted_text.push_back(single_text);
	}

	return converted_text;
}