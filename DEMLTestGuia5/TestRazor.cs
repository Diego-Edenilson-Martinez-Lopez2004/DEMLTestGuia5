using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEMLTestGuia5
{
    [TestClass]
    public class TestRazor
    {
        private IWebDriver driver;

        // Constructor para inicializar el WebDriver
        public TestRazor()
        {
            // Inicializa el controlador de Chrome
            driver = new ChromeDriver();
        }

        // Método de prueba
        [TestMethod]
        public void CrearProductoTest()
        {
            try
            {
                // Navega a la página de inicio
                driver.Navigate().GoToUrl("https://localhost:7257/");
                driver.Manage().Window.Maximize();
                System.Threading.Thread.Sleep(1000);  // Espera de 1 segundo

                // Navegar a la página de "Crear Producto"
                driver.FindElement(By.LinkText("Productos")).Click();
                System.Threading.Thread.Sleep(1000);  // Espera de 1 segundo
                driver.FindElement(By.LinkText("Registrar")).Click();
                System.Threading.Thread.Sleep(1500);  // Espera de 1.5 segundos

                // Llenar el formulario de creación de producto
                driver.FindElement(By.Id("NombreDEML")).SendKeys("ProductoTest");
                System.Threading.Thread.Sleep(1000);  // Espera de 1 segundo
                driver.FindElement(By.Id("DescripcionDEML")).SendKeys("Descripción del producto de prueba");
                System.Threading.Thread.Sleep(1000);  // Espera de 1 segundo

                // Limpiar y rellenar el campo de precio
                var precioField = driver.FindElement(By.Id("Precio"));
                precioField.Clear();
                precioField.SendKeys("100");
                System.Threading.Thread.Sleep(1000);  // Espera de 1 segundo

                // Enviar el formulario
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                System.Threading.Thread.Sleep(1500);  // Espera de 1.5 segundos

                // Verificar que la navegación a la lista de productos fue exitosa
                driver.Navigate().GoToUrl("https://localhost:7257/product-list");
                System.Threading.Thread.Sleep(1000);  // Espera de 1 segundo

                // Aquí puedes hacer una verificación adicional de que el producto fue creado
                // Por ejemplo, buscar si el producto está listado en la tabla

            }
            finally
            {
                // Cierra el navegador después de la prueba
                driver.Quit();
            }
        }

        // Método Dispose para liberar recursos al finalizar las pruebas
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
