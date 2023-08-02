namespace PowerupSystem
{
    public class Player
    {
        private float _speed;
        private int _health;

        public string Name;
        public Vector2 Position;
        public IPowerup Powerup;

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

        public Player(string name, float speed, int health, IPowerup powerup, Vector2 position)
        {
            _speed = speed;
            _health = health;
            Name = name;
            Powerup = powerup;
            Position = position;
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