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
        
        public MainWindow()
        {
            InitializeComponent();
            Data data = new Data();
            Console.WriteLine(data.temperature);
            Console.WriteLine(data.temperature);
            Console.WriteLine(data.temperature);
            Console.WriteLine(data.temperature);
            Console.WriteLine(data.temperature);
            temperature.DataContext = data.temperature;
            humidity.DataContext = data.humidity;
            pressure.DataContext = data.pressure;
            oxides.DataContext = data.oxides;

        }

        private void Button_Click(object sender)
        {
            
        }
    }

    //页面数据
    public class Data
    {
        public String temperature { get; set; }
        public String humidity { get; set; }
        public String pressure { get; set; }
        public String air { get; set; }
        public String sulfide { get; set; }
        public String oxides { get; set; }
        public String alcohols { get; set; }
        public String sun { get; set; }
        public String upload_time { get; set; }
        public String update_time { get; set; }

        public Data()
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
        }
    }
}
