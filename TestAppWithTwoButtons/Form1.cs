using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace TestAppWithTwoButtons
{
    public partial class Form1 : Form
    {
        private WebView2 webView;
        private Button btnCall;
        private Button btnEnd;

        public Form1()
        {
            InitializeComponent();
            InitUI();
        }

        private async void InitUI()
        {
            // Форма на весь экран
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;

            // Создаём WebView2
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            await webView.EnsureCoreWebView2Async(null);
            this.Controls.Add(webView);

            // Панель с кнопками внизу
            Panel panel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightGray
            };
            this.Controls.Add(panel);

            // Кнопка "Вызов"
            btnCall = new Button
            {
                Text = "Вызов",
                Width = 120,
                Height = 40,
                Left = 20,
                Top = 10
            };
            btnCall.Click += BtnCall_Click;
            panel.Controls.Add(btnCall);

            // Кнопка "Завершить"
            btnEnd = new Button
            {
                Text = "Завершить",
                Width = 120,
                Height = 40,
                Left = 160,
                Top = 10
            };
            btnEnd.Click += BtnEnd_Click;
            panel.Controls.Add(btnEnd);
        }

        private void BtnCall_Click(object sender, EventArgs e)
        {
            // Заглушка для OOS
            MessageBox.Show("Эмулируем команду OOS (OUT_OF_SERVICE)");

            // Открываем сайт (например, тестовый)
            webView.CoreWebView2.Navigate("https://www.google.com/");
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            // Заглушка для IS
            MessageBox.Show("Эмулируем команду IS (IN_SERVICE)");

            // Очищаем браузер (открываем пустую страницу)
            webView.CoreWebView2.Navigate("about:blank");
        }
    }
}
