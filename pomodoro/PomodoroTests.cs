using System;
using System.Diagnostics;
using Xunit;

namespace _SepPomodoro
{
    public class PomodoroTests
    {
        Pomodoro pomodoro = new Pomodoro(5);

        // Add test for anything public

        //[Fact]
        //public void TestTomatoCountInstantiated
        //{

        //}

        //public void TestTomatoCycleLengthInstantiated
        //{

        //}

        // variable to log where in cycle? e.g. Cycle1, Pomodoro 3, short break 1, long break.

        [Fact]
        public void UninterruptedPomodoroTimerAddsTomato()
        {
            
            // test completed pomodoro timer adds a tomato.
            pomodoro.RunTomato();
            pomodoro.RunTomato();
            pomodoro.RunTomato();
            // Check new tomato count based on count at start of cycle
            Assert.Equal(3, pomodoro.TomatoCount);

        }

        [Fact]
        public void TwoPomodorosLastExpectedTime()
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            pomodoro.RunTomato();
            pomodoro.RunTomato();
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            TimeSpan expectedLower = new TimeSpan(00, 00, 00, 00, 10);
            TimeSpan expectedHigher = new TimeSpan(00, 00, 00, 00, 12);

            // Check 2 pomodoro cycles last approx 10ms (for cycle length of 5 ms). Can this be done with a range?
            Assert.True(expectedLower.TotalMilliseconds <= (double) ts.TotalMilliseconds);
            Assert.True(expectedHigher.TotalMilliseconds >= (double)ts.TotalMilliseconds);

        }

    }

}


//         [Theory]
//         public void ShortBreakTriggeredAfterUninterruptedPomodoro()
//         {
//             // Test 5 min break is triggered after first, second and third pomodoro cycle

//         }

//         [Fact]
//         public void LongBreakTriggeredAfterFourthUninterruptedPomodoro()
//         {
//             // Test 30 min break is triggered after fourth cycle

//         }

//         [Theory]
//         public void CheckTimeElapsedMatchesNumberOfTomatoes()
//         {
//             // Stop time at specific point and check correct number of tomatoes accumulated

//         }
