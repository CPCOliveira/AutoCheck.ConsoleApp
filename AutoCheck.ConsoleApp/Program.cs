using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

Console.WriteLine("AutoCheck.ConsoleApp - motor de vistoria em construção");

var carro = new Carro("Toyota", "Corolla", 2021, 45000, 4);
carro.AdicionarItemVistoriado("Farol", "Bom");
carro.AdicionarItemVistoriado("Motor", "Regular");
var motor = new MotorVistoria();
double percentual = motor.CalcularPercentualAprovacao(carro);

var moto = new Moto("Honda", "CB 500", 2020, 12000, 500);
var caminhao = new Caminhao("Volvo", "FH 540", 2019, 280000, 30.0, 3);



Console.WriteLine("\n--- Checklist Carro ---");
foreach (string item in carro.ObterChecklistObrigatorio())
    Console.WriteLine($" - {item}");



Console.WriteLine("\n--- Checklist Moto ---");
foreach (string item in moto.ObterChecklistObrigatorio())
    Console.WriteLine($" - {item}");

Console.WriteLine("\n--- Checklist Caminhao ---");
foreach (string item in caminhao.ObterChecklistObrigatorio())
    Console.WriteLine($" - {item}");

string classificacao = motor.ClassificarVeiculo(percentual);
Console.WriteLine($"Classificação: {classificacao}");

foreach (ItemVistoria item in motor.ObterItensAtencao(carro))
{
    Console.WriteLine(motor.GerarRecomendacao(item));
}