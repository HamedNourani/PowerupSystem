using System;

namespace PowerupSystem
{
    public class Speedup : IPowerup
    {
        private float _speedMultiplier;

        public TimeSpan Duration { get; set; }
        public bool IsActive { get; set; }

        public Speedup(TimeSpan duration, float speedMultiplier)
        {
            Duration = duration;
            _speedMultiplier = speedMultiplier;
        }

        public void SetActive(bool isActive, Player player)
        {
            IsActive = isActive;

            if (IsActive)
            {
                player.Speed *= _speedMultiplier;
            }
            else
            {
                player.Speed /= _speedMultiplier;
            }
        }
    }
}