using MightyLittleGeodesyPcl.Positions;
using Newman.Domain.ViewModels;

namespace Newman.Domain
{
    public class GeoService
    {
        public Position GetPosition(string x, string y)
        {
            var y1 = double.Parse(y.Replace(',','.'));
            var x1 = double.Parse(x.Replace(',', '.'));
            var swePos = new SWEREF99Position(y1, x1, SWEREF99Position.SWEREFProjection.sweref_99_13_30);
            var wgsPos = swePos.ToWGS84();

            return new Position() { Lat = wgsPos.Latitude, Lng = wgsPos.Longitude };
        }
    }
}
