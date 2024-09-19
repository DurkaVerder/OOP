using System;
using System.ComponentModel;


namespace OOP7 
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new Airport();

            Airplane airplane1 = new Airplane(900, 18000, 100000, "Boeing 747", 300, 12000, 68.4f);
            Airplane airplane2 = new Airplane(950, 15000, 80000, "Airbus A320", 200, 10000, 34.1f);

            Helicopter helicopter1 = new Helicopter(300, 5000, 5000, "Apache AH-64", 5, 4, 3000);
            Helicopter helicopter2 = new Helicopter(280, 4500, 4000, "Bell 206", 6, 2, 2000);

            airport.Add(airplane1);
            airport.Add(airplane2);
            airport.Add(helicopter1);
            airport.Add(helicopter2);

            airport.AircraftCount();

            airplane1.ToString();
            helicopter1.ToString();

            airplane2.TakeOff();
            helicopter2.Hover();
        }
    }

    public class Aircraft
    {
        private float mass;
        private float speed;
        private float capFuel;
        private string name;

        public float Mass { get { return mass; } set { mass = value; } }
        public float Speed { get { return speed;} set { speed = value; } }
        public float CapFuel { get { return capFuel;} set { capFuel = value; } }
        public string Name { get { return name; } set { name = value ?? "объект"; } }

        public Aircraft(float speed, float capFuel, float mass, string name) { 
            Speed = speed;
            CapFuel = capFuel;
            Mass = mass;
            Name = name;
        }
        public string ToString()
        {
            return $"Название: {name}, Скорость: {speed} км/ч, Объём топлива: {capFuel} л";
        }
    }


    public class Airplane : Aircraft 
    {
        private int countPassengers;
        private float maxFlightAltitude;
        private float wingSpan; 

        public int CountPassengers { get { return countPassengers; } set { countPassengers = value; } }
        public float MaxFlightAltitude { get { return maxFlightAltitude; } set { maxFlightAltitude = value; } }
        public float WingSpan { get { return wingSpan; } set { wingSpan = value; } }

        public Airplane(float speed, float capFuel, float mass, string name, int countPassengers, float maxFlightAltitude, float wingSpan)
            : base(speed, capFuel, mass, name)
        {
            CountPassengers = countPassengers;
            MaxFlightAltitude = maxFlightAltitude;
            WingSpan = wingSpan;
        }

        public void TakeOff()
        {
            Console.WriteLine($"{Name} взлетает и поднимается на {MaxFlightAltitude} метров.");
        }

        public string ToString()
        {
            return $"Самолёт: {Name}, Скорость: {Speed} км/ч, Объём топлива: {CapFuel} л, Пассажиры: {CountPassengers}, Максимальная высота: {MaxFlightAltitude} m, Длина крыла: {WingSpan} м";
        }
    }

    public class Helicopter : Aircraft 
    {
        private int countPassengers;
        private int rotorBlades; 
        private float maxHoverAltitude; 
        public int CountPassengers { get { return countPassengers; } set { countPassengers = value; } }
        public int RotorBlades { get { return rotorBlades; } set { rotorBlades = value; } }
        public float MaxHoverAltitude { get { return maxHoverAltitude; } set { maxHoverAltitude = value; } }
        public Helicopter(float speed, float capFuel, float mass, string name, int countPassengers, int rotorBlades, float maxHoverAltitude)
        : base(speed, capFuel, mass, name)
        {
            CountPassengers = countPassengers;
            RotorBlades = rotorBlades;
            MaxHoverAltitude = maxHoverAltitude;
        }

        public void Hover()
        {
            Console.WriteLine($"{Name} зависает на {MaxHoverAltitude} метров с {CountPassengers} пассажирами.");
        }


        public string ToString()
        {
            return $"Вертолёт: {Name}, Скорость: {Speed} км/ч, Объём топлива: {CapFuel} л, Пассажиры: {CountPassengers}, Лопасти ротора: {RotorBlades}, Максимальная высота: {MaxHoverAltitude} м";
        }
    }

    public class Airport 
    { 
        private List<Aircraft> aircrafts = new List<Aircraft>();

        public void Add(Aircraft aircraft)
        {
            aircrafts.Add(aircraft);
        }

        public void AircraftCount()
        {
            int airplaneCount = aircrafts.OfType<Airplane>().Count();
            int helicopterCount = aircrafts.OfType<Helicopter>().Count();

            Console.WriteLine($"Количество самолётов: {airplaneCount}");
            Console.WriteLine($"Колтчество вертолётов: {helicopterCount}");
        }
    }

}
