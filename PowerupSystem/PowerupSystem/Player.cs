using System;
using System.Collections.Generic;

namespace PowerupSystem
{
    public class Player
    {
        private float _speed;
        private float _health;
        private float _attackPower;

        public string Name;
        public Vector2 Position;
        public IPowerup Powerup;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float Health => _health;

        public float AttackPower => _attackPower;

        public Player(string name, float speed, float health, float attackPower)
        {
            Name = name;
            _speed = speed;
            _health = health;
            _attackPower = attackPower;
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
            Powerup = null;
        }

        public void TakeDamage(float damage)
        {
            if (Powerup != null && Powerup is Shield shield && Powerup.IsActive)
            {
                _health -= damage * shield.BarrierFactor;
            }
            else
            {
                _health -= damage;
            }
        }
    }
}