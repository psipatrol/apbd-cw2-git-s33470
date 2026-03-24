using apbd_cw2_git_s33470.equipment;
using apbd_cw2_git_s33470.rental;
using apbd_cw2_git_s33470.users;

namespace apbd_cw2_git_s33470.service;

public class RentalService
{
    private List<Rental> _rentals = new();
    private PriceCalculator _priceCalculator;

    public RentalService()
    {
        _priceCalculator = new PriceCalculator();
    }

    public void RentItem(AbstractUser user, AbstractEquipment item, int plannedDuration)
    {
        if (item.Status != Status.Available)
        {
            Console.WriteLine($"!!!Equipment {item.Name} is currently not available (Status: {item.Status})");
            return;
        }
        
        int currentRentals =  _rentals.Count(r => r.User.Id == user.Id && r.ReturnDate == null);
        if (currentRentals >= user.MaxEquipment)
        {
            Console.WriteLine($"!!!User {user.FirstName} {user.LastName} is over his renting limit");
            return;
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
            Console.WriteLine($"!!!Equipment {item.Name} is not currently marked as rented");
            return;
        }
        
        double penality = _priceCalculator.CalculatePenality(rental, returnDate);
        rental.MarkAsReturned(returnDate, penality);
        item.MarkAsAvailable();
        
        Console.WriteLine($"{item.Name} is returned by {rental.User.FirstName} {rental.User.LastName}, total fee is {rental.TotalFee} with {penality} penality");
    }
    
    public void ShowOverdueRentals()
    {
        _rentals.FindAll(r => r.ReturnDate == null && DateTime.Now > r.EndDate).ForEach(r => Console.WriteLine($"{r.Item}"));
    }

    public void ShowActiveUserRentals(AbstractUser user)
    {
        _rentals.FindAll(r => r.User.Id == user.Id && r.ReturnDate == null).ForEach(r => Console.WriteLine($"{r.Item}"));
    }
    
    public void ShowAllEquipment()
    {
        _rentals.ForEach(r => Console.WriteLine($"{r.Item}"));
    }
    
    public void ShowAvailableEquipment()
    {
        _rentals.FindAll(r => r.Item.Status == Status.Available).ForEach(r => Console.WriteLine($"{r.Item}"));
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