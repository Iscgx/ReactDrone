namespace ReactDrone
{
    public class Axes
    {
        public Axes(double roll, double pitch, double yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public double Roll { get; }

        public double Pitch { get; }

        public double Yaw { get; }

        public override string ToString()
        {
            return
                $"{{{nameof(Roll)}:{Roll:#####.#####}, {nameof(Pitch)}:{Pitch:#####.#####}, {nameof(Yaw)}:{Yaw:#####.#####}}}";
        }
    }
}