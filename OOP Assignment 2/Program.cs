using System;
using System.Linq;
using System.Threading;

namespace FileDifference
{
    class gitdiff
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White; // Sets background colour to White
            Console.ForegroundColor = ConsoleColor.Black; // Sets text colour to Black
            Console.Clear(); // Clears Console

            Compare.userFileChoose(); // Where the files are located and stored
                      
            Console.ForegroundColor = ConsoleColor.Black; // Resets colour after coloured text back to black
            Console.WriteLine("\n >: Press any Key to Close"); // Prompts the user to close program with any key
            Console.Write(" >: "); // Console app text at start of each line
            Console.ReadKey(); // Takes input to close
        }                     
    }

    class CompareOptions
    {
        public static void testingTrueFalse(int input1, int input2, string[] File1, string[] File2, string[] files)
        {
            bool test = Enumerable.SequenceEqual(File1, File2);  // Testing the files are the same (true) or different (false)         

            if (test == true) // When output is true
            {
                Console.Write(" >: [Output] "); // Displays as output
                Console.ForegroundColor = ConsoleColor.Green; // Sets colour to Green
                Console.WriteLine("{0} and {1} are not different", files[input1 - 1], files[input2 - 1]); // Writes message to say the files are the same
            }
            else if (test == false) // When output is false
            {
                Console.Write(" >: [Output] "); // Displays as output
                Console.ForegroundColor = ConsoleColor.Red; // Sets colour to Red
                Console.WriteLine("{0} and {1} are different", files[input1 - 1], files[input2 - 1]); // Writes message to say the files are different
            }
            else
            {
                Console.WriteLine("\n >: Error!!! Please wait to automatically return to Start..."); // Error message prompt
                Thread.Sleep(3000); // Automatically close program
                gitdiff.Main(null); // Sends user back to start of program
            }
        }
            
    }

    class Compare
    {
        public static void userFileChoose()
        {            
            string find = System.IO.Directory.GetCurrentDirectory() + "\\"; // Searches directory for text files

            String[] files = new string[4] { "a.txt", "b.txt", "c.txt", "d.txt" }; // All text files put into a single array

            Compare.ChooseInput(find, files); // Users selection of text file options
        }
        public static void ChooseInput(string find, string[] files)
        {           

            Console.WriteLine(" >: Here are the 4 Files as shown: \n >: a = 1 \n >: b = 2 \n >: c = 3 \n >: d = 4"); // Display message for how user can choose text files

            Console.WriteLine("\n >: Enter a Number for FIRST File to Check (Example: 1)"); // Prompts user to a first number for first file
            Console.Write(" >: "); // Console app text at start of each line
            int input1;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out input1)) // For an input that isnt an integer
                {
                    Console.WriteLine(" >: Enter correct value, 1 - {0}", files.Length); // Prompts user from incorrect input
                }
            }
            while (input1 < 1 || input1 > files.Length); // User can enter 1, to final value of of array 'files', which means array can be extended or shortened easily 
            {

            }

            Console.WriteLine("\n >: Enter a Number for SECOND File to Check (Example: 2)"); // Prompts user to a second number for second file
            Console.Write(" >: "); // Console app text at start of each line
            int input2;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out input2)) // For an input that isnt an integer
                {
                    Console.WriteLine(" >: Enter correct value, 1 - {0}", files.Length); // Prompts user from incorrect input
                }
            }
            while (input2 < 1 || input2 > files.Length); // User can enter 1, to final value of of array 'files', which means array can be extended or shortened easily 
            {

            }

            string[] File1 = System.IO.File.ReadAllLines(find + files[input1 - 1]); // Takes user's first input and searches directory for corresponding text file, for first text file
            string[] File2 = System.IO.File.ReadAllLines(find + files[input2 - 1]); // Takes user's second input and searches directory for corresponding text file, for second text file

            Console.Clear(); // Clears Console

            Console.WriteLine(" >: [Input] diff {0} {1}", files[input1 - 1], files[input2 - 1]); // Displays as input with files chosen

            CompareOptions.testingTrueFalse(input1, input2, File1, File2, files); // Outputs for true and false

        }
    }
}