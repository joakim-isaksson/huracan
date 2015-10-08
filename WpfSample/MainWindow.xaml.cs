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
            DrawSurface.Children.Clear();

            List<Hex> hexes = new List<Hex>();
            for (int y = -10; y < 10; ++y)
            {
                for (int x = -10; x < 10; ++x)
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

            // ===========================

            hexes = Hex.FromOffsetY(0, 0).Spiral(4);
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 3;
                fill = new SolidColorBrush(Color.FromRgb(color, color, color));
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
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            ));
        }

        void ButtonDrawPointyGrid_Click(object sender, RoutedEventArgs e)
        {
            drawGrid(new Layout(Layout.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            ));
        }

    }
}
