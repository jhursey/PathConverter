# Firstly, get the flatfile from the user. 
def getFile():
    file_path = input("Input the path to the flat file: ")
    try:
        keypath = open(file_path, "r")
    except:
        print("The file is not there.")
        print("Run again once found.")
    return keypath
# Secondly, iterate through the file and update a state dictionary containing string and grid states.
# Also, the nested if statement checks for out of bounds and resets it accordingly.
def analyzeFile(file):
    state_dict = {
        "string_state": "",
        "grid_state": [0, 0],
    }
    nav_grid = [ 
        ['A', 'B', 'C', 'D', 'E', 'F'] ,
        ['G', 'H', 'I', 'J', 'K', 'L'] ,
        ['M', 'N', 'O', 'P', 'Q', 'R'] ,
        ['S', 'T', 'U', 'V', 'W', 'X'] ,
        ['Y', 'Z', '1', '2', '3', '4'] ,
        ['5', '6', '7', '8', '9', '0'] ]
    for character in file.read():
        if character == "U":
            if state_dict["grid_state"][0] == -6: # Out of bounds check
                state_dict["grid_state"][0] = 0
            state_dict["grid_state"][0] -= 1
        elif character == "D":
            if state_dict["grid_state"][0] == 5: # Out of bounds check
                state_dict["grid_state"][0] = -1
            state_dict["grid_state"][0] += 1
        elif character == "L":
            if state_dict["grid_state"][1] == -6: # Out of bounds check
                state_dict["grid_state"][1] = 0
            state_dict["grid_state"][1] -= 1
        elif character == "R":
            if state_dict["grid_state"][1] == 5: # Out of bounds check
                state_dict["grid_state"][1] = -1
            state_dict["grid_state"][1] += 1
        elif character == "*":
            indexOne = state_dict["grid_state"][0]
            indexTwo = state_dict["grid_state"][1]
            state_dict["string_state"] += nav_grid[indexOne][indexTwo]
        elif character == "S":
            state_dict["string_state"] += " "
    return state_dict["string_state"]
# Lastly, open a new file to return and give it your search term string.
def outputSearchTerm(textToNewFile):
    searchTermFile = open("SearchTerm", "w")
    searchTermFile.write(textToNewFile)
    searchTermFile.close()

def main():
    outputSearchTerm(analyzeFile(getFile()))
    print("--Text from Keypath Complete.--")
    print("--File Created--")
main()