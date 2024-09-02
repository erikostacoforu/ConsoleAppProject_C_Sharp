using ConsoleAppProject.Models;
using ConsoleAppProject.Services;
using Newtonsoft.Json;


public class Program
{
    private static void Main(string[] args)
    {
        // visar vart kontakterna sparas ned någonstans 
        string filepath = @"C:\Projects\CSharp\ConsoleAppProject\contacts.json";
        var fileService = new FileService(filepath);

        // Laddar in kontakter i listan som är redan skapade
        List<UserContact> contactlist = LoadContactsFromFile(fileService);

        while (true)

        {
            // allternativ för användaren att välja mellan
            Console.WriteLine("###### Välkommen till din adressbok ######");
            Console.WriteLine("1. Lägg till en användare");
            Console.WriteLine("2. Visa en specifik användare");
            Console.WriteLine("3. Visa alla användare");
            Console.WriteLine("4. Ta bort en användare");
            Console.WriteLine("5. Avsluta Programmet");
            Console.Write("Välj ett alternativ: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Ange förnamn: ");
                    string? firstname = Console.ReadLine();

                    Console.WriteLine("Ange efternamn: ");
                    string? lastname = Console.ReadLine();

                    Console.WriteLine("Ange din email: ");
                    string? email = Console.ReadLine();

                    Console.WriteLine("Ange ditt mobilnummer: ");
                    string? phonenumber = Console.ReadLine();

                    Console.WriteLine("Ange din Adress: ");
                    string? adress = Console.ReadLine();

                    // kontrollerar om fälten är tomma 
                    if    (string.IsNullOrWhiteSpace(firstname) ||
                           string.IsNullOrWhiteSpace(lastname) ||
                           string.IsNullOrWhiteSpace(email) ||
                           string.IsNullOrWhiteSpace(phonenumber) ||
                           string.IsNullOrWhiteSpace(adress))
                    {
                        Console.Clear();
                        Console.WriteLine("Alla fält måste fyllas i för att lägga till en kontakt\n");
                    }
                    else
                    {
                        // skapar en kontakt samt lägger in hen i en lista om alla krav uppfylls
                        UserContact newContact = new UserContact(firstname!, lastname!, email!, phonenumber!, adress!);
                        contactlist.Add(newContact);

                        Console.Clear();
                        Console.WriteLine("Kontakten har lagts till i listan\n");
                    }
                    break;

                    // alternativ för att kunna visa information om en viss användare 
                case "2":
                    Console.Clear();
                    Console.WriteLine("För att se en specifik användare måste du ange ett ID som börjar från 0");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < contactlist.Count)

                        
                    {
                        Console.Clear();
                        Console.WriteLine($"Informationen om användare {index}: {contactlist[index]}\n");
                        
                    }
                    else
                    {
                        Console.WriteLine("Ogitligt ID nummer");
                        Console.Write("Försök igen med ett giltligt ID");
                    }
                    break;

                    // Loopar igenom listan för att skriva ut kontakterna 
                case "3":
                    Console.Clear();
                    Console.WriteLine("Alla användare som är med i listan:");
                    for (int i = 0; i < contactlist.Count; i++)
                    {
                        Console.WriteLine($"###### {i} ###### {contactlist[i]}\n");
                    }
                    break;

                    // Tar bort en kontakt med hjälp att skriva in en befintlig email
                case "4":
                    Console.Clear();
                    Console.WriteLine("För att ta bort en kontakt behöver du ange hens email");
                    string? emailToDelete = Console.ReadLine();

                    UserContact? contactToDelete = contactlist.FirstOrDefault(x => x.Email == emailToDelete);

                    if (contactToDelete != null)
                    {
                        contactlist.Remove(contactToDelete);
                        Console.Clear();
                        Console.WriteLine($"kontakten med email {emailToDelete} har tagits bort från listan\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"ingen kontakt med email {emailToDelete} finns med i listan\n");
                    }
                    break;

                    // Sparar alla kontakter till en Json fil när programmet avslutas
                case "5":
                    SaveContactsToFile(fileService, contactlist);
                    Console.Clear();
                    Console.WriteLine("Avlsutar programmet");
                    return;

                    // tar hand om ogiltiga menyval
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val, tryck på valfri tangent för att försöka igen");
                    Console.ReadKey();
                    break;

            }
        }
    }

    // Sparar listan med kontakter ned till en Json-fil 
    private static void SaveContactsToFile(FileService fileService, List<UserContact> contacts)
    {
        string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        fileService.SaveContentToFile(json);
    }

    // Hämtar information från Json-filen samt omvandlar tillbaka informationen till programmet.
    private static List<UserContact> LoadContactsFromFile(FileService fileService)
    {
        string content = fileService.GetContentFromFile();
        if (!string.IsNullOrEmpty(content))
        {
            return JsonConvert.DeserializeObject<List<UserContact>>(content) ?? new List<UserContact>();
        }
        return new List<UserContact>();
    }
}