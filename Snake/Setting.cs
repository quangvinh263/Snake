using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Settings
    {
        private static Settings instance;
        private Settings()
        {
            Width = 16;
            Height = 16;
            directions = "left";
        }
        public string TenTK { get; set; }
        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }

        public string GameMode { get; set; }
        public int Score { get; set; }

        public SoundPlayer soundHome = new SoundPlayer(Properties.Resources.soundHome);
        public SoundPlayer soundEat = new SoundPlayer(Properties.Resources.soundEat);
        public SoundPlayer soundHit = new SoundPlayer(Properties.Resources.soundHit);
        public SoundPlayer soundDie = new SoundPlayer(Properties.Resources.soundHome);
        public Image food = Properties.Resources.apple;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static string directions;
        
    }
}
