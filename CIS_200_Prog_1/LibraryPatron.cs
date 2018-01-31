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

// FileName: LibraryPatron.cs
// Class: LibraryPatron [Origin: Prog_0]

namespace CIS_200_Prog_1
{
    class LibraryPatron
    {
        private string _patronName; // Name of the patron
        private string _patronID;   // ID of the patron

        // Precondition:  None
        // Postcondition: The patron has been initialized with the specified name and ID
        
        public LibraryPatron(string name, string id)
        {
            PatronName = name;
            PatronID = id;
        }

        public string PatronName
        {
            // Precondition:  None
            // Postcondition: The patron's name has been returned
            get
            {
                return _patronName;
            }

            // Precondition:  None
            // Postcondition: The patron's name has been set to the specified value
            set
            {

                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(PatronName)}", value,
                        $"{nameof(PatronName)} must not be null or empty");
                else
                    _patronName = value.Trim();
            }
        }

        public string PatronID
        {
            // Precondition:  None
            // Postcondition: The patron's ID has been returned
            get
            {
                return _patronID;
            }

            // Precondition:  None
            // Postcondition: The patron's ID has been set to the specified value
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(PatronID)}", value,
                        $"{nameof(PatronID)} must not be null or empty");
                else
                    _patronID = value.Trim();
            }
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary patron's data on separate lines
        
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Name: {PatronName}{NL}ID: {PatronID}";
        }
    }
}
