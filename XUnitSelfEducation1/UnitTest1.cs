using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitSelfEducation1
{
    public class UnitTest1
    {
        //неправильные значения + - и тд
        //строки

        //проверка на правильные значения
        //

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        [InlineData(100)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void InvalidParameters(int points)
        {
            Game game = new Game();
            var ex = Assert.Throws<Exception>(() => game.Roll(points));

            Assert.Equal("ballCount is out of range", ex.Message);
        
        }

      /*  [Theory]
        [InlineData(new int[] { 1, 0,  0, 2,  
                                1, 1,
                                2 },1)]
        public void ValidScore(int[] points, int expectedScore)
        {
            Game game = new Game();
           // var ex = Assert.Throws<Exception>(() => game.Sc(points));

            Assert.Equal(expectedScore, game.Score());

        }*/
    }
}
