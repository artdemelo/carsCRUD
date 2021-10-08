using System;

namespace Carros
{

    public class Car : BaseEntity
    {
        //Attributes
        private Make Make { get; set; }
        private string Model { get; set; }
        private string Description { get; set;}
        private int Mileage {get; set;}
        private int Year {get; set;}
        private bool Deleted { get; set; }


        //Methods
        public Car(int id, Make make, string model, string description, int mileage, int year)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Description = description;
            this.Mileage = mileage;
            this.Year = year; 
            this.Deleted = false;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string returning = "";
            returning += "Make: " + this.Make + Environment.NewLine;
            returning += "Model: " + this.Model + Environment.NewLine;
            returning += "Description: " + this.Description + Environment.NewLine;
            returning += "Mileage: " + this.Mileage + Environment.NewLine;
            returning += "Year: " + this.Year + Environment.NewLine; 
            returning += "Deleted: " + this.Deleted;     
            return returning;
        }

        public string returnModel()
        {
            return this.Model;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}