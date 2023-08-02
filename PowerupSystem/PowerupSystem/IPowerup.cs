using System;

namespace PowerupSystem
{
    public interface IPowerup
    { 
        TimeSpan Duration { get; set; }
        Vector2 Position { get; set; }
        bool IsActive { get; set; }

        void SetActive(bool isActive, Player owner);
    }
}