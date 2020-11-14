using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Trivia
{
    public class Game
    {
        public int Goal { get; set; }
        
        public string CurrentPlayer { get; set; }
        public Game()
        {
            Start();
        }
        public void Start()
        {
            Console.Title = "Trivia game by Michael";
            Random rnd = new Random(); //setting up random number generator
            int num = rnd.Next();
            Goal = 1000;
            Player player1 = new Player();  //initilazing the player setting score to zero and having player pick a name.
            player1.Score = 0;
            player1.Name = player1.GiveName();
            Console.WriteLine($"Welcome, {player1.Name}, to a hand picked trivia quiz with question made specifically for you. \nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You will recieve questions from a random list. If you get them right you recieve their worth in points. If you get them wrong you will lose half their worth in points.");
            Console.WriteLine("There is no timer so don't be afraid to take your time. Also if you find any bugs please tell me.");
            Console.WriteLine($"Your goal is {Goal} points. Press any key to begin the trivia.");
            Console.ReadKey();
            Console.Clear();
            TriviaItem[] TriviaItems = new TriviaItem[10];
            TriviaItems[0] = new TriviaItem("What year was the compact disk first shown on television", "1982", "Obscure technology history", 100);  //start of the trivia questions
            TriviaItems[1] = new TriviaItem("What is the bit depth of the red book standard for cds", "16", "Sound technology facts", 200);
            TriviaItems[2] = new TriviaItem("What weighs the same as a witch","Duck","movie references",100);
            TriviaItems[3] = new TriviaItem("Who killed Dumbledoor","Snape","Movie Spoilers",100);
            TriviaItems[4] = new TriviaItem("Some cats are allergic to people. True or False", "True", "Obscure facts", 150);
            TriviaItems[5] = new TriviaItem("What is the national animal of scotland", "Unicorn", "Obscure facts", 50);
            TriviaItems[6] = new TriviaItem("What does M&M stand for", "Mars and Murrie", "Very Obscure facts", 500);
            TriviaItems[7] = new TriviaItem("The odds of getting a royal flush are 1 in..", "649740", "Statistics", 500);
            TriviaItems[8] = new TriviaItem("Pepsi was the first soft drink in space. True or False", "False", "Obsure facts", 200);
            TriviaItems[9] = new TriviaItem("Only ___ mosquitos will bite you. Male or Female", "Female", "bugs", 100);                             //end of the trivia questions
            while (player1.Score < Goal)               //loops questions until the player's score is higher than the goal of the game
            {
                string skip = "y";
                while (skip != "n")
                {
                    num = rnd.Next(TriviaItems.Count());       //selects a random number for the random trivia question
                    //Console.WriteLine(num);   //writes the random number for testing purposes.
                    Console.WriteLine($"Your next question is about {TriviaItems[num].Topic} and is worth {TriviaItems[num].Worth} points\nWould you like to skip this question (y/n)");
                    ConsoleKeyInfo key = Console.ReadKey();
                    skip = Convert.ToString(key.KeyChar);
                    Console.Clear();//              this section allows you to skip questions if you don't like the topic of them.
                }
                
                TriviaItems[num].DisplayQuestion();//displays the random question
                if (TriviaItems[num].CheckAnswer(Console.ReadLine()) == true)// checks if the answer was correct and gives/ takes away points accordingly
                {
                    player1.AddPoints(TriviaItems[num].Worth);
                    Console.WriteLine($"Correct you just gained { TriviaItems[num].Worth} poins and are now at {player1.Score} total points.");
                }
                else
                {
                    player1.RemovePoints(TriviaItems[num].Worth / 2);
                    Console.WriteLine($"Incorrect. The correct answer was {TriviaItems[num].CorrectAnswer}. You lost {TriviaItems[num].Worth / 2} points and are now at {player1.Score} total points.");

                }
                if (player1.Score < Goal)
                {
                    Console.WriteLine("Press any key to continue on the the next question");
                }
                else
                {
                    Console.WriteLine("Congradulations. You win. I have yet to figue out a reward so take these free internet points.");
                    Console.WriteLine("Press any button to close the program.");
                }
                
                Console.ReadKey();
                Console.Clear();
            }
            

        }
    }
}