using Keys.Global;
using Keys.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys.Test
{
    class Sprint_xx
    {
        [TestFixture]
        [Category("Sprint_xx")]
        class Sprint_xx_property : Base
        {
            
            // Add a new user in the Account Managment
            [Test]
            public void Property_AddNewProperty()
            {
                // creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add New property");

                PropertyPage propertyObj = new PropertyPage();
                propertyObj.Navigateproperty();
                propertyObj.AddProperty();


            }

            

        }


    }
}
