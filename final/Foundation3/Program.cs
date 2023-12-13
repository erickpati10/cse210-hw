using System;

class Program
{
    static void Main()
    {
        Vehicle car = new Car("Toyota", "Corolla", 2022, 4, "N");
        Vehicle car1 = new Car("Infiniti", "Q60", 2023, 2, "Y");
        Vehicle motorcycle = new Motorcycle("Honda", "CBR", 2021, 1000, "Y");
        Vehicle truck = new Truck("Volvo", "FH16", 2019, 20, "Y");

        DisplayVehicleDetails(car);
        DisplayVehicleDetails(car1);
        DisplayVehicleDetails(motorcycle);
        DisplayVehicleDetails(truck);
    }

    static void DisplayVehicleDetails(Vehicle vehicle)
    {
        Console.WriteLine("Vehicle Details:");
        vehicle.DisplayDetails();
        Console.WriteLine();
    }
}


class Vehicle
{
    protected string make;
    protected string model;
    protected int year;
    protected string vehicleType;

    public Vehicle(string make, string model, int year, string vehicleType)
    {
        this.make = make;
        this.model = model;
        this.year = year;
        this.vehicleType = vehicleType;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Type: {vehicleType}");
        Console.WriteLine($"Make: {make}");
        Console.WriteLine($"Model: {model}");
        Console.WriteLine($"Year: {year}");
    }
}

class Car : Vehicle
{
    private int numDoors;
    private string isConvertible;

    public Car(string make, string model, int year, int numDoors, string isConvertible)
        : base(make, model, year, "Car")
    {
        this.numDoors = numDoors;
        this.isConvertible = isConvertible;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Number of Doors: {numDoors} \nConvertible: {isConvertible}");
    }
}

class Motorcycle : Vehicle
{
    private int engineCapacity;
    private string hasFairing;

    public Motorcycle(string make, string model, int year, int engineCapacity, string hasFairing)
        : base(make, model, year, "Motorcycle")
    {
        this.engineCapacity = engineCapacity;
        this.hasFairing = hasFairing;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Capacity: {engineCapacity}cc \nFairing: {hasFairing}");
    }
}

class Truck : Vehicle
{
    private int cargoCapacity;
    private string hasSleeperCab;

    public Truck(string make, string model, int year, int cargoCapacity, string hasSleeperCab)
        : base(make, model, year, "Truck")
    {
        this.cargoCapacity = cargoCapacity;
        this.hasSleeperCab = hasSleeperCab;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Cargo Capacity: {cargoCapacity} tons \nSleeper Cab: {hasSleeperCab}");
    }
}


