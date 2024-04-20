using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source= LAB1504-31\\SQLEXPRESS; Initial Catalog=Neptuno;" +
                "User Id=user01; Password=123456";
            List<Empleados> empleados = new List<Empleados>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListarEmpleados", connection);

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    int IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    string apellidos = Convert.ToString(reader["Apellidos"]);
                    string nombre = Convert.ToString( reader["Nombre"]);
                    string cargo = Convert.ToString(reader["Cargo"]);

                    empleados.Add(new Empleados { IdEmpleado = IdEmpleado, Apellidos = apellidos, Nombre = nombre, Cargo = cargo });

                }
                
                connection.Close();
                dataEmpleados.ItemsSource = empleados;
            }
            catch { }

        }

        private void InsertarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ActualizarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}