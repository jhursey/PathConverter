//___________________________________________________________________________________________
//+++++					File:		PathCollector.cpp									+++++
//++++++				Creator:	Jaden Bridges									   ++++++
//+++++					Purpose:	To host the collection of paths where				+++++
//++++++							the key paths in "path.txt" will be		 		   ++++++
//+++++								parsed.												+++++
//___________________________________________________________________________________________

#include "PathCollector.h"

PathCollector::PathCollector(){}
PathCollector::~PathCollector(){}

//-------------------------------------------------------------------------------------------
// \\\\\				Function:	collectPaths										/////
// /////				Arguments:	none												\\\\\
// \\\\\				Return:		a vector of vectors containing each					/////
// /////							button pressed in the form of characters			\\\\\
// \\\\\				Purpose:	To parse each button press in each key				/////
// /////							path from "path.txt"								\\\\\
//-------------------------------------------------------------------------------------------
vector<vector<char>> PathCollector::collectPaths()
{
	ifstream path_file;
	char path_node;
	vector<vector<char>> paths_v;
	vector<char> single_path;
	
	path_file.open("path.txt");
	if (!path_file) {
		cerr << "ERROR: path.txt not found!";
		exit(1);
	}

	// get each character in the file
	while (path_file.get(path_node))
	{
		// go to next key path if key path ended
		if (path_node == '\n')
		{
			paths_v.push_back(single_path);
			single_path.clear();
		}
		// add character to key path
		else
		{
			single_path.push_back(path_node);
		}
	}
	// add key path to vector of key paths
	paths_v.push_back(single_path);

	path_file.close();
	return paths_v;
}