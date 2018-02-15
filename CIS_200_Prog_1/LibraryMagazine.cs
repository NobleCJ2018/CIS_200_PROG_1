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

// FileName: LibraryMagazine.cs

namespace CIS_200_Prog_1
{
    public class LibraryMagazine : LibraryPeriodical
    {
        // Precondition:  None
        // Postcondition: The LibraryMagazine object has been initialized with the specified data
        public LibraryMagazine(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
                               string theCallNumber, int theVolume, int theNumber)
                               :base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber,
                                     theVolume, theNumber)
        {

        }

        // Precondition:  None
        // Postcondition: A decimal is returned presenting the charge fee for a magazine
        public override decimal CalcLateFee(int daysLate)
        {
            const decimal LATE_FEE_RATE_MAGAZINE = 0.25m; //daily rate for magazine late fee
            const decimal MAX_CHARGE_LIMIT = 20.00m; // max limit for all magazine types
            decimal chargeFee; // the charge fee to be returned

            if (daysLate * LATE_FEE_RATE_MAGAZINE >= MAX_CHARGE_LIMIT)
            {
                chargeFee = MAX_CHARGE_LIMIT;
            }
            else
                chargeFee = daysLate * LATE_FEE_RATE_MAGAZINE;

            return chargeFee;
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the LibraryMagazine's object data on separate lines
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
                $"Volume: {Volume}{NL}Number: {Number}{NL}";
        }



    }
}
