using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; set;}

        public int Score { get; set; }

        public string GiveName()
        {
            Console.WriteLine("Please enter your name");
            string CharacterName = Console.ReadLine();
            while (CharacterName == "")
            {
                Console.WriteLine("Please enter an actual name ");
                CharacterName = Console.ReadLine();
            }
            return (CharacterName);
        }
        public void AddPoints(int points)
        {
            Score += points;
        }
        public void RemovePoints(int points)
        {
            Score -= points;
        }
        public void SkipQuestion()
        {
            throw new System.NotImplementedException();
        }

        public void Answer()
        {
            throw new System.NotImplementedException();
        }
    }
}