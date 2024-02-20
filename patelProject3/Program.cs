using System.Transactions;

internal class Program
{
    // declares constants

    const double pTea = 0.43;
    const double bTea = 0.53;
    const double gTea = 0.65;
    const double wTea = 0.78;
    const double salesTaxRate = 0.045;
    public static void displayStartMenu() 
    {
       
        Console.Write("\nWelcome to the World's Best Tea Shop\n\t1 - Process a Single Order\n\t2 - Process Multiple Orders From a File\n\t3 - Quit");
        //menuChoice = Convert.ToInt32(Console.ReadLine());
    }
    public static double determineCostPerOz()
    {
        double tType = 0;   // declares variable to hold type of tea value

        // gets user input for type of tea
        Console.Write("\n\t1 - Plain Tea\n\t2 - Black Tea\n\t3 - Green Tea\n\t4 - White Tea\nEnter Choice of Tea: ");
        tType = Convert.ToDouble(Console.ReadLine());
        
        // validates user input
        while (tType < 1 || tType > 4)
        {
            Console.WriteLine("\nINVALID MENU CHOICE. PLEASE TRY AGAIN.");
            Console.Write("\n\t1 - Plain Tea\n\t2 - Black Tea\n\t3 - Green Tea\n\t4 - White Tea\nEnter Choice of Tea: ");
            tType = Convert.ToDouble(Console.ReadLine());
        }

        return tType; // returns type of tea
    } 
    public static int determineNumberOunces()
    {
        int tSize = 0;  // declares variable to hold the size of the tea
        
        // gets user input for size of tea
        Console.Write("\nSelect a Size:\n\t1 - Small (8oz)\n\t2 - Medium (16oz)\n\t3 - Large (24oz)\nEnter Choice of Size: ");
        tSize = Convert.ToInt32(Console.ReadLine());

        // validates user input
        while (tSize < 1 || tSize > 3)
        {
            Console.WriteLine("\nINVALID MENU CHOICE. PLEASE TRY AGAIN");
            Console.Write("\nSelect a Size:\n\t1 - Small (8oz)\n\t2 - Medium (16oz)\n\t3 - Large (24oz)\nEnter Choice of Size: ");
            tSize = Convert.ToInt32(Console.ReadLine());
        }
        return tSize; // returns the size of the tea
    }
    public static double calcPriceTea(int tSize, double tType)
    {
        // declares variables
        
        double priceTea = 0;    // variable to hold price of tea based on user selections
        double oz = 0;  // variable to hold number of ounces based on user selection of tea size

        // if statement to determine the number of ounces based on the user selection of tea size
        if (tSize == 1)
        {
            oz = 8;
        }
        else if (tSize == 2)
        {
            oz = 16;
        }
        else if (tSize == 3) 
        {
            oz = 24;
        }
        
        // switch statement to determine price of the tea based on calculations using 'oz' and constants which hold price per ounce

        switch (tType)
        {
            case 1:
                priceTea = pTea * oz;
                break;
            case 2:
                priceTea = bTea * oz;
                break;
            case 3:
                priceTea = gTea * oz;
                break;
            case 4:
                priceTea = wTea * oz;
                break;
        }
        
        return priceTea;
    }
    public static double calcSalesTax(double priceTea)  // method to calculate sales tax
    {
        double salesTaxOwed = 0;    // declares variable to hold the amount of sales tax that will be charged
        
        salesTaxOwed = priceTea * salesTaxRate; // calculates sales tax amount that will be charged
        
    return salesTaxOwed; // returns the amount charged for sales tax
    }
    public static double calcCostBill(double priceTea, double salesTaxOwed) // method to calculate the total cost
    {
        double totalCost = 0;     // declares variable to hold the total cost of the bill

        totalCost = priceTea + salesTaxOwed;    // calculates the total cost

        return totalCost;   // returns the total cost
    }
    static void Main(string[] args)
    {
        int menuChoice = 0; // variable to hold the user menu selection
        double tType = 0; // variable that will hold the cost
        int tSize = 0; // variable that will hold the size of the tea
        double priceTea = 0; // variable that will hold the subtotal price of the tea
        double salesTax = 0; // variable that holds the sales tax price
        double totalPrice = 0; // variable to hold the total price of the tea (subtotal + sales tax)
        string name;    // variable to hold user name
        string fileName = "orders.txt"; // name of the text file

        do
        {
            displayStartMenu();
            Console.Write("\nEnter menu choice(1, 2, or 3): ");
            menuChoice = Convert.ToInt32(Console.ReadLine());


            if (menuChoice == 1)
            {
                // processes single order based on user input

                tType = determineCostPerOz();   // gets user input for type of tea
                tSize = determineNumberOunces();    // gets user input for size of tea
                priceTea = calcPriceTea(tSize, tType);  // calculates price of tea
                salesTax = calcSalesTax(priceTea);  // calculates the sales tax
                totalPrice = calcCostBill(priceTea, salesTax);  // calculates the total cost of the bill
                Console.Write("\nEnter the name of the customer: ");
                name = Console.ReadLine();
                Console.WriteLine("\nName on order: " + name + "\nPrice of Tea: " + priceTea.ToString("c") + "\nSales Tax: " + salesTax.ToString("c") + "\nOrder Total: " + totalPrice.ToString("c")); // outputs formatted data

            }
            else if (menuChoice == 2)
            {
                // processes multiple orders from a file
                // creates file reader object

                StreamReader sr = new StreamReader(fileName);

               


                // processes the file for necessary information

                while (!sr.EndOfStream)
                {
                    name = sr.ReadLine(); // assigns name from file to variable
                
                    tType = int.Parse(sr.ReadLine()); // assigns tea type from file to variable

                    tSize = int.Parse(sr.ReadLine()); // assigns tea size from file to variable

                    sr.ReadLine();

                    priceTea = calcPriceTea(tSize, tType);  // calculates price of tea
                    salesTax = calcSalesTax(priceTea);  // calculates the sales tax
                    totalPrice = calcCostBill(priceTea, salesTax);  // calculates the total cost of the bill
                    Console.WriteLine("\n\nName on order: " + name + "\nPrice of Tea: " + priceTea.ToString("c") + "\nSales Tax: " + salesTax.ToString("c") + "\nOrder Total: " + totalPrice.ToString("c")); // outputs formatted data
                }

            } 
            else if (menuChoice == 3)
            {
                // option prompted to user to close the program

                Console.WriteLine("\nThank you for using the program. Goodbye.");
                Environment.Exit(0);
            }
            else
            {  
                // validates the user input for menu selection    
                
                Console.WriteLine("\nERROR: INVALID MENU CHOICE. TRY AGAIN.");     
             
            }
        } while (menuChoice != 3);
    }
}