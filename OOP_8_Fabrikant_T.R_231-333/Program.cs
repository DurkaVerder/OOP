using System;

namespace OOP8
{

    class Program
    {

        static void Main(string[] args)
        {
            SmartLight light = new SmartLight("Гостиная");
            SmartThermostat thermostat = new SmartThermostat("Зал");
            SmartSpeaker speaker = new SmartSpeaker("Кухня");


            OperateDevice(light);
            OperateDevice(thermostat);
            OperateDevice(speaker);
        }

        public static void OperateDevice(SmartDevice device)
        {

            device.TurnOn();


            Console.WriteLine($"Состояние умного устройства, {device.Name}: {device.IsOn}");


            device.SetParameter(75);


            device.TurnOff();
            Console.WriteLine();
        }
    }


    abstract class SmartDevice
    {
        public abstract string Name { get; set; }
        public abstract bool IsOn { get; set; }

        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void SetParameter(int parameter);
    }


    class SmartLight : SmartDevice
    {
        public override string Name { get; set; }
        public override bool IsOn { get; set; }
        public int Brightness { get; set; }

        public SmartLight(string name)
        {
            Name = name;
            IsOn = false;
            Brightness = 50; 
        }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"Умная лампа, {Name}, включена");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"Умная лампа, {Name}, выключена");
        }

        public override void SetParameter(int brightness)
        {
            if (brightness < 0 || brightness > 100)
            {
                Console.WriteLine("Неправильный параметр");
                return;
            }
            Brightness = brightness;
            Console.WriteLine($"Яркость установлена на {Brightness}%");
        }


    } 

    class SmartThermostat : SmartDevice
    {
        public override string Name { get; set; }
        public override bool IsOn { get; set; }
        public int Temperature { get; set; }

        public SmartThermostat(string name)
        {
            Name = name;
            IsOn = false;
            Temperature = 22; 
        }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"Умный термометр, {Name}, включён");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"Умный термометр, {Name}, выключен");
        }

        public override void SetParameter(int temperature)
        {
            
            Temperature = temperature;
            Console.WriteLine($"Температура установлена на {Temperature}°C");
            
        }
    }

    class SmartSpeaker : SmartDevice
    {
        public override string Name { get; set; }
        public override bool IsOn { get; set; }
        public int Volume { get; set; }

        public SmartSpeaker(string name)
        {
            Name = name;
            IsOn = false;
            Volume = 50;
        }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"Умная колонка, {Name}, включена");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"Умная колонка, {Name}, выключена");
        }

        public override void SetParameter(int volume)
        {
            if ( volume < 0 || volume > 100)
            {
                Console.WriteLine("Неверный параметр");
                return;
            }
            Volume = volume;
            Console.WriteLine($"Громкость установлена на {Volume}%");
        }
    }

    
}
