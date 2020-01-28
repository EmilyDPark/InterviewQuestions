using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            // This program has questions written within the code.
            // It will ask the user if they want a question.
            // If the user inputs "yes" or "y", it will pull a random question and display it.
            // It will then ask the user if they want another question.
            // For as long as the user inputs "yes" or "y", it will display random questions 
            // without repetitions until there are no more questions.

            Console.WriteLine("      Random Generic Question Generator \n");
            Console.WriteLine("How to Use: Input \"yes\" or \"y\" when prompted.\n");
            //Console.WriteLine("How to use:");
            //Console.WriteLine(" 1) Press Enter when you're ready for a question.");
            //Console.WriteLine(" 2) Input \"yes\" or \"y\" when prompted.");
            //Console.ReadLine();


            // Create a DataTable.
            using (DataTable table = new DataTable())
            {
                // Add Number and Question columns
                table.TableName = "table";
                table.Columns.Add("Question", typeof(string));

                // Add multiple questions as rows
                table.Rows.Add("What is your name?");
                table.Rows.Add("How old are you?");
                table.Rows.Add("What is your favorite color?");
                table.Rows.Add("What is your favorite number?");
                table.Rows.Add("What is your favorite song?");
                table.Rows.Add("What is your favorite food?");
                table.Rows.Add("What is your favorite quote?");
                table.Rows.Add("Where were you born?");
                table.Rows.Add("Where did you go to high school?");
                table.Rows.Add("What was your high school's mascot?");
                table.Rows.Add("What are your hobbies?");
                table.Rows.Add("What is your mother's maiden name?");

                // Instantiate random number generator using system-supplied value as seed
                var rand = new Random();

                // Count how many questions/rows there are
                int totalRows = table.Rows.Count;

                // Create a possible number list and a number list
                List<int> possibleNumbers = Enumerable.Range(0, totalRows).ToList();
                List<int> listNumbers = new List<int>();

                // Ask if the user wants a number
                Console.Write("Would you like a question?   ");
                string ans = Console.ReadLine();

                // While loop if the user answers "yes" or "y"
                while (ans == "yes" || ans == "y")
                {
                    // Check if there are available numbers in possible number list
                    if (possibleNumbers.Count > 0)
                    {
                        // Select a random number, add it to number list, remove from possible number list
                        int index = rand.Next(0, possibleNumbers.Count);
                        listNumbers.Add(possibleNumbers[index]);
                        possibleNumbers.RemoveAt(index);

                        // Select the last number in the list
                        int item = listNumbers[listNumbers.Count - 1];

                        // Create a variable containing the given question
                        string givenQuestion = String.Join("", table.Rows[item].ItemArray);
                        // This could probably be done better. I'm not 100% sure why it needs to be String.Join to make it a string.
                        // I wonder if it is because data in a row is expected to be part of more than one column so it is an array??

                        // Print the question with spaces used to fill the space until the string is 75 characters in length
                        Console.WriteLine("\n" + givenQuestion.PadLeft(75, ' ') + "\n");
                        //Console.ReadLine();
                    }
                    else
                    {
                        // There are no more available numbers in possible number list
                        string questionsDone = "You've answered all the questions!";
                        Console.WriteLine("\n" + questionsDone.PadLeft(75, ' ') + "\n");
                        Console.ReadLine();
                        break;
                    }

                    // Ask if the user wants another number while there are still numbers available
                    Console.Write("Would you like another question?   ");
                    ans = Console.ReadLine();
                }

                // Display text if the user inputs something other than "yes" or "y"
                string noMore = "Good Luck!";
                Console.WriteLine("\n" + noMore.PadLeft(75, ' ') + "\n");
                Console.ReadLine();

                // Written by Da Hye (Emily) Park on January 27-28, 2020.
            }
        }
    }
}