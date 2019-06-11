using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSelfEducation1
{

    class Frame
    {
        static string[] States = { "none", "spare", "strike" };
       // public int score;
        private int firstTry, secondTry;
        int numberOfTry;
        public int state = 0;

        public int FirstTry
        {
            get
            {
                return firstTry;
            }
            set
            {
                firstTry = value;
                if (value == 10)
                {
                    state = 2;
                    SecondTry = 0;
                    numberOfTry = 2;
                }
            }
        }

        public int SecondTry
        {
            get
            {
                return secondTry;
            }
            set
            {
                secondTry = value;
                if ((secondTry + firstTry) == 10)
                    state = 1;               
            }
        }
    }
    public class Game
    {

        int state;
        int currentScore;
        
        int numberOfTry = 0; 
        int frameNumber;
        
        List<Frame> frames= new List<Frame>(10);

        public void Roll(int ballCount)
        {
            if (frameNumber < 10)
            {
                if (numberOfTry == 1 && ballCount <= 10)
                    frames[frameNumber].FirstTry = ballCount;
                if (numberOfTry == 2 && (ballCount <= (10 - frames[frameNumber].FirstTry)))
                    frames[frameNumber].SecondTry = ballCount;

                if (ballCount == 10 && numberOfTry == 1)
                {
                    numberOfTry = 2;
                }

                currentScore += ballCount;
                if ((state == 1 || state == 2) && numberOfTry == 1)
                    currentScore += ballCount;
                if (state == 2 && numberOfTry == 2)
                    currentScore += ballCount;

                if (numberOfTry == 2)
                {
                    state = frames[frameNumber].state;
                    frameNumber++;
                }
            }

            if (frameNumber == 10 && state != 0)
            {
                currentScore = (ballCount <= 10 && ballCount >= 0) ? ballCount : 0;//throw exp
            }
            else
            {
                throw new Exception("ballCount is out of range");
            }
        }

        public int Score()
        {
            //починить

            return currentScore;
        }
        
    }
}
