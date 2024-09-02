using ConsoleApp.Interfaces;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class CustomerService : ICustomerService
{
    private readonly List<ICustomer> _customerList = new List<ICustomer>();
    public bool AddToList(ICustomer customer)
    {
        try
        {
            customer.Id = _customerList.Count + 1;

            _customerList.Add(customer);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
