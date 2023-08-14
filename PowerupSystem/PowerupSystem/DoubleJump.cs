using System;

namespace PowerupSystem
{
    public class DoubleJump : IPowerup
    {
        public TimeSpan Duration { get; set; }
        public bool IsActive { get; set; }

        public DoubleJump(TimeSpan duration)
        {
            Duration = duration;
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