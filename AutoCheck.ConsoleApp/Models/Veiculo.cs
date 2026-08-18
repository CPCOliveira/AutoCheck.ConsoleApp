namespace AutoCheck.ConsoleApp.Models;

public class Veiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public double Quilometragem { get; set; }
    public List<ItemVistoria> VistoriaRealizada { get; set; }

    public Veiculo(string marca, string modelo, int ano, double quilometragem)
    {
        this.Marca = marca;
        this.Modelo = modelo;
        this.Ano = ano;
        this.Quilometragem = quilometragem;
        this.VistoriaRealizada = new List<ItemVistoria>();
    }

    public void AdicionarItemVistoriado(string nome, string status)
    {
        ItemVistoria novoItem = new ItemVistoria(nome, status);
        this.VistoriaRealizada.Add(novoItem);
    }

    public virtual List<string> ObterChecklistObrigatorio()
    {
        return new List<string>
        {
            "Pneus",
            "Motor",
            "Faróis",
            "Freios"
        };
    }
};