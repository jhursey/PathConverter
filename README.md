# Keypath to Text

## Process
Begin by forking this repository.
Your solution will be reviewed once you submit a pull request.

Remember to treat the below problem as a production request that may run in production for years.
You are free to use whatever technology stack you feel is warranted.


## Problem
```
In order to analyze the search terms, as a data scientist, I need the key paths converted to text.
```

Our users input search terms using a television remote.
The arrow buttons are used to navigate a grid of letters until a letter is selected.
The letters are organized as follows:
```
ABCDEF
GHIJKL
MNOPQR
STUVWX
YZ1234
567890
```

Unfortunately only the key paths are logged.
We must convert the path into text to complete the analysis.

Please write a program that will:
* Accept a flat file as input
  * Each line is a new key path
  * Key paths consist of a string of characters where
    * U = up
    * D = down
    * L = left
    * R = right
    * S = space
    * \* = select
  * Key paths always start at the upper left corner, i.e. 'A'
* Output the search term into a new file

Sample Input
------------
DDDR\*UU\*LLLU\*SDD\*DLL\*UU\*U\*RRD\*SURRR\*LLDD\*LLL\*DRR\*RRRU\*SUULL\*DDLLL\*LLLD\*SUULL\*DDL\*LLU\*RRR\*UUR\*L\*SDDL\*RD\*UUUR\*DDR\*SRRD\*UU\*LLLU\*SDR\*RU\*UUR\*L\*SDDRRR\*DDL\*LLU\*

Sample Output
-------------
THE QUICK BROWN FOX JUMPED OVER THE LAZY DOG
