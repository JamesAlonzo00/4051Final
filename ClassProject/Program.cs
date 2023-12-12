using ClassProject.Model;

namespace ClassProject
{
    public class Program
    {
        private static Customers customers;
        private static List<Appointment> appointments;
        private static List<CutomerAppointment> customerAppointments;
        private static Customer authenticatedCustomer;
        private static Inventory inventory;
        private static Cart cart;

        private static Customer customer;
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Initialize(); // Create and initialize all objects ...
            Menu();
        }

        static void Initialize()
        {
            var c1 = new Customer
            {
                FirstName = "Kambiz",
                LastName = "Saffari",
                Username = "kambiz",
                Password = "1234"
            };
            var c2 = new Customer
            {
                FirstName = "Terence",
                LastName = "Ow",
                Username = "terence",
                Password = "2345"
            };
            var a1 = new Appointment { date = "4 pm"};
            var a2 = new Appointment { date = "4:30 pm"};
            var a3 = new Appointment { date = "1 pm"};

            var ca1 = new CutomerAppointment(c1, a1);
            var ca2 = new CutomerAppointment(c1, a2);
            var ca3 = new CutomerAppointment(c2, a3);

            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            appointments = new List<Appointment>();
            appointments.Add(a1);
            appointments.Add(a2);
            appointments.Add(a3);

            customerAppointments = new List<CutomerAppointment>();
            customerAppointments.Add(ca1);
            customerAppointments.Add(ca2);//did not use
            customerAppointments.Add(ca3);

            // Initialize inventory
            inventory = new Inventory();
            Item milk = new Item("Milk", 2.99m, inventory);
            Item bread = new Item("Bread", 1.99m, inventory);//all items have a name and price then they are stored in the inventory list
            Item gum = new Item("Gum", 0.99m, inventory);
            Item pizzaRolls = new Item("Pizza Rolls", 4.99m, inventory);
            // Add more items as needed...

        }

        static void Menu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Shopping Cart Menu: 5 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignUpMenu();
                        break;
                    case "4":
                        GetCurrentAppointmentsMenu();
                        break;
                    case "5"://case 5 is for actual shopping -- user must sign in or up to use
                        if (authenticatedCustomer == null)
                        {
                            Console.WriteLine("Please log in to start shopping.");
                        }
                        else
                        {
                            ShoppingCartMenu();// made with gpt 3.5 to list all available items and promtp you to select some
                        }
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

            }

        }


        static void LoginMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedCustomer = customers.Authenticate(username, password);
                if (authenticatedCustomer != null)
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                }
                else
                {
                    Console.WriteLine("invalid username or password");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");
            }
        }

        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out!");
        }

        static void SignUpMenu()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");

        }


        static void GetCurrentAppointmentsMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }


            var appointmentList = customerAppointments.Where(o => o.customer.Username == authenticatedCustomer.Username);

            if(appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }
            else
            {
                foreach(var appointmnet in appointmentList)
                {
                    Console.WriteLine(appointmnet.appointment.date);
                }
            }
        }

        
        
            static void ShoppingCartMenu()// shopping class that allows you to select items
            {
                Cart shopperCart = new Cart();//declares a list to store selected items in later

                string userInput;//string to use readline later -- stores the users selection
                do
                {
                    Console.WriteLine("Available Items:");//do while loop that shows available items so that the user can choose
                    List<Item> itemsInStock = inventory.GetItemsInStock();
                    foreach (var item in itemsInStock)
                    {
                        Console.WriteLine($"- {item.ItemName} (${item.Price})"); //foreach loop that prints each item in the inventory list
                    }

                    Console.Write("Select an item to add to the cart (or 'done' to finish shopping): ");//promtps user to make a decision of selecting an item or to finalize the order
                    userInput = Console.ReadLine();

                    if (userInput.ToLower() != "done")
                    {
                        shopperCart.AddItemToCart(userInput, inventory);//adds selected item to cart list
                    }
                } while (userInput.ToLower() != "done");//ends item selection process

                Console.Write("Enter pickup time: ");//prompts user for a pick up time
                string pickupTime = Console.ReadLine();

                OrderConfirmation(authenticatedCustomer, pickupTime, shopperCart.cartItems);
            }

            static void OrderConfirmation(Customer customer, string pickupTime, List<Item> cartItems)
            {
                if (customer != null)
                {
                    Console.WriteLine($"Order Confirmation for {customer.FirstName} {customer.LastName}:");
                    Console.WriteLine($"Pickup Time: {pickupTime}");
                    Console.WriteLine("Items in Cart:");
                    foreach (var item in cartItems)
                    {
                        Console.WriteLine($"- {item.ItemName} (${item.Price})");
                    }
                }
                else
                {
                    Console.WriteLine("Please log in to confirm the order.");
                }
            }
        }
    }
    




