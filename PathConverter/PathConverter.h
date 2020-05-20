//___________________________________________________________________________________________
//+++++							File:		PathConverter.h								+++++
//++++++						Creator:	Jaden Bridges							   ++++++
//___________________________________________________________________________________________

#ifndef PATHCONVERTER_H
#define PATHCONVERTER_H

#pragma once

#include <string>
#include <vector>
#include <iostream>

using namespace std;

class PathConverter
{
public:
	PathConverter();
	~PathConverter();
	vector<string> convertPathToText(vector<vector<char>> path);
};

#endif