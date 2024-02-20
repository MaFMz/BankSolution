using Newtonsoft.Json;
namespace BankConsole;

public class User
{
    [JsonProperty]
    protected int ID { get; set; } //esta es una propiedad I think
    [JsonProperty]
    protected string Name { get; set; } //también las propiedades tienen un nivel de acceso btw
    [JsonProperty]
    protected string Email { get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate { get; set; }

    public User(){}

    public User(int ID, string Name, string Email, decimal Balance) //este solo funciona cuando se le dan las propiedades mencionadas
    {
        this.ID = ID;
        this.Name = Name;
        this.Email = Email;
        this.RegisterDate = DateTime.Now;
    }

    public int GetID()
    {
        return ID;
    }

    public DateTime GetRegisteredDate()
    {
        return RegisterDate;
    }

    public virtual void SetBalance(decimal amount)//La propiedad asignada de Balance entra aquí y se vuelve amount
    {
        decimal quantity = 0; //quantity es una variable que iniciará en 0 cuando se ejecute el método
        if (amount < 0) // Checa si el valor ingresado de amount es negativo
            quantity = 0;
        else
            quantity = amount; //Si no es negativo, se asigna a quantity
        this.Balance += quantity; //Y ahora sí se suma el valor a la propiedad de la clase Balance.
        
    }

    public virtual string ShowData() //este es un método 
    {
        /* Concatenando se ve así
        return "Nombre: " + this.Name + ", Correo: " + this.Email + ", Saldo: " + this.Balance + ", Fecha de Registro: " + this.RegisterDate;
        */
        // Interpolado se ve así creo:
        return $"ID: {this.ID}, Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate.ToShortDateString()}";
    } 

    public string ShowData(string initialMessage)
    {
        return $"{initialMessage} -> ID: {this.ID}, Nombre: {this.Name}, Correo: {this.Email}, Saldo: {this.Balance}, Fecha de Registro: {this.RegisterDate.ToShortDateString()}";
    }

}