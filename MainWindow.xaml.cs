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

namespace LibrarySystemforPortfolio
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

           private void AddNewBook_Click(object sender, RoutedEventArgs e) 
           {
            book_title_text.Text = "Title:";
            book_author_text.Text = "Author:";
            book_publisher_text.Text = "Publisher:";
            book_isbn_text.Text = "ISBN:";

            TextBox title_text_box = new TextBox();
            title_text_box.Text = "Input the book title";
            Grid.SetRow(title_text_box, 0);
            Grid.SetColumn(title_text_box, 3);

            TextBox author_text_box = new TextBox();
            author_text_box.Text = "Input the book author";
            Grid.SetRow(title_text_box, 1);
            Grid.SetColumn(title_text_box, 3);

            TextBox publisher_text_box = new TextBox();
            publisher_text_box.Text = "Input the book publisher";
            Grid.SetRow(title_text_box, 2);
            Grid.SetColumn(title_text_box, 3);

            TextBox ISBN_text_box = new TextBox();
            ISBN_text_box.Text = "Input the book ISBN";
            Grid.SetRow(title_text_box, 3);
            Grid.SetColumn(title_text_box, 3);
        }

        private void AddExistingBook_Click(object sender, RoutedEventArgs e)
        {
            instruction_text.Text = "Please Search for the Book you Wish to Add";
            book_title_text.Text = "Title:";
            book_author_text.Text = "Author:";
            book_publisher_text.Text = "Publisher:";
            book_isbn_text.Text = "ISBN:";

        }
    }
}
