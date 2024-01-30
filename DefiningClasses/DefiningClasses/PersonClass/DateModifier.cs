namespace PersonClass
{
    public class DateModifier
    {
        private int diffrenceInDays;
        private readonly DateTime firstDate;
        private readonly DateTime secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            this.firstDate = DateTime.Parse(firstDate);
            this.secondDate = DateTime.Parse(secondDate);
        }

        // Option 1: Property
        public int DifferenceInDays
        {
            get
            {
                return diffrenceInDays = Math.Abs((int)(firstDate - secondDate).TotalDays);
            }
        }

        // Option 2: Method
        public int CalculateDifferenceInDays()
        {
            return Math.Abs((int)(firstDate - secondDate).TotalDays);
        }

    }
}
