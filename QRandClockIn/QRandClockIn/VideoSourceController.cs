using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace QRandClockIn
{
    public class VideoSourceController : IDisposable
    {
        public event Action<string> QRCodeReaderHandler;

        public event Action<System.Drawing.Bitmap> FrameProcessHandler;

        public event Action CameraClosingHandler;

        public event Action<string> ProcessFrameErrorHandler;

        private AForge.Video.IVideoSource _VideoSource;

        private VideoCaptureDevice _VideoDevice;

        private static object _lockObject;

        public VideoSourceController()
            : this(new VideoDeviceSelector().FirstVideoDevice)
        {
        }//end constructor

        public VideoSourceController(string moniker)
        {
            _lockObject = new object();

            // Create the video Capture device instance
            _VideoDevice = new VideoCaptureDevice(moniker);

            _VideoSource = new AsyncVideoSource(_VideoDevice, true);

            _VideoSource.NewFrame += _VideoSource_NewFrame;
            _VideoSource.PlayingFinished += _VideoSource_PlayingFinished;
            _VideoSource.VideoSourceError += _VideoSource_VideoSourceError;

        }//end method

        // Starts the video
        public void StartVideo()
        {
            if (!_VideoSource.IsRunning)
                _VideoSource.Start();
        }//end method

        // Stops the video
        public void CloseVideo()
        {
            _VideoSource.SignalToStop();

            // wait few seconds until camera stops
            for (int i = 0; (i < 50) && (_VideoSource.IsRunning); i++)
            {
                System.Threading.Thread.Sleep(100);
            }//end for

            if (_VideoSource.IsRunning)
                _VideoSource.Stop();
        }//end method

        public void Dispose()
        {
            if (CameraClosingHandler != null)
                CameraClosingHandler();
            CloseVideo();
        }//end method

        private void _VideoSource_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            if (ProcessFrameErrorHandler != null)
                ProcessFrameErrorHandler(eventArgs.Description);
        }//end method

        // Event Fired when a new frame is obtained from the web cam
        private void _VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            System.Drawing.Bitmap frame = eventArgs.Frame;

            lock (_lockObject)
            {

                if (FrameProcessHandler != null)
                {
                    FrameProcessHandler(frame);
                }//end if

                IBarcodeReader reader = new BarcodeReader();

                var result = reader.Decode(frame);

                if (result != null && result.BarcodeFormat.ToString() != string.Empty)
                {

                    if (QRCodeReaderHandler != null)
                    {
                        QRCodeReaderHandler(result.Text);
                    }//end if
                }//end if
            }//end lock
        }//end method

        // Event fired when capuring is finished. Occurrs before a camera shuts down
        private void _VideoSource_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {

        }//end method
    }
}
