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
        public static List<String> keyMatch = new List<String>(); //stores and counts the matched keywords
        public static List<String> classification = new List<String>();
        public static int keyMatchCount = 0;

        public static List<String> variables = new List<String>(); //stores and counts the variables
        public static int variableCount = 0;

        public static string fileName;
        //change this to dynamic path
        public static string filePath;
        public static string codeBlock;
        public static System.IO.StreamReader openFileProcedure(String filePath)
        {
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(filePath);
                return file;
            }
            catch (System.ArgumentNullException e)
            {
                MessageBox.Show("File not specified!");
                throw new System.ArgumentNullException("Error",e);
            }
        }

        public static String readAll(System.IO.StreamReader file)
        {
            string code = file.ReadToEnd();
            return code;
        }
        
        public static void readPerLine(String filePath)
        {
            System.IO.StreamReader file = openFileProcedure(filePath);
            codeBlock = readAll(file);
            file.Close();
            file = openFileProcedure(filePath);
            int HAIBYECounter = 0;
            int counter = 0;
            string line;
            string prevLine = "";
            bool HAIFound = false;
            bool BYEFound = false;
            bool foundWTF = false;
            bool foundORLY = false;
            bool foundYARLY = false;
            bool foundNOWAI = false;
            string patternInteger = @"^(-?[0-9]*)$"; //edit: included negative integer "-?"
            string patternVariable = @"^([a-zA-Z]+)([0-9_]*)$";
            string patternVISIBLE = "^((\t| )VISIBLE) ((\")(.*)(\")|[^\"].*[^\"])$";
            string patternBYE = @"^KTHXBYE$";
            string patternHAI = @"^HAI$";
            string patternIHASA = @"^((\t| )I HAS A) ([a-zA-Z]+)([0-9_]*)$"; //edit: changed [a-zA-Z]* to [a-zA-Z]+
            string patternIHASAITZ = @"^((\t| )I HAS A) ([a-zA-Z]*)([0-9_]*) (ITZ) (([0-9]*)|([a-zA-Z]*)([0-9_]*))$"; //edit: changed  ([a-zA-Z]*([0-9_]*)) to (".*")
            //string patternR = @"^((\t| ([a-zA-Z]*)([0-9_]*) (R) ([0-9])*)$";
            string patternGIMMEH = @"^((\t| )GIMMEH) ([a-zA-Z]*)([0-9_]*)$";
            string patternArithmeticOps = @"^((\t| )((SUM)|(DIFF)|(PRODUKT)|(QUOSHUNT)|(MOD)|(BIGGR)|(SMALLR)))"+" (OF) ([0-9]*) (AN) ([0-9]*)$";
            string patternBooleanOps = @"^((\t| )((BOTH)|(EITHER)|(WON)|(ALL)|(ANY)))"+" (OF) ((WIN)|(FAIL)) (AN) ((WIN)|(FAIL))$";
            string patternBooleanNot = @"^((\t| )NOT) ((WIN)|(FAIL))$";
            string patternIfElse = @"^((\t| )(.*))(\n)((\t| )(O RLY?)(\n))((\t| )(YA RLY)(\n))((\t| )(.*))(\n)((\t| )(NO WAI)(\n))((\t| ).*)((\t| )(OIC))$";
            //reads the file line by line
            int lineCount = File.ReadAllLines(filePath).Length; //gets the number of lines
            //reads until not null
            while ((line = file.ReadLine()) != null)
            {
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
                //check for I HAS A _ ITZ _ lexeme
                Match matchIHASA = Regex.Match(line, patternIHASA);
                Match matchIHASITZ = Regex.Match(line, patternIHASAITZ);
                if (matchIHASITZ.Success)
                {               //initialized declaration
                    keyMatch.Add(matchIHASITZ.Groups[1].ToString().Replace("\t", "").Replace(" I", "")); //edit: added replacement for \t with an empty char
                    classification.Add("Variable Declaration");
                    Console.WriteLine("{0}", matchIHASITZ.Groups[6].ToString());

                    Match matchInt = Regex.Match(matchIHASITZ.Groups[6].ToString(), patternInteger);
                    Match matchVar = Regex.Match(matchIHASITZ.Groups[6].ToString(), patternVariable);
                    if (matchInt.Success)
                    {                   //check if initialized with int
                        keyMatch.Add(matchIHASITZ.Groups[3].ToString());
                        classification.Add("NUMBR Variable");   //integer variable
                        keyMatch.Add(matchIHASITZ.Groups[5].ToString());
                        classification.Add("Variable Initialization");
                        keyMatch.Add(matchIHASITZ.Groups[6].ToString());
                        classification.Add("NUMBR");
                    }
                    else if (matchVar.Success)
                    {           //check if initialized with variable
                        keyMatch.Add(matchIHASITZ.Groups[3].ToString());
                        classification.Add("Variable");         //TODO: check value of variable
                        keyMatch.Add(matchIHASITZ.Groups[5].ToString());
                        classification.Add("Variable Initialization");
                        keyMatch.Add(matchIHASITZ.Groups[6].ToString());
                        classification.Add("Variable");
                    }
                    else
                    {
                        //initialized with expression
                    }
                    keyMatchCount += 4;
                }
                else if (matchIHASA.Success)
                { //uninitialized decalaration
                    keyMatch.Add(matchIHASA.Groups[1].ToString().Replace(" I", "I"));
                    classification.Add("Variable Declaration");
                    keyMatch.Add(matchIHASA.Groups[3].ToString());
                    classification.Add("NOOB Variable");
                    keyMatchCount += 2;
                }





                //check for GIMMEH lexeme
                Match matchGIMMEH = Regex.Match(line, patternGIMMEH);
                if (matchGIMMEH.Success)
                {
                    keyMatch.Add(matchGIMMEH.Groups[1].ToString().Replace(" ", ""));
                    keyMatchCount += 1;
                    classification.Add("Input Keyword");
                }

                //check for assignment statements
                /*Match matchRAssignment = Regex.Match(line, patternR);
				if (matchRAssignment.Success) {
					keyMatch.Add (matchRAssignment.Groups [1].ToString().Replace (" ", ""));
					classification.Add ("Variable");
					keyMatch.Add (matchRAssignment.Groups [2].ToString());
					classification.Add ("Assignment Statement");
					keyMatch.Add (matchRAssignment.Groups [3].ToString());
					classification.Add ("Variable");
					keyMatchCount += 3;
				}*/


                //check for Simple Arithmetic Operations
                Match matchArithmeticOps = Regex.Match(line, patternArithmeticOps);
                if (matchArithmeticOps.Success)
                {
                    keyMatch.Add(matchArithmeticOps.Groups[1].ToString().Replace(" ", "") +
                            " " + matchArithmeticOps.Groups[11].ToString());

                    switch (matchArithmeticOps.Groups[1].ToString().Replace(" ", ""))
                    {
                        case "SUM":
                            classification.Add("Addition Operator");
                            break;
                        case "DIFF":
                            classification.Add("Subtraction Operator");
                            break;
                        case "PRODUKT":
                            classification.Add("Product Operator");
                            break;
                        case "QUOSHUNT":
                            classification.Add("Division Operator");
                            break;
                        case "MOD":
                            classification.Add("Modulo Operator");
                            break;
                        case "BIGGR":
                            classification.Add("Max Operator");
                            break;
                        case "SMALLR":
                            classification.Add("Min Operator");
                            break;
                    }

                    keyMatch.Add(matchArithmeticOps.Groups[12].ToString());
                    classification.Add("NUMBR");
                    keyMatch.Add(matchArithmeticOps.Groups[13].ToString());
                    classification.Add("Concatenation");
                    keyMatch.Add(matchArithmeticOps.Groups[14].ToString());
                    classification.Add("NUMBR");
                    keyMatchCount += 4;
                }


                //check for Simple Boolean Operations
                Match matchBooleanOps = Regex.Match(line, patternBooleanOps);
                if (matchBooleanOps.Success)
                {
                    keyMatch.Add(matchBooleanOps.Groups[1].ToString().Replace(" ", "") +
                        " " + matchBooleanOps.Groups[9].ToString());

                    switch (matchBooleanOps.Groups[1].ToString().Replace(" ", ""))
                    {
                        case "BOTH":
                            classification.Add("AND Operator");
                            break;
                        case "EITHER":
                            classification.Add("OR Operator");
                            break;
                        case "WON":
                            classification.Add("XOR Operator");
                            break;
                        case "ALL":
                            classification.Add("Infinite Arity AND Operator");
                            break;
                        case "ANY":
                            classification.Add("Infinite Arity OR Operator");
                            break;
                    }

                    keyMatch.Add(matchBooleanOps.Groups[10].ToString());
                    if (String.Compare(matchBooleanOps.Groups[10].ToString(), "WIN") == 0)
                    {   //check if WIN or FAIL
                        classification.Add("Boolean True");
                    }
                    else if (String.Compare(matchBooleanOps.Groups[10].ToString(), "FAIL") == 0)
                    {
                        classification.Add("Boolean False");
                    }
                    keyMatch.Add(matchBooleanOps.Groups[13].ToString());
                    classification.Add("Concatenation");
                    keyMatch.Add(matchBooleanOps.Groups[14].ToString());
                    if (String.Compare(matchBooleanOps.Groups[14].ToString(), "WIN") == 0)
                    {   //check if WIN or FAIL
                        classification.Add("Boolean True");
                    }
                    else if (String.Compare(matchBooleanOps.Groups[14].ToString(), "FAIL") == 0)
                    {
                        classification.Add("Boolean False");
                    }
                    keyMatchCount += 4;
                }

                //check for NOT operation
                Match matchBooleanNot = Regex.Match(line, patternBooleanNot);
                if (matchBooleanNot.Success)
                {
                    keyMatch.Add(matchBooleanNot.Groups[1].ToString().Replace(" ", ""));
                    classification.Add("NOT Operator");
                    keyMatch.Add(matchBooleanNot.Groups[3].ToString());
                    if (String.Compare(matchBooleanNot.Groups[3].ToString(), "WIN") == 0)
                    {   //check if WIN or FAIL
                        classification.Add("Boolean True");
                    }
                    else if (String.Compare(matchBooleanNot.Groups[3].ToString(), "FAIL") == 0)
                    {
                        classification.Add("Boolean False");
                    }
                }

                //check for O RLY?
                Match matchORLY = Regex.Match(line, @"^((\t| )(O RLY(\?)))$");
                if (matchORLY.Success)
                {           //found 'O RLY?'
                    keyMatch.Add(prevLine);         //found previous expression; to be used in implementation
                    classification.Add("Expression for If-Else Statement");
                    keyMatch.Add(matchORLY.Groups[1].ToString().Replace(" ", ""));
                    classification.Add("Start of If-Else Statement");
                    foundORLY = true;
                }
                matchORLY = Regex.Match(line, @"^((\t)| )(YA RLY)$");
                if (matchORLY.Success && foundORLY)
                {           //found 'YA RLY' and foundORLY==true
                    keyMatch.Add(matchORLY.ToString().Replace(" Y", "Y"));
                    classification.Add("Start of If Clause");
                    foundYARLY = true;
                }
                matchORLY = Regex.Match(prevLine, @"^((\t| )(YA RLY))$");
                if (matchORLY.Success)
                {   //check if prevLine is YA RLY
                    matchORLY = Regex.Match(line, @".*");
                    if (matchORLY.Success)
                    {       //found code block for YA RLY
                        keyMatch.Add(matchORLY.ToString());
                        classification.Add("If Code Block");
                    }
                }
                matchORLY = Regex.Match(line, @"^((\t| )NO WAI)$");
                if (matchORLY.Success && foundYARLY)
                {       //found 'NO WAI' and foundYARLY==true
                    keyMatch.Add(matchORLY.ToString().Replace(" N", "N"));
                    classification.Add("Start of Else Clause");
                }
                if ((matchORLY = Regex.Match(prevLine, @"^((\t| )(NO WAI))$")).Success)
                {   //check if prevLine is NO WAI
                    matchORLY = Regex.Match(line, @".*");
                    if (matchORLY.Success)
                    {       //found code block NO WAI
                        keyMatch.Add(matchORLY.ToString());
                        classification.Add("Else Code Block");
                    }
                }
                matchORLY = Regex.Match(line, @"^((\t| )OIC)$");
                if (matchORLY.Success && foundORLY && foundYARLY)
                {       //found OIC and O RLY and YA RLY
                    keyMatch.Add(matchORLY.ToString().Replace(" ", ""));
                    classification.Add("End of If-Else Statement");
                    foundORLY = false;      //reset values
                    foundYARLY = false;
                }

                //check for WTF?
                Match matchWTF = Regex.Match(line, @"^((\t| )WTF(\?))$");
                if (matchWTF.Success)
                {           //found 'WTF?'
                    keyMatch.Add(matchWTF.ToString().Replace(" ", ""));
                    classification.Add("Start of Switch Statement");
                    foundWTF = true;
                }
                matchWTF = Regex.Match(line, @"^((\t)| )+(OMG) ([0-9]*)$");
                if (matchWTF.Success)
                {           //found OMG
                    keyMatch.Add(matchWTF.Groups[3].ToString());
                    classification.Add("Switch Case");
                    keyMatch.Add(matchWTF.Groups[4].ToString());
                    classification.Add("Value Literal");
                }
                matchWTF = Regex.Match(line, @"^(.*)$");
                Match matchPrev = Regex.Match(prevLine, @"^((\t)| )+(OMG) ([0-9]*)$");
                if (matchWTF.Success && matchPrev.Success)
                {   //found code block for case and prevLine is OMG _
                    keyMatch.Add(matchWTF.ToString());
                    classification.Add("Case Expression");
                }
                matchWTF = Regex.Match(line, @"^((\t)| )+(OMGWTF)$");
                if (matchWTF.Success)
                {           //found OMGWTF
                    keyMatch.Add(matchWTF.ToString().Replace(" ", ""));
                    classification.Add("Default Case");
                }
                matchWTF = Regex.Match(line, @"^(.*)$");
                matchPrev = Regex.Match(prevLine, @"^((\t)| )+(OMGWTF)$");
                if (matchWTF.Success && matchPrev.Success)
                {   //found code block for case and prevLine is OMGWTF
                    keyMatch.Add(matchWTF.ToString());
                    classification.Add("Default Case Expression");
                }
                matchWTF = Regex.Match(line, @"^((\t)| )+(OIC)$");
                if (matchWTF.Success && foundWTF == true)
                {       //found OIC and foundWTF==true
                    keyMatch.Add(matchWTF.ToString().Replace(" ", ""));
                    classification.Add("End of Switch Statement");
                    foundWTF = false;           //reset value to false
                }


                counter += 1;
                prevLine = line;
            }

            file.Close();

        }

        
    }
}
