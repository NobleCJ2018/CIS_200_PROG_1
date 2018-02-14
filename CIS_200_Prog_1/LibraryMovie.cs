﻿using System;
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

// FileName: LibraryMovie.cs

namespace CIS_200_Prog_1
{
    public class LibraryMovie : LibraryMediaItem
    {
        private string _director;
        private MediaType _medium;
        private MPAARatings _ratings;
        public enum MPAARatings { G, PG, PG13, R, NC17, U };

        public LibraryMovie(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
                            string theCallNumber, double theDuration, string theDirector, MediaType theMedium,
                            MPAARatings theRating)
                            : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                                  theCallNumber, theDuration)
        {

        }

        public string Director
        {
            // Precondition:  None
            // Postcondition: The director has been returned
            get
            {
                return _director;
            }

            set
            {
                // Precondition:  value must not be null or empty
                // Postcondition: The director has been set to the specified value
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Director)}", value, $"{nameof(Director)} please enter a Director");
                else
                    _director = value.Trim();
            }
        }

        public override MediaType Medium
        {

            get
            {
                return _medium;
            }

            set
            {
                // conditional for DVD, BLURAY, and VHS only???
                if (value == MediaType.DVD || value == MediaType.BLURAY || value == MediaType.VHS)
                    _medium = value;
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Medium)}", value, $"{nameof(Medium)} please enter a valid medium for a movie");
                    
            }

        }

        public MPAARatings Ratings
        {
            get
            {
                return _ratings;
            }

            set
            {

                // conditional for non rating values???
                if (value == MPAARatings.G || value == MPAARatings.PG || value == MPAARatings.PG13 ||
                   value == MPAARatings.R || value == MPAARatings.NC17 || value == MPAARatings.U)
                {
                    _ratings = value;
                }
                else
                    throw new ArgumentOutOfRangeException
                        ($"{nameof(Ratings)}", value, $"{nameof(Ratings)} please enter a valid MPAA rating");
            }
        }


        public override decimal CalcLateFee(int daysLate)
        {

            const decimal LATE_FEE_RATE_BLURAY = 1.50m; // Bluray daily rate
            const decimal LATE_FEE_RATE_DVD_VHS = 1.00m; // DVD/VHS daily rate
            const decimal MAX_CHARGE_LIMIT = 25.00m; // max limit for all movie types
            decimal chargeFee;
            
            if (this.Medium == MediaType.DVD)
            {
                if (daysLate * LATE_FEE_RATE_DVD_VHS >= MAX_CHARGE_LIMIT)
                {
                    chargeFee = MAX_CHARGE_LIMIT;
                }
                else
                    chargeFee = daysLate * LATE_FEE_RATE_DVD_VHS;
            }

            else 
            {
                if (daysLate * LATE_FEE_RATE_BLURAY >= MAX_CHARGE_LIMIT)
                {
                    chargeFee = MAX_CHARGE_LIMIT;
                }
                else
                    chargeFee = daysLate * LATE_FEE_RATE_BLURAY;
            }

            return chargeFee;

            


            
        }
    }
}
