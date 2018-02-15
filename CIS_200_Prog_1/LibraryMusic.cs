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

// FileName: LibraryMusic.cs

namespace CIS_200_Prog_1
{
    public class LibraryMusic : LibraryMediaItem
    {
        private string _artist;
        private LibraryMediaItem.MediaType _medium;
        private int _numTracks;

        // Precondition:  None
        // Postcondition: The LibraryMusic object has been initialized with the specified data
        public LibraryMusic(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
                            string theCallNumber, double theDuration, string theArtist, MediaType theMedium,
                            int theNumTracks)
                            : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                                   theCallNumber, theDuration)
        {
            Artist = theArtist;
            Medium = theMedium;
            NumTracks = theNumTracks;
        }

        public string Artist
        {
            get
            {
                // Precondition:  None
                // Postcondition: The artist has been returned
                return _artist;
            }

            set
            {
                // Precondition:  value must not be null or empty
                // Postcondition: The artist has been set to the specified value
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Artist)}", value, $"{nameof(Artist)} please enter an Artist");
                else
                    _artist = value.Trim();
            }
        }

        public override MediaType Medium
        {
            // Precondition: Medium must be of type CD/SACD/VINYL only
            // Postcondition: The medium has been set to the specified value
            get
            {
                return _medium;
            }
            // Precondition:  None
            // Postcondition: The medium has been set to the specified value
            set
            {
                // conditional for CD, SACD, and VINYL only???
                if (value == MediaType.CD || value == MediaType.SACD || value == MediaType.VINYL)
                    _medium = value;
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Medium)}", value, $"{nameof(Medium)} please enter a valid medium");
            }
        }

        public int NumTracks
        {
            // Precondition:  None
            // Postcondition: The number of tracks has been returned
            get
            {
                return _numTracks;
            }
            // Precondition:  value >= 1
            // Postcondition: The number of tracks has been set to the specified value
            set
            {
                if (value >= 1)
                    _numTracks = value;
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(NumTracks)}", value, $"{nameof(NumTracks)} must be greater than or equal to one");
            }
        }


        public override decimal CalcLateFee(int daysLate)
        {
            const decimal LATE_FEE_RATE_MUSIC = 0.50m; //daily rate for music late fee
            const decimal MAX_CHARGE_LIMIT = 20.00m;    //max charge limit for music late fee
            decimal chargeFee;  // the charge to be returned

            if (daysLate * LATE_FEE_RATE_MUSIC >= MAX_CHARGE_LIMIT)
            {
                chargeFee = MAX_CHARGE_LIMIT;
            }
            else
                chargeFee = daysLate * LATE_FEE_RATE_MUSIC;

            return chargeFee;
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the LibraryMusic object data on separate lines
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Artist: {Artist}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}{NL}" +
                $"Media Type: {Medium}{NL}Number of Tracks: {NumTracks}{NL}Duration: {Duration}";
        }





    }
}
