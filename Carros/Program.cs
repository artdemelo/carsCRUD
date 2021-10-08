using System;

namespace Carros
{
    class Program
    {
        static CarRepository repository = new CarRepository();
        static void Main(string[] args)
        {
           string userOption = ObtainUserOption();

           while (userOption.ToUpper() != "X")
           {
               switch (userOption)
               {
                   case "1":
                        ListCars();
                        break;
                   case "2":
                        InsertCar();
                        break;
                   case "3":
                        UpdateCar();
                        break;
                   case "4":
                        DeleteCar();
                        break;
                   case "5":
                        ShowCar();
                        break;
                   case "C":
                        Console.Clear();
                        break;
                   default:
                        throw new ArgumentOutOfRangeException();
               }
               userOption = ObtainUserOption();
           }

           Console.WriteLine("Thank you for choosing our services.");
           Console.ReadLine();
        }

        private static void ListCars()
        {
            Console.WriteLine("List cars");

            var list = repository.Listing();

            if (list.Count == 0)
            {
                Console.WriteLine("There is no registered car.");
                return;
            }

            foreach (var car in list)
            {
                var deleted = car.returnDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", car.returnId(), car.returnModel(), (deleted ? "*Deleted*" : ""));
            }
        }

        private static void InsertCar() 
        {
            Console.WriteLine("Insert a new car:");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1

            foreach (int i in Enum.GetValues(typeof(Make)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Make), i));
            }
            Console.WriteLine();
            Console.Write("Select the make:");
            int inputMake = int.Parse(Console.ReadLine());

            Console.Write("Enter the model name:");
            string inputModel = Console.ReadLine();

            Console.Write("Enter the year of the car:");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the mileage of the car:");
            int inputMileage = int.Parse(Console.ReadLine());

            Console.Write("Enter the car description:");
            string inputDescription = Console.ReadLine();

            Car newCar = new Car(id: repository.NextId(),
                                 make: (Make)inputMake,
                                 model: inputModel,
                                 description: inputDescription,
                                 mileage: inputMileage,
                                 year: inputYear);
            
            repository.Insert(newCar);
        }

        private static void UpdateCar()
        {
            Console.Write("Enter the id of the car: ");
            int carIndex = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Make)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Make), i));
            }
            Console.Write("Select the make:");
            int makeInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the model of the car: ");
            string modelInput = Console.ReadLine();

            Console.Write("Enter the year of the car: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the mileage of the car: ");
            int mileageInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the car description: ");
            string descriptionInput = Console.ReadLine();

            Car updateCar = new Car (id: carIndex,
                                     make: (Make)makeInput,
                                     model: modelInput,
                                     year: yearInput,
                                     mileage: mileageInput,
                                     description: descriptionInput);
            repository.Update(carIndex, updateCar);
        }

        private static void DeleteCar()
        {
            Console.Write("Enter the car ID: ");
            int carIndex = int.Parse(Console.ReadLine());

            repository.Delete(carIndex);
        }

        private static void ShowCar()
        {
            Console.Write("Enter the car ID: ");
            int carIndex = int.Parse(Console.ReadLine());

            var car = repository.ReturnPerId(carIndex);

            Console.WriteLine(car);
        }

        private static string ObtainUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Art Cars at your service!!!");
            Console.WriteLine("Choose an option:");

            Console.WriteLine("1- List Cars");
            Console.WriteLine("2- Insert a new car");
            Console.WriteLine("3- Update car");
            Console.WriteLine("4- Delete car");
            Console.WriteLine("5- View a car's info");
            Console.WriteLine("C- Clear the screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
