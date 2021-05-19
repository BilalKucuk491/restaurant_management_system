using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace restaurantt
{
    class cSound
    {
        public void playClickButtonSound()
        {
            SoundPlayer ses = new SoundPlayer(@"C:/Users/Administrator/Desktop/AslaSilme/Projects/Restaurant/restoran v1.2.8/restaurantt/restaurantt/bin/Debug/Sound/buttonVoice.wav");
            ses.Play();

        }
    }
}
