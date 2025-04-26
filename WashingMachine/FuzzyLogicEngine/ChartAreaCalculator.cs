using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Constants;

namespace WashingMachine.FuzzyLogicEngine
{
    public class ChartAreaCalculator
    {

        public List<PointF> calculateGivenArea(FuzzyLogicConstant.OutputType center, double y, int areaId)
        {
            switch (center)
            {
                case FuzzyLogicConstant.OutputType.Rotation:
                    return calculateRotationArea(y, areaId);
                case FuzzyLogicConstant.OutputType.Duration:
                    return calculateDurationArea(y, areaId);
                case FuzzyLogicConstant.OutputType.Detergent:
                    return calculateDetergentArea(y, areaId);
            }

            return new List<PointF>();
        }

        private List<PointF> calculateRotationArea(double y, int areaId)
        {
            double[] d1, d2, d3, d4, d5;
            d1 = new double[] { -5.8, -2.8, 0.5, 1.5 };
            d2 = new double[] { 0.5, 2.75, 5 };
            d3 = new double[] { 2.75, 5, 7.25 };
            d4 = new double[] { 5, 7.25, 9.5 };
            d5 = new double[] { 8.5, 9.5, 12.8, 15.2 };

            List<PointF> points = new List<PointF>();
            double x1 = 0.0;
            double x2 = 0.0;

            switch (areaId)
            {
                case 0:
                    //baslangic...
                    x1 = d1[0] + (y * Math.Abs(d1[0] - d1[1]));
                    x2 = d1[3] - (y * Math.Abs(d1[2] - d1[3]));
                    points.Add(new PointF((float)d1[0], 0));
                    points.Add(new PointF((float)x1, (float)y));
                    points.Add(new PointF((float)x2, (float)y));
                    points.Add(new PointF((float)d1[3], 0));
                    break;
                case 1:
                    x1 = d2[0] + (y * Math.Abs(d2[0] - d2[1]));
                    //x2 = (1 - y) * (d2[1] - d2[2]) + d2[2];
                    x2 = d2[2] - (y * Math.Abs(d2[1] - d2[2]));
                    points.Add(new PointF((float)d2[0], 0));
                    points.Add(new PointF((float)x1, (float)y));
                    points.Add(new PointF((float)x2, (float)y));
                    points.Add(new PointF((float)d2[2], 0));
                    break;
                case 2:
                    x1 = d3[0] + (y * Math.Abs(d3[0] - d3[1]));
                    x2 = d3[2] - (y * Math.Abs(d3[1] - d3[2]));
                    points.Add(new PointF((float)d3[0], 0));
                    points.Add(new PointF((float)x1, (float)y));
                    points.Add(new PointF((float)x2, (float)y));
                    points.Add(new PointF((float)d3[2], 0));
                    break;
                case 3:
                    x1 = d4[0] + (y * Math.Abs(d4[0] - d4[1]));
                    x2 = d4[2] - (y * Math.Abs(d4[1] - d4[2]));
                    points.Add(new PointF((float)d4[0], 0));
                    points.Add(new PointF((float)x1, (float)y));
                    points.Add(new PointF((float)x2, (float)y));
                    points.Add(new PointF((float)d4[2], 0));
                    break;
                case 4:
                    x1 = d5[0] + (y * Math.Abs(d5[0] - d5[1]));
                    x2 = d5[3] - (y * Math.Abs(d5[2] - d5[3]));
                    points.Add(new PointF((float)d5[0], 0));
                    points.Add(new PointF((float)x1, (float)y));
                    points.Add(new PointF((float)x2, (float)y));
                    points.Add(new PointF((float)d5[3], 0));
                    break;
            }

            return points;
        }

        private List<PointF> calculateDetergentArea(double y, int areaId)
        {
            double[] d1 = { 0, 0, 20, 85 };
            double[] d2 = { 20, 85, 150 };
            double[] d3 = { 85, 150, 215 };
            double[] d4 = { 150, 215, 280 };
            double[] d5 = { 215, 280, 300, 300 };

            double x1 = 0.0;
            double x2 = 0.0;

            List<PointF> points = new List<PointF>();

            if (areaId == 0)
            {
                points.Add(new PointF((float)d1[0], 0));
                points.Add(new PointF((float)d1[1], (float)y));
                x1 = d1[3] - (y * (Math.Abs(d1[2] - d1[3])));
                points.Add(new PointF((float)x1, (float)y));
                points.Add(new PointF((float)d1[3], 0));
            }

            else if (areaId == 1)
            {
                points.Add(new PointF((float)d2[0], 0));
                x1 = d2[0] + (y * (Math.Abs(d2[0] - d2[1])));
                //x2 = (1 - y) * (d2[1] - d2[2]) + d2[2];
                points.Add(new PointF((float)x1, (float)y));
                x2 = d2[2] - (y * (Math.Abs(d2[1] - d2[2])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d2[2], 0));
            }

            else if (areaId == 2)
            {
                points.Add(new PointF((float)d3[0], 0));
                x1 = d3[0] + (y * (Math.Abs(d3[0] - d3[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d3[2] - (y * (Math.Abs(d3[1] - d3[2])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d3[2], 0));
            }

            else if (areaId == 3)
            {
                points.Add(new PointF((float)d4[0], 0));
                x1 = d4[0] + (y * (Math.Abs(d4[0] - d4[1])));
                x2 = (1 - y) * (d4[1] - d4[2]) + d4[2];
                points.Add(new PointF((float)x1, (float)y));
                x2 = d4[2] - (y * (Math.Abs(d4[1] - d4[2])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d4[2], 0));
            }

            else if (areaId == 4)
            {
                points.Add(new PointF((float)d5[0], 0));
                x1 = d5[0] + (y * (Math.Abs(d5[0] - d5[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d5[3] - (y * (Math.Abs(d5[2] - d5[3])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d5[3], 0));
            }

            return points;
        }

        private List<PointF> calculateDurationArea (double y, int areaId)
        {
            double[] d1, d2, d3, d4, d5;
            d1 = new double[] { -46.5, -25.28, 22.3, 39.9 };
            d2 = new double[] { 22.3, 39.9, 57.5 };
            d3 = new double[] { 39.9, 57.5, 75.1 };
            d4 = new double[] { 57.5, 75.1, 92.7 };
            d5 = new double[] { 75, 92.7, 111.6, 130 };

            double x1 = 0.0;
            double x2 = 0.0;

            List<PointF> points = new List<PointF>();

            if (areaId == 0)
            {
                points.Add(new PointF((float)d1[0], 0));
                x1 = d1[0] + (y * (Math.Abs(d1[0] - d1[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d1[3] - (y * (Math.Abs(d1[2] - d1[3])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d1[3], 0));
            }

            if (areaId == 1)
            {
                points.Add(new PointF((float)d2[0], 0));
                x1 = d2[0] + (y * (Math.Abs(d2[0] - d2[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d2[2] - (y * (Math.Abs(d2[1] - d2[2])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d2[2], 0));
            }

            if (areaId == 2)
            {
                points.Add(new PointF((float)d3[0], 0));
                x1 = d3[0] + (y * (Math.Abs(d3[0] - d3[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d3[2] - (y * (Math.Abs(d3[1] - d3[2])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d3[2], 0));
            }
            if (areaId == 3)
            {
                points.Add(new PointF((float)d4[0], 0));
                x1 = d4[0] + (y * (Math.Abs(d4[0] - d4[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d4[2] - (y * (Math.Abs(d4[1] - d4[2])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d4[2], 0));
            }

            if (areaId == 4)
            {
                points.Add(new PointF((float)d5[0], 0));
                x1 = d5[0] + (y * (Math.Abs(d5[0] - d5[1])));
                points.Add(new PointF((float)x1, (float)y));
                x2 = d5[3] - (y * (Math.Abs(d5[2] - d5[3])));
                points.Add(new PointF((float)x2, (float)y));
                points.Add(new PointF((float)d5[3], 0));
            }

            return points;
        }
    }
}
