//___________________________________________________________________________________________
//+++++					Project:	PathConverter										+++++
//++++++				Creator:	Jaden Bridges									   ++++++
//+++++					Purpose:	To convert key paths obtained from a				+++++
//++++++							remote to readable text such that				   ++++++
//+++++								data scientists can analyze the search				+++++
//++++++							terms.											   ++++++
//___________________________________________________________________________________________


#include <iostream>
#include "PathCollector.h"
#include "PathConverter.h"
#include "FileCreator.h"

using namespace std;

// main function for running the PathConverter project
int main()
{
	PathCollector *pcol = new PathCollector();
	PathConverter *pcon = new PathConverter();
	FileCreator *fc = new FileCreator();

	// Collect all key paths entered from the remote using the PathCollector class
	vector<vector<char>> paths = pcol->collectPaths();
	cout << "Key paths collected successfully!\n";

	// Convert the key paths into a readable text using the PathConverter class
	vector<string> converted_text = pcon->convertPathToText(paths);
	cout << "Key path converted to text successfully!\n";

	// Create a file containing the readable text using the FileCreator class
	if (fc->createFile(converted_text))
	{
		cerr << "ERROR: Unable to create output file!\n";
		return 1;
	}
	cout << "File created successfully!\n";

	return 0;
}