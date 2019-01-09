import sys

inFile = sys.argv[1]
file = open(inFile, "r")

letters = [
    ['A', 'B','C','D','E','F'],
    ['G','H','I','J','K','L'],
    ['M','N','O','P','Q','R'],
    ['S','T','U','V','W','X'],
    ['Y','Z','1','2','3','4'],
    ['5','6','7','8','9','0']
]


# READ IN KEYPATHS FROM FILE
keypaths = []
for line in file:
    keypaths.append(line)


def keypathRecurse(keypaths):
    if len(keypaths) == 0:
        return 
    else:
        xPos = 0
        yPos = 0
        message = ""

        for key in keypaths[0]:
            # MAP KEYS TO CURSOR POSITIONS
            # ADD TO MESSAGE IF SPACE IS FOUND
            if key == '*':
                message += letters[xPos][yPos]
            else:
                if key == 'U':
                    xPos = xPos - 1
                elif key == 'D':
                    xPos = xPos + 1
                elif key == 'L':
                    yPos = yPos - 1
                elif key == 'R':
                    yPos = yPos + 1
                elif key == 'S':
                    message += ' '

                # ADJUST THE CURSOR IF OUT OF BOUNDS
                if xPos > 5:
                    xPos = 0
                if xPos < 0:
                    xPos = 5
                if yPos > 5:
                    yPos = 0
                if yPos < 0:
                    yPos = 5

    print message
    keypaths.remove(keypaths[0])
    keypathRecurse(keypaths)

keypathRecurse(keypaths)









