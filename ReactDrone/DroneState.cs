namespace ReactDrone
{
    public class DroneState
    {
        public DroneState(Location location, DroneStatus state, Axes axes)
        {
            this.Location = location;
            this.State = state;
            this.Axes = axes;
        }

        public Location Location { get; }

        public DroneStatus State { get; }

        public Axes Axes { get; }
    }
}
