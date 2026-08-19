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
            string valor = value.Trim();

            if (string.Equals(valor, "Bom", StringComparison.OrdinalIgnoreCase))
            {
                _status = "Bom";
            }
            else if (string.Equals(valor, "Regular", StringComparison.OrdinalIgnoreCase))
            {
                _status = "Regular";
            }
            else if (string.Equals(valor, "Ruim", StringComparison.OrdinalIgnoreCase))
            {
                _status = "Ruim";
            }
            else
            {
                throw new ArgumentException($"Status inválido: '{value}'. Use 'Bom', 'Regular' ou 'Ruim'.");
            }
        }
    }

    public ItemVistoria(string nome, string status)
    {
        Nome = nome;
        Status = status;
    }
}
