using Wendy;

void SelectionUser()
{
    Console.WriteLine("Choose who you want to enter in for");

    Console.WriteLine("1. User");
    Console.WriteLine("2. Admin");
    Console.WriteLine("0. Exet");
}
static int InputInt(string msg)
{
    bool inputReault;
    int number;

    Console.Write(msg + " ");

    do
    {
        inputReault = int.TryParse(Console.ReadLine(), out number);
    } while (!inputReault);

    return number;
}

static Drink[] CreateDrinks(Drink[] drinks)
{
    string[] arrayCoffe = { "Coffe", "Latte", "Macchiato ", "DobleEx", "Americano", "Cappuccino" };
    int[] prise = { 100, 120, 150, 140, 160, 155 };


    for (int i = 0; i < arrayCoffe.Length; i++)
    {
        drinks[i].Name = arrayCoffe[i];
        drinks[i].Prise = prise[i];
        drinks[i].id = i;
    }

    return drinks;
}

static void PrintDrinks(Drink[] drinks)
{
    Console.WriteLine("{0, -3}{1, -15}{2, -8}", "№   ", "Name", "Prise");
    if (drinks == null)
    {
        Console.WriteLine("there are no drinks");
    }
    else
    {
        for (int i = 0; i < drinks.Length; i++)
        {
            Console.WriteLine("{0, -3}{1, -15}{2, -8}", i + 1, drinks[i].Name, drinks[i].Prise + "(руб)");
        }
    }
}

# region User 

static void AdditionoСoffee(ref int orderSum)
{
    int suggar = 10;
    int syrop = 20;

    Console.Write("Choose the amount of sugar(10 руб): ");
    suggar = "Yes" == Console.ReadLine() ? suggar : 0;
    WriteRow();

    Console.Write("Add syrup(20руб): ");
    syrop = "Yes" == Console.ReadLine() ? syrop : 0;
    WriteRow();

    int value = InputInt("Chosse the value of the gless \n 1. 100ml \n 2. 150ml \n 3. 200ml");
    value = orderSum * value / 2;

    orderSum = suggar + syrop + value;
}

static void WriteRow()
{
    Console.WriteLine("-----------------------------------");
}

static void PayOrder(ref int orderSum)
{
    Console.WriteLine($"Order sum: {orderSum}");

    int deposited = InputInt("Deposit the amount for payment");

    if (deposited < orderSum)
    {
        int addendum = InputInt("Not enough money to pay for a drink. Add more");
        Console.WriteLine($"Your change {orderSum - addendum - deposited} enjoy your meal");
    }
    else
    {
        Console.WriteLine($"Your change {deposited - orderSum}. Enjoy your meal");
    }
}

static void ChosseCoffe(ref int orderSum)
{
    int numberCoffe = InputInt("Write id coffe you want buy: ");

    switch (numberCoffe)
    {
        case 1:
            orderSum += (int)Prise.Coffe;
            break;
        case 2:
            orderSum += (int)Prise.Latte;
            break;
        case 3:
            orderSum += (int)Prise.Macchiato;
            break;
        case 4:
            orderSum += (int)Prise.DoubleEx;
            break;
        case 5:
            orderSum += (int)Prise.Americano;
            break;
        case 6:
            orderSum += (int)Prise.Cappuccino;
            break;
    }
    AdditionoСoffee(ref orderSum);
    Console.Clear();
    PayOrder(ref orderSum);
}
# endregion

# region Admin

static Drink CreateDrink()
{
    Drink drink;

    drink.id = 0;

    Console.Write("Enter the name of the drink: ");
    drink.Name = Console.ReadLine();

    drink.Prise = InputInt("Введите цену: ");

    return drink;
}

static void PrintCommands() 
{
    Console.WriteLine("Admin");

    Console.WriteLine("1. Adding a new element to the end");
    Console.WriteLine("2. Clear all drinks");
    Console.WriteLine("3. New prise by id");

}

static void ResizeArray(ref Drink[] drinks, int newLength)
{
    int minLenght = newLength > drinks.Length ? drinks.Length : newLength;

    Drink[] newArray = new Drink[newLength];

    for (int i = 0; i < minLenght; i++)
    {
        newArray[i] = drinks[i];
    }

    drinks = newArray;
}

static void AddNewElemendEnd(ref Drink[] drinks, Drink drink)
{
    ResizeArray(ref drinks, drinks.Length + 1);

    drinks[drinks.Length - 1] = drink;
}

static bool EnterPassword()
{
    Console.WriteLine("Enter Password");
    string password = Console.ReadLine();

    if (password == "1")
    {
        Console.WriteLine("true");
        Console.ReadLine();

        return true;
    }
    else
    {
        Console.WriteLine("false");
        Console.ReadLine();

        return false;
    }
}

static void ChengeThePrice(Drink[] drinks) 
{
    int id = InputInt("Write id drink") - 1;

    int newPrise = InputInt("Write new prise drink");

    drinks[id].Prise = newPrise;
}

static void ClearDrinks(ref Drink[] drinks) 
{
    drinks = null;
}

static void ChosseAction(ref Drink[] drinks)
{
    PrintDrinks(drinks);
    WriteRow();
    PrintCommands();

    int numberAction = InputInt("");

    switch (numberAction)
    {
        case 1:
            Drink drink = CreateDrink();
            AddNewElemendEnd(ref drinks, drink);
            break;
        case 2:
            ClearDrinks(ref drinks);    
            break;
        case 3:
            ChengeThePrice(drinks);
            break;
    }
}
# endregion

Drink[] drinks = new Drink[6];
drinks = CreateDrinks(drinks);
CreateDrinks(drinks);

bool runProgram = true;
int orderSum = 0;

while (runProgram)
{
    SelectionUser();

    int account = InputInt("");
    Console.Clear();
    switch (account)
    {
        case 0:
            runProgram = false;
            Console.WriteLine("Exit");
            Console.ReadLine();
            break;
        case 1:
            PrintDrinks(drinks);
            ChosseCoffe(ref orderSum);
            Console.ReadLine();
            Console.Clear();
            break;
        case 2:
            runProgram = EnterPassword();
            Console.Clear();

            if (runProgram)
            {
                ChosseAction(ref drinks);

                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("");
            }
            Console.Clear();
            break;
        default:
            Console.WriteLine("Unknow command");
            break;
    }
}
Console.Clear();

