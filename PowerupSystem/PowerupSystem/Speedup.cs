using System;

namespace PowerupSystem
{
    public class Speedup : IPowerup
    {
        private const float SPEED_MULTIPLIER = 2f;

        public TimeSpan Duration { get; set; }
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; }
        
        public Speedup(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        public void SetActive(bool isActive, Player owner)
        {
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
}