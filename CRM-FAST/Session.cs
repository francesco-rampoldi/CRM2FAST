using CRM_FAST.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace CRM_FAST
{
    class Session :IDisposable
    {
        public LoginResult SessionInformation
        {
            get { return loginResult; }
        }
        public SforceService Service
        {
            get { return binding; }
        }

        /* Contains information on login details such as session id,
        * user information */ 
        private LoginResult loginResult = new LoginResult();
        // Contains set of methods exposed by SalesForce.com API
        private SforceService binding = new SforceService();

        public Session(string username, string password)
        {
            try
            {
                // Login callout
                loginResult = binding.login(username, password);
                binding.SessionHeaderValue = new SessionHeader();
                
                /* Here we pass results of the login call including the session ID
                 * to the SforceService so that when we invoke it to do work in
                 * SFDC, it can authenticate us. */
                binding.Url = loginResult.serverUrl;
                binding.SessionHeaderValue.sessionId = loginResult.sessionId;
            }
            catch(SoapException sEx)
            {
                Console.WriteLine(sEx.Message);
            }
        }


        public void Dispose()
        {
            if (binding != null)
            {
                binding.Dispose();
            }
        }
    }
}
