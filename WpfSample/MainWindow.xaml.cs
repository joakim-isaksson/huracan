using Huracan.Hexagon;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
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

        void drawGrid(Layout layout)
        {
            // Clear draw surface
            DrawSurface.Children.Clear();

            // Create list of hexes
            List<Hex> hexes = new List<Hex>();
            for (int y = 0; y < 10; ++y)
            {
                for (int x = 0; x < 10; ++x)
                {
                    hexes.Add(Hex.FromOffsetY(x, y));
                }
            }

            SolidColorBrush stroke = new SolidColorBrush(Colors.Black);
            SolidColorBrush fill = new SolidColorBrush(Colors.LightGray);
            foreach (Hex hex in hexes)
            {
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = stroke;
                polygon.Fill = fill;
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        void ButtonDrawFlatGrid_Click(object sender, RoutedEventArgs e)
        {
            drawGrid(new Layout(Layout.Flat,
                new Point(DrawSurface.ActualWidth / 10, DrawSurface.ActualWidth / 10),
                new Point(0, 0)
            ));
        }

        void ButtonDrawPointyGrid_Click(object sender, RoutedEventArgs e)
        {
            drawGrid(new Layout(Layout.Pointy,
                new Point(DrawSurface.ActualWidth / 10, DrawSurface.ActualWidth / 10),
                new Point(0, 0)
            ));
        }

    }
}
