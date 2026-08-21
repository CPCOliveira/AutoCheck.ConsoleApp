using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

int LerInteiro(string mensagem)
{
    Console.Write(mensagem);
    string texto = Console.ReadLine();
    bool valido = int.TryParse(texto, out int valor);

    while (!valido)
    {
        Console.WriteLine("Valor inválido. Por favor, digite novamente.");
        Console.Write(mensagem);
        texto = Console.ReadLine();
        valido = int.TryParse(texto, out valor);
    }

    return valor;
}

double LerDecimal(string mensagem)
{
    Console.Write(mensagem);
    string texto = Console.ReadLine();
    bool valido = double.TryParse(texto, out double valor);

    while (!valido)
    {
        Console.WriteLine("Valor inválido. Por favor, digite novamente.");
        Console.Write(mensagem);
        texto = Console.ReadLine();
        valido = double.TryParse(texto, out valor);
    }

    return valor;
}

List<Veiculo> vistorias = new List<Veiculo>();
MotorVistoria motor = new MotorVistoria();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\n=== AUTOCHECK - MENU PRINCIPAL ===");
    Console.WriteLine("1 - Realizar Nova Vistoria");
    Console.WriteLine("2 - Exibir Relatório das Vistorias");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Console.Write("Tipo de veículo (Carro, Moto, Caminhao): ");
        string tipo = Console.ReadLine().Trim().ToUpper();

        Console.Write("Marca: ");
        string marca = Console.ReadLine();

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        int ano = LerInteiro("Ano: ");
        double quilometragem = LerDecimal("Quilometragem: ");

        Veiculo veiculo = null;

        if (tipo == "CARRO")
        {
            int portas = LerInteiro("Quantidade de portas: ");
            veiculo = new Carro(marca, modelo, ano, quilometragem, portas);
        }
        else if (tipo == "MOTO")
        {
            int cilindradas = LerInteiro("Cilindradas: ");
            veiculo = new Moto(marca, modelo, ano, quilometragem, cilindradas);
        }
        else if (tipo == "CAMINHAO")
        {
            double capacidadeCarga = LerDecimal("Capacidade de carga (toneladas): ");
            int eixos = LerInteiro("Quantidade de eixos: ");
            veiculo = new Caminhao(marca, modelo, ano, quilometragem, capacidadeCarga, eixos);
        }
        else
        {
            Console.WriteLine("Tipo de veículo inválido.");
        }

        if (veiculo != null)
        {
            foreach (string item in veiculo.ObterChecklistObrigatorio())
            {
                string status;
                bool statusValido;

                do
                {
                    Console.Write($"Status do item '{item}' (Bom, Regular, Ruim): ");
                    status = Console.ReadLine();

                    statusValido = ItemVistoria.StatusEhValido(status);

                    if (!statusValido)
                    {
                        Console.WriteLine("Avaliação inválida. Por favor, digite 'Bom', 'Regular' ou 'Ruim'.");
                    }
                } while (!statusValido);

                veiculo.AdicionarItemVistoriado(item, status);
            }

            vistorias.Add(veiculo);
            Console.WriteLine("Vistoria registrada com sucesso!");
        }
    }
    else if (opcao == "2")
    {
        if (vistorias.Count == 0)
        {
            Console.WriteLine("Nenhuma vistoria registrada até o momento.");
        }
        else
        {
            foreach (Veiculo veiculo in vistorias)
            {
                int pontuacaoObtida = motor.CalcularPontuacaoObtida(veiculo);
                int pontuacaoMaxima = veiculo.VistoriaRealizada.Count * 10;
                double percentual = motor.CalcularPercentualAprovacao(veiculo);
                string classificacao = motor.ClassificarVeiculo(percentual);

                Console.WriteLine($"\n--- {veiculo.Marca} {veiculo.Modelo} ({veiculo.Ano}) ---");
                Console.WriteLine($"Pontuação: {pontuacaoObtida} de {pontuacaoMaxima} pontos possíveis");
                Console.WriteLine($"Percentual de aprovação: {percentual:F1}%");
                Console.WriteLine($"Classificação: {classificacao}");

                List<ItemVistoria> criticos = motor.ObterItensCriticos(veiculo);
                List<ItemVistoria> atencao = motor.ObterItensAtencao(veiculo);

                if (criticos.Count > 0)
                {
                    Console.WriteLine("Itens criticos");
                    foreach (ItemVistoria item in criticos)
                    {
                        Console.WriteLine(" - " + motor.GerarRecomendacao(item));
                    }
                }

                if (atencao.Count > 0)
                {
                    Console.WriteLine("Itens de atenção");
                    foreach (ItemVistoria item in atencao)
                    {
                        Console.WriteLine(" - " + motor.GerarRecomendacao(item));
                    }
                }

                if (criticos.Count == 0 && atencao.Count == 0)
                {
                    Console.WriteLine("Nenhuma pendência mecânica identificada. Veículo em boas condições.");
                }
            }
        }
    }
    else if (opcao == "0")
    {
        continuar = false;
    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }
}

Console.WriteLine("Encerrando o AutoCheck. Até logo!");
