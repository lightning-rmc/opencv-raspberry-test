using System;
using OpenCvSharp;

namespace opencv_raspberry_test
{
    class Program
    {
        static void Main(string[] args)
        {
             using var src = Cv2.ImRead("Kamera_2.png");

            using (new Window("SubMat", src))
            {
                Cv2.WaitKey();
            }
        }
    }
}
