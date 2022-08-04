#pragma warning disable CA1416 // Validate platform compatibility
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using BMDSwitcherAPI;
using System.Drawing;
using System.Drawing.Imaging;

namespace AtemTest
{
    public class Program
    {
        public static long GetInputId(IBMDSwitcherInput input)
        {
            input.GetInputId(out var id);
            return id;
        }

        static void Main(string[] args)
        {
            //Test();


            var bmp = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

            var g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            var format = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var rectf = RectangleF.FromLTRB(0, 0, 1920, 1080);

            g.DrawString("yourText", new Font("Tahoma", 80), Brushes.White, rectf);
            g.Flush();

            bmp.Save("test.png", ImageFormat.Png);
        }

        static void Test()
        {
            IBMDSwitcherDiscovery discovery = new CBMDSwitcherDiscovery();

            var ipAddr = "192.168.0.100";

            discovery.ConnectTo(ipAddr, out var switcher, out var failureReason);
            Console.WriteLine("Connected to switcher");

            var atem = new AtemSwitcher(switcher);

            var me0 = atem.MixEffectBlocks.First();
            var me0TransitionParams = me0 as IBMDSwitcherTransitionParameters;
            var me0WipeTransitionParams = me0 as IBMDSwitcherTransitionWipeParameters;
            var input3 = atem.SwitcherInputs.Where((i, ret) =>
            {
                i.GetPortType(out _BMDSwitcherPortType type);
                return type == _BMDSwitcherPortType.bmdSwitcherPortTypeExternal;
            }).ElementAt(3);

            Console.WriteLine("Setting preview input");
            me0.SetPreviewInput(GetInputId(input3));

            Console.WriteLine("Setting next transition selection");
            me0TransitionParams?.SetNextTransitionSelection(_BMDSwitcherTransitionSelection.bmdSwitcherTransitionSelectionBackground);

            Console.WriteLine("Setting next transition style");
            me0TransitionParams?.SetNextTransitionStyle(_BMDSwitcherTransitionStyle.bmdSwitcherTransitionStyleWipe);

            Console.WriteLine("Setting transition style");
            me0WipeTransitionParams?.SetPattern(_BMDSwitcherPatternStyle.bmdSwitcherPatternStyleRectangleIris);

            Console.WriteLine("Setting transition rate");
            me0WipeTransitionParams?.SetRate(60);

            Console.WriteLine("Performing auto transition");
            me0.PerformAutoTransition();
            Thread.Sleep(2000);
            Thread.Sleep(1000);
            me0.PerformAutoTransition();
        }

        internal class AtemSwitcher
        {
            private readonly IBMDSwitcher switcher;
            public AtemSwitcher(IBMDSwitcher switcher)
            {
                this.switcher = switcher;
            }

            public IEnumerable<IBMDSwitcherMixEffectBlock> MixEffectBlocks
            {
                get
                {
                    switcher.CreateIterator(typeof(IBMDSwitcherMixEffectBlockIterator).GUID, out var meIteratorPtr);
                    IBMDSwitcherMixEffectBlockIterator meIterator = (IBMDSwitcherMixEffectBlockIterator)Marshal.GetObjectForIUnknown(meIteratorPtr);
                    if (meIterator == null) yield break;

                    while (true)
                    {
                        meIterator.Next(out var me);

                        if (me != null) yield return me;
                        else yield break;
                    }
                }
            }

            public IEnumerable<IBMDSwitcherInput> SwitcherInputs
            {
                get
                {
                    switcher.CreateIterator(typeof(IBMDSwitcherInputIterator).GUID, out var inputIteratorPtr);
                    IBMDSwitcherInputIterator inputIterator = (IBMDSwitcherInputIterator)Marshal.GetObjectForIUnknown(inputIteratorPtr);
                    if (inputIterator == null)
                        yield break;

                    while (true)
                    {
                        inputIterator.Next(out var input);

                        if (input != null) yield return input;
                        else yield break;

                    }
                }
            }
        }
    }
}


