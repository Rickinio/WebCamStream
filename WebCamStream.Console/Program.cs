namespace WebCamStream.Console
{
    using OpenCvSharp;
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            VideoCapture capture = new VideoCapture(0);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (Window window = new Window("capture"))
            {
                using (Mat image = new Mat()) // Frame image buffer
                {
                    // When the movie playback reaches end, Mat.data becomes NULL.
                    while (true)
                    {
                        capture.Read(image); // same as cvQueryFrame
                        if (image.Empty())
                            break;

                        window.ShowImage(image);
                        Cv2.WaitKey(5);
                    }
                }
            }
        }
    }
}
