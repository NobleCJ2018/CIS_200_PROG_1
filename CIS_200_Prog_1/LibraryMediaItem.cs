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

// FileName: LibraryMediaItem.cs

namespace CIS_200_Prog_1
{
    public abstract class LibraryMediaItem : LibraryItem
    {
        private double _duration;

        public enum MediaType { DVD, BLURAY, VHS, CD, SACD, VINYL};

        public LibraryMediaItem(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
                                string theCallNumber, double duration)
                                :base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {
            Duration = _duration;
        }

        public double Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                if (value >= 0)
                    _duration = value;
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Duration)}", value, $"{nameof(Duration)} must be greater than or equal to zero");
            }
        }


        
        
        public abstract MediaType Medium { get; set; }

        public abstract override decimal CalcLateFee(int daysLate);

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}Duration: {Duration}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}";
        }




    }
}
