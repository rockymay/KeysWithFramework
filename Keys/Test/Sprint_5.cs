using Keys.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys.Test
{
    class Sprint_1
    {
        [TestFixture]
        [Category("Sprint_5")]
        class Sprint_1_Administration : Base
        {

            // Add a new user in the Account Managment
            [Test]
            public void Register_CreateNewUser()
            {
                // creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Register New Customer");
                Register obj = new Register();
                obj.register();

            }
           
            
        }


    }
}
