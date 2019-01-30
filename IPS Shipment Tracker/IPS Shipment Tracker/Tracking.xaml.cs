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
using System.Windows.Shapes;

namespace IPS_Shipment_Tracker
{
    /// <summary>
    /// Interaction logic for Tracking.xaml
    /// </summary>
    public partial class Tracking : Window
    {
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Thomas\Documents\Shipments3.mdb";
        public Tracking()
        {
            try
            {
                InitializeComponent();

                // Hide the grid from the other pages. *ADD MORE PAGE HIDING HERE*
                findTrackingNumberGrid.Visibility = Visibility.Hidden;
                findCustomerGrid.Visibility = Visibility.Hidden;

                // Create random number between 1-35. Generally the number of new shipments
                // generated will be less than the average random chosen from 1-35 because of possible duplicate primary
                // keys being generated.
                Random random = new Random(DateTime.Now.Millisecond);
                int maxIter = random.Next(0, 35);

                // Generates new shipments into the database. Number of generated shipments is determined by randomness.
                for (int i = 0; i < maxIter; i++)
                {
                    GenerateNewShipments();
                }

                // Update any records in database that need updating.
                UpdateExistingShipments();

                // This method populates the fields and records in the data grid.
                PopulateShipmentsDataGrid();

                // This method populates the customer list data grid.
                PopulateCustomerListDataGrid();

                // This method populates the customer search data grid.
                PopulateCustomerSearchDataGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception was detected when trying to establish connection to the server.");
            }
        }

        private void TrackingWindow_Closed(object sender, EventArgs e)
        {
            // Kills any background process(es) if the .exe gets closed 
            // but keeps running in the background.
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void ButtonShipments_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonShipments.FontSize = 20;
        }

        private void ButtonShipments_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonShipments.FontSize = 18;
        }

        private void ButtonFindShipment_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonFindShipment.FontSize = 20;
        }

        private void ButtonFindShipment_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonFindShipment.FontSize = 18;
        }

        private void ButtonFindShipment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DisplayStackPanel.Visibility = Visibility.Hidden;
            AllShipments.Visibility = Visibility.Hidden;
            findCustomerGrid.Visibility = Visibility.Hidden;

            findTrackingNumberGrid.Visibility = Visibility.Visible;
        }

        private void ButtonShipments_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            findCustomerGrid.Visibility = Visibility.Hidden;
            findTrackingNumberGrid.Visibility = Visibility.Hidden;

            DisplayStackPanel.Visibility = Visibility.Visible;
            AllShipments.Visibility = Visibility.Visible;
        }

        private void ButtonFindCustomers_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonFindCustomers.FontSize = 20;
        }

        private void ButtonFindCustomers_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonFindCustomers.FontSize = 18;
        }

        private void ButtonFindCustomers_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DisplayStackPanel.Visibility = Visibility.Hidden;
            AllShipments.Visibility = Visibility.Hidden;
            findTrackingNumberGrid.Visibility = Visibility.Hidden;

            findCustomerGrid.Visibility = Visibility.Visible;
        }

        private void ButtonExit_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonExit.FontSize = 20;
        }

        private void ButtonExit_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonExit.FontSize = 18;
        }

        private void RefreshButton_MouseEnter(object sender, MouseEventArgs e)
        {
            refreshButton.FontWeight = FontWeights.ExtraBold;
        }

        private void RefreshButton_MouseLeave(object sender, MouseEventArgs e)
        {
            refreshButton.FontWeight = FontWeights.Medium;
        }

        private void RefreshButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Create random number.
            Random random = new Random(DateTime.Now.Millisecond);
            int maxIter = random.Next(0, 15);

            // Generates new shipments into the database. Number of generated shipments is 'partially' determined by randomness.
            for (int i = 0; i < maxIter; i++)
            {
                GenerateNewShipments();
            }

            // Update all the records in the data grid.
            PopulateShipmentsDataGrid();
            PopulateCustomerListDataGrid();
            PopulateCustomerSearchDataGrid();
            UpdateExistingShipments();
        }

        private void ButtonExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;

            // Create a new MessageBox to ask user to confirm that they truly intend to exit the application.
            MessageBoxResult messageBoxResult =
                System.Windows.MessageBox.Show("Are you sure you want to exit?", "Exit", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Hide the current window.
                this.Hide();

                // Open and run the .exe file for the application. Bringing the user back to the main window.
                System.Diagnostics.Process.Start("IPS Shipment Tracker.exe");

                // Exit the previously shown run window.
                Environment.Exit(0);

            }
        }

        private void searchPackageLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            searchPackageLabel.FontWeight = FontWeights.Bold;
        }

        private void searchPackageLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            searchPackageLabel.FontWeight = FontWeights.Normal;
        }


        private void AllShipments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // This string is assigned the shipped date. This string will be broken down further into days, months, years.
                string initiated = shippedDateTextBox.Text;

                // Assigned to a shorter variable names. Will be indexed like an array to pass the date into new DateTime constructor.
                int year = Convert.ToInt32((initiated[6].ToString() + initiated[7].ToString() + initiated[8].ToString() + initiated[9].ToString()));
                int day = Convert.ToInt32((initiated[3].ToString() + initiated[4].ToString()));
                int month = Convert.ToInt32((initiated[0].ToString() + initiated[1].ToString()));

                // This object creates a range of time. The start (shipped date) and end ranges are passed into the constructor.
                CalendarDateRange calendarDate = new CalendarDateRange(
                    new DateTime(year, month, day), new DateTime(2999, 12, 31));


                // Conditional processing that estimates the delivery time based on the shipment status and original shipment date.
                if (packageStatusTextBox.Text == "Delivered")
                {
                    estimatedDeliveryTextBox.Text = "Delivered by IPS";
                }
                else if (packageStatusTextBox.Text == "Out For Delivery")
                {
                    estimatedDeliveryTextBox.Text = "Today";
                }
                else if (packageStatusTextBox.Text == "In-Transit")
                {
                    DateTime date = calendarDate.Start.AddDays(2);
                    estimatedDeliveryTextBox.Text = date.ToString("MM/dd/yyyy");
                }
                else if (packageStatusTextBox.Text == "Label Printed" || packageStatusTextBox.Text == "On Way To Carrier")
                {
                    DateTime date = calendarDate.Start.AddDays(2);
                    estimatedDeliveryTextBox.Text = date.ToString("MM/dd/yyyy");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                // Do nothing.
            }
            catch (Exception ex)
            {
                // Do nothing.
            }

        }

        private void PopulateShipmentsDataGrid()
        {
            // Steps below - establish connection to database and populate the display shipments screen's datagrid.
            OleDbConnection cnn = new OleDbConnection();

            cnn.ConnectionString = connectionString;

            OleDbCommand command = new OleDbCommand();
            string commandString = "SELECT [ID] AS [Shipment], [TrackingID] AS [Tracking #], [Progress] AS [Status], [DepartingHubLocationID] AS [Departure ID], [DestinationHubLocationID] AS [Destination ID], [CustomerID] AS [Customer ID], [DateInitiated] AS [Date Initiated], [DateLastUpdated] AS [Date Updated], [DateDelivered] AS [Date Delivered] FROM Shipment ORDER BY [ID] DESC";
            command.Connection = cnn;
            command.CommandText = commandString;

            OleDbDataAdapter da = new OleDbDataAdapter(commandString, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Item source for the data grid is the table that is generated with the SQL command.
            AllShipments.ItemsSource = dt.DefaultView;
            AllShipments.AutoGenerateColumns = true;

            // Set the visibility of the following two properties.
            AllShipments.HeadersVisibility = DataGridHeadersVisibility.Column;

            // Set the boundaries for what the user can do with the data grid.
            AllShipments.CanUserResizeColumns = false;
            AllShipments.CanUserResizeRows = false;
            AllShipments.CanUserAddRows = false;
            AllShipments.CanUserDeleteRows = false;
            AllShipments.IsReadOnly = true;
        }

        // ************************************* SHIPMENT SIMULATOR ********************************************
        // This method simulates the creation of new shipments into the database.
        // *****************************************************************************************************
        private void GenerateNewShipments()
        {
            // Random class. Seed is the current time in Milliseconds.
            Random random = new Random(DateTime.Now.Millisecond);

            // Pick a random number 0-3.
            int randomNum1 = random.Next(0,3);

            // These two arrays are parallel. Same index corresponds to same index in other array.
            string[] trackingHalf1 = { "BBBCDA", "BBBADA", "CDABBB", "ADABBB", };
            string[] customers = { "1A", "2C", "1B", "1B" };

            // Populate the various data variables.
            string trackingNumber = null;
            string progress = "Label Printed";
            string departingHub = trackingHalf1[randomNum1].Substring(0, 3) + "01";
            string destinationHub = trackingHalf1[randomNum1].Substring(3, 3) + "02";
            string customerID = customers[randomNum1];
            string shipDate = DateTime.Now.ToString("MM/dd/yyyy");
            string lastUpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

            // First half of random chosen tracking number is 
            trackingNumber = trackingHalf1[randomNum1];

            // Create a new instance of the Access Connection.
            OleDbConnection cnn = new OleDbConnection(connectionString);

            // This variable will be used to check if the randomly created trackingNumber already exists in the database.
            string tempChecker = "";
            int randomNum2;

            try
            {
                cnn.Open();

                do
                {
                    // Pick a random number 100000-999999.
                    randomNum2 = random.Next(100000, 999999);

                    // Generate another random value to be used to make the original generated value slightly more random.
                    int randomizer = random.Next(100, 10000);

                    // Trying to create an even more random number.
                    randomNum2 += randomizer;
                    randomNum2 -= 2;

                    // Assign the random num to the string.
                    string trackingHalf2 = randomNum2.ToString();

                    // If looped again, trackingNumber will be storing junk. Set to null and restore the first 6 characters.
                    trackingNumber = null;
                    trackingNumber = trackingHalf1[randomNum1];

                    // Concatenate the number to create the full tracking number.
                    trackingNumber += trackingHalf2;

                    // Create the command and provide the connection variable. Add the parameter value.
                    OleDbCommand command = new OleDbCommand("SELECT TrackingID FROM Shipment WHERE TrackingID = @trackingID", cnn);
                    command.Parameters.AddWithValue("@trackingID", trackingNumber);

                    // Create a reader for the query results.
                    OleDbDataReader dataReader = command.ExecuteReader();

                    // If rows returned populate tempChecker with the resulting value. Otherwise set to null.
                    if (dataReader.Read())
                    {
                        tempChecker = dataReader.GetString(0);
                    }
                    else
                    {
                        tempChecker = null;
                    }

                } while (tempChecker != null);
            }
            catch (OleDbException ex)
            {
                // Do nothing.
                //MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                // Do nothing.
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnn.Close();
            }

            // This variable will store the returned max ID number in the table.
            int maxOrderID = 0;

            try
            {
                cnn.Open();

                string getData = "SELECT MAX(ID) FROM Shipment";
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandText = getData;
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    maxOrderID = reader.GetInt32(0); //first column
                }

                maxOrderID++;

            }
            catch (Exception m)
            {
                //MessageBox.Show("Connection with database has failed.");
                //MessageBox.Show(m.ToString());
            }
            finally
            {
                cnn.Close();
            }

            // This code below is used to insert a new record into the 'Shipment' table on Microsoft Access Database.
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;            
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Shipment " +
                        "VALUES (@orderID, @trackingNum, @progressCol, @departHub, @destinHub, @customerID, @shipDate, @dateLastUpdated, @dateDelivered)";

                    command.Parameters.AddWithValue("@orderID", maxOrderID);
                    command.Parameters.AddWithValue("@trackingNum", trackingNumber);
                    command.Parameters.AddWithValue("@progressCol", "Label Printed");
                    command.Parameters.AddWithValue("@departHub", departingHub);
                    command.Parameters.AddWithValue("@destinHub", destinationHub);
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@shipDate", shipDate);
                    command.Parameters.AddWithValue("@dateLastUpdated", lastUpdatedDate);
                    command.Parameters.AddWithValue("@dateDelivered", "");

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        // Do Nothing. This exception handler basically hides the exception message 
                        // when duplicate tracking numbers are created. 
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        // ************************************* SHIPMENT SIMULATOR ********************************************
        // This method will update existing records. Will simulate changes in shipment progress. 
        // Ex: 'In-Transit' changes to 'Out For Delivery' after a day. 'Label Printed' or 'On Way To Carrier'
        // changes to 'In-Transit' after a day has passed.
        // *****************************************************************************************************
        private void UpdateExistingShipments()
        {
            // These strings hold dates that will be used in the SQL query.
            string todaysDate = DateTime.Now.ToString("MM/dd/yyyy");

            // Subtract 2 days to get the date from two days ago from today.
            DateTime twoDaysAgo = DateTime.Now;
            twoDaysAgo = twoDaysAgo.AddDays(-2);

            // Assign the date to the variable in a string format.
            string twoDaysAgoString = twoDaysAgo.ToString("MM/dd/yyyy");        

            // Get today's year, day, and month.
            int todayYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int todayDay = Convert.ToInt32(DateTime.Now.ToString("dd"));
            int todayMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));

            // Get two days ago year, day, and month.
            int twoDaysAgoYear = Convert.ToInt32(twoDaysAgoString.Substring(6, 4));
            int twoDaysAgoDay = Convert.ToInt32(twoDaysAgoString.Substring(3, 2));
            int twoDaysAgoMonth = Convert.ToInt32(twoDaysAgoString.Substring(0, 2));

            //This object creates a range of time. The start (shipped date) and end ranges are passed into the constructor.
            CalendarDateRange calendarDate = new CalendarDateRange(
                new DateTime(twoDaysAgoYear, twoDaysAgoMonth, twoDaysAgoDay), new DateTime(todayYear, todayMonth, todayDay));

            int daysPassed = (calendarDate.End - calendarDate.Start).Days;

            if (daysPassed == 2)
            {
                // This code below is used to update two day old records in the 'Shipment' table on Microsoft Access Database.
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE Shipment " +
                            "SET DateLastUpdated = @todaysDate, Progress = @newProgress, DateDelivered = @deliveryDate " +
                            "WHERE DateInitiated = @twoDaysAgoDate AND NOT Progress = @delivered";

                        // Seed the random number generator.
                        Random random = new Random(DateTime.Now.Millisecond);

                        command.Parameters.AddWithValue("@todaysDate", todaysDate);

                        if (random.Next(1, 5) == 1)
                        {
                            command.Parameters.AddWithValue("@newProgress", "Out For Delivery");
                            command.Parameters.AddWithValue("@deliveryDate", "");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@newProgress", "Delivered");
                            command.Parameters.AddWithValue("@deliveryDate", todaysDate);
                        }

                        command.Parameters.AddWithValue("@twoDaysAgoDate", twoDaysAgo.Date.ToString("MM/dd/yyyy"));
                        command.Parameters.AddWithValue("@delivered", "Delivered");

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            // Subtract 1 day to get the date from two days ago from today.
            DateTime oneDayAgo = DateTime.Now;
            oneDayAgo = oneDayAgo.AddDays(-1);

            // Assign the date to the variable in a string format.
            string oneDayAgoString = oneDayAgo.ToString("MM/dd/yyyy");

            int oneDayAgoYear = Convert.ToInt32(oneDayAgoString.Substring(6, 4));
            int oneDayAgoDay = Convert.ToInt32(oneDayAgoString.Substring(3, 2));
            int oneDayAgoMonth = Convert.ToInt32(oneDayAgoString.Substring(0, 2));

            calendarDate = new CalendarDateRange(
                new DateTime(oneDayAgoYear, oneDayAgoMonth, oneDayAgoDay), new DateTime(todayYear, todayMonth, todayDay));

            daysPassed = (calendarDate.End - calendarDate.Start).Days;

            if (daysPassed == 1)
            {
                // This code below is used to update two day old records in the 'Shipment' table on Microsoft Access Database.
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE Shipment " +
                            "SET DateLastUpdated = @todaysDate, Progress = @newProgress " +
                            "WHERE DateInitiated = @oneDayAgoDate AND (Progress = @lblPrinted OR Progress = @movedToCarrier)";

                        command.Parameters.AddWithValue("@todaysDate", todaysDate);
                        command.Parameters.AddWithValue("@newProgress", "In-Transit");
                        command.Parameters.AddWithValue("@oneDayAgoDate", oneDayAgoString);
                        command.Parameters.AddWithValue("@lblPrinted", "Label Printed");
                        command.Parameters.AddWithValue("movedToCarrier", "On Way To Carrier");

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            // Excute and update database records when more than 2 days have passed.
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Shipment " +
                        "SET Progress = @progress, DateDelivered = @deliveryDate, DateLastUpdated = @todaysDate " +
                        "WHERE NOT DateInitiated = @dateInitiated1 AND NOT DateInitiated = @dateInitiated2 AND NOT DateInitiated = @today AND NOT Progress = @progress";

                    DateTime deliveryDate = calendarDate.Start.AddDays(-1);

                    string deliveryDateString = deliveryDate.ToString("MM/dd/yyyy");

                    command.Parameters.AddWithValue("@progress", "Delivered");
                    command.Parameters.AddWithValue("@deliveryDate", deliveryDate.ToString("MM/dd/yyyy"));
                    command.Parameters.AddWithValue("@todaysDate", todaysDate);
                    command.Parameters.AddWithValue("@dateInitiated1", oneDayAgoString);
                    command.Parameters.AddWithValue("@dateInitiated2", twoDaysAgoString);
                    command.Parameters.AddWithValue("@today", todaysDate);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        //MessageBox.Show(ex.Data.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void PopulateCustomerListDataGrid()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlCmd = "SELECT CustomerID AS ID, [Business Name] AS Business, [Street Address] AS Street, " +
                    " City AS City, State AS State, ZipCode AS Zip FROM Customer";

                using (OleDbCommand command = new OleDbCommand(sqlCmd, connection))
                {
                    try
                    {
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                        DataTable table = new DataTable();

                        // Fill the table with the data.
                        dataAdapter.Fill(table);

                        // Populate the customer list data grid with the table filled from the SQL command's resulting query.
                        customerListDataGrid.ItemsSource = table.DefaultView;

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Exception caught while trying to populate customer list.");
                    }
                    finally
                    {
                        customerListDataGrid.AutoGenerateColumns = true;

                        // Set the visibility of the following two properties.
                        customerListDataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;

                        // Set the boundaries for what the user can do with the data grid.
                        customerListDataGrid.CanUserResizeColumns = false;
                        customerListDataGrid.CanUserResizeRows = false;
                        customerListDataGrid.CanUserAddRows = false;
                        customerListDataGrid.CanUserDeleteRows = false;
                        customerListDataGrid.IsReadOnly = true;

                        // Set the color of the following data grid properties.
                        customerListDataGrid.RowBackground = Brushes.Black;
                        customerListDataGrid.Foreground = Brushes.White;
                    }
                }
            }
        }

        private void PopulateCustomerSearchDataGrid()
        {
            // Will be set conditionally based on whether there is text in the customer search text box.
            string sqlCmd = null;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    if (customerSearchTextBox.Text == "")
                    {

                        sqlCmd = "SELECT Customer.CustomerID, Customer.[Business Name], Customer.ZipCode AS [Zip Code], " +
                            "Shipment.TrackingID AS [Tracking ID], Shipment.DateLastUpdated AS [Last Updated], Shipment.DateInitiated AS [Shipped Date], Shipment.DateDelivered AS [Date Delivered] " +
                            "FROM Customer INNER JOIN Shipment ON Customer.CustomerID = Shipment.CustomerID";

                    }
                    else
                    {
                        sqlCmd = "SELECT Customer.CustomerID, Customer.[Business Name], Customer.ZipCode AS [Zip Code], " +
                            "Shipment.TrackingID AS [Tracking ID], Shipment.DateLastUpdated AS [Last Updated], Shipment.DateInitiated AS [Shipped Date], Shipment.DateDelivered AS [Date Delivered] " +
                            "FROM Customer INNER JOIN Shipment ON Customer.CustomerID = Shipment.CustomerID " +
                            "WHERE Customer.CustomerID = @customerID";

                        command.Parameters.AddWithValue("@customerID", customerSearchTextBox.Text);
                    }

                    try
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        command.CommandText = sqlCmd;

                        //command.Parameters.AddWithValue("@customerID", customerSearchTextBox.Text);

                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                        DataTable table = new DataTable();

                        // Fill the table with the data.
                        dataAdapter.Fill(table);

                        // Populate the customer shipments data grid with the table filled from the SQL command's resulting query.
                        customerShipmentsDataGrid.ItemsSource = table.DefaultView;

                    }
                    catch (OleDbException ex)
                    {
                        //MessageBox.Show("Exception caught while trying to populate customer search list.\n" + ex.ToString());
                    }
                    finally
                    {
                        customerShipmentsDataGrid.AutoGenerateColumns = true;

                        // Set the visibility of the following two properties.
                        customerShipmentsDataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;

                        // Set the boundaries for what the user can do with the data grid.
                        customerShipmentsDataGrid.CanUserResizeColumns = false;
                        customerShipmentsDataGrid.CanUserResizeRows = false;
                        customerShipmentsDataGrid.CanUserAddRows = false;
                        customerShipmentsDataGrid.CanUserDeleteRows = false;
                        customerShipmentsDataGrid.IsReadOnly = true;

                        // Set the color of the following data grid properties.
                        customerShipmentsDataGrid.RowBackground = Brushes.Black;
                        customerShipmentsDataGrid.Foreground = Brushes.White;

                        customerShipmentsDataGrid.ColumnWidth = 170;
                    }
                }
            }
        }

        private void SearchByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (searchByComboBox.SelectedIndex == 0)
                {
                    enterLabel.Content = "Enter Tracking Number: ";
                }
                else if (searchByComboBox.SelectedIndex == 1)
                {
                    enterLabel.Content = "Enter Order ID Number: ";
                }
            }
            catch (Exception ex)
            {
                // Do nothing.
                //MessageBox.Show(ex.ToString());
            }
        }

        private void SearchPackageLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // These strings act as temporary variables that will store each data member from the query result.
            int orderID;
            string trackingNumber = null;
            string progress = null;
            string departingHubID = null;
            string destinationHubID = null;
            string customerID = null;
            string dateInitiated = null;
            string dateLastUpdated = null;
            string dateDelivered = null;

            OleDbConnection cnn = new OleDbConnection(connectionString);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                // The command is dependent upon which combo box search criteria is selected by the user.
                if ((string)enterLabel.Content == "Enter Tracking Number: ")
                {
                    cmd.CommandText = "SELECT * FROM Shipment WHERE TrackingID = @tracking";
                    cmd.Parameters.AddWithValue("@tracking", enterTextBox.Text);
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Shipment WHERE ID = @orderID";
                    cmd.Parameters.AddWithValue("@orderID", enterTextBox.Text);
                }

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Assign the read values from each column in the query's result.
                    orderID = reader.GetInt32(0);
                    trackingNumber = reader.GetString(1);
                    progress = reader.GetString(2);
                    departingHubID = reader.GetString(3);
                    destinationHubID = reader.GetString(4);
                    customerID = reader.GetString(5);
                    dateInitiated = reader.GetString(6);
                    dateLastUpdated = reader.GetString(7);
                    dateDelivered = reader.GetString(8);
                    break;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnn.Close();

                // Change the rectangle background/fill color based on the status of the found shipment.
                if (progress == "Delivered")
                    backgroundRectangle.Stroke = Brushes.LimeGreen;
                else if (progress == "Out For Delivery")
                    backgroundRectangle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF00FF68");
                else if (progress == "In-Transit")
                    backgroundRectangle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF4A933");
                else if (progress == "On Way To Carrier")
                    backgroundRectangle.Stroke = Brushes.Yellow;
                else if (progress == "Label Printed")
                    backgroundRectangle.Stroke = Brushes.Red;
                else
                    backgroundRectangle.Stroke = Brushes.White;
            }

            // Assign the found results from the query into the result labels for the user to see.
            lblCustomerIDResult.Content = customerID;
            lblDateDeliveredResult.Content = dateDelivered;
            lblDepartureHubResult.Content = departingHubID;
            lblDestinationHubResult.Content = destinationHubID;
            lblLastUpdatedDateResult.Content = dateLastUpdated;
            lblShipDateResult.Content = dateInitiated;
            lblStatusResult.Content = progress;
            lblTrackingNumberResult.Content = trackingNumber;
        }

        private void CustomerSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateCustomerSearchDataGrid();
        }
    }
}
