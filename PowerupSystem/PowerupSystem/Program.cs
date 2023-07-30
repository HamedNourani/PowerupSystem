using System;
using System.Threading;

namespace PowerupSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var shield = new Shield(TimeSpan.FromSeconds(5), new Vector2(1, 2));
            shield.SetActive(true);
            var shieldTimer = new Timer();
            var shieldDurationThread = new Thread(() => ShieldDurationRoutine(shield, shieldTimer));
            shieldDurationThread.Start();
            
            var speedup = new Speedup(TimeSpan.FromSeconds(10), new Vector2(3, 4));
            speedup.SetActive(true);
            var speedupTimer = new Timer();
            SpeedupDurationRoutine(speedup, speedupTimer);
        }
        
        public static void ShieldDurationRoutine(Shield shield, Timer shieldTimer)
        {
            while (true)
            {
                if (DateTime.Now - shieldTimer.StartTime >= shield.Duration)
                {
                    shield.SetActive(false);
                    break;
                }
            }
        }
        
        public static void SpeedupDurationRoutine(Speedup speedup, Timer speddupTimer)
        {
            while (true)
            {
                if (DateTime.Now - speddupTimer.StartTime >= speedup.Duration)
                {
                    speedup.SetActive(false);
                    break;
                }
            }
        }
    }


    public class Powerup
    {
        protected internal TimeSpan Duration { get; set; }
        protected internal Vector2 Position { get; set; }
        protected internal bool IsActive { get; set; }

        protected internal virtual void SetActive(bool isActive)
        {
            Console.WriteLine("Powerup is active.");
        }
    }


    public class Shield : Powerup
    {
        public Shield(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        protected internal override void SetActive(bool isActive)
        {
            IsActive = isActive;
            CheckIfShieldIsActive();
        }

        private void CheckIfShieldIsActive()
        {
            if (IsActive)
            {
                Console.WriteLine("Shield is active.");
            }
            else
            {
                Console.WriteLine("Shield is inactive.");
            }
        }
    }
    
    
    public class DoubleJump : Powerup
    {
        public DoubleJump(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        protected internal override void SetActive(bool isActive)
        {
            IsActive = isActive;
            CheckIfDoubleJumpIsActive();
        }

        private void CheckIfDoubleJumpIsActive()
        {
            if (IsActive)
            {
                Console.WriteLine("Double jump is active.");
            }
            else
            {
                Console.WriteLine("Double jump is inactive.");
            }
        }
    }
    
    
    public class Speedup : Powerup
    {
        public Speedup(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        protected internal override void SetActive(bool isActive)
        {
            IsActive = isActive;
            CheckIfSpeedupIsActive();
        }

        private void CheckIfSpeedupIsActive()
        {
            if (IsActive)
            {
                Console.WriteLine("Speedup is active.");
            }
            else
            {
                Console.WriteLine("Speedup is inactive.");
            }
        }
    }


    public class Vector2
    {
        private float _x;
        private float _y;

        public float X => _x;
        public float Y => _y;

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
    
    
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