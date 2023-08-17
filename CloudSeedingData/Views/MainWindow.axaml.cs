using Avalonia.Controls;
using ScottPlot;
using ScottPlot.Avalonia;
using ScottPlot.Plottable;
using ScottPlot.Statistics;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudSeedingData.Views;

public partial class MainWindow : Window {
    static string Directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    public MainWindow() {
        InitializeComponent();

        AvaPlot1.Plot.XAxis.Grid(false);
        AvaPlot1.Plot.XTicks(new string[] { "Control" , "Seeded" });

        string[] lines = ReadLines("CloudSeedingData.csv").Skip(1).ToArray();

        double[] control = new double[lines.Length];
        double[] seeded = new double[lines.Length];

        for (int i = 0; i < lines.Length; i++) {
            string line = lines[i];
            string[] numbers = line.Split(',');
            control[i] = double.Parse(numbers[0]);
            seeded[i] = double.Parse(numbers[1]);
        }

        Population population_control = new Population(control);
        Population population_seeded = new Population(seeded);
        PopulationPlot populationPlot = AvaPlot1.Plot.AddPopulations(new Population[] { population_control , population_seeded});
        populationPlot.DistributionCurve = false;
        populationPlot.DataFormat = PopulationPlot.DisplayItems.ScatterOnBox;
        populationPlot.DataBoxStyle = PopulationPlot.BoxStyle.BoxMedianQuartileOutlier;
        AvaPlot1.Refresh();
    }

    internal static IEnumerable<string> ReadLines(string fileName) {
        StreamReader reader;
        string? line;
        reader = new(Directory + @"\" + fileName);
        reader.ReadLine();
        while ((line = reader.ReadLine()) is not null) {
            yield return line;
        }
    }
}
