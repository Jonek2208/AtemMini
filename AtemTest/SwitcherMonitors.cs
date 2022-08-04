using System;
using System.Text;
using BMDSwitcherAPI;


namespace AtemTest
{
    public delegate void SwitcherEventHandler(object sender, object? args);

    public class SwitcherMonitor : IBMDSwitcherCallback
    {
        public event SwitcherEventHandler? SwitcherDisconnected;

        public void Notify(_BMDSwitcherEventType eventType, _BMDSwitcherVideoMode coreVideoMode)
        {
            if (eventType == _BMDSwitcherEventType.bmdSwitcherEventTypeDisconnected)
            {
                SwitcherDisconnected?.Invoke(this, null);
            }
        }
    }

    public class MixEffectBlockMonitor : IBMDSwitcherMixEffectBlockCallback
    {
        public event SwitcherEventHandler? ProgramInputChanged;
        public event SwitcherEventHandler? PreviewInputChanged;
        public event SwitcherEventHandler? TransitionFramesRemainingChanged;
        public event SwitcherEventHandler? TransitionPositionChanged;
        public event SwitcherEventHandler? InTransitionChanged;

        public MixEffectBlockMonitor()
        {
        }


        public void Notify(_BMDSwitcherMixEffectBlockEventType eventType)
        {
            switch (eventType)
            {
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeProgramInputChanged:
                    ProgramInputChanged?.Invoke(this, null);
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypePreviewInputChanged:
                    PreviewInputChanged?.Invoke(this, null);
                    break;
                case _BMDSwitcherMixEffectBlockEventType
                    .bmdSwitcherMixEffectBlockEventTypeTransitionFramesRemainingChanged:
                    TransitionFramesRemainingChanged?.Invoke(this, null);
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeTransitionPositionChanged:
                    TransitionPositionChanged?.Invoke(this, null);
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeInTransitionChanged:
                    InTransitionChanged?.Invoke(this, null);
                    break;
                    
            }
        }
    }

    public class InputMonitor : IBMDSwitcherInputCallback
    {
        public event SwitcherEventHandler? LongNameChanged;

        private readonly IBMDSwitcherInput _input;

        public InputMonitor(IBMDSwitcherInput input)
        {
            _input = input;
        }

        public IBMDSwitcherInput Input => _input;

        void IBMDSwitcherInputCallback.Notify(_BMDSwitcherInputEventType eventType)
        {
            switch (eventType)
            {
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeLongNameChanged:
                    LongNameChanged?.Invoke(this, null);
                    break;
            }
        }
    }

    public class StillMonitor : IBMDSwitcherStillsCallback
    {
        public void Notify(_BMDSwitcherMediaPoolEventType eventType, IBMDSwitcherFrame frame, int index)
        {
            switch (eventType)
            {
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeValidChanged:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeNameChanged:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeHashChanged:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeAudioValidChanged:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeAudioNameChanged:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeAudioHashChanged:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeLockBusy:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeLockIdle:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeTransferCompleted:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeTransferCancelled:
                    break;
                case _BMDSwitcherMediaPoolEventType.bmdSwitcherMediaPoolEventTypeTransferFailed:
                    break;
            }
        }
    }

    public class ClipMonitor : IBMDSwitcherClipCallback
    {
        public void Notify(_BMDSwitcherMediaPoolEventType eventType, IBMDSwitcherFrame frame, int frameIndex, IBMDSwitcherAudio audio, int clipIndex)
        {
            switch(eventType)
            {

            }
        }
    }

    public class MediaPlayerMonitor : IBMDSwitcherMediaPlayerCallback
    {
        public event SwitcherEventHandler? SourceChanged;
        public event SwitcherEventHandler? PlayingChanged;
        public event SwitcherEventHandler? LoopChanged;
        public event SwitcherEventHandler? AtBeginningChanged;
        public event SwitcherEventHandler? ClipFrameChanged;


        private readonly IBMDSwitcherMediaPlayer _mediaPlayer;
        public MediaPlayerMonitor(IBMDSwitcherMediaPlayer mediaPlayer)
        {
            _mediaPlayer = mediaPlayer;
        }
        void IBMDSwitcherMediaPlayerCallback.SourceChanged()
        {
            SourceChanged?.Invoke(this, null);
        }

        void IBMDSwitcherMediaPlayerCallback.PlayingChanged()
        {
            PlayingChanged?.Invoke(this, null);
        }

        void IBMDSwitcherMediaPlayerCallback.LoopChanged()
        {
            LoopChanged?.Invoke(this, null);
        }

        void IBMDSwitcherMediaPlayerCallback.AtBeginningChanged()
        {
            AtBeginningChanged?.Invoke(this, null);
        }

        void IBMDSwitcherMediaPlayerCallback.ClipFrameChanged()
        {
            ClipFrameChanged?.Invoke(this, null);
        }
    }
}