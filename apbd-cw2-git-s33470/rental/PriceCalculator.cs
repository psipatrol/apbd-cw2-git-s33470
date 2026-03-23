using apbd_cw2_git_s33470.equipment;

namespace apbd_cw2_git_s33470.rental;

public class PriceCalculator
{
    private const double DailyRate = 0.1;
    private const double PenalityRate = 0.1;
    
    public double CalculateBaseFee(AbstractEquipment equipment, int days)
    {
        return equipment.Value * DailyRate *  days;
    }
    
    public double CalculatePenality(Rental rental, DateTime returnDate)
    {
        if (returnDate <= rental.EndDate)
        {
            return 0;
        }
        int delay = (returnDate - rental.EndDate).Days;
        return rental.Item.Value * PenalityRate *  delay;
    }
}