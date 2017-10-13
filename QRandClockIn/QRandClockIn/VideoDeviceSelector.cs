using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video.DirectShow;

namespace QRandClockIn
{
    public class VideoDeviceSelector
    {
        static string _DeviceName;
        static FilterInfoCollection _VideoFilter;

        public VideoDeviceSelector()
        {
            VideoDevices = new List<FilterInfo>();
            _VideoFilter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (_VideoFilter.Count > 0)
            {
                foreach (FilterInfo videoInfo in _VideoFilter)
                {
                    VideoDevices.Add(videoInfo);
                }//end foreach
            }//end if
        }//end constructor

        public List<FilterInfo> VideoDevices { get; set; }

        public string FirstVideoDevice
        {
            get
            {
                return VideoDevices[0].MonikerString;


            }//end get
        }//end method
    }
}
