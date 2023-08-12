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

        public void SetActive(bool isActive, Player player)
        {
            IsActive = isActive;

            if (IsActive)
            {
                player.Speed *= SPEED_MULTIPLIER;
            }
            else
            {
                player.Speed /= SPEED_MULTIPLIER;
            }
        }
    }
}