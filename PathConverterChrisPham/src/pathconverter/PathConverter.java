/*  Chris Pham 
 *  Feb 12, 2021
 *  Connors Group Interview Assignment - 1
 * 
 */
package pathconverter;

import java.io.*;
import java.util.*;

public class PathConverter {
    
    private static String TelevisionRemoteKeypad(String remoteKeyPath){
        String searchTerm = " ";
        
        StringBuffer sb = new StringBuffer();
        
        //Tv Keypad
        String[][] tvKeypad = {{"A", "B", "C", "D", "E", "F"},
                               {"G", "H", "I", "J", "K", "L"},
                               {"M", "N", "O", "P", "Q", "R"},
                               {"S", "T", "U", "V", "W", "X"},
                               {"Y", "Z", "1", "2", "3", "4"},
                               {"5", "6", "7", "8", "9", "0"}};

        //Key into array to iterate
        String[] inputTempArray = remoteKeyPath.split(""); 

        //Tracking position of cursor on keypad
        int positionX = 0, positionY = 0; 

        for(int i = 0; i < inputTempArray.length; i++){
            
            //Pushing Arrow and Select Keys on remote
            String temp = inputTempArray[i];
                        
            if(temp.equals("U")){
                positionY--;
            } else if(temp.equals("D")){
                positionY++;
            } else if(temp.equals("L")){
                positionX--;
            } else if(temp.equals("R")){
                positionX++;
            } else if(temp.equals("S")){
                sb.append(" ");
            } else if(temp.equals("*")){
                
                //Handling reset when cursor moves out of bounds to other side of key pad
                if(positionX < 0){
                    positionX = 6 + positionX;
                }
                if(positionX > 6){
                    positionX = positionX - 6;
                }
                if(positionY < 0){
                    positionY = 6 + positionY;
                }
                if(positionY > 6){
                    positionY = positionY - 6;
                }
                if(positionX == 6){
                    positionX = 0;
                }
                if(positionY == 6){
                    positionY = 0;
                }
                //Append letter to string buffer sb
                sb.append(tvKeypad[positionY][positionX].toString());
            }
        }
        searchTerm = sb.toString();
        return searchTerm;
    }

    public static void main(String[] args) throws IOException{
        /*  
            U = up
            D = down
            L = left
            R = right
            S = space
            * = select
        
            {{"A", "B", "C", "D", "E", "F"},
            {"G", "H", "I", "J", "K", "L"},
            {"M", "N", "O", "P", "Q", "R"},
            {"S", "T", "U", "V", "W", "X"},
            {"Y", "Z", "1", "2", "3", "4"},
            {"5", "6", "7", "8", "9", "0"}};
        
            "DDDR*UU*RRRU*SDD*DLL*UU*U*RRD*SULLL*LLDD*LLL*DRR*RRRU*SUULL*DDLLL*LLLD*SUULL*DDL*LLU*RRR*UUR*L*SDDL*RD*UUUR*DDR*SRRD*UU*LLLU*SDR*RU*UUR*L*SDDRRR*DDL*LLU*"
        
            THE QUICK BROWN FOX JUMPED OVER THE LAZY DOG
        */ 

        try{
            //Reading in file "Keypath.txt"
            File input = new File("src/Keypath.txt");
            
            //Converting text file contents to string
            Scanner scanner = new Scanner(input);
            String remoteKeyPath = scanner.next();
            
            //Convert keypath to Search term on TV
            String searchTerm = TelevisionRemoteKeypad(remoteKeyPath);
            
            //Outputting search term to SearchTerm.txt
            FileOutputStream outputStream = new FileOutputStream("src/SearchTerm.txt");
            byte[] strToBytes = searchTerm.getBytes();
            outputStream.write(strToBytes);            
            outputStream.close();
        } catch(FileNotFoundException e){
            System.err.println("File not found");
        }
    }    
}

/*
        for(int remoteButton = 0; remoteButton < inputTempArray.length; remoteButton++){
            String temp = inputTempArray[remoteButton];
            System.out.print(temp);

            for(int characterRow = positionY; characterRow < tvRemote.length; characterRow++){
                for(int characterColumn = positionX; characterColumn < tvRemote.length; characterColumn++){
                                   
                    if(temp.equals("U")){
                        characterRow--; 
                        positionY = characterRow; 
                        //System.out.println(tvRemote[characterRow][characterColumn]);
                    } else if(temp.equals("D")){
                        characterRow++;
                        positionY = characterRow;
                        //System.out.println(tvRemote[characterRow][characterColumn]);
                    } else if(temp.equals("L")){
                        characterColumn--;
                        positionX = characterColumn;
                        //System.out.println(tvRemote[characterRow][characterColumn]);
                    } else if(temp.equals("R")){
                        characterColumn++;
                        positionX = characterColumn;
                        //System.out.println(tvRemote[characterRow][characterColumn]);
                    } else if(temp.equals("S")){
                        output.add(" ");
                    } else if(temp.equals("*")){                        
                        output.add(tvRemote[characterRow][characterColumn].toString());  
                    } 
                }
            }
            searchTerm = output.toString();
            //System.out.println("OUTPUT: " + output.toString());
        }
*/