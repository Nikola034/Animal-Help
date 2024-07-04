using System;

namespace AnimalHelp.Application.Stores;

public class DonationStore
{
    public event Action? DonationListUpdated;
    
    public void UpdateDonationList()
    {
        DonationListUpdated?.Invoke();
    }
}