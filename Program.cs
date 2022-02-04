
using Paralell.Service;
using System.Diagnostics;

string[] ceps = new string[5];
ceps[0] = "69048183";
ceps[1] = "29175459";
ceps[2] = "90830410";
ceps[3] = "37701010";
ceps[4] = "37704170";

Console.WriteLine($"Executando as chamadas de requisições para os Ceps: {ceps[0]},{ceps[1]},{ceps[2]},{ceps[3]},{ceps[4]} de forma Paralela");
Console.WriteLine();

//Define quantos nucles lógicos da cpu utilizaremos para executar as  requisições, ou seja, quantas Threads serão usadas para processar as requisições.
var parallelOptions = new ParallelOptions();
parallelOptions.MaxDegreeOfParallelism = 8;

var stopWatch = Stopwatch.StartNew();

stopWatch.Start();

//Executa de forma paralela as requisições, para cada iteração do for ele cria uma nova Thread definida pelo DotNet de forma automatica. Caso o parâmetro parallelOptions não seje passado.
Parallel.ForEach(ceps, parallelOptions, cep =>
{
    Console.WriteLine(new CepService().GetCep(cep) + $" - Thread de número: {Thread.CurrentThread.ManagedThreadId}");
});

/*Executa de forma sequencial aguardando a Thread corrente pra terminar as 5 requisições.
foreach (var cep in ceps)
{
    Console.WriteLine(new CepService().GetCep(cep) + $" - Thread de número: {Thread.CurrentThread.ManagedThreadId}");
}
*/
stopWatch.Stop();

Console.WriteLine();
Console.WriteLine($"O tempo de processamento foi de: {stopWatch.ElapsedMilliseconds} Ms");
Console.ReadKey();