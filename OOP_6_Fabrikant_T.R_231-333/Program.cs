using System;

namespace OOP6
{
    class Programm
    {
        static void Main()
        {
            MyClass obj1 = new MyClass
            {
                NonNullStr = "Aaa",
                NonNullInt = 1,
                NonNullDouble = 2.2,
                NullStr = null,
                NullInt = null,
                NullDouble = null,
            };

            MyClass obj2 = new MyClass
            {
                NonNullStr = "VVV",
                NonNullInt = 45,
                NonNullDouble = 1232.2,
                NullStr = "Yapii",
                NullInt = 10,
                NullDouble = 1.231,
            };

            obj1.Info();
            obj2.Info();


            obj1.NonNullStr = null;
            obj1.Info();

            obj2.NonNullStr = null!;
            obj2.Info();

            // obj1.NonNullInt = null; Ошибка компиляции. Невозвможно преобразовать тип Null в тип int
            // obj1.NonNullInt = null!; Ошибка компиляции. Невозвможно преобразовать тип Null в тип int
            obj1.NonNullStr = "AAAA";

            int LengthStr = obj1.NonNullStr!.Length; // Компилятору указано, что свойство точно не Null


            // Попытка присовить Null к полям типа Int и Double вызовет ошибку, так как значимые типы по умолчанию не могут быть равны null.
            // Даже с восклицательным знаком ошибка не исчезнет.
            // Попытка присвоить Null к полям типа String не приводит к ошибке, но компилятор делает предупреждение.\
            // Восклицательный знак подавляет предупреждение компилятора.
            AssignIfNull(obj1);
            obj1.Info();

            Console.WriteLine(GetNonNullString(null));

            Console.WriteLine(GetNullIntValue(obj2));
            
        }

        static void AssignIfNull(MyClass obj)
        {
            obj.NullStr ??= "Значение по умолчанию";
            obj.NullInt ??= 0;
            obj.NullDouble ??= 0.0;
        }

        static string GetNonNullString(MyClass? obj)
        {
            return obj?.NonNullStr ?? "Объект null";
        }

        static int GetNullIntValue(MyClass obj)
        {
            return obj.NullInt ?? -1; 
        }
    }

    class MyClass() 
    {
        // Подавление предупреждение компилятора
#nullable disable
        public string NonNullStr {  get; set; }
#nullable restore

        public int NonNullInt { get; set; }
        public double NonNullDouble { get; set; }


        public string? NullStr { get; set; }
        public int? NullInt { get; set; }
        public double? NullDouble { get; set; }

        public void Info()
        {
            Console.WriteLine($"NonNullStr: {NonNullStr}");
            Console.WriteLine($"NonNullInt: {NonNullInt}");
            Console.WriteLine($"NonNullDouble: {NonNullDouble}");



            Console.WriteLine($"NullStr: {NullStr ?? "Данные отсутствуют"}");
            if (NullInt == null)
            {
                Console.WriteLine($"NullInt: Данные отсутствуют");
            }
            else
            {
                Console.WriteLine($"NullInt: {NullInt}");
            }
            
            if (NullDouble == null) 
            {
                Console.WriteLine($"NullDouble: Данные отсутствуют\n");
            }
            else
            {
                Console.WriteLine($"NullDouble: {NullDouble}\n");
            }
        }
    }

}