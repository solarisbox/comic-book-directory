using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
/*
 *I, Salvador Valle, #000322660 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.8
 * Program Use: The Program takes input from a text file and displays data according to user selection
 */
namespace Lab4b
{
    class Program
    {
        static string input;
        static Regex tagPattern = new Regex("<.*?>");
        static Stack<string> html = new Stack<string>();
        static Stack<string> tags = new Stack<string>();
        static int count = 0;
       
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Simple HTML file checker\n");
                Console.WriteLine("Please enter the name of the HTML file to analyse: ");
                input = Console.ReadLine();

                Read();
            }
        }

        /// <summary>
        /// Reads data from the HTML files
        /// </summary>
        private static void Read()
        {
            try
            {
                FileStream file = new FileStream(input, FileMode.Open, FileAccess.Read);
                StreamReader data = new StreamReader(file);
                string line;

                while ((line = data.ReadLine()) != null)
                {
                    Match match = tagPattern.Match(line);
                    if (match.Success)
                    {
                        if (match.Value != "<br>")
                        {
                            tags.Push(match.Value);
                            html.Push(line);
                        }

                    }
                    count = tags.Count;
                }
                int mod = count % 2;
                if (mod != 0)
                {
                    Console.WriteLine("Tags are not balanced.");
                }
                else
                {
                    Console.WriteLine("Tags are balanced.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Simple HTML file checker\n");
                Console.WriteLine("Please enter the name of the HTML file to analyse: ");
            }
            
        }
    }
}
