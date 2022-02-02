using System;

namespace IParking.Domain.Services.Parking.ParkingCalculators
{
    public abstract class ParkingCalculator
    {
        protected decimal DailyFee { get; private set; }
        protected decimal NightlyFee { get; private set; }

        public ParkingCalculator(
             decimal DailyFee,
             decimal NightlyFee
            )
        {
            this.DailyFee = DailyFee;
            this.NightlyFee = NightlyFee;
        }

        public decimal CalculateMethod(DateTime startTime, DateTime endTime)
        {
            var totalMinutes = (endTime - startTime).TotalMinutes;

            var halfHours = Convert.ToDecimal(totalMinutes) / 30M;

            var RoundedhalfHours = Math.Ceiling(halfHours);

            return GetTotal(Convert.ToInt32(RoundedhalfHours), startTime);
        }

        /// <summary>
        /// Recursive Method
        /// </summary>
        /// <param name="HalfHoursRemaing">The half hours to check when to stop</param>
        /// <param name="startTime">Time to check the day time</param>
        /// <param name="amount">the total</param>
        /// <returns>Total value</returns>
        private decimal GetTotal(int HalfHoursRemaing, DateTime startTime, decimal amount = 0)
        {
            if (HalfHoursRemaing <= 0)
                return amount;

            if (IsDayTime(startTime))
                amount += DailyFee;
            else
                amount += NightlyFee;

            return GetTotal(--HalfHoursRemaing, startTime.AddMinutes(30), amount);
        }

        private bool IsDayTime(DateTime date)
        {
            return date.TimeOfDay > new TimeSpan(7, 00, 00) && date.TimeOfDay < new TimeSpan(19, 00, 00);
        }
    }
}
