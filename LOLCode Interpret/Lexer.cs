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
            if (filePath != null)
            {
                file = new System.IO.StreamReader(filePath);
                return file;
            }
            else
            {
                MessageBox.Show("File not specified!");
                return null;
            }
        }
        public static void smooshString(String input)
        {
            string patternSmoosh = @"^( |\t)?(SMOOSH) ([a-zA-Z]+[0-9_]*|WIN|FAIL|-?[0-9]+|-?[0-9]*\.[0-9]|\042.*\042) (AN) ([a-zA-Z]+[0-9_]*|WIN|FAIL|-?[0-9]+|-?[0-9]*\.[0-9]|\042.*\042)$";
            Match isSmoosh = Regex.Match(input, patternSmoosh);
            if (isSmoosh.Success)
            {
                keyMatch.Add(isSmoosh.Groups[2].ToString());
                classification.Add("Concatenation Keyword");
                keyMatch.Add(isSmoosh.Groups[3].ToString());
                isWhat(isSmoosh.Groups[3].ToString());
                keyMatch.Add(isSmoosh.Groups[4].ToString());
                classification.Add("Concatenation");
                //can't use again because therer is no more SMOOSH keyword
                //create another function that will read the AN and the follow
                string isSmooshMore = @"(AN) ([a-zA-Z]+[0-9_]*|WIN|FAIL|-?[0-9]+|-?[0-9]*\.[0-9]|\042.*\042) ";
                Match isSmooshAgain = Regex.Match(isSmooshMore, patternSmoosh);
                if (isSmooshAgain.Success)
                {
                    smooshString(isSmoosh.Groups[5].ToString());
                }
                else
                {
                    keyMatch.Add(isSmoosh.Groups[5].ToString());
                    isWhat(isSmoosh.Groups[5].ToString());
                }
            }
        }
        public static String readAll(System.IO.StreamReader file)
        {
            string code = file.ReadToEnd();
            return code;
        }
        public static void matchSingleComment(String input)
        {
            string patternBTW = @"^( |\t)?(BTW)(.*)$";
            Match matchBTWSingle = Regex.Match(input, patternBTW);
            if (matchBTWSingle.Success)
            {
                keyMatch.Add(matchBTWSingle.Groups[2].ToString());
                classification.Add("Single Line Comment Delimiter");
                keyMatch.Add(matchBTWSingle.Groups[3].ToString());
                classification.Add("Comment");
            }

        }

        public static void matchRAssignment(String input)
        {
                                //variable              R   variable            boolean int        yarn            numbar
            string patternR = @"(^([a-zA-Z]+)([0-9_]*)) (R) ([a-zA-Z]+[0-9_]*|WIN|FAIL|-?[0-9]+|(\042)(.*)(\042)|[0-9]*\.[0-9]+|(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+))$";
            Match matchPatternR = Regex.Match(input, patternR);
            if(matchPatternR.Success)
            {
                keyMatch.Add(matchPatternR.Groups[1].ToString());
                classification.Add("Variable");
                keyMatch.Add(matchPatternR.Groups[4].ToString());
                classification.Add("Variable Assignment");
                isWhat(matchPatternR.Groups[5].ToString());
                arithmeticOp(matchPatternR.Groups[5].ToString());
            }
        }
        public static void matchMultiComment(String input)
        {
            
        }

        public static void matchGimmeh(String input)
        {
            string patternGimmeh = @"^(GIMMEH) (([a-zA-Z]+)([0-9_]*))$";
            Match matchPatternGimmeh = Regex.Match(input, patternGimmeh);
            if (matchPatternGimmeh.Success)
            {
                keyMatch.Add(matchPatternGimmeh.Groups[1].ToString());
                classification.Add("Input Keyword");
                keyMatch.Add(matchPatternGimmeh.Groups[2].ToString());
                classification.Add("Variable");
                variables.Add(matchPatternGimmeh.Groups[2].ToString());
            }
        }
        public static void isWhat(String input)
        {
            string patternVariable = @"^([a-zA-Z]+)([0-9_]*)$";
            string patternNumbar = @"^[0-9]*\.[0-9]+$";
            string patternYarn = @"(\042)(.*)(\042)";
            string patternBoolean = @"^(WIN|FAIL)$";
            Match isVariable = Regex.Match(input, patternVariable);
            Match isYarn = Regex.Match(input, patternYarn);
            Match isBoolean = Regex.Match(input, patternBoolean);
            if (isBoolean.Success)
            {
                if(isBoolean.ToString() == "WIN")
                {
                    classification.Add("Boolean True");
                    return;
                }
                else
                {
                    classification.Add("Boolean False");
                    return;
                }
            }
            if (isYarn.Success)
            {
                classification.Add("Yarn");
                return;
            }
            if (isVariable.Success)
            {
                classification.Add("Variable");
            }
            else
            {
                Match isNumbar = Regex.Match(input, patternNumbar);
                if (isNumbar.Success)
                {
                    classification.Add("NUMBAR");
                }
                else classification.Add("NUMBR");
            }
        }
        public static void arithmeticOp(String input)
        {
            string patternArithmeticOps = @"^(\t| )?(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+)$";
            Match matchArithmeticOps = Regex.Match(input, patternArithmeticOps);
            if (matchArithmeticOps.Success)
            {

                switch (matchArithmeticOps.Groups[2].ToString()) //edited
                {
                    case "SUM OF":
                        classification.Add("Addition Operator");
                        break;
                    case "DIFF OF":
                        classification.Add("Subtration Operator");
                        break;
                    case "PRODUKT OF":
                        classification.Add("Product Operator");
                        break;
                    case "QUOSHUNT OF":
                        classification.Add("Division Operator");
                        break;
                    case "MOD OF":
                        classification.Add("Modulo Operator");
                        break;
                    case "BIGGR OF":
                        classification.Add("Max Operator");
                        break;
                    case "SMALLR OF":
                        classification.Add("Min Operator");
                        break;
                }
                keyMatch.Add(matchArithmeticOps.Groups[2].ToString());
                keyMatch.Add(matchArithmeticOps.Groups[3].ToString());
                isWhat(matchArithmeticOps.Groups[3].ToString());
                keyMatch.Add(matchArithmeticOps.Groups[5].ToString());
                classification.Add("Concatenation");
                keyMatch.Add(matchArithmeticOps.Groups[6].ToString());
                isWhat(matchArithmeticOps.Groups[6].ToString());
            }
        }
        public static void isExpression(String input)
        {
            string patternArithmeticOps = @"^(\t| )?(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+)$";
            Match isExpression = Regex.Match(input, patternArithmeticOps);
            if (isExpression.Success)
            {
                arithmeticOp(input);
            }
            else
            {
                keyMatch.Add(input);
                isWhat(input);
            }
        }
        public static void booleanOperator(String input)
        {
            MessageBox.Show("Went here!");
            string patternBooleanOps = "^(\t | )?(BOTH OF | EITHER OF | WON OF) ([a - zA - Z] +[0 - 9_] *| WIN | FAIL | ((BOTH OF | EITHER OF | WON OF) ([a - zA - Z] +[0 - 9_] *| WIN | FAIL)(AN)([a - zA - Z] +[0 - 9_] *| WIN | FAIL))) (AN)([a - zA - Z] +[0 - 9_] *| WIN | FAIL)$";
            Match matchPatternBooleanOps = Regex.Match(input, patternBooleanOps);
            if(matchPatternBooleanOps.Success)
            {
                keyMatch.Add(matchPatternBooleanOps.Groups[2].ToString());
                classification.Add("Boolean Operator");
                Match matchPatternBooleanOpsAgain = Regex.Match(matchPatternBooleanOps.Groups[3].ToString(), patternBooleanOps);
                if (matchPatternBooleanOpsAgain.Success)
                {
                    keyMatch.Add(matchPatternBooleanOps.Groups[5].ToString());
                    classification.Add("Boolean Operator");
                    keyMatch.Add(matchPatternBooleanOps.Groups[6].ToString());
                    isWhat(matchPatternBooleanOps.Groups[6].ToString());
                    keyMatch.Add(matchPatternBooleanOps.Groups[7].ToString());
                    classification.Add("Concatenation");
                    keyMatch.Add(matchPatternBooleanOps.Groups[8].ToString());
                    isWhat(matchPatternBooleanOps.Groups[8].ToString());
                    keyMatch.Add(matchPatternBooleanOps.Groups[10].ToString());
                    isWhat(matchPatternBooleanOps.Groups[10].ToString());
                }
                else
                {
                    keyMatch.Add(matchPatternBooleanOps.Groups[3].ToString());
                    isWhat(matchPatternBooleanOps.Groups[3].ToString());
                    keyMatch.Add(matchPatternBooleanOps.Groups[9].ToString());
                    classification.Add("Concatenation");
                    keyMatch.Add(matchPatternBooleanOps.Groups[10].ToString());
                    isWhat(matchPatternBooleanOps.Groups[10].ToString());
                }
            }
        }
        public static void readPerLine(String filePath)
        {

            int lineCount = 0;
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
            string patternArithmeticOps = @"^(\t| )?(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+)$";
            string patternInteger = @"^(-?[0-9]+)$"; //edit: included negative integer "-?"
            string patternVariable = @"^([a-zA-Z]+)([0-9_]*)$";
            string patternVISIBLE = "^((\t| )VISIBLE) ((\")(.*)(\")|[^\"].*[^\"])$";
            string patternBYE = @"^KTHXBYE$";
            string patternHAI = @"^HAI ([0-9]\.[0-9])?$";
            string patternIHASA = @"^((\t| )?I HAS A) (([a-zA-Z]+)([0-9_]*))$"; //edit: changed [a-zA-Z]* to [a-zA-Z]+
            string patternIHASAITZ = @"^((\t| )?I HAS A) (([a-zA-Z]+)([0-9_]*)) (ITZ) (-?[0-9]*|([a-zA-Z]+)([0-9_]*)|-?[0-9]*\.[0-9]+|(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+))$"; //edit: changed  ([a-zA-Z]*([0-9_]*)) to (".*")
            //string patternR = @"^((\t| ([a-zA-Z]*)([0-9_]*) (R) ([0-9])*)$";
            string patternGIMMEH = @"^((\t| )GIMMEH) ([a-zA-Z]*)([0-9_]*)$";
            string patternBooleanOps = @"^(\t| )?(BOTH OF|EITHER OF|WON OF`) (([a-zA-Z]+)([0-9_]*)|(WIN|FAIL)|(BOTH OF|EITHER OF|WON OF) (([a-zA-Z]+)([0-9_]*)|WIN|FAIL) (AN) (([a-zA-Z]+)([0-9_]*)|WIN|FAIL)) (AN) (([a-zA-Z]+)([0-9_]*)|(WIN|FAIL))$";
            string patternBooleanNot = @"^((\t| )NOT) ((WIN)|(FAIL))$";
            string patternIfElse = @"^((\t| )(.*))(\n)((\t| )(O RLY?)(\n))((\t| )(YA RLY)(\n))((\t| )(.*))(\n)((\t| )(NO WAI)(\n))((\t| ).*)((\t| )(OIC))$";
            string patternBOTHSAEM = @"^(\t| )?(BOTH SAEM) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+|(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+))$";
            string patternDIFFRINT = @"^(\t| )?(DIFFRINT) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+|(SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|-?[0-9]*\.[0-9]+) (AN) (-?[0-9]+|([a-zA-Z]+[0-9_]*)|[0-9]*\.[0-9]+))$";
            System.IO.StreamReader file = openFileProcedure(filePath);
             
            if (file != null)
            {
                codeBlock = readAll(file);
                file.Close();
                file = openFileProcedure(filePath);
                lineCount = File.ReadAllLines(filePath).Length; //gets the number of lines
            }
            else return;

            
            //reads the file line by line
            
            //reads until not null
            while ((line = file.ReadLine()) != null)
            {
                booleanOperator(line);
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

                //arithmeticOp(line);
                matchRAssignment(line);
                smooshString(line);
                matchSingleComment(line);
                matchMultiComment(line);
                arithmeticOp(line);
                matchGimmeh(line);
                Match matchVISIBLE = Regex.Match(line, patternVISIBLE);
                if (matchVISIBLE.Success)
                {
                    keyMatch.Add(matchVISIBLE.Groups[1].ToString().Replace("\t", "").Replace(" ",""));
                    classification.Add("Output Keyword");
                    keyMatchCount += 1;
                    //check for the pair of string delimiter
                    if (matchVISIBLE.ToString().Contains('"'))
                    {
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
                    keyMatch.Add(matchIHASITZ.Groups[1].ToString());
                    classification.Add("Variable Declaration");
                    keyMatch.Add(matchIHASITZ.Groups[3].ToString());
                    classification.Add("Variable");
                    variables.Add(matchIHASITZ.Groups[3].ToString());
                    keyMatch.Add(matchIHASITZ.Groups[6].ToString());
                    classification.Add("Variable Initialization");
                    isExpression(matchIHASITZ.Groups[7].ToString());

                }
                else if (matchIHASA.Success)
                { //uninitialized decalaration
                    keyMatch.Add(matchIHASA.Groups[1].ToString());
                    classification.Add("Variable Declaration");
                    keyMatch.Add(matchIHASA.Groups[3].ToString());
                    classification.Add("NOOB Variable");
                    keyMatchCount += 2;
                }





                //check for GIMMEH lexeme
                //Match matchGIMMEH = Regex.Match(line, patternGIMMEH);
                //if (matchGIMMEH.Success)
                //{
                //    keyMatch.Add(matchGIMMEH.Groups[1].ToString().Replace(" ", ""));
                //    keyMatchCount += 1;
                //    classification.Add("Input Keyword");
                //}


                //check for Simple Arithmetic Operations
                //Match matchArithmeticOps = Regex.Match(line, patternArithmeticOps);
                //if (matchArithmeticOps.Success)
                //{

                //    switch (matchArithmeticOps.Groups[2].ToString()) //edited
                //    {
                //        case "SUM OF":
                //            classification.Add("Addition Operator");
                //            break;
                //        case "DIFF OF":
                //            classification.Add("Subtration Operator");
                //            break;
                //        case "PRODUKT OF":
                //            classification.Add("Product Operator");
                //            break;
                //        case "QUOSHUNT OF":
                //            classification.Add("Division Operator");
                //            break;
                //        case "MOD OF":
                //            classification.Add("Modulo Operator");
                //            break;
                //        case "BIGGR OF":
                //            classification.Add("Max Operator");
                //            break;
                //        case "SMALLR OF":
                //            classification.Add("Min Operator");
                //            break;
                //    }
                //    keyMatch.Add(matchArithmeticOps.Groups[2].ToString());
                //    keyMatch.Add(matchArithmeticOps.Groups[3].ToString());
                //    isWhat(matchArithmeticOps.Groups[3].ToString());
                //    keyMatch.Add(matchArithmeticOps.Groups[5].ToString());
                //    classification.Add("Concatenation");
                //    isExpression(matchArithmeticOps.Groups[6].ToString());

                //}


                //check for Simple Boolean Operations
                //Match matchBooleanOps = Regex.Match(line, patternBooleanOps);
                //if (matchBooleanOps.Success)
                //{

                //    keyMatch.Add(matchBooleanOps.Groups[2].ToString());
                //    switch (matchBooleanOps.Groups[2].ToString())
                //    {
                //        case "BOTH OF":
                //            classification.Add("AND Operator");
                //            break;
                //        case "EITHER OF":
                //            classification.Add("OR Operator");
                //            break;
                //        case "WON OF":
                //            classification.Add("XOR Operator");
                //            break;
                //        case "ALL OF":
                //            classification.Add("Infinite Arity AND Operator");
                //            break;
                //        case "ANY OF":
                //            classification.Add("Infinite Arity OR Operator");
                //            break;
                //    }
                //    keyMatch.Add(matchBooleanOps.Groups[3].ToString());
                //    isWhat(matchBooleanOps.Groups[3].ToString());
                //    keyMatch.Add(matchBooleanOps.Groups[6].ToString());
                //    classification.Add("Concatenation");
                //    keyMatch.Add(matchBooleanOps.Groups[7].ToString());
                //    isWhat(matchBooleanOps.Groups[7].ToString());
                    
                //}

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
                Match matchBOTHSAEM = Regex.Match(line, patternBOTHSAEM);
                if (matchBOTHSAEM.Success)
                {
                    keyMatch.Add(matchBOTHSAEM.Groups[2].ToString());
                    classification.Add("Comparison Operator");
                    //compare if immediate value or variable
                    keyMatch.Add(matchBOTHSAEM.Groups[3].ToString());
                    isWhat(matchBOTHSAEM.Groups[3].ToString());
                    keyMatch.Add(matchBOTHSAEM.Groups[5].ToString());
                    classification.Add("Concatenation");
                    isExpression(matchBOTHSAEM.Groups[6].ToString());
                    //keyMatch.Add(matchBOTHSAEM.Groups[6].ToString());
                    //isWhat(matchBOTHSAEM.Groups[6].ToString());

                }

                Match matchDIFFRINT = Regex.Match(line, patternDIFFRINT);
                if (matchDIFFRINT.Success)
                {
                    keyMatch.Add(matchDIFFRINT.Groups[2].ToString());
                    classification.Add("Comparison Operator");
                    //compare if immediate value or variable
                    keyMatch.Add(matchDIFFRINT.Groups[3].ToString());
                    isWhat(matchDIFFRINT.Groups[3].ToString());
                    keyMatch.Add(matchDIFFRINT.Groups[5].ToString());
                    classification.Add("Concatenation");
                    keyMatch.Add(matchDIFFRINT.Groups[6].ToString());
                    isWhat(matchDIFFRINT.Groups[6].ToString());
                }


                counter += 1;
                prevLine = line;
            }

            file.Close();

        }

        
    }
}
