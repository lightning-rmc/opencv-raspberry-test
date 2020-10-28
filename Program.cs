using System;
using OpenCvSharp;

namespace opencv_raspberry_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //  using var src = Cv2.ImRead("Kamera_2.png");

            // using (new Window("SubMat", src))
            // {
            //     Cv2.WaitKey();
            // }

            using var capture = new VideoCapture("sample.mp4");
            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (var window = new Window("capture"))
            {
                // Frame image buffer
                var image = new Mat();

                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    capture.Read(image); // same as cvQueryFrame
                    if(image.Empty())
                        break;

                    window.ShowImage(image);
                    Cv2.WaitKey(sleepTime);
                } 
            }
        }
    }
}
