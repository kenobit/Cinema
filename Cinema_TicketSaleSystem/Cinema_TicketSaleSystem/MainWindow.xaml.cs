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
using System.IO;
using Microsoft.Win32;



namespace Cinema_TicketSaleSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] bt = new Button[9];
        public List <string> hallsFolderPathes = new List<string>();
        public List <List<List<string>>> AllHalls = new List<List<List<string>>>();  
        
        public MainWindow()
        {
            InitializeComponent();
            double y = 0, x = 0;
            for (int i = 0; i < bt.Length; i++)
            {
                bt[i] = new Button();
                bt[i].Width = 30;
                bt[i].Height = 30;
                if (i % 3 == 0 && i != 0)
                {
                    x = 0;
                    y += (bt[i].Height + 31);
                }

                bt[i].Content = (i + 1).ToString();
                bt[i].Margin = new Thickness(x, y, 0, 0);
                x += (bt[i].Width + 31);
                bt[i].Click += MainWindow_Click;
                bt[i].Tag = i;

            }
        }

        void HallFilesParser()
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Hall files(*.hl)|*.HL";
            dlg.CheckFileExists = true;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == true)
            {
                hallsFolderPathes = dlg.FileNames.ToList();
            }
            
            foreach (var item in hallsFolderPathes)
            {
                string[] columns;
                List<List<string>> OneHall = new List<List<string>>();
                columns = File.ReadLines(item.ToString()).ToArray();
                List<string> rows = new List<string>();
                foreach (var i in columns)
                {
                    rows = i.Split('.').ToList();
                    OneHall.Add(rows);
                    foreach (var t in rows)
                    {
                        MessageBox.Show(t);
                    }
                }
                if (OneHall.Capacity == 0)
                {
                    MessageBox.Show("File not contains hall structure!","Application ERROR");
                    Close();
                }
                AllHalls.Add(OneHall);
            }
        }
        public void GridCreator()
        {

        }

        void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Content.ToString() + " " + (sender as Button).Tag);
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < bt.Length; i++)
            {
                HallGrid.Children.Add(bt[i]);
                
            }
            HallFilesParser();
        }
    }
}
