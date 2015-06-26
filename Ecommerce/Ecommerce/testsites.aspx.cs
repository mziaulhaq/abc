using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Web.Administration;

namespace Ecommerce
{
    public partial class testsites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Test(1);
        }

        private void Test()
        {
            ServerManager IIS = new ServerManager();
            string str = string.Empty;
            foreach (Site site in IIS.Sites)
            {
               str = str +"<br>"+ String.Concat
                (
                    site.Name, " , ",
                    site.Id, " , ",
                    site.State, " , ",
                    site.Applications["/"].VirtualDirectories[0].PhysicalPath
                );
            }
            Response.Write(str);
        }

        private void Test(int a)
        {
            try
            {
                const string siteName = "theTestSiteForApp";
                const string applicationPoolName = "Ecommerce";
                const string ipAddress = "*";
                const string tcpPort = "81";
                const string hostHeader = "";
                long highestId = 1;

                using (var mgr = new ServerManager())
                {
                    Site site = mgr.Sites["siteName"];
                    if (site != null)
                        return; // Site bestaat al

                    ApplicationPool appPool = mgr.ApplicationPools[applicationPoolName];
                    if (appPool == null)
                        throw new Exception(String.Format("ApplicationPool:{0}does not exist.", applicationPoolName));

                    foreach (Site mysite in mgr.Sites)
                    {
                        if (mysite.Id > highestId)
                            highestId = mysite.Id;
                    }
                    highestId++;

                    site = mgr.Sites.CreateElement();
                    site.SetAttributeValue("name", siteName);
                    site.Id = highestId;
                    site.Bindings.Clear();

                    const string bind = ipAddress + ":"
                                        + tcpPort + ":"
                                        + hostHeader;

                    Binding binding = site.Bindings.CreateElement();
                    binding.Protocol = "http";
                    binding.BindingInformation = bind;
                    site.Bindings.Add(binding);
                    //site.Bindings.Add(bind, "http");

                    //Application app = site.Applications.CreateElement();
                    //app.Path = applicationPath;
                    //app.ApplicationPoolName = applicationPoolName;
                    //VirtualDirectory vdir = app.VirtualDirectories.CreateElement();
                    //vdir.Path = virtualDirectoryPath;
                    //vdir.PhysicalPath = virtualDirectoryPhysicalPath;
                    //app.VirtualDirectories.Add(vdir);
                    //site.Applications.Add(app);

                    //mgr.Sites.Add(site);
                    mgr.CommitChanges();
                }
            }
            catch (Exception ae)
            {
                Response.Write(ae.Message);
            }

        }
    }
}