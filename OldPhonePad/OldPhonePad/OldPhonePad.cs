using System;


namespace OldPhonePad
{
    public class OldPhonePad
    {
        private static readonly string[] letters = {
        " ",    // 0
        "",     // 1
        "ABC",  // 2
        "DEF",  // 3
        "GHI",  // 4
        "JKL",  // 5
        "MNO",  // 6
        "PQRS", // 7
        "TUV",  // 8
        "WXYZ"  // 9
    };
        
        public static string  ConvertInputToText(string input)
        {
            string output = "";
            int pointer = 0;

            for(int index = 0; index < input.Length; index++)
            {
                int i = input[index] - '0';               // getting the indexed character and converted to integer

                //checking the indexed character to digit
                if (char.IsDigit(input[index]))
                {
                    //adding the first character to output
                    if (index == 0)
                    {
                        output += letters[i][pointer];
                    }
                    else {
                        //checking current character samed to the previous one
                        if (input[index] == input[index - 1])
                        {
                            output = output.Substring(0, output.Length-1);
                            pointer++;
                        }
                        else
                        {
                            pointer = 0;
                        }
                        output += letters[i][pointer];
                    }
                }
                //checking the indexed character to *
                else if(input[index]=='*')
                {
                    pointer = 0;
                    output = output.Substring(0, output.Length-1); //removing the last character from the output string 
                 }
                //checking the indexed character to #
                else if (input[index] == '#')
                {
                    break;
                }
                else
                {
                    pointer = 0;
                }
            }
            return output;
        }
            
        
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad.ConvertInputToText("222 2 22"));              //test case for output CAB
            Console.WriteLine(OldPhonePad.ConvertInputToText("33#"));                   //test case for output E
            Console.WriteLine(OldPhonePad.ConvertInputToText("227*#"));                 //test case for output B
            Console.WriteLine(OldPhonePad.ConvertInputToText("4433555 555666#"));       //test case for output HELLO
            Console.WriteLine(OldPhonePad.ConvertInputToText("8 88777444666*664#"));    //test case for output TURING
        }
    }
}