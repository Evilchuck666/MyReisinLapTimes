namespace MyReisinLapTimes
{
    internal class TimeSpanComparer : IComparer<TimeSpan>
    {
        public int Compare(TimeSpan x, TimeSpan y)
        {
            return x.CompareTo(y);
        }
    }
}
