def getFile():
    file_path = input("Input the path to the flat file: ")
    try:
        keypath = open(file_path, "r")
    except:
        print("The file is not there.")
    return keypath
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
            if state_dict["grid_state"][0] == -6:
                state_dict["grid_state"][0] = 0
            state_dict["grid_state"][0] -= 1
        elif character == "D":
            if state_dict["grid_state"][0] == 5:
                state_dict["grid_state"][0] = -1
            state_dict["grid_state"][0] += 1
        elif character == "L":
            if state_dict["grid_state"][1] == -6:
                state_dict["grid_state"][1] = 0
            state_dict["grid_state"][1] -= 1
        elif character == "R":
            if state_dict["grid_state"][1] == 5:
                state_dict["grid_state"][1] = -1
            state_dict["grid_state"][1] += 1
        elif character == "*":
            print(state_dict["string_state"])
            indexOne = state_dict["grid_state"][0]
            indexTwo = state_dict["grid_state"][1]
            state_dict["string_state"] += nav_grid[indexOne][indexTwo]
        elif character == "S":
            state_dict["string_state"] += " "
    return state_dict["string_state"]

def outputSearchTerm(textToNewFile):
    searchTermFile = open("SearchTerm", "w")
    searchTermFile.write(textToNewFile)
    searchTermFile.close()

def main():
    outputSearchTerm(analyzeFile(getFile()))

main()