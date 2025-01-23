using dotnet_async.Client;

#region Programação Assincrona
//object chave = new object();
//Task<string> conteudoTask;

//lock(chave)
//{
//    conteudoTask = Task.Run(() => File.ReadAllTextAsync("voos.txt"));
//}

//async Task LerArquivoAsync(CancellationToken token)
//{
//	try
//	{
//        await Task.Delay(new Random().Next(300, 8000));
//        Console.WriteLine($"Conteúdo: \n{conteudoTask.Result}");
//		token.ThrowIfCancellationRequested();
//    }
//    catch (OperationCanceledException ex)
//    {
//        Console.WriteLine($"Tarefa Cancelada: {ex.Message}");
//    }
//    catch (AggregateException ex)
//	{
//        Console.WriteLine($"Aconteceu o erro: {ex.InnerException!.Message}");
//	}
//}

//async Task<List<Voo>> LerVoosDoArquivoJsonAsync(string caminhoArquivo)
//{
//    using (var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
//    {
//        return await JsonSerializer.DeserializeAsync<List<Voo>>(stream);
//    }

//}

//async Task ExibirRelatorioAsync(CancellationToken token)
//{
//	try
//	{
//        Console.WriteLine("Executando relatório de compra de passagens!");
//        await Task.Delay(new Random().Next(300, 8000));
//        token.ThrowIfCancellationRequested();
//    }
//	catch (OperationCanceledException ex)
//	{
//        Console.WriteLine($"Tarefa Cancelada: {ex.Message}");
//	}

//}

//async Task ProcessarVooAsync(Voo voo)
//{
//    // Simulação de algum processamento assíncrono (ex: gravação em banco, envio de email, etc.)
//    await Task.Delay(1000); // Simula um atraso de 1 segundo para cada voo
//    Console.WriteLine($"Voo: {voo.Id}, Origem: {voo.Origem}, Destino: {voo.Destino}, Preço: {voo.Preco}, Milhas: {voo.MilhasNecessarias}");
//}

//async Task ProcessarVoosAsync()
//{
//    string caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("\\bin\\Debug\\net9.0\\", "\\voos.json");
//    //string caminhoArquivo = "\\voos.json";
//    var voos = await LerVoosDoArquivoJsonAsync(caminhoArquivo);

//    var tarefas = new List<Task>();

//    foreach (var voo in voos)
//    {
//        // Processa cada voo de forma assíncrona
//        tarefas.Add(ProcessarVooAsync(voo));
//    }

//    // Aguarda todas as tarefas terminarem
//    await Task.WhenAll(tarefas);
//}

//await ProcessarVoosAsync();

//CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

//Task tarefa = Task.WhenAll(LerArquivoAsync(cancellationTokenSource.Token), ExibirRelatorioAsync(cancellationTokenSource.Token));
//await Task.Delay(1000).ContinueWith(_ => cancellationTokenSource.Cancel());


//Console.WriteLine("Outras operações.");
//Console.ReadKey();
#endregion

var client = new JornadaMilhasClient(new JornadaMilhasClientFactory().CreateClient());

async Task ProcessarConsultaDeVoosAsync()
{
    var voos = await client.ConsultarVoos();

    foreach (var voo in voos)
    {
        Console.WriteLine(voo.ToString());
    }
}

await ProcessarConsultaDeVoosAsync();