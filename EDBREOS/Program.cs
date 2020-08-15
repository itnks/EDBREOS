using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EDBREOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //EDBREOS.Utilities.DataFeeder.ReadFromFile();
            //fileNames.Add("Desktop_Mozilla_FullBugs_with_Commits.csv");
            //fileNames.Add("final_bug_WithCommit_K3B.csv");
            //fileNames.Add("final_bug_WithCommit_Kate.csv");
            //fileNames.Add("final_bug_WithCommitAnt.csv");
            //fileNames.Add("final_bugWithCommits_AspectJ.csv");
            //fileNames.Add("final_bugWithCommits_Birt.csv");
            //fileNames.Add("final_bugWithCommits_EclipsePlatform.csv");
            //fileNames.Add("final_bugWithCommits_JDT.csv");
            //fileNames.Add("final_bugWithCommits_SWT.csv");
            //fileNames.Add("final_bugWithCommits_Tomcat.csv");
            //fileNames.Add("final_bugWithCommits_UI.csv");
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bug_WithCommit_K3B.csv", "51b4b83e-7f29-4bce-9f3c-e4fd21e48cc9", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bug_WithCommit_Kate.csv", "cbfc520b-cea7-4abc-b4e2-a751414a0719", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_AspectJ.csv", "e76cec1d-ada7-460d-bc94-3b860bdd2182", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bug_WithCommitAnt.csv", "82e2c64c-6aa9-44bd-9534-8b1d29572cc6", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_Birt.csv", "6a4674a7-ac95-4876-ac19-fbdfd93ee640", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_EclipsePlatform.csv", "a966eee5-1525-4ec8-9c15-69887d156db4", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_JDT.csv", "9ed7dd96-ecd8-4765-a6af-ee7d6dc207dd", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_SWT.csv", "05ab36eb-b8e3-420b-accc-90708bf04af0", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_Tomcat.csv", "8bd42888-5b57-4335-8b89-ce327cf7605e", services);
                //EDBREOS.Utilities.DataFeeder.ReadFromFile("final_bugWithCommits_UI.csv", "91424ec2-fdf9-4f53-bef9-922699e53911", services);
                //EDBREOS.Utilities.DataFeeder.WriteProjects(services);
            }
           
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
