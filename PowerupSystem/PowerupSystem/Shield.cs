using System;

namespace PowerupSystem
{
    public class Shield : IPowerup
    {
        public TimeSpan Duration { get; set; }
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; }

        public PowerupTypes PowerupType { get; set; } = PowerupTypes.Shield;
        
        public Shield(TimeSpan duration, Vector2 position)
        {
            Duration = duration;
            Position = position;
        }

        public void SetActive(bool isActive, Player owner)
        {
            IsActive = isActive;

            if (IsActive)
            {
                Console.WriteLine($"Shield is active for {owner.Name}.");
                Console.WriteLine($"{owner.Name}'s health: {owner.Health}");
                owner.Damage /= 2;
                
                while (IsActive)
                {
                    var input = Console.ReadLine();
                    if (input == "k")
                    {
                        owner.Health -= owner.Damage;
                        Console.WriteLine($"{owner.Name}'s health: {owner.Health}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Shield is inactive for {owner.Name}.");
                owner.Damage *= 2;
                
                while (!IsActive)
                {
                    var input = Console.ReadLine();
                    if (input == "k")
                    {
                        owner.Health -= owner.Damage;
                        Console.WriteLine($"{owner.Name}'s health: {owner.Health}");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}