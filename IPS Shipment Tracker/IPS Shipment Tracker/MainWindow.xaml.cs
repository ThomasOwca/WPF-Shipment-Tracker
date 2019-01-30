using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace IPS_Shipment_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creating a new instance of the tracking screen called trackScreen.
        private Tracking trackScreen = new Tracking();

        public MainWindow()
        {
            InitializeComponent();
            MainScreen.Visibility = Visibility.Hidden;
        }

        //If X is pressed in the top right, app will shutdown.
        private void X_Pressed_CloseApp(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        //If Minimize is pressed in the top right, minimize the window.
        private void Minimize_Pressed_MinimizeApp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //This method allows for the dragging of the window when the left mouse button is pressed/dragged.
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //Change color of button when mouse enters the exit button (X).
        private void ExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitButton.Foreground = Brushes.White;
        }

        //Change color of button when mouse leaves the exit button (X).
        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            ExitButton.Foreground = (Brush)bc.ConvertFrom("#FF49C6FB");
        }

        //Change color of button when mouse enters the minimize window button (_).
        private void MinimizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            MinimizeButton.Foreground = Brushes.White;
        }

        //Change color of button when mouse leaves the minimize window button ()).
        private void MinimizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            MinimizeButton.Foreground = (Brush)bc.ConvertFrom("#FF49C6FB");
        }

        //Method call when user clicks 'Authorize Button'.
        private void AuthorizeLogIn_Click(object sender, RoutedEventArgs e)
        {
            string departureHubID;
            bool validated = false;
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Thomas\Documents\Shipments3.mdb";
            OleDbConnection cnn = new OleDbConnection(connectionString);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ID FROM DepartureHub", cnn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    departureHubID = reader.GetString(0);

                    if (EmployeeID.Password == departureHubID)
                    {
                        //MessageBox.Show("Authorization Valid.");
                        validated = true;
                        EmployeeID.Password = "";
                        LogInGrid.Visibility = Visibility.Hidden;
                        MainScreen.Visibility = Visibility.Visible;
                        this.Visibility = Visibility.Hidden;
                        trackScreen.Visibility = Visibility.Visible;

                        break;
                    }
                }

                if (!validated)
                {
                    MessageBox.Show("Invalid Credentials.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection with the Database Server could not be established.");
            }
            finally
            {
                cnn.Close();
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Kills any background process(es) if the .exe gets closed 
            //but keeps running in the background.
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
