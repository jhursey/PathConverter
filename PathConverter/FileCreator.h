//___________________________________________________________________________________________
//+++++							File:		FileCreator.h								+++++
//++++++						Creator:	Jaden Bridges							   ++++++
//___________________________________________________________________________________________

#ifndef FILECREATOR_H
#define FILECREATOR_H

#pragma once

#include <string>
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

class FileCreator
{
public:
	FileCreator();
	~FileCreator();
	int createFile(vector<string> converted_text);
};

#endif