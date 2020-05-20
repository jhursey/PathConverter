//___________________________________________________________________________________________
//+++++					File:		FileCreator.cpp										+++++
//++++++				Creator:	Jaden Bridges									   ++++++
//+++++					Purpose:	To host the creation of the text file				+++++
//++++++							that will store the text obtained from			   ++++++
//+++++								converting the key paths.							+++++
//___________________________________________________________________________________________

#include "FileCreator.h"

FileCreator::FileCreator(){}
FileCreator::~FileCreator(){}

//-------------------------------------------------------------------------------------------
// \\\\\				Function:	createFile											/////
// /////				Arguments:	a vector of strings containing what was				\\\\\
// \\\\\							converted from the key paths						/////
// /////				Return:		an integer representing if the file was				\\\\\
// \\\\\							created without any errors or not					/////
// /////				Purpose:	To create a file containing the text				\\\\\
// \\\\\							that was obtained from converting the				/////
// /////							key paths.											\\\\\
//-------------------------------------------------------------------------------------------
int FileCreator::createFile(vector<string> converted_text)
{
	// create output file called "converted_text.txt"
	ofstream output("converted_text.txt");
	// if file is opened and associated with output object,
	//		add each line of converted text to the file.
	if (output.is_open())
	{
		for (int i = 0; i < (int)converted_text.size(); i++)
		{
			output << converted_text[i] << endl;
			output.flush();
		}
		output.close();
	}
	else
	{
		cerr << "ERROR: File is not opened!\n";
		return 1;
	}
	return 0;
}