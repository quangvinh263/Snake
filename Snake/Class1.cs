using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Setting
    {
        public Image food;
        public int mapType;

        public string TK;
        public string MK;
        public string LV;
        public string EASY;
        public string MED;
        public string HARD;

        public SoundPlayer Menu;
        public SoundPlayer Eat;
        public SoundPlayer Music;
        public Setting()
        {
        }
    }
}
