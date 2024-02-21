using BankConsole;

/*User james = new User();*/ //<----- Constructor por defecto User()

/*Esto de acceder a las propiedades para cambiar su valor fuera de la clase, solo es posible si las propiedades son
public: 

james.ID = 1;
james.Name = "James";
james.Email = "james@gmail.com";
james.Balance = 1000;
james.RegisterDate = DateTime.Now;

Si las propiedades son privadas entonces se les asignan las propiedades a través del constructor con parámetros:
*/
//Client james = new Client(1, "James", "james@gmail.com", 2500, 'M');


/*Ahora que creamos el método SetBalance(decimal Balance), al momento de ingresar un valor para Balance, tendrá que pasar
este valor por el código del método. De manera que controlemos mejor el resultado final de los valores asignados.*/
//james.SetBalance(1500);

//Console.WriteLine(james.ShowData("La información del usuario es la siguiente."));

//Storage.AddUser(james);

//Employee pedro = new Employee(2, "Pedro", "pedro@hotmail.com", 2500, "IT");

//pedro.SetBalance(1500);

//Console.WriteLine(pedro.ShowData("La info del usuario es la sig."));

//Storage.AddUser(pedro);
// Console.WriteLine(pedro.ShowData());

/*
if (args.Length ==0)
    EmailService.SendMail();
else //si escribo en terminal dotnet run 4 6 9, el sig. código me imprimirá "Segundo Argumento: 6"
    Console.WriteLine("Segundo Argumento:" + args[1]);
Client ana = new Client(3, "Ana", "ana01gmail.com", 1500, 'M');
Storage.AddUser(ana);
*/

if (args.Length ==0)
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Seleccionar una opción:");
    Console.WriteLine("1 - Crear un Usuario nuevo.");
    Console.WriteLine("2 - Eliminar un Usuario existente.");
    Console.WriteLine("3 - Salir.");

    int option = 0;
    do
    {
        string input = Console.ReadLine();

        if (!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un número (1, 2 o 3).");
        else if (option > 3)
            Console.WriteLine("Debes ingresar un número válido (1, 2 o 3).");
    }
    while (option == 0 || option >3);

    switch (option)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
}


void CreateUser()
{
    Console.Clear();
    Console.WriteLine("Intrese la información del usuario:");
    string email;
    int ID;
    decimal balance;

    do
    {
        start:
        Console.WriteLine("ID: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out ID) && ID > 0)
        {
            do
            {
                ID = int.Parse(input);

                bool idExists = Storage.CheckUsers(ID);

                if (idExists)
                {
                    Console.WriteLine("Error: El ID ya existe.");
                    goto start;
                }
                else
                {
                    break;
                }
            } while (true);
            break;
        }
        else
        {
            Console.WriteLine("Error: Debe ingresar un número entero positivo.");
        }
    } while (true);


    Console.Write("Nombre: ");
    string name = Console.ReadLine();

    do
    {
        Console.Write("Email:");
        string mail = Console.ReadLine();
        if (Storage.EmailValid(mail))
        {
            email = mail;
            break;
        }
        else
        {
            Console.WriteLine("Error: Formato del correo inválido.");
        }
    } while(true);

    decimal dinero;
    do
    {
        Console.Write("Saldo: ");
        string saldo = Console.ReadLine();
        
        if (decimal.TryParse(saldo, out dinero) && dinero > 0)
        {
            balance = decimal.Parse(saldo);
            break;
        }

        else
        {
            Console.WriteLine("Error: El saldo  a ingresar debe de ser un número decimal positivo.");
        }
    } while(true);
    
    char userType;
    do
    {
        Console.Write("Escribe 'c' si el usuario es Cliente, 'e' si es Empleado: ");
        userType = char.Parse(Console.ReadLine());

        if (userType == 'c' || userType == 'e')
        {
            break;
        }

        else
        {
            Console.WriteLine("Error: Solo se permiten los caracteres 'c' y 'e' como opciones.");
        }
    }while(true);
    
    

    User newUser;

    if (userType.Equals('c'))
    {
        Console.Write("Regimen Fiscal: ");
        char taxRegime = char.Parse(Console.ReadLine());

        newUser = new Client(ID, name, email, balance, taxRegime);
    }
    else
    {
        Console.Write("Departamento: ");
        string department = Console.ReadLine();

        newUser = new Employee(ID, name, email, balance, department);
    }

    Storage.AddUser(newUser);

    Console.WriteLine("Usuario creado.");
    Thread.Sleep(2000);
    ShowMenu();
}

void DeleteUser()
{
    Console.Clear();

    Console.Write("Ingresa el ID del usuario a eliminar: ");
    int ID = int.Parse(Console.ReadLine());

    string result = Storage.DeleteUser(ID);

    if (result.Equals("Success"))
    {
        Console.Write("Usuario eliminado.");
        Thread.Sleep(2000);
        ShowMenu();
    }
}