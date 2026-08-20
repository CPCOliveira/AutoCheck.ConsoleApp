namespace AutoCheck.ConsoleApp.Models;

public class ItemVistoria
{
    public string Nome { get; set; }
    public string Status { get; private set; }

    public ItemVistoria(string nome, string status)
    {
        Nome = nome;

        if (!StatusEhValido(status))
        {
            throw new ArgumentException($"Status inválido: '{status}'. Use 'Bom', 'Regular' ou 'Ruim'.");
        }

        string valorMaiusculo = status.Trim().ToUpper();

        if (valorMaiusculo == "BOM")
        {
            Status = "Bom";
        }
        else if (valorMaiusculo == "REGULAR")
        {
            Status = "Regular";
        }
        else
        {
            Status = "Ruim";
        }
    }

    public static bool StatusEhValido(string valor)
    {
        string valorMaiusculo = valor.Trim().ToUpper();

        if (valorMaiusculo == "BOM" || valorMaiusculo == "REGULAR" || valorMaiusculo == "RUIM")
        {
            return true;
        }

        return false;
    }
}
