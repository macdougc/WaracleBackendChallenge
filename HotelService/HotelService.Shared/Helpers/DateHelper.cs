namespace HotelService.Shared.Helpers;

public class DateHelper : IDateHelper
{
    public static bool DoDatesIntersect(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
    {
        return (startDate1 <= endDate2 && startDate1 >= startDate2) || (endDate1 <= endDate2 && endDate1 >= startDate2);
    }
}
