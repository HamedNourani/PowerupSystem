using System;
using System.Threading;
using System.Collections.Generic;

namespace PowerupSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var speedup = new Speedup(TimeSpan.FromSeconds(5), new Vector2(0f, 0f));
            var player1 = new Player("Sonic", 10, 100);
            player1.SetPosition(new Vector2(0f, 0f));
            player1.AddPowerup(speedup);
            player1.ActivateCurrentPowerup();
            var speedupTimer = new Timer();
            SpeedupDurationRoutine(speedup, speedupTimer, player1);
            Console.WriteLine();
            Console.ReadLine();

            // var shield = new Shield(TimeSpan.FromSeconds(10), new Vector2(0, 0));
            // var player2 = new Player("Mario", 3, 100);
            // Console.WriteLine($"{player2.Name}'s health: {player2.Health}");
            // var shieldTimer = new Timer();
            // var shieldDurationThread = new Thread(() => ShieldDurationRoutine(shield, shieldTimer, player2));
            // shieldDurationThread.Start();
            // player2.ActivateCurrentPowerup();

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
        
        public static void ShieldDurationRoutine(Shield shield, Timer shieldTimer, Player player)
        {
            while (true)
            {
                if (DateTime.Now - shieldTimer.StartTime >= shield.Duration)
                {
                    player.DeactivateCurrentPowerup();
                    break;
                }
            }
        }
        
        public static void SpeedupDurationRoutine(Speedup speedup, Timer speddupTimer, Player player)
        {
            while (true)
            {
                if (DateTime.Now - speddupTimer.StartTime >= speedup.Duration)
                {
                    player.DeactivateCurrentPowerup();
                    break;
                }
            }
        }
    }
}