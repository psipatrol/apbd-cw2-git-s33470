using apbd_cw2_git_s33470.equipment;
using apbd_cw2_git_s33470.users;

namespace apbd_cw2_git_s33470.rental;

public class Rental
{
    private static int _IdCounter = 0;
    public int Id { get; init; }
    public AbstractEquipment Item { get; init; }
    public AbstractUser User { get; init; }
    public DateTime StartDate {get; init;}
    public DateTime EndDate {get; private set;}
    public DateTime ReturnDate {get; private set;}
    public double BaseFee {get; private set;}
    public double PenalityFee {get; private set;}
    public double TotalFee => BaseFee + PenalityFee;

    
    public Rental(AbstractEquipment item,  AbstractUser user,  DateTime startDate, int days, double basicFee)
    {
        Id = GetId();
        Item = item;
        User = user;
        StartDate = startDate;
        EndDate = startDate.AddDays(days);
        BaseFee =  basicFee;
    }

    public void MarkAsReturned(DateTime returnDate, double penality)
    {
        ReturnDate = returnDate;
        PenalityFee = penality;
    }
    
    private static int GetId()
    {
        return _IdCounter++;
    }
}