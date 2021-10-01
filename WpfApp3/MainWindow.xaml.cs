using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(b.Text);
            using (StreamReader reader = new StreamReader(data))
            {
                string str = reader.ReadToEnd();
                string word = "";
                List<string> list = new List<string>(10);
                List<Slovar> slovars = new List<Slovar>();

                for (int i = 0; i < str.Length; i++)
                {
                    word += str[i];
                    if (str[i] == ' ')
                    {
                        list.Add(word);
                        word = "";
                    }
                }

                int count = 0;
                bool f = false;
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                    {
                        foreach (var item in slovars)
                            if (item.name == list[i])
                            {
                                f = true;
                                break;
                            }
                            else f = false;
                    }
                    if (!f)
                    {
                        for (int j = i; j < list.Count; j++)
                        {
                            if (list[i] == list[j])
                            {
                                count++;
                            }
                        }
                        slovars.Add(new Slovar() { name = list[i], count = count });
                        count = 0;
                    }
                }

                var sortedUsers = from u in slovars
                                  orderby u.count descending
                                  select u;

                for (int i = 0; i < slovars.Count; i++)
                {
                    listbox.Items.Add(sortedUsers.ElementAt(i));
                }
            }

            data.Close();
        
        }



    }
}
