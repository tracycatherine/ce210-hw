public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthMeters / 1000;
    public override double GetSpeed() => (GetDistance() / _minutes) * 60;
    public override double GetPace() => _minutes / GetDistance();
}