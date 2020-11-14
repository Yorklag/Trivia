using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia
{
    public class TriviaItem
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Topic { get; set; }
        public int Worth { get; set; }
        public TriviaItem(string Ques, string CorAns, string Top, int Wth)
        {
            Question = Ques;
            CorrectAnswer = CorAns;
            Topic = Top;
            Worth = Wth;
        }
        public void DisplayQuestion()
        {
            Console.WriteLine($"{Question} ?");


        }
        public string AnswerQuestion()
        {
            return ("1");
        }
        public bool CheckAnswer(string answer)
        {
            return (answer.ToLower().Contains(CorrectAnswer.ToLower())&& (!(answer.ToLower().Contains("true")&&answer.ToLower().Contains("false"))));
            /*above line is to remove case sensitivity in answers and make it so answers that contain the answer (like a duck instead of duck) still work while
            While still disallowing the use of both true and false in the same answer to buypass the true false questions*/
        }
    }
}