using System;
using System.Collections.Generic;

namespace PowerupSystem
{
    public class Player
    {
        private float _speed;
        private float _health;

        public string Name;
        public Vector2 Position;
        public IPowerup Powerup;
        public float Damage = 20f;

        public static List<Player> Players = new List<Player>();

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float Health
        {
            get => _health;
            set => _health = value;
        }
        
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