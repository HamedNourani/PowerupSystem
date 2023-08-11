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

            // Sonic : 10
            // Mario : 10
            // ks = damage sonic
            // km = damage mario
            // ms = move sonic in x axis
            // mm = move mario in x axis
            // sps = add speed powerup to sonic
            // spm = add speed powerup to mario
            // shs = add shield powerup to sonic
            // shm = add shield powerup to mario
            // as = activate sonic powerup
            // am = activate mario powerup
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
            var sonic = GetPlayer("Sonic");
            var speedup = new Speedup(TimeSpan.FromSeconds(10f), new Vector2(0f, 0f));
            sonic.AddPowerup(speedup);
            Console.WriteLine("Speedup added to Sonic.");
        }
        
        private static void AddShieldPowerupToSonic()
        {
            var sonic = GetPlayer("Sonic");
            var shield = new Shield(TimeSpan.FromSeconds(10f), new Vector2(0f, 0f));
            sonic.AddPowerup(shield);
            Console.WriteLine("Shield added to Sonic.");
        }

        private static void ActivateSonicPowerup()
        {
            var sonic = GetPlayer("Sonic");
            var timer = new Timer();
            var powerupDurationThread = new Thread(() => PowerupDurationRoutine(sonic.Powerup, timer, sonic));
            powerupDurationThread.Start();
            sonic.ActivateCurrentPowerup();
            powerupDurationThread.Join();
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
            var speedup = new Speedup(TimeSpan.FromSeconds(10f), new Vector2(0f, 0f));
            mario.AddPowerup(speedup);
            Console.WriteLine("Speedup added to Mario.");
        }
        
        private static void AddShieldPowerupToMario()
        {
            var mario = GetPlayer("Mario");
            var shield = new Shield(TimeSpan.FromSeconds(10f), new Vector2(0f, 0f));
            mario.AddPowerup(shield);
            Console.WriteLine("Shield added to Mario.");
        }
        
        private static void ActivateMarioPowerup()
        {
            var mario = GetPlayer("Mario");
            var timer = new Timer();
            var powerupDurationThread = new Thread(() => PowerupDurationRoutine(mario.Powerup, timer, mario));
            powerupDurationThread.Start();
            mario.ActivateCurrentPowerup();
            powerupDurationThread.Join();
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
                    break;
                }
            }
        }
    }
}