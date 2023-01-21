using System.Reflection.Metadata.Ecma335;
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

    Console.Write(msg);

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
    int flag = 0;

    Console.WriteLine("{0, -3}{1, -15}{2, -8}", "№   ", "Name", "Prise");
    if (drinks == null)
    {
        Console.WriteLine("There are no drinks");
    }
    else
    {
        for (int i = 0; i < drinks.Length; i++)
        {
            if (drinks[i].Name != null)
            {
                Console.WriteLine("{0, -3}{1, -15}{2, -8}", i + 1 - flag, drinks[i].Name, drinks[i].Prise + "(руб)");
            }
            else 
            {
                flag = 1;
            }
        }
    }
}

# region User 

static void AdditionoСoffee(ref int orderSum)
{
    int suggar = 10;
    int syrop = 20;

    WriteRow();
    Console.Write("Choose the amount of sugar(10 руб): ");
    suggar = "Yes" == Console.ReadLine() ? suggar : 0;
    WriteRow();

    Console.Write("Add syrup(20руб): ");
    syrop = "Yes" == Console.ReadLine() ? syrop : 0;
    WriteRow();

    int value = InputInt("1. 100ml \n2. 150ml \n3. 200ml \nChosse the value of the gless: ");
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

    int deposited = InputInt("Deposit the amount for payment: ");

    if (deposited < orderSum)
    {
        int addendum = InputInt("Not enough money to pay for a drink. Add more: ");
        Console.WriteLine($"Your change {orderSum - addendum - deposited} enjoy your meal");
    }
    else
    {
        Console.WriteLine($"Your change {deposited - orderSum}. Enjoy your meal");
    }
}

static void PrintCommandsUser()
{
    WriteRow();

    Console.WriteLine("1. Buy drinks");
    Console.WriteLine("0. Exit");

    WriteRow();
}

static void ChosseCoffe(ref int orderSum, Drink[] drinks)
{
    PrintCommandsUser();

    int active = InputInt("Read active: ");

    if (active == 1)
    {
        Console.Clear();

        Console.WriteLine("-------User-------");
        PrintDrinks(drinks);

        bool flag = true;

        int numberCoffe = InputInt("Write id coffe you want buy: ");

        switch (numberCoffe)
        {
            case 1:
                orderSum += drinks[numberCoffe].Prise;
                break;
            case 2:
                orderSum += drinks[numberCoffe].Prise;
                break;
            case 3:
                orderSum += drinks[numberCoffe].Prise;
                break;
            case 4:
                orderSum += drinks[numberCoffe].Prise;
                break;
            case 5:
                orderSum += drinks[numberCoffe].Prise;
                break;
            case 6:
                orderSum += drinks[numberCoffe].Prise;
                break;
            case 0:
                Console.Clear();
                Console.WriteLine("Exit");
                break;
            default:
                {
                    Console.WriteLine("Unknown command");
                    flag = false;
                    break;
                }
        }
        if (flag)
        {
            AdditionoСoffee(ref orderSum);
            Console.Clear();
            PayOrder(ref orderSum);
        }
    }
    else 
    {
        Console.Clear();
        Console.WriteLine("Exiting user mode ");
    }
}
# endregion

# region Admin

static Drink[] NewElementInArray()
{
    Drink[] newDrinks = new Drink[1];

    return newDrinks;
}


static Drink CreateDrink()
{
    Drink drink;

    drink.id = 0;

    Console.Write("Enter the name of the drink: ");
    drink.Name = Console.ReadLine();

    drink.Prise = InputInt("Write prise: ");

    return drink;
}

static void PrintCommandsAdmin()
{
    Console.WriteLine("Admin");

    Console.WriteLine("1. Adding a new element to the end");
    Console.WriteLine("2. Clear all drinks");
    Console.WriteLine("3. New prise by id");
    Console.WriteLine("4. Clear element by id");
    Console.WriteLine("0. Exet user acount");
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

static void EnterPassword()
{
    int count = 0;
    int password;

    do
    {
        if (count != 0)
        {
            Console.WriteLine("false");
            Console.ReadLine();
            Console.Clear();
            password = InputInt("Enter Password: ");
        }
        else 
        {
            password = InputInt("Enter Password: ");
        }
        count = 1;
    } while (password != 1);
    Console.WriteLine("true");
}

static void ChengeThePrice(Drink[] drinks)
{
    int id = InputInt("Write id drink: ") - 1;

    int newPrise = InputInt("Write new prise drink: ");

    drinks[id].Prise = newPrise;
}

static void ClearDrinks(ref Drink[] drinks)
{
    drinks = null;
}

static void ClearElementBuId(ref Drink[] drinks, int id)
{
    Drink[] newDrinks = new Drink[drinks.Length];

    int readI = 0;

    for (int i = 0; i < drinks.Length; i++)
    {
        if (i != id)
        {
            newDrinks[readI] = drinks[i];
            readI++;
        }
    }
    drinks = newDrinks;
}

static void ChosseAction(ref Drink[] drinks)
{
    EnterPassword();
    Console.Clear();

    PrintDrinks(drinks);
    WriteRow();
    PrintCommandsAdmin();

    int numberAction = InputInt("Enter the action id: ");

    switch (numberAction)
    {
        case 1:
            Drink drink = CreateDrink();

            if (drinks == null)
            {
                drinks = NewElementInArray();
            }
            AddNewElemendEnd(ref drinks, drink);
            break;
        case 2:
            ClearDrinks(ref drinks);
            break;
        case 3:
            ChengeThePrice(drinks);
            break;
        case 4:
            int elementId = InputInt("Write elements id: ") - 1;
            ClearElementBuId(ref drinks, elementId);
            break;
        case 0:
            Console.Clear();
            Console.WriteLine("Exit admin mode");
            break;
        default:
            {
                Console.WriteLine("Unknown command");
                break;
            }
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
            Console.WriteLine("-------User-------");

            PrintDrinks(drinks);
            ChosseCoffe(ref orderSum, drinks);

            Console.ReadLine();
            Console.Clear();
            break;
        case 2:
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