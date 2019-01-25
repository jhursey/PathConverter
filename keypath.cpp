/*
 * Author: Thomas Singleton <thomas.s.singleton@gmail.com>
 * Project: Keypath Programming Test for Connors Group LLC
 * Date: 2018-01-24
 * Description: Parse a "key path" from a television remote
 * into readable text, from users searching like with a set-top box.
 */

#include <iostream>
#include <string>
#include <ctime>
#include <fstream>

using namespace std;

class KeyParser{
  
public:
  //Parses an entire line, char by char, from key action
  //into human readable text.
  string ParseLine(string l){
    string result;
    
    //Ensure X and Y Pos are reset
    this->xPos = 0;
    this->yPos = 0;
    
    for(unsigned int i=0; i < l.length(); i++){
      switch(l[i]){
      case 'U':
	this->cursorUp();
	break;
      case 'D':
	this->cursorDown();
	break;
      case 'L':
	this->cursorLeft();
	break;
      case 'R':
	this->cursorRight();
	break;
      case 'S':
	//Space is input; append a space
	result += ' ';
	break;
      case '*':
	//Current character is selected; append character at (y,x)
	result += this->keyGrid[yPos][xPos];
	break;
      default:
	//Any other character has shown up and is invalid.
	//throw runtime_error("Invalid path character.");

	//Instead of throwing an exception, return a warning with info
	return string("Warning, invalid character (") + l[i] +
	  string(") detected in string: ") + l +
	  string(". Skipping line.");
	break;
      }
    }

    //Pass along the parsed string.
    return result;
  }
private:
  //Use a constant for the key grid, as the values here never change.
  const char keyGrid[6][6] = {
    {'A','B','C','D','E','F'}, //Row 0 ABCDEF
    {'G','H','I','J','K','L'}, //Row 1 GHIJKL
    {'M','N','O','P','Q','R'}, //Row 2 MNOPQR
    {'S','T','U','V','W','X'}, //Row 3 STUVWX
    {'Y','Z','1','2','3','4'}, //Row 4 YZ1234
    {'5','6','7','8','9','0'}  //Row 5 567890
  };
  int xPos = 0;
  int yPos = 0;

  void cursorUp(){
    //0 is top, 5 is bottom
    //Unless yPos is 0, decrement yPos to move up.
    //Otherwise, set yPos to 5
    if(yPos == 0)
      yPos = 5;
    else
      yPos--;
  }

  void cursorDown(){
    //0 is top, 5 is bottom
    //Unless yPos is 5, increment yPos to move down.
    //Otherwise, set yPos to 0.
    if(yPos == 5)
      yPos = 0;
    else
      yPos++;
  }

  void cursorLeft(){
    //0 is leftmost, 5 is rightmost.
    //Unless xPos is 0, decrement xPos to move left.
    //Otherwise, set xPos to 5.
    if(xPos == 0)
      xPos = 5;
    else
      xPos--;
  }

  void cursorRight(){
    //0 is leftmost, 5 is rightmost.
    //Unless xPos is 5, increment xPos to move right.
    //Otherwise, set xPos to 0.
    if (xPos == 5)
      xPos = 0;
    else
      xPos++;
  }
};


int main(int argc, char* argv[]){
  string inputFileName;
  string outputFileName;
  time_t now = time(0);

  KeyParser kp;

  //We should have at least three args.
  // executable, -i, and the input filename.
  // -o OUTPUTFILE is optional as a whole
  if (argc < 3){
    cerr << "Usage: " << argv[0] << "-i INPUTFILE [-o OUTPUTFILE]" << endl;
    return 1;
  }

  //Arguments can be in any order; we just need to make sure we actually have an input file
  for (int i = 1; i < argc; i++){
    if (string(argv[i]) == "-i"){
      if ( i + 1 < argc && string(argv[i+1]) != "-o") //Ensure we aren't at end of arguments and an argument is actually passed if it's the first
	inputFileName = argv[++i]; //Increment, so we don't lose our argument in the next iteration
      
	else {
	cerr << "-i requires one argument" << endl;
	return 1;
      }
    }
    else if (string(argv[i]) == "-o"){
      if (i + 1 < argc && string(argv[i+1]) != "-i") //Ensure we aren't at the end of arguments and an argument is actually passed if it's the first
	outputFileName = argv[++i]; //Increment, so we don't lose our argument in the next iteration
      else {
	cerr << "-o requires one argument or should not be passed" << endl;
	return 1;
      }
    }
  }

  //If we don't have an input file, then exit -- we need an input file.
  if (inputFileName.length() == 0){
    cerr << "-i is required; please provide an input file." << endl;
    return 1;
  }

  //If we don't have an output file, create a basic one with the current date and time
  if(outputFileName.length() == 0){
    struct tm * timeinfo;
    timeinfo = localtime(&now);
    char timepart [16];

    //format: yyyymmdd_HHMMSS e.g. 20190124_153530
    strftime(timepart, 16, "%Y%m%d_%H%M%S", timeinfo);

    outputFileName = "keypath_output_" + string(timepart) + ".txt";
  }

  //Since we have both an input and output file now, create the filestreams.
  ifstream inputFile(inputFileName);
  ofstream outputFile(outputFileName);
  string line; //read input lines here

  //While there are lines in the input file, parse the lines and write them immediately to the output file
  if(inputFile.is_open()){
    while(getline (inputFile, line) ){
      if(outputFile.is_open())
	outputFile << kp.ParseLine(line) << endl;
      else
	throw runtime_error("Failed to open output file: " + outputFileName);
    }

    //With no more input, close the files
    inputFile.close();
    outputFile.close();
  }
  else
    throw runtime_error("Failed to open input file: " + inputFileName);

  return 0;

}
