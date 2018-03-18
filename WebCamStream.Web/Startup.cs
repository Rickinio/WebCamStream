using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OpenCvSharp;

namespace WebCamStream.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path.ToString().Equals("/sse"))
            //    {
            //        var response = context.Response;
            //        response.Headers.Add("Content-Type", "text/event-stream");

            //        VideoCapture capture = new VideoCapture(0);

            //        //int sleepTime = (int)Math.Round(1000 / capture.Fps);

            //        //using (Window window = new Window("capture"))
            //        //{
            //        using (Mat image = new Mat()) // Frame image buffer
            //        {
            //            // When the movie playback reaches end, Mat.data becomes NULL.
            //            while (true)
            //            {
            //                capture.Read(image); // same as cvQueryFrame
            //                if (image.Empty())
            //                    break;

            //                // WriteAsync requires `using Microsoft.AspNetCore.Http`
            //                var base64img = Convert.ToBase64String(image.ToBytes());
            //                response.WriteAsync($"data: {base64img}").Wait();

            //                response.Body.Flush();
            //                await Task.Delay(5 * 1000);
            //            }
            //        }
            //        //}

            //        //for (var i = 0; true; ++i)
            //        //{
            //        //    WriteAsync requires `using Microsoft.AspNetCore.Http`
            //        //    await response
            //        //        .WriteAsync($"data: Middleware {i} at {DateTime.Now}\r\r");

            //        //    response.Body.Flush();
            //        //    await Task.Delay(5 * 1000);
            //        //}
            //    }

            //    await next.Invoke();
            //});

            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
