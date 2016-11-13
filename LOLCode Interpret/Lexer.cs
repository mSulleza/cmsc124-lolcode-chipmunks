using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LOLCode_Interpret
{
    public class Lexer
    {
        public static char[] token = new Char[500];

        public static List<String> code = new List<String>();
        public static List<String> keyMatch = new List<String>(); //stores and counts the matched keywords
        public static List<String> classification = new List<String>();
        public static int keyMatchCount = 0;

        public static List<String> variables = new List<String>(); //stores and counts the variables
        public static int variableCount = 0;

        public static string fileName;
        //change this to dynamic path
        public static string filePath;
        public static void readPerLine(String filePath)
        {
            
            int HAIBYECounter = 0;
            int counter = 0;
            string line;
            bool HAIFound = false;
            bool BYEFound = false;
            string patternVISIBLE = "^((\t| )VISIBLE) ((\")(.*)(\")|[^\"].*[^\"])$";
            string patternBYE = @"^KTHXBYE$";
            string patternHAI = @"^HAI$";
            string patternGIMMEH = @"^GIMMEH [a-zA-Z]*[0-9_]*$";
            //reads the file line by line
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            int lineCount = File.ReadAllLines(filePath).Length; //gets the number of lines
            //reads until not null
            while ((line = file.ReadLine()) != null)
            {
                code.Add(line.ToString());
                //checks for HAI BYE partner
                if (counter == 0)
                {   //checks for HAI
                    Match matchHAI = Regex.Match(line, patternHAI);
                    if(matchHAI.Success)
                    {
                        HAIFound = true;
                        keyMatch.Add(matchHAI.ToString());
                        keyMatchCount += 1;
                        classification.Add("Code Delimiter");
                    }
                }
                if (counter == lineCount-1 && HAIFound == true)
                {
                    Match matchBYE = Regex.Match(line, patternBYE);
                    if(matchBYE.Success)
                    {
                        BYEFound = true;
                        HAIBYECounter += 1;
                        keyMatch.Add(matchBYE.ToString());
                        keyMatchCount += 1;
                        classification.Add("Code Delimiter");
                    }
                }
                //end of HAI BYE partner
                
                //checks for keyword VISIBLE

                
                Match matchVISIBLE = Regex.Match(line, patternVISIBLE);
                if (matchVISIBLE.Success)
                {
                    keyMatch.Add(matchVISIBLE.Groups[1].ToString().Replace("\t", "").Replace(" ",""));
                    classification.Add("Output Keyword");
                    keyMatchCount += 1;
                    //check for the pair of string delimiter
                    if (matchVISIBLE.ToString().Contains('"'))
                    {
                        Console.Write(matchVISIBLE.Groups[5].ToString());
                        keyMatch.Add(matchVISIBLE.Groups[4].ToString());
                        classification.Add("String Delimiter");
                        keyMatch.Add(matchVISIBLE.Groups[5].ToString());
                        classification.Add("String Literal");
                        keyMatch.Add(matchVISIBLE.Groups[6].ToString());
                        classification.Add("String Delimiter");
                        keyMatchCount += 3;
                    }
                    else
                    {
                        //no need to add, because it is assumed that the variable is already declared
                        //reference the variable in 
                        keyMatch.Add(matchVISIBLE.Groups[2].ToString());
                        keyMatchCount += 1;
                        classification.Add("Variable");
                    }
                }
                //check for GIMMEH lexeme
                Match matchGIMMEH = Regex.Match(line, patternGIMMEH);



                counter += 1;
            }

            file.Close();

        }

        
    }
}
