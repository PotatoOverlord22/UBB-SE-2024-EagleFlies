using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeBuddies.Views.UserControls
{
    public partial class DrawingBoard : UserControl
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Brush drawingColor = Brushes.Black;
        private double penSize = 1;

        public DrawingBoard()
        {
            InitializeComponent();
        }

        private void PenColor(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Color selectedColor = (Color)(e.NewValue ?? Colors.Black);
            SolidColorBrush brush = new SolidColorBrush(selectedColor);
            drawingColor = brush;
        }

        private void IncreasePenSize(object sender, RoutedEventArgs e)
        {
            penSize += 1;
        }

        private void DecreasePenSize(object sender, RoutedEventArgs e)
        {
            penSize = Math.Max(1, penSize - 1);
        }

        private void EraserColor(object sender, RoutedEventArgs e)
        {
            drawingColor = DrawingCanvas.Background;
        }

        private void BackgroundColor(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Color selectedColor = (Color)(e.NewValue ?? Colors.Black);
            SolidColorBrush brush = new SolidColorBrush(selectedColor);
            DrawingCanvas.Background = brush;
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.GetPosition(DrawingCanvas);
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                Line line = new Line
                {
                    X1 = lastPoint.X,
                    Y1 = lastPoint.Y,
                    X2 = currentPoint.X,
                    Y2 = currentPoint.Y,
                    Stroke = drawingColor,
                    StrokeThickness = penSize
                };

                DrawingCanvas.Children.Add(line);
                lastPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }
    }
}