using System;

namespace PowerupSystem
{
    public class DoubleJump : IPowerup
    {
        public TimeSpan Duration { get; set; }
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; }
        
        public PowerupTypes PowerupType { get; set; } = PowerupTypes.DoubleJump;
        
        public DoubleJump(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        public void SetActive(bool isActive, Player player)
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
}