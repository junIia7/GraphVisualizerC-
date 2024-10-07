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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for InpData.xaml
    /// </summary>
    public partial class InpData : Page
    {

        private readonly MainWindow mainWindow;
        public InpData(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            Style es = FindResource("EasyStyle") as Style;
            btnadd.Style = es;
            btnadd.MouseEnter += OnMouse;
            btnadd.MouseLeave += OffMouse;
            cheto();
        }

        List<List<int>> GraphMatrix = new List<List<int>>(0);
        List<int> NameArray = new List<int>(); //Так как индексация матрицы не совпадает с именами вершин

        HashSet<int> list = new HashSet<int>();

        // StackPanel btnstack = new StackPanel();
        
        Button btnadd = new Button
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            Width = 145,
            Height = 45,
            Content = "Добавить вершину"
        };

        private void Letsgo()
        {
            if (GraphMatrix.Count > 0)
                mainWindow.mainFrame.Navigate(new Graph(mainWindow, GraphMatrix, NameArray));
        }

        private void FindASus()
        {
            StackPanel MainVertex, Adj;
            for (int i = 0; i < MainStack.Children.Count - 1; i++)
            {
                MainVertex = MainStack.Children[i] as StackPanel;
                for (int j = 4; MainVertex.Children.Count > 4 && j < MainVertex.Children.Count; j++)
                {
                    Adj = MainVertex.Children[j] as StackPanel;
                    TextBox t = Adj.Children[1] as TextBox; // 0 это "Вершина _" или "Расстояние _"
                    t.BorderBrush = Brushes.Black;

                    if (!int.TryParse(t.Text, out int n) && n <= 0)
                        t.BorderBrush = Brushes.Red;
                }
            }
        }

        private void CreateMatrix(object sender, RoutedEventArgs e)
        {
            if (!CheckValid())
            {
                FindASus();
                return;
            }

            StackPanel MainVertex, Adj;
            for (int i = 0; i < MainStack.Children.Count - 1; i++) // по первой строке(по "главным" вершинам)
            {
                MainVertex = MainStack.Children[i] as StackPanel;
                TextBlock t = MainVertex.Children[1] as TextBlock; // 1 потому что 0 это DelVertex

                int.TryParse(t.Text.Substring(8), out int n);
                NameArray.Add(n); // именуем наш массив имен
            }

            for (int i = 0; i < MainStack.Children.Count - 1; i++) // по первой строке(по "главным" вершинам)
            {
                MainVertex = MainStack.Children[i] as StackPanel;
                for (int j = 4; j < MainVertex.Children.Count; j += 2) // по каждому столбцу (по смежным)
                {
                    Adj = MainVertex.Children[j] as StackPanel;

                    TextBox t = Adj.Children[1] as TextBox; // 0 это "Вершина"
                    int.TryParse(t.Text, out int n);

                    if(!NameArray.Contains(n))
                        NameArray.Add(n);
                }
            } /* Может можно объединить два цикла в один */

            for (int i = 0; i < NameArray.Count; i++) // Создаем нужную матрицу
            {
                List<int> row = new List<int>();
                for (int j = 0; j < NameArray.Count; j++)
                    row.Add(0); // начальное значение для каждой ячейки
                GraphMatrix.Add(row);
            }

            bool flag = true;

            for (int i = 0; i < MainStack.Children.Count - 1; i++) // по первой строке(по "главным" вершинам) -1 чтобы кроме кнопки
            {
                MainVertex = MainStack.Children[i] as StackPanel;
                // главную вершину берем
                TextBlock mt = MainVertex.Children[1] as TextBlock; // 1 потому что 0 это DelVertex
                int.TryParse(mt.Text.Substring(8), out int n1); // преобразуем в число номер вершины

                int indofn1 = NameArray.IndexOf(n1);

                for (int j = 4; j < MainVertex.Children.Count; j += 2) // по каждому столбцу (по смежным)
                {
                    Adj = MainVertex.Children[j] as StackPanel;
                    TextBox t = Adj.Children[1] as TextBox; // 0 это "Вершина _"
                    int.TryParse(t.Text, out int n2); // в число номер второстепенной вершины
                    t.BorderBrush = Brushes.Black;

                    int indofn2 = NameArray.IndexOf(n2);

                    Adj = MainVertex.Children[j + 1] as StackPanel;
                    t = Adj.Children[1] as TextBox; // 0 это "Расстояние _"
                    int.TryParse(t.Text, out int dist);
                    
                    if (GraphMatrix[indofn1][indofn2] != 0 &&
                        GraphMatrix[indofn2][indofn1] != 0 &&
                        GraphMatrix[indofn1][indofn2] != dist &&
                        GraphMatrix[indofn2][indofn1] != dist)
                    {
                        GraphMatrix[indofn1][indofn2] = -1;
                        GraphMatrix[indofn2][indofn1] = -1;
                        MyFunc(i, j + 1);
                        flag = false;
                    }
                    else
                    {
                        GraphMatrix[indofn1][indofn2] = dist;
                        GraphMatrix[indofn2][indofn1] = dist;
                    }
                }
            }

            for (int i = 0; i < MainStack.Children.Count - 1; i++) // по первой строке(по "главным" вершинам) -1 чтобы кроме кнопки
            {
                MainVertex = MainStack.Children[i] as StackPanel;
                // главную вершину берем
                TextBlock mt = MainVertex.Children[1] as TextBlock; // 1 потому что 0 это DelVertex
                int.TryParse(mt.Text.Substring(8), out int n1); // преобразуем в число номер вершины

                int indofn1 = NameArray.IndexOf(n1);

                for (int j = 4; j < MainVertex.Children.Count; j += 2) // по каждому столбцу (по смежным)
                {
                    Adj = MainVertex.Children[j] as StackPanel;
                    TextBox t = Adj.Children[1] as TextBox; // 0 это "Вершина _"
                    int.TryParse(t.Text, out int n2); // в число номер второстепенной вершины
                    t.BorderBrush = Brushes.Black;

                    int indofn2 = NameArray.IndexOf(n2);

                    Adj = MainVertex.Children[j + 1] as StackPanel;
                    t = Adj.Children[1] as TextBox; // 0 это "Расстояние _"
                    int.TryParse(t.Text, out int dist);

                    if (GraphMatrix[indofn1][indofn2] < 0 &&
                        GraphMatrix[indofn2][indofn1] < 0)
                        t.BorderBrush = Brushes.Red;
                    else
                        t.BorderBrush = Brushes.Black;
                }
            }

            if (flag)
                Letsgo();
            else
            {
                GraphMatrix.Clear();
                NameArray.Clear();
                return;
            }
        }

        private void MyFunc(int i, int j)
        {
            StackPanel MainVertex = MainStack.Children[i] as StackPanel;
            StackPanel Adj = MainVertex.Children[j] as StackPanel;

            TextBox t = Adj.Children[1] as TextBox; // 0 это "Вершина"
            t.BorderBrush = Brushes.Red;
        }

        private void cheto()
        {
            list.Add(0);

            btnadd.Click += Create_Vertex;

            // btnstack.Children.Add(btnadd);

            MainStack.Children.Add(btnadd);
        }

        private bool CheckValid()
        {
            StackPanel MainVertex, Adj;
            for (int i = 0; i < MainStack.Children.Count - 1; i++)
            {
                MainVertex = MainStack.Children[i] as StackPanel;
                for (int j = 4; MainVertex.Children.Count > 4 && j < MainVertex.Children.Count; j++)
                {
                    Adj = MainVertex.Children[j] as StackPanel;
                    TextBox t = Adj.Children[1] as TextBox; // 0 это "Вершина _" или "Расстояние _"
                    if (!int.TryParse(t.Text, out int n))
                        return false;
                }
            }
            return true;
        }

        private void Remove_Vertex(object sender, RoutedEventArgs e)
        {
            StackPanel s = new StackPanel();
            Button clickedButton = sender as Button;
            for (int i = 0; i < MainStack.Children.Count; i++)
            {
                s = MainStack.Children[i] as StackPanel;
                if (s != null && s.Children.Contains(clickedButton))
                {
                    TextBlock t = s.Children[1] as TextBlock;
                    int.TryParse(t.Text.Substring(8), out int n);
                    list.Remove(n);
                    break;
                }
            }

            while (s != null && s.Children.Count > 0)
                s.Children.Remove(s.Children[0]);

            MainStack.Children.Remove(s);
        }

        private void Create_Vertex(object sender, RoutedEventArgs e)
        {
            Scroller.ScrollToHorizontalOffset(10000);
            int i = 1;
            while (list.Contains(i))
                i++;
            list.Add(i);

            StackPanel sp = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Left
            };

            Style es = FindResource("EasyStyle") as Style;

            Button DelVertex = new Button
            {
                Width = 135,
                Height = 45,
                Content = "Удалить вершину",
                Style = es,
                Margin = new Thickness(10)
            };
            DelVertex.Click += Remove_Vertex;
            DelVertex.MouseEnter += OnMouse;
            DelVertex.MouseLeave += OffMouse;

            TextBlock VertexName = new TextBlock
            {
                Text = $"Вершина {i}",
                FontSize = 20,
                Width = 135,
                Height = 45,
            };

            Button AddAdj = new Button
            {
                Width = 135,
                Height = 45,
                Content = "Добавить смежную",
                Style = es,
            };
            AddAdj.Click += AddAdjacent;
            AddAdj.MouseEnter += OnMouse;
            AddAdj.MouseLeave += OffMouse;

            Button DelAdj = new Button
            {
                Width = 135,
                Height = 45,
                Content = "Удалить смежную",
                Style = es,
            };
            DelAdj.Click += DelAdjacent;
            DelAdj.MouseEnter += OnMouse;
            DelAdj.MouseLeave += OffMouse;

            sp.Children.Add(DelVertex);
            sp.Children.Add(VertexName);
            sp.Children.Add(AddAdj);
            sp.Children.Add(DelAdj);

            sp.Children[3].Visibility = Visibility.Hidden;

            MainStack.Children.Add(sp);
            MainStack.Children.Remove(btnadd);
            MainStack.Children.Add(btnadd);
        }

        private void DelAdjacent(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            StackPanel s = new StackPanel();
            for (int i = 0; i < MainStack.Children.Count; i++)
            {
                s = MainStack.Children[i] as StackPanel;
                if (s != null && s.Children.Contains(clickedButton))
                    break;
            }

            s.Children.Remove(s.Children[s.Children.Count - 1]);
            s.Children.Remove(s.Children[s.Children.Count - 1]);

            if (s.Children.Count < 5)
                s.Children[3].Visibility = Visibility.Hidden;
        }

        private void AddAdjacent(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            StackPanel s = new StackPanel();
            for (int i = 0; i < MainStack.Children.Count; i++)
            {
                s = MainStack.Children[i] as StackPanel;
                if (s != null && s.Children.Contains(clickedButton))
                    break;
            }

            StackPanel VertexNameSP = new StackPanel();
            VertexNameSP.Orientation = Orientation.Horizontal;

            TextBlock tb1 = new TextBlock
            {
                Text = "-Вершина",
                FontSize = 15,
                Width = 80,
                Height = 30
            };

            TextBox VertexName = new TextBox
            {
                Width = 50,
                Height = 30,
                FontSize = 15,
                BorderBrush = Brushes.Black,
                Background = Brushes.LightBlue
            };

            VertexNameSP.Children.Add(tb1);
            VertexNameSP.Children.Add(VertexName);

            StackPanel VertexDistanceSP = new StackPanel();
            VertexDistanceSP.Orientation = Orientation.Horizontal;

            TextBlock tb2 = new TextBlock
            {
                Text = "Расстояние",
                FontSize = 15,
                Width = 80,
                Height = 30,
            };

            TextBox VertexDist = new TextBox
            {
                Width = 50,
                Height = 30,
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center,
                BorderBrush = Brushes.Black,
                Background = Brushes.LightBlue
            };

            VertexDistanceSP.Children.Add(tb2);
            VertexDistanceSP.Children.Add(VertexDist);

            s.Children[3].Visibility = Visibility.Visible;

            s.Children.Add(VertexNameSP);
            s.Children.Add(VertexDistanceSP);
        }

        private void OnMouse(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = Brushes.LightSalmon;
        }
        private void OffMouse(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = Brushes.LightBlue;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {

            mainWindow.mainFrame.GoBack();
        }
    }
}