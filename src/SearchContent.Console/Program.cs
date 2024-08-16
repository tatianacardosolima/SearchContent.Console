// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string directoryPath = @"C:\_DEV\GitHubPortifolio"; 
string searchTerm = "Controller"; 

SearchInFiles(directoryPath, searchTerm);

static void SearchInFiles(string directoryPath, string searchTerm)
{
    // Verificar se o diretório existe
    if (!Directory.Exists(directoryPath))
    {
        Console.WriteLine("O diretório especificado não existe.");
        return;
    }

    
    var files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                         .Where(file => file.EndsWith(".cs") || file.EndsWith(".csproj"));

    foreach (var file in files)
    {
        // Ler todas as linhas do arquivo
        var lines = File.ReadAllLines(file);

        // Verificar se o conteúdo pesquisado está presente no arquivo
        bool found = lines.Any(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

        if (found)
        {
            Console.WriteLine($"{file}");
        }
    }
}