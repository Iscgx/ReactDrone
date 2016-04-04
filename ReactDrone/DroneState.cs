namespace ReactDrone
{
    public class DroneState
    {
        public DroneState(Location location, DroneStatus status, Axes axes)
        {
            this.Location = location;
            this.Status = status;
            this.Axes = axes;
        }

        public Location Location { get; }

        public DroneStatus Status { get; }

        public Axes Axes { get; }
    }
}
