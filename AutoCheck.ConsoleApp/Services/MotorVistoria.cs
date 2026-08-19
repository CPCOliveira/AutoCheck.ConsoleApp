namespace AutoCheck.ConsoleApp.Services;

using AutoCheck.ConsoleApp.Models;

public class MotorVistoria
{
    private int ConverterStatusEmPontos(string status)
    {
        if (status == "Bom")
        {
            return 10;
        }

        if (status == "Regular")
        {
            return 5;
        }

        if (status == "Ruim")
        {
            return 0;
        }

        throw new ArgumentException("Status inválido");
    }

    public int CalcularPontuacaoObtida(Veiculo veiculo)
    {
        int total = 0;

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            int pontos = ConverterStatusEmPontos(item.Status);
            total = total + pontos;
        }

        return total;
    }

    public double CalcularPercentualAprovacao(Veiculo veiculo)
    {
        int pontuacaoObtida = CalcularPontuacaoObtida(veiculo);
        int pontuacaoMaxima = veiculo.VistoriaRealizada.Count * 10;

        double percentual = (double)pontuacaoObtida / pontuacaoMaxima * 100;

        return percentual;
    }

    public string ClassificarVeiculo(double percentual)
    {
        if (percentual >= 90)
        {
            return "Aprovado com Excelência";

        }
        if (percentual >= 60)
        {
            return "Aprovado com Apontamentos";
        }

        return "Reprovado na Vistoria";
    }

    public List<ItemVistoria> ObterItensCriticos(Veiculo veiculo)
    {
        List<ItemVistoria> criticos = new List<ItemVistoria>();


        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Ruim")
            {
                criticos.Add(item);
            }
        }

        return criticos;
    }

    public List<ItemVistoria> ObterItensAtencao(Veiculo veiculo)
    {
        List<ItemVistoria> atencao = new List<ItemVistoria>();
        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular")
            {
                atencao.Add(item);
            }
        }
        return atencao;
    }

    public string GerarRecomendacao(ItemVistoria item)
    {
        if (item.Status == "Ruim")
        {
            return $"{item.Nome}: reparo ou substituição imediata necessária.";
        }

        if (item.Status == "Regular")
        {
            return $"{item.Nome}: revisão preventiva recomendada.";
        }

        return $"{item.Nome}: sem pendências.";
    }
}