namespace AutoCheck.ConsoleApp.Models;

public class Caminhao : Veiculo
{
    public int QuantidadeEixos { get; set; }
    public double CapacidadeCargaToneladas { get; set; }

    public Caminhao(string marca, string modelo, int ano, double quilometragem, double capacidadeCargaToneladas, int quantidadeEixos)
        : base(marca, modelo, ano, quilometragem)
    {
        this.CapacidadeCargaToneladas = capacidadeCargaToneladas;
        this.QuantidadeEixos = quantidadeEixos;
    }

    public override List<string> ObterChecklistObrigatorio()
    {
        List<string> itens = base.ObterChecklistObrigatorio();
        itens.Add("Estepe");
        return itens;
    }
}