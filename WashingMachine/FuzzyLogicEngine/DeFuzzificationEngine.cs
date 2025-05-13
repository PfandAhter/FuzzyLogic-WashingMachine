using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WashingMachine.Constants;
using WashingMachine.PanelHelper;
using WashingMachine.Rules;
using WashingMachine.Util;
using WashingMachine.Util.DeFuzzificationFunctions;
using WashingMachine.Util.test;

namespace WashingMachine.FuzzyLogicEngine
{

    public class DeFuzzificationEngine
    {
        List<Tuple<double, double>> rotationOutputValueTuple;

        List<Tuple<double, double>> durationOutputValueTuple;

        List<Tuple<double, double>> detergentOutputValueTuple;

        Dictionary<int, List<PointF>> rotationPoints;
        Dictionary<int, List<PointF>> durationPoints;
        Dictionary<int, List<PointF>> detergentPoints;

        private InputPanelHelper inputPanelHelper;

        private List<Rule> suitableRules;

        private ChartAreaCalculator areaCalculator;

        public string labelRotationWeightedAvgText = "";
        public string labelRotationCentroidText = "";
        public string labelDurationWeightedAvgText = "";
        public string labelDurationCentroidText = "";
        public string labelDetergentWeightedAvgText = "";
        public string labelDetergentCentroidText = "";

        public DeFuzzificationEngine(InputPanelHelper inputPanelHelper)
        {
            this.inputPanelHelper = inputPanelHelper;
            this.suitableRules = inputPanelHelper.suitableRules;
            areaCalculator = new ChartAreaCalculator();
            startDeFuzzification();
        }

        public void startDeFuzzification()
        {
            calculateRotation();
            calculateDuration();
            calculateDetergent();
            var weightedAvgCalculationManager = new CalculationManager<Tuple<double, double>>();
            var centroidCalculationManager = new CalculationManager<Dictionary<int, List<PointF>>>();

            weightedAvgCalculationManager.registerStrategy(new WeightedAverageFunction<Tuple<double, double>>(a => a.Item1, b => b.Item2));
            centroidCalculationManager.registerStrategy(new CentroidFunction<Dictionary<int, List<PointF>>>(
                areaNo => areaNo.Keys.FirstOrDefault(),
                areaPoints => areaPoints.Values.FirstOrDefault()
                ));

            labelRotationCentroidText = centroidCalculationManager.calculate("Centroid", new List<Dictionary<int, List<PointF>>> { rotationPoints }).ToString();
            labelDurationCentroidText = centroidCalculationManager.calculate("Centroid", new List<Dictionary<int, List<PointF>>> { durationPoints }).ToString();
            labelDetergentCentroidText = centroidCalculationManager.calculate("Centroid", new List<Dictionary<int, List<PointF>>> { detergentPoints }).ToString();

            labelRotationWeightedAvgText = weightedAvgCalculationManager.calculate("Weighted Avg.", rotationOutputValueTuple).ToString();
            labelDurationWeightedAvgText = weightedAvgCalculationManager.calculate("Weighted Avg.", durationOutputValueTuple).ToString();
            labelDetergentWeightedAvgText = weightedAvgCalculationManager.calculate("Weighted Avg.", detergentOutputValueTuple).ToString();
        }

        private void calculateRotation()
        {
            rotationOutputValueTuple = new List<Tuple<double, double>>();
            rotationPoints = new Dictionary<int, List<PointF>>();

            int areaCounter = 0;
            for (int i = 0; i < 5; i++)
            {

                FuzzyLogicConstant.Rotation rotation = (FuzzyLogicConstant.Rotation)i;
                var rules = suitableRules.Where(a => a.Rotation == rotation);
                Tuple<double, double> maxTupple = null;

                if (rules.Count() > 0)
                {
                    double maxValue = rules.Max(a => a.getIntersections.Min());
                    Rule maxRule = rules.First(a => a.getIntersections.Min() == maxValue);
                    maxTupple = new Tuple<double, double>(maxRule.getIntersections.Min(), FuzzyLogicConstant.getRuleOutputValue(FuzzyLogicConstant.OutputType.Rotation, maxRule));
                    rotationOutputValueTuple.Add(maxTupple);
                }

                if (maxTupple != null)
                {
                    areaCounter++;
                    string labelStr = maxTupple.Item1.ToString().Length > 5 ? maxTupple.Item1.ToString().Substring(0, 5) : maxTupple.Item1.ToString();

                    Chart chart4 = inputPanelHelper.inputForm
                        .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                        .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_RotationResult"))
                        .Controls.OfType<Chart>().FirstOrDefault(chart => chart.Name.Equals("chart4"));

                    Series series = chart4.Series.Any(a => a.Name == "area" +i) ? chart4.Series["area" + i] : new Series("area" + i);
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(175, 255 - (i * 51), i * 51, 255 / (i + 1));
                    series.Points.Clear();

                    var list = areaCalculator.calculateGivenArea(FuzzyLogicConstant.OutputType.Rotation, maxTupple.Item1, i);

                    List<PointF> points = new List<PointF>();

                    foreach (var l in list)
                    {
                        series.Points.AddXY(l.X, l.Y);
                        points.Add(l);
                    }

                    rotationPoints.Add(areaCounter, points);

                    if (!chart4.Series.Contains(series))
                        chart4.Series.Add(series);
                }
            }
        }

        private void calculateDuration()
        {
            durationOutputValueTuple = new List<Tuple<double, double>>();
            durationPoints = new Dictionary<int, List<PointF>>();

            int areaCounter = 0;

            for (int i = 0; i < 5; i++)
            {

                FuzzyLogicConstant.Duration duration = (FuzzyLogicConstant.Duration)i;
                var rules = suitableRules.Where(a => a.Duration == duration);
                Tuple<double, double> maxTupple = null;
                if (rules.Count() > 0)
                {
                    double maxValue = rules.Max(a => a.getIntersections.Min());
                    Rule maxRule = rules.First(a => a.getIntersections.Min() == maxValue);
                    maxTupple = new Tuple<double, double>(maxRule.getIntersections.Min(), FuzzyLogicConstant.getRuleOutputValue(FuzzyLogicConstant.OutputType.Duration, maxRule));
                    durationOutputValueTuple.Add(maxTupple);
                }

                if (maxTupple != null)
                {
                    areaCounter++;
                    string labelStr = maxTupple.Item1.ToString().Length > 5 ? maxTupple.Item1.ToString().Substring(0, 5) : maxTupple.Item1.ToString();

                    Chart chart6 = inputPanelHelper.inputForm
                        .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                        .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DurationResult"))
                        .Controls.OfType<Chart>().FirstOrDefault(chart => chart.Name.Equals("chart6"));

                    Series series = chart6.Series.Any(a => a.Name == "area" + i) ? chart6.Series["area" + i] : new Series("area" + i);
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(175, 255 - (i * 51), i * 51, 255 / (i + 1));
                    series.Points.Clear();

                    var list = areaCalculator.calculateGivenArea(FuzzyLogicConstant.OutputType.Duration, maxTupple.Item1, i);

                    List<PointF> points = new List<PointF>();

                    foreach (var l in list)
                    {
                        series.Points.AddXY(l.X, l.Y);
                        points.Add(l);
                    }

                    durationPoints.Add(areaCounter, points);

                    if (!chart6.Series.Contains(series))
                        chart6.Series.Add(series);
                }
            }
        }

        private void calculateDetergent()
        {
            detergentOutputValueTuple = new List<Tuple<double, double>>();
            detergentPoints = new Dictionary<int, List<PointF>>();

            int areaCounter = 0;
            for (int i = 0; i < 5; i++)
            {
                FuzzyLogicConstant.Detergent detergent = (FuzzyLogicConstant.Detergent)i;
                var rules = suitableRules.Where(a => a.Detergent == detergent);
                Tuple<double, double> maxTupple = null;
                if (rules.Count() > 0)
                {
                    double maxValue = rules.Max(a => a.getIntersections.Min());
                    Rule maxRule = rules.First(a => a.getIntersections.Min() == maxValue);
                    maxTupple = new Tuple<double, double>(maxRule.getIntersections.Min(), FuzzyLogicConstant.getRuleOutputValue(FuzzyLogicConstant.OutputType.Detergent, maxRule));
                    detergentOutputValueTuple.Add(maxTupple);
                }

                if (maxTupple != null)
                {
                    areaCounter++;
                    string labelStr = maxTupple.Item1.ToString().Length > 5 ? maxTupple.Item1.ToString().Substring(0, 5) : maxTupple.Item1.ToString();

                    Chart chart5 = inputPanelHelper.inputForm
                        .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                        .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DetergentResult"))
                        .Controls.OfType<Chart>().FirstOrDefault(chart => chart.Name.Equals("chart5"));

                    Series series = chart5.Series.Any(a => a.Name == "area" + i) ? chart5.Series["area" + i] : new Series("area" + i);
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(175, 255 - (i * 51), i * 51, 255 / (i + 1));
                    series.Points.Clear();

                    var list = areaCalculator.calculateGivenArea(FuzzyLogicConstant.OutputType.Detergent, maxTupple.Item1, i);

                    List<PointF> points = new List<PointF>();

                    foreach (var l in list)
                    {
                        series.Points.AddXY(l.X, l.Y);
                        points.Add(l);
                    }

                    detergentPoints.Add(areaCounter,points);

                    if (!chart5.Series.Contains(series))
                        chart5.Series.Add(series);
                }
            }
        }
    }
}
