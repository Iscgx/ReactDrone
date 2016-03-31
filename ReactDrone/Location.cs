namespace ReactDrone
{
    public class Location
    {
        public Location(double latitude, double longitude, double altitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
        }

        public double Altitude { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}