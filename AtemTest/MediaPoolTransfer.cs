using BMDSwitcherAPI;

namespace AtemTest
{
    public class MediaPoolTransfer 
    {
        protected MediaPoolTransfer(IBMDSwitcher switcher, IBMDSwitcherMediaPool mediaPool) 
        { 
            
        }

        IBMDSwitcherFrame LoadFrame(string filePath)
        {
            IBMDSwitcherFrame frame;
            Switcher.GetVideoMode(out var videoMode);
            int width, height;

            switch(videoMode)
            {
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode625i50PAL:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode625i50Anamorphic:
                    width = 720;
                    height = 576;
                    break;
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode525i5994NTSC:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode525i5994Anamorphic:
                    width = 720;
                    height = 486;
                    break;
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode720p50:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode720p5994:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode720p60:
                    width = 1280;
                    height = 720;
                    break;
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080i50:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080i5994:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080i60:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p2398:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p24:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p25:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p2997:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p30:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p50:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p5994:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode1080p60:
                    width = 1920;
                    height = 1080;
                    break;
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode4KHDp2398:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode4KHDp24:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode4KHDp25:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode4KHDp2997:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode4KHDp50:
                case _BMDSwitcherVideoMode.bmdSwitcherVideoMode4KHDp5994:
                    width = 3840;
                    height = 2160;
                    break;
            }
        }

        string FileNameFromFilePath(string filePath)
        { 

        }

        public IBMDSwitcher Switcher { get; set; }

        public IBMDSwitcherMediaPool MediaPool { get; set; }
    }

    public class StillTransfer : MediaPoolTransfer
    {
        public StillTransfer(IBMDSwitcher switcher, IBMDSwitcherMediaPool mediaPool, IBMDSwitcherStills stills)
        {
        }

        public bool Upload(int stillIndex, string filePath)
        { 

        }

        public OnLockObtained()
        { 

        }

        public OnTransferEnded(bool success)
        {

        }

        private IBMDSwitcherStills Stills { get; set; }
        LockCallback 
    }
}