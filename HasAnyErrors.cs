partial class Program
{
    static bool HasAnyErrors(string line)
    {
        string[] lineArr = line.Split(' ');

        return lineArr[2].Contains("ERRO");
    }
}