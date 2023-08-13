﻿using System;
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

            if (sonic != null)
            {
                if (sonic.Powerup != null)
                {
                    sonic.ActivateCurrentPowerup();
                
                    var timer = new Timer();
                    var powerupDurationThread = new Thread(() => PowerupDurationRoutine(sonic.Powerup, timer, sonic));
                    powerupDurationThread.Start();

                    if (sonic.Powerup is Speedup)
                    {
                        Console.WriteLine($"Speedup is active for Sonic");
                        Console.WriteLine($"Current speed of Sonic is: {sonic.Speed}");
                    }
                    else if (sonic.Powerup is Shield)
                    {
                        Console.WriteLine($"Shield is active for Sonic.");
                        Console.WriteLine($"Sonic's health: {sonic.Health}");
                    }
                }
                else
                {
                    Console.WriteLine("No powerup is added to Sonic! Add one.");
                }
            }
            else
            {
                Console.WriteLine("Sonic is not instantiated! Instantiate it.");
            }
        }
        
        private static void InstantiateMario()
        {
            var mario = new Player("Mario", 5f, 100);
            mario.SetPosition(new Vector2(0f, 0f));
            Console.WriteLine("Mario instantiated.");
        }
        
        private static void AddSpeedPowerupToMario()
        {
            var mario = GetPlayer("Mario");

            if (mario != null)
            {
                var speedup = new Speedup(TimeSpan.FromSeconds(30f), new Vector2(0f, 0f));
                mario.AddPowerup(speedup);
                Console.WriteLine("Speedup added to Mario.");
            }
            else
            {
                Console.WriteLine("Mario is not instantiated! Instantiate it.");
            }
        }
        
        private static void AddShieldPowerupToMario()
        {
            var mario = GetPlayer("Mario");

            if (mario != null)
            {
                var shield = new Shield(TimeSpan.FromSeconds(30f), new Vector2(0f, 0f));
                mario.AddPowerup(shield);
                Console.WriteLine("Shield added to Mario.");
            }
            else
            {
                Console.WriteLine("Mario is not instantiated! Instantiate it.");
            }
        }
        
        private static void ActivateMarioPowerup()
        {
            var mario = GetPlayer("Mario");

            if (mario != null)
            {
                if (mario.Powerup != null)
                {
                    mario.ActivateCurrentPowerup();
                
                    var timer = new Timer();
                    var powerupDurationThread = new Thread(() => PowerupDurationRoutine(mario.Powerup, timer, mario));
                    powerupDurationThread.Start();

                    if (mario.Powerup is Speedup)
                    {
                        Console.WriteLine($"Speedup is active for Mario");
                        Console.WriteLine($"Current speed of Mario is: {mario.Speed}");
                    }
                    else if (mario.Powerup is Shield)
                    {
                        Console.WriteLine($"Shield is active for Mario.");
                        Console.WriteLine($"Mario's health: {mario.Health}");
                    }
                }
                else
                {
                    Console.WriteLine("No powerup is added to Mario! Add one.");
                }
            }
            else
            {
                Console.WriteLine("Mario is not instantiated! Instantiate it.");
            }
        }

        private static void MoveSonic()
        {
            try
            {
                var sonic = GetPlayer("Sonic");
            
                if (sonic.Powerup != null && sonic.Powerup is Speedup && sonic.Powerup.IsActive)
                {
                    sonic.Position.X += sonic.Speed;
                    Console.WriteLine($"Current X position of Sonic is: {sonic.Position.X}");
                }
                else
                {
                    sonic.Position.X += sonic.Speed;
                    Console.WriteLine($"Current X position of Sonic is: {sonic.Position.X}");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Sonic is not instantiated! Instantiate it.");
            }
        }
        
        private static void MoveMario()
        {
            try
            {
                var mario = GetPlayer("Mario");
            
                if (mario.Powerup != null && mario.Powerup is Speedup && mario.Powerup.IsActive)
                {
                    mario.Position.X += mario.Speed;
                    Console.WriteLine($"Current X position of Mario is: {mario.Position.X}");
                }
                else
                {
                    mario.Position.X += mario.Speed;
                    Console.WriteLine($"Current X position of Mario is: {mario.Position.X}");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Mario is not instantiated! Instantiate it.");
            }
        }

        private static void DamageSonic()
        {
            try
            {
                var sonic = GetPlayer("Sonic");
            
                if (sonic.Powerup != null && sonic.Powerup is Shield && sonic.Powerup.IsActive)
                {
                    sonic.Health -= sonic.Damage;
                    Console.WriteLine($"Current health of Sonic is: {sonic.Health}");
                }
                else
                {
                    sonic.Health -= sonic.Damage;
                    Console.WriteLine($"Current health of Sonic is: {sonic.Health}");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Sonic is not instantiated! Instantiate it.");
            }
        }
        
        private static void DamageMario()
        {
            try
            {
                var mario = GetPlayer("Mario");
            
                if (mario.Powerup != null && mario.Powerup is Shield && mario.Powerup.IsActive)
                {
                    mario.Health -= mario.Damage;
                    Console.WriteLine($"Current health of Mario is: {mario.Health}");
                }
                else
                {
                    mario.Health -= mario.Damage;
                    Console.WriteLine($"Current health of Mario is: {mario.Health}");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Mario is not instantiated! Instantiate it.");
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
                        Console.WriteLine($"Speedup is inactive for {player.Name}.");
                        Console.WriteLine($"Current speed of {player.Name} is: {player.Speed}");
                    }
                    else if (powerup is Shield)
                    {
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