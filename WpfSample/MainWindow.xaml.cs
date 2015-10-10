using Huracan.Hexagon;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RangeFlat_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Flat,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = Hex.Zero.Range(5);
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void RangePointy_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = Hex.Zero.Range(5);
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Ring_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = Hex.Zero.Ring(4);
            byte color = 100;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Spiral_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = Hex.Zero.Spiral(5);
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = Hex.RectangleY(-2, -2, 2, 2);
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = Hex.FromOffsetY(-2, -3).LineTo(Hex.FromOffsetY(3, 2));
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void LineOfSight_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> blocked = new List<Hex>();
            blocked.Add(Hex.FromOffsetY(1, 1));
            blocked.Add(Hex.FromOffsetY(-1, -1));
            foreach (Hex hex in blocked)
            {
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }

            List<Hex> range = Hex.Zero.Range(5);
            List<Hex> hexes = new List<Hex>();
            foreach (Hex hex in range)
            {
                if (Hex.Zero.LineOfSight(hex, blocked)) hexes.Add(hex);
            }

            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = new List<Hex>();
            Hex start = Hex.FromOffsetY(3, 3);
            hexes.Add(start);
            hexes.Add(start.Rotate(60));
            hexes.Add(start.Rotate(120));
            hexes.Add(start.Rotate(180));
            hexes.Add(start.Rotate(240));
            hexes.Add(start.Rotate(300));
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Reachable_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> blocked = new List<Hex>();
            blocked.Add(Hex.FromOffsetY(2, -1));
            blocked.Add(Hex.FromOffsetY(2, 0));
            blocked.Add(Hex.FromOffsetY(2, 1));
            blocked.Add(Hex.FromOffsetY(2,2));
            foreach (Hex hex in blocked)
            {
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(200, 0, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }

            List<Hex> hexes = Hex.Zero.Rechable(5, blocked);
            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            DrawSurface.Children.Clear();

            Layout layout = new Layout(Orientation.Pointy,
                new Point(DrawSurface.ActualWidth / 20, DrawSurface.ActualWidth / 20),
                new Point(DrawSurface.ActualWidth / 2, DrawSurface.ActualHeight / 2)
            );

            List<Hex> hexes = new List<Hex>();
            hexes.Add(Hex.FromOffsetY(-3, -3));
            hexes.Add(Hex.FromOffsetY(-3, 3));
            hexes.Add(Hex.FromOffsetY(3, 3));
            hexes.Add(Hex.FromOffsetY(3, -3));
            hexes = new List<Hex>(Hex.Polygon(hexes));

            byte color = 0;
            foreach (Hex hex in hexes)
            {
                color += 20;
                PointCollection points = new PointCollection();
                Point[] corners = layout.Corners(hex);
                foreach (Point p in corners)
                {
                    points.Add(new Point(p.X, p.Y));
                }
                Polygon polygon = new Polygon();
                polygon.Points = points;
                polygon.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                polygon.Fill = new SolidColorBrush(Color.FromRgb(color, 100, 0));
                polygon.StrokeThickness = 1;
                DrawSurface.Children.Add(polygon);
            }
        }
    }
}
