using System;

public class KolichestvoException : Exception
{
    public KolichestvoException(string message) : base(message) { }
}

public class VkladException : Exception
{
    public VkladException(string message) : base(message) { }
}

public class Bank
{
    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
    }
}

public class Filial
{
    public string Name { get; set; }
    public double TotalDeposits { get; set; }

    public Filial(string name)
    {
        Name = name;
        TotalDeposits = 0;
    }
}

public abstract class Vklad
{
    public string FIO { get; set; }
    public double Sum { get; set; }
    public int Months { get; set; }

    public Vklad(string fio, double sum, int months)
    {
        FIO = fio;
        Sum = sum;
        Months = months;
    }

    public abstract double CalculateSum(int months);
}

public class DolgosrochnyVklad : Vklad
{
    public DolgosrochnyVklad(string fio, double sum, int months) : base(fio, sum, months) { }

    public override double CalculateSum(int months)
    {
        try
        {
            if (months < 0)
            {
                throw new KolichestvoException("количество месяцев не может быть отрицательным.");
            }

            return Sum * (1 + 0.16 * months / 12);
        }
        catch (KolichestvoException ex)
        {
            Console.WriteLine($"ошибка: {ex.Message}");
            return Sum;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ошибка: {ex.Message}");
            return Sum;
        }
    }
}

public class VkladDoVostrebovaniya : Vklad
{
    public VkladDoVostrebovaniya(string fio, double sum, int months) : base(fio, sum, months) { }

    public override double CalculateSum(int months)
    {
        try
        {
            if (months < 0)
            {
                throw new KolichestvoException("Количество месяцев не может быть отрицательным.");
            }

            return Sum;
        }
        catch (KolichestvoException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Sum;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Sum;
        }
    }
}

public class KratkosrochnyVklad : Vklad
{
    public KratkosrochnyVklad(string fio, double sum, int months) : base(fio, sum, months) { }

    public override double CalculateSum(int months)
    {
        try
        {
            if (months < 0)
            {
                throw new KolichestvoException("Количество месяцев не может быть отрицательным.");
            }

            return Sum * (1 + 0.03 * months / 12);
        }
        catch (KolichestvoException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Sum;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Sum;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Проверка обработки KolichestvoException:");
        try
        {
            DolgosrochnyVklad dolgosrochny = new DolgosrochnyVklad("Иванов Иван Иванович", 1000, -3);
            double sum = dolgosrochny.CalculateSum(dolgosrochny.Months);
            Console.WriteLine($"Сумма вклада: {sum}");
        }
        catch (KolichestvoException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nПроверка обработки VkladException:");
        try
        {
            Vklad vklad = new VkladDoVostrebovaniya("Петров Петр Петрович", -500, 1);
        }
        catch (VkladException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}