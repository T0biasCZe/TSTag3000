using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace TSTag3000.UI.controls
{
    public class AnimationBox : PictureBox
    {
        List<Bitmap> frames;
        int currentFrame;
        public int msPerFrame { get; set; }
        Timer timer1;
        public AnimationBox()
        {
            frames = new List<Bitmap>();
            if (msPerFrame == 0) msPerFrame = 100;
            var path = "C:\\Users\\user\\source\\repos\\TSTag3000\\gfx\\loading";

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                frames.Add(new Bitmap(file));
            }

            timer1 = new Timer();
            timer1.Interval = msPerFrame;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= frames.Count) currentFrame = 0;
            Image = frames[currentFrame];
        }
    }
}
