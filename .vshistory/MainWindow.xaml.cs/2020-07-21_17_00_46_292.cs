using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp21
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public String temperature;
        public String humidity;
        public String pressure;
        public String air;
        public String sulfide;
        public String oxides;
        public String alcohols;
        public String sun;
        public String upload_time;
        public String update_time;


        public MainWindow()
        {
            string connectStr = "server = 106.52.239.27; port = 3306; user = root; password = deQA0VNIQvLf; database = xunhua;";
            MySqlConnection connect = new MySqlConnection(connectStr);
            try
            {
                connect.Open();
                Console.WriteLine("已经建立连接");
                string sql = "select * from data";
                MySqlCommand cmd = new MySqlCommand(sql, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                //Console.WriteLine(reader.GetString("name") + "   " + reader.GetString("number") + "  " + reader.GetInt16("age"));
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString("temperature"));
                    this.temperature = reader.GetString("temperature");
                    this.humidity = reader.GetString("humidity");
                    this.pressure = reader.GetString("pressure");
                    this.air = reader.GetString("air");
                    this.sulfide = reader.GetString("sulfide");
                    this.oxides = reader.GetString("oxides");
                    this.alcohols = reader.GetString("alcohols");
                    this.sun = reader.GetString("sun");
                  
                }

            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server, Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
            finally
            {
                connect.Close();
            }
            InitializeComponent();
        }

        private void Button_Click(object sender)
        {

        }
    }
}
