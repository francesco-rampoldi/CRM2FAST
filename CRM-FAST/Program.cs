using CRM_FAST.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CRM_FAST
{
    class Program
    {
        /* This is example on how to query opportunity information from SalesForce.
         * We are using Enterprise WSDL for KONE org to get a strongly typed mapping
         * to the standard and custom objects we have in the system. 
         * 
         * The reference is in Web References/API. Source is located in project root
         * (salesforce-enterprise-31.xm)
         * 
         * API documentation and reference can be found here:
         * http://www.salesforce.com/us/developer/docs/api/
         */
        
        static void Main(string[] args)
        {
            Topgraf.LibManager.InitializeLibrary("root");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            Topgraf.LibManager.Logger.LogInfo(String.Format("****START**** {0} v. {1}", fvi.ProductName, fvi.ProductVersion));
            Topgraf.LibManager.Logger.LogInfo("Establishing connection to SalesForce...");

 
            CRM_FAST crm_fast = new CRM_FAST();
            crm_fast.Run();

            //Console.WriteLine("\nPress any key to exit");
            System.Threading.Thread.Sleep(3000);
            Topgraf.LibManager.Logger.LogInfo(String.Format("****STOP**** {0} v. {1}", fvi.ProductName, fvi.ProductVersion));
            Topgraf.LibManager.CloseUp();
        }
    }
}

