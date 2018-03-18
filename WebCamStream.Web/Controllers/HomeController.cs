using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;

namespace WebCamStream.Web.Controllers
{
    public class HomeController : Controller
    {
        private static VideoCapture capture;

        static HomeController()
        {
            capture = new VideoCapture(0);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImage()
        {
            using (Mat image = new Mat()) // Frame image buffer
            {
                capture.Read(image);
                return File(image.ToBytes(), "image/png");
            }
        }
    }
}