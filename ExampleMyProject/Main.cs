using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExampleMyProject
{
    public partial class Main : Form
    {
        IWebDriver BrowserPavelYO ;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowserPavelYO = new OpenQA.Selenium.Chrome.ChromeDriver();
            BrowserPavelYO.Manage().Window.Maximize();
            BrowserPavelYO.Navigate().GoToUrl("http://google.com");
            IWebElement SearchInput = BrowserPavelYO.FindElement(By.Name ("q"));
            SearchInput.SendKeys("с#" + OpenQA.Selenium.Keys.Enter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrowserPavelYO.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWebElement elementPavelYo;
            //поиск по ID
            elementPavelYo = BrowserPavelYO.FindElement(By.Id("text"));
            elementPavelYo.SendKeys("тест");

            //поиск по имени класса
            elementPavelYo = BrowserPavelYO.FindElement(By.ClassName("football"));
            elementPavelYo.Click();

            //поиск по тексту ссылки
            elementPavelYo = BrowserPavelYO.FindElement(By.LinkText("Картинки"));
            elementPavelYo.Click();

            //поиск по частичному тексту ссылки (переводчик)
            elementPavelYo = BrowserPavelYO.FindElement(By.PartialLinkText("ревод"));
            elementPavelYo.Click();

            // Варинатов много .... ( мне удобнее по )
        }

        // открытие пустого браузера без параметров ( так же есть с параметрами )
        private void button4_Click(object sender, EventArgs e)
        {
            BrowserPavelYO = new OpenQA.Selenium.Chrome.ChromeDriver();
            BrowserPavelYO.Manage().Window.Maximize();
        }

        //  как в зависемости от текста сделать что то со строкой

        /* 
         * Шаги: 
         * Открыть браузер 
         * открыть главную старницу яндекса
         * В зависемости от новости вбить нужный текст в шаги
         */

        private void button5_Click(object sender, EventArgs e)
        {
            List<IWebElement> News = BrowserPavelYO.FindElements(By.CssSelector("#tabnews_newsc a")).ToList();

            for (int i = 0; i < News.Count; i++)
            {
                String s = News[i].Text; // текст новости с номером i

                if (s.StartsWith(""))
                {
                    textBox1.AppendText("Информация №" + (i + 1).ToString() + "  начинается с 'Вирус'" + "\r\n");
                }

                if (s.EndsWith("Кремля"))
                {
                    textBox1.AppendText("Информация № " + (i + 1).ToString() + "  заканчивается  'домой'" + "\r\n");
                }

                if (s.Contains("вывести"))
                {
                    textBox1.AppendText("Информация №" + (i + 1).ToString() + "  содержит 'удалит из'" + "\r\n");
                    News[i].Click();
                    break;
                }
            }
        }

        // JavaScript  в автотестах 
        private void button6_Click(object sender, EventArgs e)
        {
             IJavaScriptExecutor jse = BrowserPavelYO as IJavaScriptExecutor; // тип JS экзекютер
            jse.ExecuteScript("alert('Закрой это окно');");
        }

        // текстовое окно
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
