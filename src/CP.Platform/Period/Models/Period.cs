namespace CP.Platform.Period.Models
{
    public class Period
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public Period()
        {
        }

        public Period(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public override string ToString()
        {
            return $"{Month}/{Year}";
        }

        public bool Equals(Period other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Year == other.Year && Month == other.Month;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Period) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Year * 397) ^ Month;
            }
        }

        #region static

        public static Period Parse(string value)
        {
            var values = value.Split('-');

            return new Period(int.Parse(values[0]), int.Parse(values[1]));
        }

        public static bool operator ==(Period first, Period second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            {
                return true;
            }

            if (ReferenceEquals(first, null))
            {
                return false;
            }
            
            return first.Equals(second);
        }

        public static bool operator !=(Period first, Period second)
        {
            return !(first == second);
        }

        #endregion
    }
}