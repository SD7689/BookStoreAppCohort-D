using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookStore_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            receiver.Receive();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                //  WebHost.CreateDefaultBuilder(args)
                //  .UseKestrel()
                //.UseIISIntegration()
                //      .UseStartup<Startup>()
                //      .Build();
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
