using System;
using System.Threading;
using System.Collections.Generic;

namespace PowerupSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                HandleCommand(command);
            }
        }
        
        private static void HandleCommand(string command)
        {
            switch (command)
            {
                case "is":
                    InstantiateSonic();
                    break;
                case "asps": 
                    AddSpeedPowerupToSonic();
                    break;
                case "ashps":
                    AddShieldPowerupToSonic();
                    break;
                case "asp":
                    ActivateSonicPowerup();
                    break;
                case "im":
                    InstantiateMario();
                    break;
                case "aspm": 
                    AddSpeedPowerupToMario();
                    break;
                case "ashpm":
                    AddShieldPowerupToMario();
                    break;
                case "amp":
                    ActivateMarioPowerup();
                    break;
                case "ms":
                    MoveSonic();
                    break;
                case "mm":
                    MoveMario();
                    break;
                case "ks":
                    DamageSonic();
                    break;
                case "km":
                    DamageMario();
                    break;
                default:
                    PrintErrorMessage(command);
                    break;
            }
        }
        
        private static void InstantiateSonic()
        {
            var sonic = new Player("Sonic", 10f, 100);
            sonic.SetPosition(new Vector2(0f, 0f));
            Console.WriteLine("Sonic instantiated.");
        }

        private static void AddSpeedPowerupToSonic()
        {
            var speedup = new Speedup(TimeSpan.FromSeconds(30f), new Vector2(0f, 0f));
            AddPowerupToSonic(speedup);
        }

        private static void AddShieldPowerupToSonic()
        {
            var shield = new Shield(TimeSpan.FromSeconds(30f), new Vector2(0f, 0f));
            AddPowerupToSonic(shield);
        }
        
        private static void AddPowerupToSonic(IPowerup powerup)
        {
            var sonic = GetPlayer("Sonic");

            if (sonic != null)
            {
                sonic.AddPowerup(powerup);
                Console.WriteLine($"{powerup.GetType().Name} added to Sonic.");
            }
            else
            {
                Console.WriteLine("Sonic is not instantiated! Instantiate it.");
            }
        }

        private static void ActivateSonicPowerup()
        {
            var sonic = GetPlayer("Sonic");
            ActivatePowerup(sonic);
        }

        
        private static void InstantiateMario()
        {
            var mario = new Player("Mario", 5f, 100);
            mario.SetPosition(new Vector2(0f, 0f));
            Console.WriteLine("Mario instantiated.");
        }
        
        private static void AddSpeedPowerupToMario()
        {
            var speedup = new Speedup(TimeSpan.FromSeconds(30f), new Vector2(0f, 0f));
            AddPowerupToMario(speedup);
        }
        
        private static void AddShieldPowerupToMario()
        {
            var shield = new Shield(TimeSpan.FromSeconds(30f), new Vector2(0f, 0f));
            AddPowerupToMario(shield);
        }
        
        private static void AddPowerupToMario(IPowerup powerup)
        {
            var mario = GetPlayer("Mario");

            if (mario != null)
            {
                mario.AddPowerup(powerup);
                Console.WriteLine($"{powerup.GetType().Name} added to Mario.");
            }
            else
            {
                Console.WriteLine("Mario is not instantiated! Instantiate it.");
            }
        }

        private static void ActivateMarioPowerup()
        {
            var mario = GetPlayer("Mario");
            ActivatePowerup(mario);
        }

        private static void ActivatePowerup(Player player)
        {
            if (player != null)
            {
                if (player.Powerup != null)
                {
                    player.ActivateCurrentPowerup();

                    var timer = new Timer();
                    var powerupDurationThread = new Thread(() => PowerupDurationRoutine(player.Powerup, timer, player));
                    powerupDurationThread.Start();

                    if (player.Powerup is Speedup)
                    {
                        Console.WriteLine($"Speedup is active for {player.Name}.");
                        Console.WriteLine($"Current speed of {player.Name} is: {player.Speed}");
                    }
                    else if (player.Powerup is Shield)
                    {
                        Console.WriteLine($"Shield is active for {player.Name}.");
                        Console.WriteLine($"{player.Name}'s health: {player.Health}");
                    }
                }
                else
                {
                    Console.WriteLine($"No powerup is added to {player.Name}! Add one.");
                }
            }
            else
            {
                Console.WriteLine($"{player.Name} is not instantiated! Instantiate it.");
            }
        }

        private static void MoveSonic()
        {
            var sonic = GetPlayer("Sonic");
            MovePlayer(sonic);
        }
        
        private static void MoveMario()
        {
            var mario = GetPlayer("Mario");
            MovePlayer(mario);
        }

        private static void MovePlayer(Player player)
        {
            if (player != null)
            {
                player.Position.X += player.Speed;
                Console.WriteLine($"Current X position of {player.Name} is: {player.Position.X}");
            }
            else
            {
                Console.WriteLine($"{player.Name} is not instantiated! Instantiate it.");
            }
        }

        private static void DamageSonic()
        {
            var sonic = GetPlayer("Sonic");
            DamagePlayer(sonic);
        }
        
        private static void DamageMario()
        {
            var mario = GetPlayer("Mario");
            DamagePlayer(mario);
        }

        private static void DamagePlayer(Player player)
        {
            if (player != null)
            {
                player.Health -= player.Damage;
                Console.WriteLine($"Current health of {player.Name} is: {player.Health}");
            }
            else
            {
                Console.WriteLine($"{player.Name} is not instantiated! Instantiate it.");
            }
        }

        private static Player GetPlayer(string name)
        {
            foreach (var player in Player.Players)
            {
                if (player.Name == name)
                {
                    return player;
                }
            }

            return null;
        }

        private static void PowerupDurationRoutine(IPowerup powerup, Timer timer, Player player)
        {
            while (true)
            {
                if (DateTime.Now - timer.StartTime >= powerup.Duration)
                {
                    player.DeactivateCurrentPowerup();
                    
                    if (powerup is Speedup)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Speedup is inactive for {player.Name}.");
                        Console.WriteLine($"Current speed of {player.Name} is: {player.Speed}");
                    }
                    else if (powerup is Shield)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Shield is inactive for {player.Name}.");
                    }
                    
                    break;
                }
            }
        }

        private static void PrintErrorMessage(string command)
        {
            Console.WriteLine($"'{command}' is not recognized as a valid command.");
        }
    }
}