using System.Globalization;
using MightyLittleGeodesyPcl.Positions;
using Newman.Domain.ViewModels;

namespace Newman.Domain
{
    public class GeoService
    {
        static GeoService()
        {
            _cultureInfo = new CultureInfo("sv-se");
        }
        private static readonly CultureInfo _cultureInfo;

        public Position GetPosition(string x, string y)
        {
            var y1 = double.Parse(y, _cultureInfo);
            var x1 = double.Parse(x, _cultureInfo);
            var swePos = new SWEREF99Position(y1, x1, SWEREF99Position.SWEREFProjection.sweref_99_13_30);
            var wgsPos = swePos.ToWGS84();

            return new Position() { Lat = wgsPos.Latitude, Lng = wgsPos.Longitude };
        }

        public Position GetPositionFromRt90(string x, string y)
        {
            var y1 = double.Parse(y, _cultureInfo);
            var x1 = double.Parse(x, _cultureInfo);
            var swePos = new RT90Position(x1, y1, RT90Position.RT90Projection.rt90_2_5_gon_v);
            var wgsPos = swePos.ToWGS84();

            return new Position() { Lat = wgsPos.Latitude, Lng = wgsPos.Longitude };
        }
    }
}
