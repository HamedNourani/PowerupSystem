using System;
using System.Collections.Generic;

namespace PowerupSystem
{
    // Suppose that all the powerups can be used only once
    public class Player
    {
        private float _speed;
        private int _health;

        public string Name;
        public Vector2 Position;
        public IPowerup Powerup;
        public int Damage = 20;

        public static List<Player> Players = new List<Player>();

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
        
        // There is no need for powerup and position in constructor
        public Player(string name, float speed, int health)
        {
            _speed = speed;
            _health = health;
            Name = name;
            
            Players.Add(this);
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void AddPowerup(IPowerup powerup)
        {
            // Handle the old powerup : Override it
            Powerup = powerup;
        }

        public void ActivateCurrentPowerup()
        {
            Powerup.SetActive(true, this);
        }
        
        public void DeactivateCurrentPowerup()
        {
            Powerup.SetActive(false, this);
        }
    }
}