using System;

namespace PowerupSystem
{
    public class Timer
    {
        private DateTime _startTime;

        public DateTime StartTime => _startTime;

        public Timer()
        {
            _startTime = DateTime.Now;
        }
    }
}