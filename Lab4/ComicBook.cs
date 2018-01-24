using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *I, Salvador Valle, #000322660 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.
 * Program Use: The Program takes input from a text file and displays the comic book data according to user selection.
 */
namespace Lab4
{
    /// <summary>
    /// Represents a single comic book
    /// </summary>
    class ComicBook : IComparable<ComicBook>
    {
        public string Publisher;
        public string Title;
        public int Issue;
        public string StrDate;
        public DateTime Date;
        public decimal BookValue;
        public decimal MarketValue;

        /// <summary>
        /// ComicBook Constructor
        /// </summary>
        /// <param name="publisher">Comic publisher</param>
        /// <param name="title">Comic title</param>
        /// <param name="issue">Issue Number</param>
        /// <param name="date">Cover Date</param>
        /// <param name="bookValue">Cover Price</param>
        /// <param name="marketValue">Market Value</param>
        public ComicBook(string publisher, string title, int issue, string date, decimal bookValue, decimal marketValue)
        {
            Publisher = publisher;
            Title = title;
            Issue = issue;
            StrDate = date;
            Date = Convert.ToDateTime(date);
            BookValue = bookValue;
            MarketValue = marketValue;
        }

        public static Comparer GetComparer()
        {
            return new ComicBook.Comparer();
        }
        /// <summary>
        /// Compares two comicbook values
        /// </summary>
        /// <param name="x">First comicbook object</param>
        /// <param name="Which">Which property of the objects to compare</param>
        /// <returns></returns>
        public int CompareTo(ComicBook x, ComicBook.Comparer.ComparisonType Which)
        {
            switch (Which)
            {
                case ComicBook.Comparer.ComparisonType.Publisher:
                    return this.Publisher.CompareTo(x.Publisher);
                case ComicBook.Comparer.ComparisonType.Title:
                    return this.Title.CompareTo(x.Title);
                case ComicBook.Comparer.ComparisonType.Issue:
                    return this.Issue.CompareTo(x.Issue);
                case ComicBook.Comparer.ComparisonType.Date:
                    return this.Date.CompareTo(x.Date);
                case ComicBook.Comparer.ComparisonType.BookValue:
                    return this.BookValue.CompareTo(x.BookValue);
                case ComicBook.Comparer.ComparisonType.MarketValue:
                    return this.MarketValue.CompareTo(x.MarketValue);
            }
            return 0;
        }

        /// <summary>
        /// Nested class that implements IComparer
        /// </summary>
        public class Comparer : IComparer<ComicBook>
        {
            public ComicBook.Comparer.ComparisonType WhichComparison { get; set; }
            // enumeration of comparsion types
            public enum ComparisonType
            {
                Publisher,
                Title,
                Issue,
                Date,
                BookValue,
                MarketValue
            };

            /// <summary>
            /// This method executes the comparison
            /// </summary>
            /// <param name="x">First comicbook object</param>
            /// <param name="y">Second comicbook object to compare to</param>
            /// <returns></returns>
            public int Compare(ComicBook x, ComicBook y)
            {
                return x.CompareTo(y, WhichComparison);
                //if (x.BookValue > y.BookValue)
                //    return 1;
                //if (x.BookValue == y.BookValue)
                //    return 0;
                //else
                //    return -1;
            }
        }

        public int CompareTo(ComicBook other)
        {
            throw new NotImplementedException();
        }
    }
}
