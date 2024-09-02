using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests;

public class CustomerService_Test    
{
    [Fact]
    public void AddToListShould_AddOneCustomerToCustomList_ReturnTrue()
    {

        // Arrange
        ICustomer customer = new Customer { FirstName = "Sten-ove", LastName = "Sundberg", Email = "sten-ove@gmail.com", PhoneNumber = "070 696969", Adress = "Solsidan 43" };
        ICustomerService customerService = new CustomerService();

        // Act
        bool result = customerService.AddToList(customer);

        // Assert
        Assert.True(result);
    }
}

