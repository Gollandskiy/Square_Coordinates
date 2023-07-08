using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Square_Coordinates
{
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point lastMousePosition;

        private void btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.GetPosition(btn.Parent as UIElement);
            btn.CaptureMouse();
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.GetPosition(btn.Parent as UIElement);

                double deltaX = currentMousePosition.X - lastMousePosition.X;
                double deltaY = currentMousePosition.Y - lastMousePosition.Y;

                Canvas.SetLeft(btn, Canvas.GetLeft(btn) + deltaX);
                Canvas.SetTop(btn, Canvas.GetTop(btn) + deltaY);

                lastMousePosition = currentMousePosition;

                UpdateCoordinates();
            }
        }

        private void btn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            btn.ReleaseMouseCapture();
        }

        private void UpdateCoordinates()
        {
            double left = Canvas.GetLeft(btn);
            double top = Canvas.GetTop(btn);

            txtX.Text = left.ToString();
            txtY.Text = top.ToString();
        }
    }
}
