using Huracan;
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

namespace WpfSample
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

        private void ButtonDrawFlatGrid_Click(object sender, RoutedEventArgs e)
        {
            Layout layout = new Layout(Layout.Flat,
                new Point2D(DrawSurface.ActualWidth / 10, DrawSurface.ActualWidth / 10),
                new Point2D(DrawSurface.ActualWidth / 2, DrawSurface.ActualWidth / 2)
            );
            drawGrid(layout);
        }

        private void ButtonDrawPointyGrid_Click(object sender, RoutedEventArgs e)
        {
            Layout layout = new Layout(Layout.Pointy,
                new Point2D(DrawSurface.ActualWidth / 10, DrawSurface.ActualWidth / 10),
                new Point2D(DrawSurface.ActualWidth / 2, DrawSurface.ActualWidth / 2)
            );
            drawGrid(layout);
        }

        void drawGrid(Layout layout)
        {
            // Clear draw surface
            DrawSurface.Children.Clear();

            // Create list of hexes
            List<Hex> hexes = new List<Hex>();
            Hex origin = Hex.Zero;
            hexes.Add(origin);
            for (int i = 0; i < 12; ++i)
            {
                hexes.Add(origin.Add(Hex.Unit[i]));
            }

            // Draw hexes to surface
            SolidColorBrush black = new SolidColorBrush(Colors.Black);
            SolidColorBrush grey = new SolidColorBrush(Colors.LightGray);
            foreach (Hex hex in hexes)
            {
                PointCollection points = new PointCollection();
                List<Point2D> corners = layout.PolygonCorners(hex);
                foreach (Point2D p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = black;
                polygon.Fill = grey;
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }
    }
}
