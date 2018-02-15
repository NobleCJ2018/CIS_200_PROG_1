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

    // FileName: Program.cs

namespace CIS_200_Prog_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // TEST APPLICATION PLEASE IGNORE - MIDDLE MGMT DINO

            //Make one of each library item type

            decimal displayLateFee;
            string overDueMessage = "Est. if item is 2 weeks overdue:";

            LibraryPatron Pat1 = new LibraryPatron("Bob Dole", "ID5485");
            LibraryBook book1 = new LibraryBook("Book 1", "Mr. Dole", "Dole Press", 1988, 90, "B1988");
            LibraryJournal journal1 = new LibraryJournal("Journal 1", "Dole Press", 1988, 90, "J1988", 10, 100,
                                                         "Trickle Down", "Ross Perot");
            LibraryMagazine magazine1 = new LibraryMagazine("The Wright Stuff", "Dole Press", 1988, 90, "M1988",
                                                            20, 200);
            LibraryMovie movie1 = new LibraryMovie("Code Wars: A New Hope", "Dole Press", 1988, 90, "MO1988",
                                                   120.00, "Raplh Nader", LibraryMediaItem.MediaType.BLURAY,
                                                   LibraryMovie.MPAARatings.NC17);
            LibraryMusic music1 = new LibraryMusic("Higgz BugZon", "Dole Press", 1988, 90, "MU1988", 731, "DJ BeeDole",
                                                   LibraryMediaItem.MediaType.VINYL, 32);

            // check out items

            journal1.CheckOut(Pat1);
            book1.CheckOut(Pat1);
            magazine1.CheckOut(Pat1);
            movie1.CheckOut(Pat1);
            music1.CheckOut(Pat1);

            //display some items
            Console.WriteLine(book1.ToString());
            Console.Write(overDueMessage); //and if late??
            displayLateFee = book1.CalcLateFee(14);
            Console.WriteLine($"{displayLateFee.ToString("C")}");
            Pause();

            Console.WriteLine(journal1.ToString());
            Console.Write(overDueMessage);
            displayLateFee = journal1.CalcLateFee(14);
            Console.WriteLine($"{displayLateFee.ToString("C")}");
            Pause();

            Console.WriteLine(magazine1.ToString());
            Console.Write(overDueMessage);
            displayLateFee = magazine1.CalcLateFee(14);
            Console.WriteLine($"{displayLateFee.ToString("C")}");
            Pause();

            Console.WriteLine(movie1.ToString());
            Console.Write(overDueMessage);
            displayLateFee = movie1.CalcLateFee(14);
            Console.WriteLine($"{displayLateFee.ToString("C")}");
            Pause();

            Console.WriteLine(music1.ToString());
            Console.Write(overDueMessage);
            displayLateFee = music1.CalcLateFee(14);
            Console.WriteLine($"{displayLateFee.ToString("C")}");
            Pause();






            
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
