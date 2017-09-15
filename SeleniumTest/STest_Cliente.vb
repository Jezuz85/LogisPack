Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports System.Threading

<TestClass()> Public Class STest_Cliente

    <TestMethod()> Public Sub Registrar_Cliente()

        Dim driver As IWebDriver = New ChromeDriver()
        driver.Navigate().GoToUrl("http://www.midemo.es/logispack/Portal/Cliente/index")
        driver.Manage().Window.Maximize()

        Dim GridView1 As IWebElement = driver.FindElement(By.Id("MainContent_GridView1"))
        Dim filasAntes As List(Of IWebElement) = GridView1.FindElements(By.TagName("tr")).ToList()

        Dim btnRegistrar As IWebElement = driver.FindElement(By.Id("MainContent_btnRegistrar"))
        btnRegistrar.Click()

        Thread.Sleep(3000)

        Dim txtCodigo_Add As IWebElement = driver.FindElement(By.Id("txtCodigo_Add"))
        txtCodigo_Add.SendKeys("Cod")

        Dim txtNombre_Add As IWebElement = driver.FindElement(By.Id("txtNombre_Add"))
        txtNombre_Add.SendKeys("NombrePrueba")

        Dim btnAdd As IWebElement = driver.FindElement(By.Id("MainContent_btnAdd"))
        btnAdd.Click()

        Thread.Sleep(3000)

        GridView1 = driver.FindElement(By.Id("MainContent_GridView1"))
        Dim filasDespues As List(Of IWebElement) = GridView1.FindElements(By.TagName("tr")).ToList()

        driver.Close()

        Assert.AreEqual(filasDespues.Count(), (filasAntes.Count() + 1))

    End Sub

End Class
