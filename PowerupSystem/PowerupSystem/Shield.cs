using System;

namespace PowerupSystem
{
    public class Shield : IPowerup
    {
        public TimeSpan Duration { get; set; }
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; }

        public Shield(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        public void SetActive(bool isActive, Player player)
        {
            IsActive = isActive;

            if (IsActive)
            {
                player.Damage /= 2f;
            }
            else
            {
                player.Damage *= 2f;
            }
        }
    }
}