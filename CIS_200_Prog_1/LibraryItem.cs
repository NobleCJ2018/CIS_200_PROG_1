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
    class LibraryItem
    {
        private string _title;
        private string _publisher;
        private int _copyrightYear;
        private int _loanPeriod;
        private string _callNumber;

        public LibraryItem(string title, string publisher, int copyrightYear, int loanPeriod, string callNumber)
        {
            
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Title)} Please Enter A Title");
                }
                Title = value.Trim();
            }
        }

        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Publisher)} Please Enter a Publisher");
                }
                ///////// Stop 2/1/2018
                Publisher = value;
            }
        }

        public int CopyrightYear
        {
            get
            {
                return _copyrightYear;
            }

            set
            {
                CopyrightYear = value;
            }
        }

        public int LoanPeriod
        {
            get
            {
                return _loanPeriod;
            }

            set
            {
                LoanPeriod = value;
            }
        }

        public string CallNumber
        {
            get
            {
                return _callNumber;
            }
            set
            {
                CallNumber = value;
            }
        }

    }

        
   
}
