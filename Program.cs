// Use the namespace where the Product class is defined
using ManagementInventory;

// Define the Program class
class Program
{
    // Create a list to hold the inventory products in memory
    static List<Product> inventory = new List<Product>();

    // Main method: Entry point of the application
    static void Main()
    {
        // Loop to display the menu and keep the app running
        while (true)
        {
            // Display the main menu
            Console.WriteLine("\n--- Inventory Management System ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            // Read the user's menu choice
            string choice = Console.ReadLine();

            // Execute the corresponding method based on user input
            switch (choice)
            {
                case "1": AddProduct(); break;         // Call AddProduct
                case "2": ViewInventory(); break;      // Call ViewInventory
                case "3": UpdateProduct(); break;      // Call UpdateProduct
                case "4": DeleteProduct(); break;      // Call DeleteProduct
                case "5": return;                      // Exit the app
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    // Method to add a new product to the inventory
    static void AddProduct()
    {
        // Ask for product name
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        // Ask for product quantity
        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        // Ask for product price
        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        // Create and add the new product to the inventory list
        inventory.Add(new Product
        {
            Id = Guid.NewGuid(), // Generate unique ID
            Name = name,
            Quantity = quantity,
            Price = price
        });

        // Confirmation message
        Console.WriteLine("Product added to inventory.");
    }

    // Method to display all products in the inventory
    static void ViewInventory()
    {
        Console.WriteLine("\n--- Inventory List ---");

        // Loop through and print each product's details
        foreach (var item in inventory)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Qty: {item.Quantity}, Price: {item.Price:C}");
        }
    }

    // Method to update an existing product
    static void UpdateProduct()
    {
        Console.Write("Enter item ID to update: ");
        // Try to convert user input into a valid GUID
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            // Find the product in the inventory by ID
            var item = inventory.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                // Ask for new values and update the product
                Console.Write("Enter new name: ");
                item.Name = Console.ReadLine();

                Console.Write("Enter new quantity: ");
                item.Quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter new price: ");
                item.Price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Item updated."); // Confirmation message
            }
            else
            {
                Console.WriteLine("Item not found."); // If no matching product is found
            }
        }
        else
        {
            Console.WriteLine("Invalid GUID format."); // If the user input is not a valid GUID
        }
    }

    // Method to delete a product from the inventory
    static void DeleteProduct()
    {
        Console.Write("Enter item ID to delete: ");
        // Try to convert input into GUID
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            // Find product in the inventory by ID
            var item = inventory.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                inventory.Remove(item); // Remove product from the list
                Console.WriteLine("Item deleted."); // Confirmation message
            }
            else
            {
                Console.WriteLine("Item not found."); // If no match is found
            }
        }
        else
        {
            Console.WriteLine("Invalid GUID format."); // If GUID is invalid
        }
    }
}
