partial class Program
{
    static DateTime GetDateFromLine(string line)
    {
        try
        {
            string[] lineArr = line.Split(' ');
            string dateString = $"{lineArr[0]} {lineArr[1]}";

            DateTime date = DateTime.Parse(dateString);

            return date;
        }
        catch (FormatException) 
        {
            Console.WriteLine("O formato da date é inválido");

            throw new Exception("Formato de log é inválido");
        }
    }
}