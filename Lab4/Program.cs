using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 *I, Salvador Valle, #000322660 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.8
 * Program Use: The Program takes input from a text file and displays data according to user selection
 */
namespace Lab4
{
    class Program
    {
        static List<ComicBook> comics = new List<ComicBook>(); //List of comicbooks
        static ComicBook.Comparer cc = ComicBook.GetComparer(); //Used to compare comicbook values

        static void Main(string[] args)
        {
            Read();

            while (true)
            {
                Console.WriteLine("1. Sort by Publisher Name" + Environment.NewLine +
                                   "2. Sort by Comic Title" + Environment.NewLine +
                                   "3. Sort by Issue Number" + Environment.NewLine +
                                   "4. Sort by Cover Date" + Environment.NewLine +
                                   "5. Sort by Cover Value" + Environment.NewLine +
                                   "6. Sort by Market Value" + Environment.NewLine +
                                   "7. Exit");

                string input = Console.ReadLine();
                input.ToString();
                if (input == "1")
                {
                    cc.WhichComparison = ComicBook.Comparer.ComparisonType.Publisher;
                    comics.Sort(cc);
                    
                    foreach (ComicBook comic in comics)
                    {
                        Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} ${4,-4} {5,14:$#,###,###.00} ", comic.Publisher, 
                            comic.Title, comic.Issue, comic.StrDate, comic.BookValue, comic.MarketValue);
                    }
                    Console.WriteLine();
                }
                else if (input == "2")
                {
                    cc.WhichComparison = ComicBook.Comparer.ComparisonType.Title;
                    comics.Sort(cc);

                    foreach (ComicBook comic in comics)
                    {
                        Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} ${4,-4} {5,14:$#,###,###.00} ", comic.Publisher,
                            comic.Title, comic.Issue, comic.StrDate, comic.BookValue, comic.MarketValue);
                    }
                    Console.WriteLine();
                }
                else if (input == "3")
                {
                    cc.WhichComparison = ComicBook.Comparer.ComparisonType.Issue;
                    comics.Sort(cc);

                    foreach (ComicBook comic in comics)
                    {
                        Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} ${4,-4} {5,14:$#,###,###.00} ", comic.Publisher,
                            comic.Title, comic.Issue, comic.StrDate, comic.BookValue, comic.MarketValue);
                    }
                    Console.WriteLine();
                }
                else if (input == "4")
                {
                    cc.WhichComparison = ComicBook.Comparer.ComparisonType.Date;
                    comics.Sort(cc);

                    foreach (ComicBook comic in comics)
                    {
                        Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} ${4,-4} {5,14:$#,###,###.00} ", comic.Publisher,
                            comic.Title, comic.Issue, comic.StrDate, comic.BookValue, comic.MarketValue);
                    }
                    Console.WriteLine();
                }
                else if (input == "5")
                {           
                    cc.WhichComparison = ComicBook.Comparer.ComparisonType.BookValue;
                    comics.Sort(cc);

                    foreach (ComicBook comic in comics)
                    {
                        Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} ${4,-4} {5,14:$#,###,###.00} ", comic.Publisher,
                            comic.Title, comic.Issue, comic.StrDate, comic.BookValue, comic.MarketValue);
                    }
                    Console.WriteLine();
                }
                else if (input == "6")
                {
                    cc.WhichComparison = ComicBook.Comparer.ComparisonType.MarketValue;
                    comics.Sort(cc);

                    foreach (ComicBook comic in comics)
                    {
                        Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} ${4,-4} {5,14:$#,###,###.00} ", comic.Publisher,
                            comic.Title, comic.Issue, comic.StrDate, comic.BookValue, comic.MarketValue);
                    }
                    Console.WriteLine();
                }
                else if (input == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Invalid Selection, Try Again." + Environment.NewLine);
                }
                Display();
            }
        }
        /// <summary>
        /// Dsiplays menu for user
        /// </summary>
        private static void Display()
        {
            Console.WriteLine("{0,-10} {1,-23} {2,4} {3,-12} {4,-4} {5,14}", "Publisher", "Title", "Issue", "Date", "Value", "Market");
            Console.WriteLine("==============================================================================");
            Console.WriteLine();
        }
        /// <summary>
        /// Reads data from a text file
        /// </summary>
        private static void Read()
        {
            FileStream file = new FileStream("comics.txt", FileMode.Open, FileAccess.Read);
            StreamReader data = new StreamReader(file);
            string line;

            while ((line = data.ReadLine()) != null)
            {
                string[] dataArray = line.Split(',');

                comics.Add(new ComicBook(dataArray[0].Trim(), dataArray[1].Trim(), Convert.ToInt32(dataArray[2]), dataArray[3],
                                Convert.ToDecimal(dataArray[4]), Convert.ToDecimal(dataArray[5])));
            }
            data.Close();
        }
    }
}



