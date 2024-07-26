partial class Program
{
    static void ReadAndLogResults(string file)
    {
        DateTime firstDate = DateTime.MinValue;
        DateTime lastDate = DateTime.MinValue;
        int logs = 0;
        int errors = 0;

        try
        {
            using (var logFileStream = new FileStream(file, FileMode.Open))
            {
                var fileReader = new StreamReader(logFileStream);

                while (!fileReader.EndOfStream)
                {
                    var line = fileReader.ReadLine();
                    DateTime date = GetDateFromLine(line);

                    if (HasAnyErrors(line))
                    {
                        errors++;
                    }

                    if (logs == 0)
                    {
                        firstDate = date;
                    }

                    logs++;
                    lastDate = date;
                }

                var totalTime = lastDate.Subtract(firstDate);

                Console.WriteLine($"Número total de entradas de log: {logs}");
                Console.WriteLine($"Número total de erros: {errors}");
                Console.WriteLine($"Tempo total decorrido: {totalTime} ({totalTime.Minutes} minutos e {totalTime.Seconds} segundos)");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("O arquivo não foi encontrado.");

            throw new Exception("Digite um diretório para o arquivo válido.");
        }
    }
}