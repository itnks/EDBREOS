using System;
using System.IO;
using System.Linq;
using FileHelpers;
using EDBREOS.Models;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using CsvHelper;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EDBREOS.Utilities
{
    public class DataFeeder
    {

        public readonly Contexts _context;

        public DataFeeder(Contexts context)
        {
            _context = context;
        }
        //public static Contexts db = new Contexts();

        public static void ReadFromFile(string FileName, string ProjectId, IServiceProvider serviceProvider)
        {
            List<string> fileNames = new List<string>
            {
                FileName
            };


            foreach (string _fileName in fileNames)
            {
                using (var reader = new StreamReader(@"MSR2019/"+_fileName))
                using (var csv = new CsvHelper.CsvReader(reader))
                {

                    var _d = csv.GetRecords<dynamic>();
                    using (var context = new Contexts(
    serviceProvider.GetRequiredService<
        DbContextOptions<Contexts>>()))
                    {
                        foreach (var _s in _d)
                        {
                            Project _p = new Project();
                            _p.ProjectAdditionalDetails = new List<ProjectAdditionalDetails>();
                            _p.GId = Guid.NewGuid();
                            _p.Project_Id = Guid.Parse(ProjectId);
                            foreach (var _ss in _s)
                            {
                                //id    Summary Depends.on  Duplicates  Modified    Product Version Reported    Status  Blocks  Commit_ID   description author  files   created_at
                                if (_ss.Key == "id")
                                {
                                    if (_ss.Value.Length > 0)
                                    {
                                        _p.Id = int.Parse(_ss.Value);
                                    }
                                }
                                else if (_ss.Key == "Summary")
                                {
                                    _p.Summary = _ss.Value;
                                }
                                else if (_ss.Key == "Depends.on")
                                {
                                    _p.DependsOn = _ss.Value;
                                }
                                else if (_ss.Key == "Duplicates")
                                {
                                    _p.Duplicates = _ss.Value;
                                }
                                else if (_ss.Key == "Modified")
                                {
                                    if (_ss.Value.Length > 5)
                                    {
                                        string _dateS = _ss.Value.Substring(0, 16) + ":00";
                                        _p.Modified = DateTime.Parse(_dateS);
                                    }
                                }
                                else if (_ss.Key == "Product")
                                {
                                    _p.Product = _ss.Value;
                                }
                                else if (_ss.Key == "Version")
                                {
                                    _p.Version = _ss.Value;
                                }
                                else if (_ss.Key == "Reported")
                                {
                                    if (_ss.Value.Length > 5)
                                    {
                                        string _dateR = _ss.Value.Substring(0, 16) + ":00";
                                        _p.Reported = DateTime.Parse(_dateR);
                                    }
                                }
                                else if (_ss.Key == "Status")
                                {
                                    _p.Status = _ss.Value;
                                }
                                else if (_ss.Key == "Blocks")
                                {
                                    _p.Blocks = _ss.Value;
                                }
                                else if (_ss.Key == "Commit_ID")
                                {
                                    _p.Commit_ID = _ss.Value;
                                }
                                else if (_ss.Key == "description")
                                {
                                    _p.Description = _ss.Value;
                                }
                                else if (_ss.Key == "author")
                                {
                                    _p.Author = _ss.Value;
                                }
                                else if (_ss.Key == "files")
                                {
                                    _p.Files = _ss.Value;
                                }
                                else if (_ss.Key == "created_at")
                                {
                                    if (_ss.Value.Length > 5)
                                    {
                                        string _dateC = _ss.Value.Substring(0, 16) + ":00";
                                        _p.CreatedAt = DateTime.Parse(_dateC);
                                    }
                                }
                                else
                                {
                                    if (_ss.Value != "NA")
                                    {
                                        ProjectAdditionalDetails _pad = new ProjectAdditionalDetails
                                        {
                                            GId = Guid.NewGuid(),
                                            Key = _ss.Key,
                                            Value = _ss.Value,
                                            Project_Id = _p.GId
                                        };
                                        _pad.Project_Id = _p.GId;
                                        _p.ProjectAdditionalDetails.Add(_pad);
                                    }
                                }
                            }
                            context.Add(_p);
                            Console.WriteLine(_p);
                        }
                        context.SaveChanges();
                    }
                }
            }

        }

        public static void WriteProjects(IServiceProvider serviceProvider)
        {
            using (var context = new Contexts(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Contexts>>()))
            {
                //throw new NotImplementedException();
                IDictionary<string, string> Projects = new Dictionary<string, string>
            {
                { "Mozilla", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Firefox_Logo%2C_2017.svg/1200px-Firefox_Logo%2C_2017.svg.png" },
                { "K3b", "https://1088045785.rsc.cdn77.org/img/logo.plain.png" },
                { "Kate", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Sc-apps-kate.svg/128px-Sc-apps-kate.svg.png" },
                { "Apache Ant", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Apache-Ant-logo.svg/440px-Apache-Ant-logo.svg.png" },
                { "AspectJ", "https://www.eclipse.org/aspectj/doc/next/progguide/figureUML.gif" },
                { "BIRT Project", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Birt-purple-logo.png/113px-Birt-purple-logo.png" },
                { "Eclipse Platform", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/Eclipse-Luna-Logo.svg/547px-Eclipse-Luna-Logo.svg.png" },
                { "JDT", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/Eclipse-Luna-Logo.svg/547px-Eclipse-Luna-Logo.svg.png" },
                { "Standard Widget Toolkit", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/EclipseScreenshot.png/600px-EclipseScreenshot.png" },
                { "Apache Tomcat", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Tomcat-logo.svg/192px-Tomcat-logo.svg.png" },
                { "UI", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d0/Eclipse-Luna-Logo.svg/547px-Eclipse-Luna-Logo.svg.png" }
            };

                foreach (var _p in Projects)
                {
                    Projects _pro = new Projects
                    {
                        Description = "",
                        Logo = _p.Value,
                        Name = _p.Key,
                        Id = Guid.NewGuid()
                    };
                    context.Add(_pro);
                }
                context.SaveChanges();
            }
        }

        public static void FeedIn()
        {
            
        }
    }
}
