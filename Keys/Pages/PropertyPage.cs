using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace Keys.Pages
{
    class PropertyPage
    {

        public PropertyPage()  //Initiate
        {

            PageFactory.InitElements(Driver.driver, this);

        }
        #region  Construct Element
        [FindsBy(How = How.Id, Using = "add-new-property")]
        public IWebElement addPropertyBtn { get; set; }
        [FindsBy(How = How.Id, Using = "//*[@id='propList']/tr")]
        public IWebElement properLists { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[1]/div/div/input")]
        public IWebElement propertyName { get; set; }
        [FindsBy(How = How.Id, Using = "jobDescription")]
        public IWebElement description { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[3]/div/div/select")]
        public IWebElement propertyType { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[4]/div[2]/div/div/select")]
        public IWebElement propertyType2 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[5]/div/div/input")]
        public IWebElement targetRent { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[6]/div/select")]
        public IWebElement rentType { get; set; }
        [FindsBy(How = How.Id, Using = "autocomplete0")]
        public IWebElement addressAutoComplete { get; set; }
        [FindsBy(How = How.Id, Using = "street_number")]
        public IWebElement streetNumber { get; set; }
        [FindsBy(How = How.Id, Using = "route")]
        public IWebElement streetName { get; set; }
        [FindsBy(How = How.Id, Using = "postal_code")]
        public IWebElement postalCode { get; set; }
        [FindsBy(How = How.Id, Using = "locality")]
        public IWebElement city { get; set; }
        [FindsBy(How = How.Id, Using = "sublocality_level_1")]
        public IWebElement suburb { get; set; }
        //*[@id="propertyDetails"]
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[2]/div[2]/div/div[1]/div/input")]
        public IWebElement yearBuilt { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[3]/div/div[6]/div/input")]
        public IWebElement parkingSpace { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[1]/div/input")]
        public IWebElement purchasePrice { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[2]/div/input")]
        public IWebElement mortgage { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[3]/div/input")]
        public IWebElement repayment { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[4]/div/select")]
        public IWebElement repaymentFrequency { get; set; }
        //*[@id="propertyDetails"]
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[2]/div[4]/button[1]")]
        public IWebElement saveBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[5]/button[2]")]
        public IWebElement cancelBtn { get; set; }
        //*[@id="photoUpload"]/div/div[3]/button[1]
        [FindsBy(How = How.XPath, Using = "//*[@id='photoUpload']/div/div[3]/button[1]")]
        public IWebElement fileUploadSaveBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='photoUpload']/div/div[3]/button[2]")]
        public IWebElement fileUploadCancelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "searchId")]
        public IWebElement searchTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='property-grid']/div/form/div/div/div/button")]
        public IWebElement searchBtn { get; set; }

        #endregion



        public static void Navigate()
        {
            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Navigate Start " );
            var sidebarItem = Driver.driver.FindElements(By.XPath("//*[@id='leftsidebar']/div[2]/div/ul/li"));
            foreach (var item in sidebarItem)
            {
                if (item.Text == "Properties")
                { item.Click(); }
            }



            //ExcelLib.PopulateInCollection(Base.ExcelPath, "Property");
            // Navigating to Login page using value from Excel
            //Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));


        }

      

        public void AddPropertyBatch()
        {
            // Driver.driver.Manage().Window.Maximize();
            Navigate();

            //Populate excel-data
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Property");




            for (int i = 2; i < 7; i++)
            {
                Driver.WaitForElement(Driver.driver, By.Id("add-new-property"), 10);
                addPropertyBtn.Click();
                propertyName.SendKeys(ExcelLib.ReadData(i, "name"));
                description.SendKeys(ExcelLib.ReadData(i, "description"));
                streetNumber.SendKeys(ExcelLib.ReadData(i, "number"));
                streetName.SendKeys(ExcelLib.ReadData(i, "streetname"));
                postalCode.SendKeys(ExcelLib.ReadData(i, "postcode"));
                city.SendKeys(ExcelLib.ReadData(i, "city"));
                yearBuilt.SendKeys(ExcelLib.ReadData(i, "yearBuilt"));

                Actions move = new Actions(Driver.driver);
                move.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
                //Click somewhere to make sure year build


                Thread.Sleep(1000);
                //Save button press
                saveBtn.Click();
                Thread.Sleep(1000);
                fileUploadSaveBtn.Click();
            }


        }

        public void CheckActionButton()
        {

            //Get page number
            var pageMessage = Driver.driver.FindElement(By.XPath("//*[@id='pagedList']/div/ul/li[1]/a")).Text;
            int startIndex = pageMessage.IndexOf("of") + 2;
            int endIndex = pageMessage.IndexOf(".");
            int pageNumber = int.Parse(pageMessage.Substring(startIndex, endIndex - startIndex));
            //Console.WriteLine(pageNumber);

            string currentURL = Driver.driver.Url;

            for (int i = 2; i < 4; i++)
            {
                //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Button Check on Page: " + (i + 1));

                string url = currentURL.Substring(0, currentURL.Length - 1) + i;

                Driver.driver.Navigate().GoToUrl(url);

                var propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));

                foreach (var item in propLists)
                {
                    //Click on Action button and Click away.
                    item.FindElement(By.XPath("./td[3]/div/button")).Click();

                    item.FindElement(By.XPath("./td[1]")).Click();

                }

            }
            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Button Check Pass");

        }

        public void ActionDetailViewButton()
        {


            var propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));

            for (int i = 0; i < propLists.Count(); i++)
            {
                //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Button Check on Proplist: " + (i + 1));

                propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));

                //Click on Action button and Click away.
                propLists[i].FindElement(By.XPath("./td[3]/div/button")).Click();

                //Get action detail button
                var actionDetailBtn = propLists[i].FindElements(By.XPath("./td[3]/div/ul/li"));
                Console.WriteLine("No. Detail Button: " + actionDetailBtn.Count());
                for (int j = 0; j < actionDetailBtn.Count(); j++)

                {
                    Console.WriteLine(actionDetailBtn[j].Text + "+END");

                    if (actionDetailBtn[j].Text == "DETAILS")
                    {
                        actionDetailBtn[j].Click();
                        //Go back to Index
                        Driver.driver.FindElement(By.XPath("//*[@id='property-grid']/div/div/div[5]/button")).Click();
                        break;
                    }

                }

            }
            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Detail Button Check Pass");
        }

        public void ActionDetailEditButton()
        {

            var propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));

            for (int i = 0; i < propLists.Count(); i++)
            {
                //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Button Check on Proplist: " + (i + 1));

                propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));


                //Click on Action button and Click away.
                propLists[i].FindElement(By.XPath("./td[3]/div/button")).Click();

                //Get action detail button
                var actionDetailBtn = propLists[i].FindElements(By.XPath("./td[3]/div/ul/li"));
                Console.WriteLine("No. Detail Button: " + actionDetailBtn.Count());
                for (int j = 0; j < actionDetailBtn.Count(); j++)

                {
                    if (actionDetailBtn[j].Text == "EDIT")
                    {
                        actionDetailBtn[j].Click();
                        //Go back to Index
                        Driver.driver.FindElement(By.XPath("//*[@id='propertyDetails']/div/div[5]/button[2]")).Click();
                        break;
                    }
                }

            }
            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit Button Check Pass");
        }

        public void ActionDetailDeleteButton()
        {

            var propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));

            for (int i = 0; i < propLists.Count(); i++)
            {
                //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Button Check on Proplist: " + (i+1));

                propLists = Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr"));

                //Click on Action button and Click away.
                propLists[i].FindElement(By.XPath("./td[3]/div/button")).Click();

                //Get action detail button
                var actionDetailBtn = propLists[i].FindElements(By.XPath("./td[3]/div/ul/li"));
                Console.WriteLine("No. Detail Button: " + actionDetailBtn.Count());
                for (int j = 0; j < actionDetailBtn.Count(); j++)

                {
                    Console.WriteLine(actionDetailBtn[j].Text + "+END");

                    if (actionDetailBtn[j].Text == "DELETE")
                    {
                        actionDetailBtn[j].Click();
                        //Go back to Index
                        Thread.Sleep(1000);
                        Driver.driver.FindElement(By.XPath("/html/body/div[7]/div/div/div[3]/button[2]")).Click();
                        Thread.Sleep(1000);

                    }

                }

            }
            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete Button Check Pass");
        }


        public void SearchFunction()
        {
            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Click on UI");
            searchTextBox.SendKeys("test");
            searchBtn.Click();

            //Get number of results
            Console.WriteLine("Search result number for current page: " + Driver.driver.FindElements(By.XPath("//*[@id='propList']/tr")).Count());

            //ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Search func pass");

        }


        public void verifyResult()
        {
            //Populate excel-data
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Property");

            var driver = Driver.driver;

            string excelStreetNum = ExcelLib.ReadData(3, "number");
            string excelStreetName = ExcelLib.ReadData(3, "streetname");
            string excelPostCode = ExcelLib.ReadData(3, "postcode");
            string excelCity = ExcelLib.ReadData(3, "city");
            //string excelSuburb = ExcelLib.ReadData(2, "suburb");
            //string excelRent = ExcelLib.ReadData(3, "targetRent");
            string excelDescription = ExcelLib.ReadData(3, "description");

            string keyword = ExcelLib.ReadData(3, "name");


            Console.WriteLine(
                excelStreetNum + Environment.NewLine
                + excelStreetName + Environment.NewLine
                 + excelPostCode + Environment.NewLine
              + excelCity + Environment.NewLine
                 + excelDescription + Environment.NewLine

                );
            searchTextBox.SendKeys(keyword);
            searchBtn.Click();


            var lines = driver.FindElements(By.XPath("//*[@id='propList']/tr"));
            Console.WriteLine("Search result: " + lines.Count());

            for (int i = 0; i < lines.Count(); i++)
            {

                //Reset lines once detail does not match.
                lines = driver.FindElements(By.XPath("//*[@id='propList']/tr"));


                if (lines[i].FindElement(By.XPath("./td[1]")).Text == keyword)
                {

                    Console.WriteLine("Line:" + (i + 1) + " match with keyword");
                    lines[i].FindElement(By.XPath("./td[3]/div")).Click();
                    lines[i].FindElement(By.XPath("./td[3]/div/ul/li[1]")).Click();

                    //Compare result:
                    var location = driver.FindElement(By.XPath("//*[@id='property-grid']/div/div/div[2]/table/tbody/tr[1]/td")).Text;
                    var description = driver.FindElement(By.XPath("//*[@id='property-grid']/div/div/div[2]/div/p")).Text;
                    var rentPrice = driver.FindElement(By.XPath("//*[@id='property-grid']/div/div/div[2]/table/tbody/tr[6]/td")).Text;

                    Console.WriteLine(location);
                    var locationList = location.Split(',').ToList();

                    foreach (var word in locationList)
                    {
                        Console.WriteLine(word);
                    }

                    Console.WriteLine("NOW COMPARING");

                    if (
                        excelStreetNum == locationList[0].Trim() &&
                         excelStreetName == locationList[1].Trim() &&
                          excelCity == locationList[2].Trim() &&
                           excelPostCode == locationList[3].Trim() &&
                            excelDescription == description
                        )


                    {
                        Console.WriteLine("Test Pass");
                        break;


                    }

                    else
                    {
                        Console.WriteLine("Not in thi page");
                        driver.FindElement(By.XPath("//*[@id='property-grid']/div/div/div[5]/button")).Click();
                    }

                }
                else { Console.WriteLine("Not Match, Continue"); }

            }
  
        }

        public void SearchAddress()
        {
            var driver = Driver.driver;
            Actions move = new Actions(driver);
            addressAutoComplete.SendKeys("keyword");
            move.SendKeys(OpenQA.Selenium.Keys.Down).Perform();
            move.SendKeys(OpenQA.Selenium.Keys.Enter).Perform();

        }

    }


}