namespace AutoCheck.ConsoleApp.Models;

public class ItemVistoria
{
    private string _status;

    public string Nome { get; set; }

    public string Status
    {
        get => _status;
        set
        {
            if (value != "Bom" && value != "Regular" && value != "Ruim")
            {
                throw new ArgumentException($"Status inválido: '{value}'. Use 'Bom', 'Regular' ou 'Ruim'.");
            }
            _status = value;
        }
    }

    public ItemVistoria(string nome, string status)
    {
        Nome = nome;
        Status = status;
    }
}
