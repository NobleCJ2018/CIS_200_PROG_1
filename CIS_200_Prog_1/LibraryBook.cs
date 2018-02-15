using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Grading_ID:****: 
Program********: 1
Due_Date*******: xx XXX 2018
Section********: CIS 200 01
*/

// FileName: LibraryBook.cs

namespace CIS_200_Prog_1
{
    public class LibraryBook : LibraryItem
    {
        private string _author;


        public LibraryBook(string theTitle, string theAuthor, string thePublisher, int theCopyrightYear,
               int theLoanPeriod, string theCallNumber)
            : base(theTitle,thePublisher,theCopyrightYear,theLoanPeriod, theCallNumber)
        {
            Author = theAuthor;          
        }

        public string Author
        {
            // Precondition:  None
            // Postcondition: The author has been returned
            get
            {
                return _author;
            }
            // Precondition:  None
            // Postcondition: The author has been set to the specified value
            set
            {
                /*
                if (value == null)
                    _author = string.Empty;
                else
                    _author = value.Trim();
                */

                _author = (value == null ? string.Empty : value.Trim());
            }
        }

        public override decimal CalcLateFee(int daysLate)
        {

        const decimal LATE_FEE_RATE = 0.25m;
        decimal chargeFee;

            chargeFee = daysLate * LATE_FEE_RATE;
            return chargeFee;
        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Author: {Author}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}";
        }




    }
}
