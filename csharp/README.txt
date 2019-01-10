-----------PathConverter implementation notes-----------

To run the program use:
PathConverter.exe <InputFile> [<OutputFile>]

An input file is required and a default output file will be created 
if none is specified

------Assumptions------

- Assume there can be multiple lines of input, each representing to a 
	different keypath
	
- A single output file will be created where each line is the corresponding
	search term to each key path input

- The program will exit on bad input with no output. For example, if an
	unexpected character is encountered in the input, the program will 
	immediately exit with an error message without generating any output.
