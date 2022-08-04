using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BMDSwitcherAPI;

namespace AtemTest2
{
    public class MediaPlayerCallback : IBMDSwitcherMediaPlayerCallback
    {
        public void SourceChanged()
        {
            throw new NotImplementedException();
        }

        public void PlayingChanged()
        {
            throw new NotImplementedException();
        }

        public void LoopChanged()
        {
            throw new NotImplementedException();
        }

        public void AtBeginningChanged()
        {
            throw new NotImplementedException();
        }

        public void ClipFrameChanged()
        {
            throw new NotImplementedException();
        }
    }

    public class MediaPlayerMonitor
    {
        private readonly MediaPlayerCallback _callback;
        private IBMDSwitcherMediaPlayer? _mediaPlayer;
        public MediaPlayerMonitor()
        {
            _callback = new MediaPlayerCallback();
        }

        public void SetMediaPlayer(IBMDSwitcherMediaPlayer? mediaPlayer)
        { 
            if(_mediaPlayer != null)
            {
                _mediaPlayer.RemoveCallback(_callback);
            }

            _mediaPlayer = mediaPlayer;

            if (_mediaPlayer != null)
            {
                _mediaPlayer.AddCallback(_callback);

                Flush();
            }
        }
        public void Flush()
        {
            _callback.SourceChanged();
            _callback.PlayingChanged();
            _callback.LoopChanged();
            _callback.AtBeginningChanged();
        }

    }

    public class StillsCallback
    { 
    }

    public class StillsMonitor
    {
        private IBMDSwitcherStillsCallback callback;
        public StillsMonitor()
        {

        }

    }


    public class ClipCallback : IBMDSwitcherClipCallback
    {
        public void Notify(_BMDSwitcherMediaPoolEventType eventType, IBMDSwitcherFrame frame, int frameIndex, IBMDSwitcherAudio audio, int clipIndex)
        {
            throw new NotImplementedException();
        }
    }

    public class ClipMonitor
    {
        private IBMDSwitcherClipCallback callback;
        public ClipMonitor()
        {

        }


        public IBMDSwitcherClip Clip { get; set; }

        public void Flush()
        {

        }
    }

    internal class LockCallback
    {
    }
}
