using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecretSanta.Data;

namespace SecretSanta.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // //database testing stuff.
            // using (var dbcontext = new DbContext())
            // {
            //     //     // dbcontext.Users.Add(new User() {UserId = 9, FirstName = "Jef", LastName = "g"});
            // //     // dbcontext.Groups.Add(new Group() {GroupId = 42, Name = "Mikes Pizza"});
            // //     // dbcontext.SaveChanges();
            // //     foreach (var user in dbcontext.Users.ToList())
            // //     {
            // //         Console.WriteLine($"First= {user.FirstName}, Last = {user.LastName}");
            // //     }
            // //
            // //     foreach (var group in dbcontext.Groups.ToList())
            // //     {
            // //         Console.WriteLine($"GroupId= {group.GroupId}, GroupName  = {group.Name}"); 
            // //         
            // //     }
            // //     Console.ReadLine();
            // // }
            //
            
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
        
    }
}
