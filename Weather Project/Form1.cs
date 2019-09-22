using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Weather_Project
{
    public partial class Form1 : Form
    {
        const string APPID = "3789c4e4e5b2d1a4633f2f89ef213e23";
        string cityName = "Tallinn";
        Image MyImage = Image.FromFile(@"C:\Users\marti\source\repos\Weather Project\Weather Project\icons\refresh.png");

        public Form1()
        {
            InitializeComponent();
            getWeather(cityName, APPID);
            this.button1.Image = (Image)(new Bitmap(MyImage, new Size(58, 58)));
        }

        void getWeather(string city, string id)
        {
            using (WebClient web = new WebClient())
            {

                var json = web.DownloadString(string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&ctn=6", city, id));

                var result = JsonConvert.DeserializeObject<WeatherGet.root>(json);
                WeatherGet.root output = result;
                lbl_cityname.Text = string.Format("{0}", output.name);
                lbl_country.Text = string.Format("{0}", output.sys.country);
                lbl_temp.Text = string.Format("{0} \u00b0"+"C", output.main.temp);
                lbl_description.Text = string.Format("{0}", output.weather[0].description);
                lbl_main.Text = string.Format("{0}", output.weather[0].main);
                lbl_pressure.Text = string.Format("{0}"+" hPa", output.main.pressure);
                lbl_humidity.Text = string.Format("{0}"+"%", output.main.humidity);
                lbl_wind.Text = string.Format("{0}"+"m/s", output.wind.speed);
                string ID = string.Format(output.weather[0].icon);
                string imgpath =@"C:\Users\marti\source\repos\Weather Project\Weather Project\icons\";
                string end = ".png";
                pictureBox2.Image = Image.FromFile(imgpath+ID+end);
            }
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            getWeather(cityName, APPID);
            
        }
    }
}
