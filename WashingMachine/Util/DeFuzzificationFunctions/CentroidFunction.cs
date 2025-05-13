
using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Union;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Util.test;

namespace WashingMachine.Util.DeFuzzificationFunctions
{
    public class CentroidFunction<T> : ICalculationStrategy<T>
    {
        private readonly Func<T, int> areaNo;
        private readonly Func<T, List<PointF>> areaPoints;


        private Dictionary<int, List<PointF>> points;
        public string name => "Centroid";
        public CentroidFunction(Func<T, int> areaNo, Func<T,List<PointF>> areaPoints)
        {
            this.areaNo = areaNo;
            this.areaPoints = areaPoints;
        }

        public double calculate(IEnumerable<T> records)
        {
            if(records == null || !records.Any())
                return 0.0;


            var firstRecord = records.FirstOrDefault();

            if (firstRecord is Dictionary<int,List<PointF>> pointList)
            {
                points = pointList;
            }

            var geometryFactory = new GeometryFactory();
            List<Polygon> polygons = cretepoint(points, geometryFactory);

            Geometry unionGeometry = CascadedPolygonUnion.Union(polygons.Cast<Geometry>().ToList());


            return unionGeometry.Area * 2;
        }

        static List<Polygon> cretepoint(Dictionary<int,List<PointF>> pointList, GeometryFactory factory)
        {
            //var linearRing = factory.CreateLinearRing(coordinates);
            List<Polygon> polygons = new List<Polygon>();

            foreach (var kvp in pointList)
            {
                int areaNo = kvp.Key;
                List<PointF> points = kvp.Value;

                Coordinate[] coordinates = new Coordinate[points.Count + 1];
                int index = 0;

                foreach(PointF point in points)
                {
                    coordinates[index] = new Coordinate(point.X,point.Y);
                    index++;
                }
                coordinates[index] = new Coordinate(points[0].X, points[0].Y);

                polygons.Add(CreatePolygon(coordinates,factory));
            }

            return polygons;
        }

        static Polygon CreatePolygon(Coordinate[] coordinates, GeometryFactory factory)
        {
            var linearRing = factory.CreateLinearRing(coordinates);
            return factory.CreatePolygon(linearRing);
        }
    }
}
