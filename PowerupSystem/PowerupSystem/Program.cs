using System;
using System.Threading;
using System.Collections.Generic;

namespace PowerupSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var speedup = new Speedup(TimeSpan.FromSeconds(5), new Vector2(0, 0));
            var player1 = new Player("Sonic", 5, 100, speedup, new Vector2(0, 0));
            player1.ActiveCurrentPowerup();
            var speedupTimer = new Timer();
            SpeedupDurationRoutine(speedup, speedupTimer, player1);
            Console.WriteLine();
            
            var shield = new Shield(TimeSpan.FromSeconds(10), new Vector2(0, 0));
            var player2 = new Player("Mario", 3, 100, shield, new Vector2(0, 0));
            Console.WriteLine($"{player2.Name}'s health: {player2.Health}");
            var shieldTimer = new Timer();
            var shieldDurationThread = new Thread(() => ShieldDurationRoutine(shield, shieldTimer, player2));
            shieldDurationThread.Start();
            player2.ActiveCurrentPowerup();
        }
        
        public static void ShieldDurationRoutine(Shield shield, Timer shieldTimer, Player player)
        {
            while (true)
            {
                if (DateTime.Now - shieldTimer.StartTime >= shield.Duration)
                {
                    shield.SetActive(false, player);
                    break;
                }
            }
        }
        
        public static void SpeedupDurationRoutine(Speedup speedup, Timer speddupTimer, Player player)
        {
            while (true)
            {
                if (DateTime.Now - speddupTimer.StartTime >= speedup.Duration)
                {
                    speedup.SetActive(false, player);
                    break;
                }
            }
        }
    }


    public class Player
    {
        private float _speed;
        private int _health;

        public string Name;
        public Vector2 Position;
        public Powerup Powerup;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public Player(string name, float speed, int health, Powerup powerup, Vector2 position)
        {
            _speed = speed;
            _health = health;
            Name = name;
            Powerup = powerup;
            Position = position;
        }

        public void ActiveCurrentPowerup()
        {
            Powerup.SetActive(true, this);
        }
    }


    public abstract class Powerup
    {
        protected internal TimeSpan Duration { get; set; }
        protected internal Vector2 Position { get; set; }
        protected internal bool IsActive { get; set; }

        protected internal Player Player { get; set; }

        protected internal virtual void SetActive(bool isActive, Player owner)
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

        protected internal override void SetActive(bool isActive, Player owner)
        {
            IsActive = isActive;
            
            if (IsActive)
            {
                Console.WriteLine($"Shield is active for {owner.Name}.");
                while (IsActive)
                {
                    var input = Console.ReadLine();
                    if (input == "k")
                    {
                        owner.Health -= 10;
                        Console.WriteLine($"{owner.Name}'s health: {owner.Health}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Shield is inactive for {owner.Name}.");
                while (!IsActive)
                {
                    var input = Console.ReadLine();
                    if (input == "k")
                    {
                        owner.Health -= 20;
                        Console.WriteLine($"{owner.Name}'s health: {owner.Health}");
                    }
                }
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

        protected internal override void SetActive(bool isActive, Player player)
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
        private const float SPEED_MULTIPLIER = 2f;

        private Player owner;
        
        public Speedup(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        public void BeCollected(Player player)
        {
            owner = player;
        }

        protected internal override void SetActive(bool isActive, Player owner)
        {
            if (owner == null)
                return;
            IsActive = isActive;
            
            if (IsActive)
            {
                Console.WriteLine($"Speedup is active for {owner.Name}");
                owner.Speed *= SPEED_MULTIPLIER;
                Console.WriteLine($"Current speed of {owner.Name} is: {owner.Speed}");
            }
            else
            {
                Console.WriteLine($"Speedup is inactive for {owner.Name}");
                owner.Speed /= SPEED_MULTIPLIER;
                Console.WriteLine($"Current speed of {owner.Name} is: {owner.Speed}");
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