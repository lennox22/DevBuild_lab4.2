using System;
using System.Collections.Generic;

namespace Lab4._2MovieList
{
    class MoviesDB
    {
        public string title;                //creating the variables
        public int runTime;
        public int year;
        public bool scifi;
        public bool animated;
        public bool action;
        public bool comedy;
        public bool superhero;
        public int rating;

        public MoviesDB(string name, int length, int age, bool scienceFantasy, bool cartoon, bool booms, bool laugh, bool capes, int stars)
        {
            title = name;                   //method to add them into the list
            runTime = length;
            year = age;
            scifi = scienceFantasy;
            animated = cartoon;
            action = booms;
            comedy = laugh;
            superhero = capes;
            rating = stars;
        }


    }
    class Program
    {
        public static List<MoviesDB> movieList = new List<MoviesDB>();        //creating the list

        static void Main(string[] args)
        {
            bool loop = true;
            int category;

            addMovies();                               //method to add the movies to the list of objects

            Console.Write($"\nWelcome to the Movie List Application!\n\n");

            do                                          //do while loop to loop through the program if the user wants
            {
                category = mainMenu();                            //main menu 

                catChoice(category);                            //sending to cat choice method

                loop = continueYN();                              //this method returns if the loop breaks or not

            } while (loop);
        }


        static bool continueYN()                   //continue method
        {
            bool loop = true;
            string input;

            bool notValid = true;

            do
            {

            Console.Write($"\n\nWould you like to choose again? (y/n): ");
            input = Console.ReadLine().ToLower();
            

                if (input != "y" && input != "n")             //if user enters anything but a y or an n
                {
                    invalidMessages(3);                    //error message method
                }
                else                                      //valid answer since user put in a y or n
                {
                    notValid = false;                             //ends loop in this method
                    

                    if (input == "n")                      //if user enters no
                    {
                        loop = false;                   //ends loop in main
                    }

                }

            } while (notValid);


            return loop;
        }
        static int genreChoice()
        {
            int submenu = 0;

            string input;
            bool validInput = false;
            
            bool loop = true;

            do
            {

                Console.Write($"\nWhich genre would you like to sort by?\n ");                  //genre menu
                Console.Write($"--------------\n|1 - SciFi    |\n|2 - Animated |\n|3 - Action   |\n|4 - comedy   |\n|5 - SuperHero|\n---------------\n\n");
                

                input = Console.ReadLine().ToLower();


                validInput = validator(input);          //sending to the validator to see if the answer is an integer

                if (validInput)               //if user entered an integer within bounds
                {
                    submenu = Int32.Parse(input);

                    if (submenu < 1 || submenu > 5)
                    {
                        invalidMessages(2);                    //sending to error message method

                        continue;
                    }
                    else
                    {
                        loop = false;
                    }
                }
                else                                //sorting for strings to make the menu choice
                {

                    if (input == "scifi" || input == "sci fi" || input == "syfy" || input.Contains("science fiction") || input.Contains("fantasy"))
                    {
                        submenu = 1;
                        loop = false;
                    }
                    else if (input == "animated" || input == "cartoon" || input == "anime")
                    {
                        submenu = 2;
                        loop = false;
                    }
                    else if (input == "action" || input.Contains("explosion"))
                    {
                        submenu = 3;
                        loop = false;
                    }
                    else if (input == "comedy" || input == "funny" || input == "laugh")
                    {
                        submenu = 4;
                        loop = false;
                    }
                    else if (input == "superhero" || input.Contains("supe") || input.Contains("cape"))
                    {
                        submenu = 5;
                        loop = false;
                    }
                    else                             //sending error message and looping again
                    {
                        invalidMessages(2);
                        continue;
                    }
                }
            } while (loop);

            


            return submenu;
        }

        static void runTimeSort()   //viewing the list of movies
        {
            int counter = 1;   //to show numbers
            foreach ( MoviesDB runtime in movieList)    //cycle through the list
            {
                
                Console.Write($"\n{counter} - {runtime.title} - {runtime.runTime}mins");  //display the list
                counter++;                                           //increment the menu item
            }
        }

        static void premierSort()       //view the movies with their premier year
        {
            int counter = 1;
            foreach (MoviesDB item in movieList)  //cycle through list
            {
                Console.Write($"\n{counter} - {item.title} - {item.year}"); //display the movie and the year it came out
                counter++;
            }
        }

        static void genreSort()              //view movies in a genre
        {
            int decision = genreChoice();
            int counter = 1;

            switch (decision)
            {
                case 1:
                    foreach (MoviesDB item in movieList)
                    {
                        if(item.scifi == true)
                        {
                            Console.Write($"\n{counter} - {item.title}");
                            counter++;
                        }
                    }
                    break;
                case 2:
                    foreach (MoviesDB item in movieList)
                    {
                        if (item.animated == true)
                        {
                            Console.Write($"\n{counter} - {item.title}");
                            counter++;
                        }
                    }
                    break;
                case 3:
                    foreach (MoviesDB item in movieList)
                    {
                        if (item.action == true)
                        {
                            Console.Write($"\n{counter} - {item.title}");
                            counter++;
                        }
                    }
                    break;
                case 4:
                    foreach (MoviesDB item in movieList)
                    {
                        if (item.comedy == true)
                        {
                            Console.Write($"\n{counter} - {item.title}");
                            counter++;
                        }
                    }
                    break;
                case 5:
                    foreach (MoviesDB item in movieList)
                    {
                        if (item.superhero == true)
                        {
                            Console.Write($"\n{counter} - {item.title}");
                            counter++;
                        }
                    }
                    break;
            }


        }

        static void ratingSort()             //view movies and ratings
        {
            int counter = 1;
            foreach (MoviesDB item in movieList)
            {
                Console.Write($"\n{counter} - {item.title} - {item.rating} stars");  //show movies and their ratings
                counter++;
            }
        }
        static void catChoice(int num)  //soley to send user to method that they chose
        {
            switch (num)
            {
                
                case 1:
                    runTimeSort();
                    break;
                case 2:
                    premierSort();
                    break;
                case 3:
                    genreSort();
                    break;
                case 4:
                    ratingSort();
                    break;
            }
        }
        static void invalidMessages(int error)   //method for all error messages
        {
            switch (error)
            {
                case 1:
                    Console.Write($"\n\nThat was not a valid category choice.\nPlease enter an integer between 1 and 4 or enter the category name: ");    //invalid category choice

                    break;

                case 2:
                    Console.Write($"\n\nThat was not a valid genre choice.\nPlease enter an integer between 1 and 5 or enter the genre name: ");       //genre error message    
                    break;

                case 3:
                    Console.Write($"\n\nThat was not a valid answer.\nPlease enter either y or n: ");         //yn error message
                    break;
            }
        }

        static bool validator(string input)                  //for validating input
        {
            bool valid;
            int test;

            try                          // trying to parse will set valid to true
            {
                test = Int32.Parse(input);
                valid = true;
            }
            catch (Exception)                   //if it fails, then it's false. 
            {
                valid = false;
            }

            return valid;                  //returns if user entered an integer
        }
        static int mainMenu()              //this will print out the categories the user can choose to sort with
        {
            string input;
            bool validInput = false;
            int menuChoice = 3;
            bool loop = true;

            do
            {

                Console.Write($"\nThere are {movieList.Count} movies in this list.\nWhat category would you like to sort by?: ");
                Console.Write($"\n------------------");
                Console.Write($"\n|1 - Run Time    |\n|2 - Premier Year|\n|3 - Genre       |\n|4 - Rating      |\n");
                Console.Write($"------------------\n\n");

                input = Console.ReadLine().ToLower();


                validInput = validator(input);          //sending to the validator to see if the answer is an integer

                if (validInput)               //if user entered an integer within bounds
                {
                    menuChoice = Int32.Parse(input);

                    if (menuChoice < 1 || menuChoice > 4)
                    {
                        invalidMessages(1);                    //sending to error message method
                        
                        continue;
                    }
                    else
                    {
                        loop = false;
                    }
                }
                else                                //sorting for strings to make the menu choice
                {
                    
                    if (input == "run time" || input == "length" || input == "duration")
                    {
                        menuChoice = 1;
                        loop = false;
                    }
                    else if (input == "premier" || input == "year" || input == "premier year")
                    {
                        menuChoice = 2;
                        loop = false;
                    }
                    else if (input == "genre" || input == "category" || input == "type")
                    {
                        menuChoice = 3;
                        loop = false;
                    }
                    else if (input == "rating" || input == "score" || input == "quality")
                    {
                        menuChoice = 4;
                        loop = false;
                    }
                    else                             //sending error message and looping again
                    {
                        invalidMessages(1);
                        continue;
                    }
                }
            } while (loop);

            return menuChoice;


        }
        static void addMovies()   //method to add all of the movies
        {
            movieList.Add(new MoviesDB("Avengers", 143, 2012, true, false, true, false, true, 4));
            movieList.Add(new MoviesDB("Short Circuit", 98, 1986, true, false, false, true, false, 5));
            movieList.Add(new MoviesDB("Mystery Men", 121, 1999, true, false, true, true, true, 3));
            movieList.Add(new MoviesDB("Safety Not Guaranteed", 86, 2012, true, false, false, true, false, 5));
            movieList.Add(new MoviesDB("Red Dwarf: The Promised Land", 87, 2020, true, false, false, true, false, 4));
            movieList.Add(new MoviesDB("Goofy Movie", 78, 1995, false, true, false, true, false, 3));
            movieList.Add(new MoviesDB("Big Trouble in Little China", 99, 1986, true, false, true, true, false, 4));
            movieList.Add(new MoviesDB("Fired Up", 90, 2009, false, false, false, true, false, 5));
            movieList.Add(new MoviesDB("Shaun of the Dead", 99, 2004, true, false, true, true, false, 4));
            movieList.Add(new MoviesDB("Mad Max", 88, 1979, true, false, true, false, false, 3));
            movieList.Add(new MoviesDB("Intersteller", 140, 2016, true, false, true, false, false, 4));
            movieList.Add(new MoviesDB("Primer", 95, 2002, true, false, false, false, false, 5));
            
        }
    }
}
