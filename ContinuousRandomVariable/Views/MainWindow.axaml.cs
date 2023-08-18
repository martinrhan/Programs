using Avalonia.Controls;
using System;

namespace ContinuousRandomVariable.Views;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        static double Square(double x) {
            return x * x;
        }
        static double F(double x) {
            return Math.Pow(Math.E, -x) / Square(1 + Math.Pow(Math.E, -x));
        }

        double[] array_y = new double[10000];
        double max_x = 100;
        for (int i = 0; i < array_y.Length; i++) {
            double x = (double)i / (double)array_y.Length * max_x;
            double y = F(x);
            array_y[i] = y;
        }

        AvaPlot1.Plot.AddSignal(array_y, max_x);

        AvaPlot1.Refresh();
    }
}
