using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class EmailTemplate
    {
       
        public string ServerURL;

        public EmailTemplate(string serverURL)
        {
            this.ServerURL = serverURL;
           

        }

        public string MakePage()
        {
            return @"" +       "<html> " +
                                    "<body style=\"background-color:#ff7f26;text-align:center;\">" + "<br><br>" +
                                    "<h1 style=\"color:#051a80;\">Welcome to FunDo Note Web API</h1> " +
                                    "<h2 style=\"color:#fff;\">Please find the Link and replace password and confirm password After click on Rest Button.</h2> " + "<br>" +
                                    "<a href=\"" + this.ServerURL + "\" target=\"_blank\" style=\"background-color: #f44336;color: white;padding: 14px 25px;text-align:center;text-decoration: none;display: inline-block;\">RESET PASSWORD</a>" +
                                      "<br><br>" +
                                      "<p style=\"color:black;\">©Copyright reserve by Pranav Waghmare</p>" +
                                    "</body> " +
                                "</html>";
        }
       
    }
}
