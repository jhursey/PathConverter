//___________________________________________________________________________________________
//+++++							File:		PathCollector.h								+++++
//++++++						Creator:	Jaden Bridges							   ++++++
//___________________________________________________________________________________________

#ifndef PATHCOLLECTOR_H
#define PATHCOLLECTOR_H

#pragma once

#include <string>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

class PathCollector
{
public:
	PathCollector();
	~PathCollector();
	vector<vector<char>> collectPaths();
};

#endif