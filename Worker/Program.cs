using System;

class Worker
{
    private string name;
    private int age;
    private int experience;

    public Worker(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Возраст должен быть в пределах от 0 до 100 лет.");
            }
            age = value;
        }
    }

    public int Experience
    {
        get { return experience; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Стаж не может быть отрицательным.");
            }
            if (value > age)
            {
                throw new ArgumentException("Стаж не может быть больше возраста.");
            }
            experience = value;
        }
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Возраст: {Age}, Стаж: {Experience} лет";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Worker worker = new Worker(name);

            Console.Write("Введите возраст: ");
            worker.Age = int.Parse(Console.ReadLine());

            Console.Write("Введите стаж: ");
            worker.Experience = int.Parse(Console.ReadLine());

            Console.WriteLine(worker);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите числовое значение для возраста и стажа.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}