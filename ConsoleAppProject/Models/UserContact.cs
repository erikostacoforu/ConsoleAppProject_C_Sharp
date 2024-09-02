namespace ConsoleAppProject.Models
{
    public class UserContact
    {
        // egenskaper för informationen om en kontakt samt att den inte kan vara null.
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; }

        public string Adress { get; set; } = null!;

        public UserContact(string? firstname, string? lastname, string? email, string? phonenumber, string? adress)

        {
            FirstName = firstname!;
            LastName = lastname!;
            Email = email!;
            PhoneNumber = phonenumber!;
            Adress = adress!;
        }

        // returnerar informationen om en kontakt.
        public override string ToString()
        {
            return $"\n- Förnamn: {FirstName} \n- Lastname: {LastName} \n- Email: {Email} \n- Phonenumber: {PhoneNumber} \n- Adress: {Adress} ";
        }
    }
}
