using System;
using System.Threading;
using System.Collections.Generic;

namespace PowerupSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var speedup = new Speedup(TimeSpan.FromSeconds(2), new Vector2(0, 0));
            var player1 = new Player("Sonic", 5, 100, speedup, new Vector2(0, 0));
            player1.ActivateCurrentPowerup();
            var speedupTimer = new Timer();
            SpeedupDurationRoutine(speedup, speedupTimer, player1);
            Console.WriteLine();
            
            var shield = new Shield(TimeSpan.FromSeconds(10), new Vector2(0, 0));
            var player2 = new Player("Mario", 3, 100, shield, new Vector2(0, 0));
            Console.WriteLine($"{player2.Name}'s health: {player2.Health}");
            var shieldTimer = new Timer();
            var shieldDurationThread = new Thread(() => ShieldDurationRoutine(shield, shieldTimer, player2));
            shieldDurationThread.Start();
            player2.ActivateCurrentPowerup();
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