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

// FileName: LibraryPeriodical.cs

namespace CIS_200_Prog_1
{
    public abstract class LibraryPeriodical : LibraryItem
    {
        private int _volume; //Backing for volume
        private int _number; //Backing for number

        public LibraryPeriodical(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
                                 string theCallNumber, int theVolume, int theNumber)
                                :base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {

            Volume = theVolume;
            Number = theNumber;
        }

        public int Volume
        {
            // Precondition:  None
            // Postcondition: The volume has been returned
            get
            {
                return _volume;
            }
            // Precondition:  value >= 1
            // Postcondition: The volume has been set to the specified value
            set
            {
                if (value >= 1)
                    _volume = value;
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Volume)}", value, $"{nameof(Volume)} must be greater than or equal to one");
            }
        }

        public int Number
        {
            // Precondition:  None
            // Postcondition: The number has been returned
            get
            {
                return _number;
            }
            // Precondition:  value >= 1
            // Postcondition: The number has been set to the specified value
            set
            {
                if (value >= 1)
                    _number = value;
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Number)}", value, $"{nameof(Number)} must be greater than or equal to one");
            }
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the LibraryPeriodical object data on separate lines
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
                $"Volume: {Volume}{NL}Number: {Number}";
        }





    }
}
