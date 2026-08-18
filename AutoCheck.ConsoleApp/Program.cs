using AutoCheck.ConsoleApp.Models;

Console.WriteLine("AutoCheck.ConsoleApp - motor de vistoria em construção");

var veiculo = new Veiculo("Toyota", "Corolla", 2021, 45000);
veiculo.AdicionarItemVistoriado("Farol", "Bom");
veiculo.AdicionarItemVistoriado("Motor", "Regular");

Console.WriteLine($"Veículo: {veiculo.Marca} {veiculo.Modelo} ({veiculo.Ano})");
Console.WriteLine($"Itens vistoriados: {veiculo.VistoriaRealizada.Count}");

Console.WriteLine("Checklist obrigatório:");
foreach (string item in veiculo.ObterChecklistObrigatorio())
{
    Console.WriteLine($" - {item}");
}