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

// FileName: LibraryJournal.cs

namespace CIS_200_Prog_1
{
    public class LibraryJournal : LibraryPeriodical
    {
        private string _discipline; //Backing for discipline
        private string _editor; //Backing for editor

        // Precondition:  None
        // Postcondition: The LibraryJournal object has been initialized with the specified data
        public LibraryJournal(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
                              string theCallNumber, int theVolume, int theNumber, string theDiscipline,
                              string theEditor)
                              :base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber,
                                    theVolume, theNumber)
        {
            Discipline = theDiscipline;
            Editor = theEditor;

        }

        public string Discipline
        {
            // Precondition:  None
            // Postcondition: The discipline has been returned
            get
            {
                return _discipline;
            }
            // Precondition:  value must not be null or empty
            // Postcondition: The discipline has been set to the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Discipline)}", value, $"{nameof(Discipline)} please enter a Discipline");
                else
                    _discipline = value.Trim();
            }
        }

        public string Editor
        {
            // Precondition:  None
            // Postcondition: The editor has been returned
            get
            {
                return _editor;
            }
            // Precondition:  value must not be null or empty
            // Postcondition: The editor has been set to the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Editor)}", value, $"{nameof(Editor)} please enter an Editor");
                else
                    _editor = value.Trim();
            }
        }

        // Precondition:  None
        // Postcondition: A decimal is returned presenting the charge fee for a journal
        public override decimal CalcLateFee(int daysLate)
        {
            const decimal LATE_FEE_RATE_JOURNAL = 0.75m; //daily rate for journal late fee
            decimal chargeFee;  // the charge to be returned

            chargeFee = daysLate * LATE_FEE_RATE_JOURNAL;
            return chargeFee;
        }


        // Precondition:  None
        // Postcondition: A string is returned presenting the LibraryJournal's object data on separate lines
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}{NL}" +
                $"Volume: {Volume}{NL}Number: {Number}{NL}Discipline: {Discipline}{NL}" +
                $"Editor: {Editor}";
        }

    }
}
