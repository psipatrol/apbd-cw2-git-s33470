using apbd_cw2_git_s33470.equipment;
using apbd_cw2_git_s33470.rental;
using apbd_cw2_git_s33470.users;

namespace apbd_cw2_git_s33470.service;

public class RentalService
{
    private List<Rental> _rentals = new();
    private PriceCalculator _priceCalculator;

    public RentalService(PriceCalculator priceCalculator)
    {
        _priceCalculator = priceCalculator;
    }

    public void RentItem(AbstractUser user, AbstractEquipment item, int plannedDuration)
    {
        if (item.Status != Status.Available)
        {
            throw new InvalidOperationException($"Equipment {item.Name} is currently not available (Status: {item.Status})");
        }
        
        int currentRentals =  _rentals.Count(r => r.User.Id == user.Id && r.ReturnDate == null);
        if (currentRentals >= user.MaxEquipment)
        {
            throw new InvalidOperationException($"User {user.FirstName} {user.LastName} is over his renting limit");
        }
        
        double baseFee = _priceCalculator.CalculateBaseFee(item, plannedDuration);
        Rental rental = new Rental(item, user, DateTime.Now, plannedDuration, baseFee);
        
        _rentals.Add(rental);
        item.MarkAsRented();
        
        Console.WriteLine($"{item.Name} is rented by {user.FirstName} {user.LastName}");
        Console.WriteLine($"base fee is {baseFee} for duration of {plannedDuration}");
    }

    public void ReturnItem(AbstractEquipment item, DateTime returnDate)
    {
        Rental? rental = _rentals.FirstOrDefault((r => r.Item.Id == item.Id && r.ReturnDate == null), null);

        if (rental == null)
        {
            throw new InvalidOperationException($"Equipment {item.Name} is not currently marked as rented");
        }
        
        double penality = _priceCalculator.CalculatePenality(rental, returnDate);
        rental.MarkAsReturned(returnDate, penality);
        item.MarkAsAvailable();
        
        Console.WriteLine($"{item.Name} is returned by {rental.User.FirstName} {rental.User.LastName}, total fee is {rental.TotalFee} with {penality} penality");
    }
    
    public List<Rental> GetOverdueRentals(Status status)
    {
        return _rentals.Where(r => r.ReturnDate == null && DateTime.Now > r.EndDate).ToList();
    }

    public List<Rental> GetActiveUserRentals(AbstractUser user)
    {
        return _rentals.Where(r => r.User.Id == user.Id && r.ReturnDate == null).ToList();
    }

    public void GenerateReport()
    {
        Console.WriteLine($"Generating report for {DateTime.Now}");
        Console.WriteLine($"All rented equipment amount {_rentals.Count}");
        Console.WriteLine($"Active rentals {_rentals.Count(r => r.ReturnDate == null)}");
        Console.WriteLine($"Total income {_rentals.FindAll(r => r.ReturnDate != null).Sum(r => r.TotalFee)}");
        Console.WriteLine($"Including penalities {_rentals.FindAll(r => r.ReturnDate != null).Sum(r => r.PenalityFee)}");
        Console.WriteLine($"Predicted income {_rentals.FindAll(r => r.ReturnDate == null).Sum(r => r.TotalFee)}");
        Console.WriteLine($"Predicted penalities {_rentals.FindAll(r => r.ReturnDate == null).Sum(r => r.PenalityFee)}");
    }
    
}