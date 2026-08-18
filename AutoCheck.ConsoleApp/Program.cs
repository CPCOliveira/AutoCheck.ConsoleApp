using AutoCheck.ConsoleApp.Models;

Console.WriteLine("AutoCheck.ConsoleApp - motor de vistoria em construção");

var carro = new Carro("Toyota", "Corolla", 2021, 45000, 4);
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