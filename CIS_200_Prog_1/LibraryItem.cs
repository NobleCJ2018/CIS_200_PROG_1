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

// FileName: LibraryItem.cs

namespace CIS_200_Prog_1
{
    public abstract class  LibraryItem
    {

        private string _title;  // Backing for Title
        private string _callNumber; //Backing for CallNumber
        private string _publisher;  //Backing for Publisher
        private int _copyrightYear; //Backing for Copyright Year
        private int _loanPeriod;    //Backing for LoanPeriod
        private bool _checkedOut;   //Backing Bool for status: Checked Out?


        public LibraryItem(string theTitle, string thePublisher, int theCopyrightYear, 
                           int theLoanPeriod, string theCallNumber)
        {
            Title = theTitle;
            Publisher = thePublisher;
            CopyrightYear = theCopyrightYear;
            LoanPeriod = theLoanPeriod;
            CallNumber = theCallNumber;
            Patron = null;  // Item has no patron

            _checkedOut = false;    // Make sure book is not checked out

        }



        public LibraryPatron Patron
        {
            // Precondition:  None
            // Postcondition: The book's patron has been returned
            get;

            // Helper
            // Precondition:  None
            // Postcondition: The book's patron has been set to the specified value
            private set;    // Auto-implement
        }

        public int LoanPeriod
        {
            // Precondition:  None
            // Postcondition: The loan period has been returned
            get
            {
                return _loanPeriod;
            }
            // Precondition:  value >= 0
            // Postcondition: The loan period has been set to the specified value
            set
            {
                if (value >= 0)
                {
                    _loanPeriod = value;
                }
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(LoanPeriod)}", value, $"{nameof(LoanPeriod)} can not be a negative value");
            }
        }

        public string Title
        {
            // Precondition:  None
            // Postcondition: The title has been returned
            get
            {
                return _title;
            }
            // Precondition:  value must not be null or empty
            // Postcondition: The title has been set to the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Title)}", value, $"{nameof(Title)} must not be null or empty");
                }
                else
                    _title = value.Trim();
            }
        }

        public string CallNumber
        {
            // Precondition:  None
            // Postcondition: The call number has been returned
            get
            {
                return _callNumber;
            }

            set
            {
                // Precondition:  None
                // Postcondition: The call number has been set to the specified value
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                {
                    throw new ArgumentOutOfRangeException 
                        ($"{nameof(value)}", value, $"{nameof(value)} must not be null or empty");
                }
                else
                    _callNumber = value.Trim();
            }
        }

        public string Publisher
        {
            // Precondition:  None
            // Postcondition: The publisher has been returned
            get
            {
                return _publisher;
            }
            // Precondition:  None
            // Postcondition: The publisher has been set to the specified value
            set
            {
                /*
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Publisher)}", value, $"{nameof(Publisher)} can not be null or empty");
                }
                else
                    _publisher = value.Trim();
                */

                _publisher = (value == null ? string.Empty : value.Trim());
            }
        }

        public int CopyrightYear
        {
            // Precondition:  None
            // Postcondition: The copyright year has been returned
            get
            {
                return _copyrightYear;
            }
            // Precondition:  value >= 0
            // Postcondition: The copyright year has been set to the specified value
            set
            {
                if (value >= 0)
                {
                    _copyrightYear = value;
                }
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(CopyrightYear)}", value, $"{nameof(CopyrightYear)} must greater than or equal to zero");

            }
        }


        //////////    METHODS    //////////



        // Precondition:  thePatron != null
        // Postcondition: The book is checked out by the specified patron
        public void CheckOut(LibraryPatron thePatron)
        {
            if (thePatron != null)
                Patron = thePatron;
            else
                throw new ArgumentNullException($"{nameof(thePatron)}", $"{nameof(thePatron)} must not be null");

            _checkedOut = true;
        }

        // Precondition:  None
        // Postcondition: The book is not checked out
        public void ReturnToShelf()
        {
            Patron = null; // Remove previously stored reference to patron

            _checkedOut = false;
        }

        // Precondition:  None
        // Postcondition: true is returned if the book is checked out,
        //                otherwise false is returned
        public bool IsCheckedOut()
        {
            return _checkedOut;
        }

        // Precondition:  None
        // Postcondition: A string is returned representing the libaryitem
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}";
        }

        // Precondition:  None
        // Postcondition: None Abstract
        public abstract decimal CalcLateFee();
        


    }
}
