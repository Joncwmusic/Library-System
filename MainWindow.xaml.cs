using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace LibrarySystemforPortfolio
{


    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ConnectionString = "ConnectionStringtoServer";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (rbExistingBook.IsChecked == true)
            {
                // User chose to add an existing book
                string existingBookId = txtExistingBookId.Text;
                // Implement logic to add existing book to the library based on book ID
                MessageBox.Show($"Adding existing book with ID '{existingBookId}'.");
            }
            else if (rbNewBook.IsChecked == true)
            {
                // User chose to add a new book
                // Toggle visibility of controls for adding a new book
                lblTitle.Visibility = Visibility.Visible;
                txtTitle.Visibility = Visibility.Visible;

                lblAuthor.Visibility = Visibility.Visible;
                txtAuthor.Visibility = Visibility.Visible;

                lblISBN.Visibility = Visibility.Visible;
                txtISBN.Visibility = Visibility.Visible;

                lblPublisher.Visibility = Visibility.Visible;
                txtPublisher.Visibility = Visibility.Visible;

                UpdateSystemButton.Visibility = Visibility.Visible;
            }
            else
            {
                // No option selected
                MessageBox.Show("Please select an option.");
            }
        }

        private void UpdateDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a SqlConnection named "sqlConnection" initialized elsewhere in your code
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Open the connection
                connection.Open();

                try
                {
                    // Assuming you have a SqlCommand named "sqlCommand" initialized elsewhere in your code
                    using (SqlCommand command = new SqlCommand())
                    {
                        // Set the connection for the command
                        command.Connection = connection;

                        // Assuming you have a table named "Books" with columns "Title", "Author", and "ISBN"
                        string newBookTitle = txtTitle.Text;
                        string newBookAuthor = txtAuthor.Text;
                        int newBookISBN = Convert.ToInt32(txtISBN.Text);
                        string newPublisher = txtPublisher.Text;

                        // Assuming you have a variable "existingBookId" for the book you want to update
                        int existingBookId = GetExistingBookId(newBookISBN); // You need to implement this method to retrieve the existing book ID

                        // Set the SQL UPDATE statement
                        command.CommandText = "INSERT INTO Books (ISBN, Title) VALUES(@ISBN, @Title)";

                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Title", newBookTitle);
                        command.Parameters.AddWithValue("@Author", newBookAuthor);
                        command.Parameters.AddWithValue("@ISBN", newBookISBN);
                        command.Parameters.AddWithValue("@Id", existingBookId);

                        // Execute the UPDATE statement
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Database updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No records were updated.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating database: {ex.Message}");
                }
            }
        }


        private int GetExistingBookId(int existingBookISBN)
        {
            // Assuming you have a SqlConnection named "connection" initialized elsewhere
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // Assuming you have a SqlCommand named "command" initialized elsewhere
                using (SqlCommand command = new SqlCommand("SELECT ISBN FROM Books WHERE ISBN = @ISBN", conn))
                {
                    command.Parameters.AddWithValue("@ISBN", existingBookISBN);

                    // Execute the query and get the result
                    object result = command.ExecuteScalar();

                    // Check if the result is not null
                    if (result != null)
                    {
                        // Convert the result to int (assuming the Id is an integer)
                        conn.Close();
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Handle the case where the book with the specified title was not found
                        MessageBox.Show("Book not found.");
                        conn.Close();
                        return -1; // Or some other value indicating not found
                    }
                }
            }
        }
    }
}
