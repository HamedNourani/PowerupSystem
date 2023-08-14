using System;

namespace PowerupSystem
{
    public class Shield : IPowerup
    {
        private float _barrierFactor;
        public TimeSpan Duration { get; set; }
        public bool IsActive { get; set; }

        public float BarrierFactor => _barrierFactor;

        public Shield(TimeSpan duration, float barrierFactor)
        {
            Duration = duration;
            _barrierFactor = barrierFactor;
        }
        
        public void SetActive(bool isActive, Player player)
        {
            IsActive = isActive;
        }
    }
}