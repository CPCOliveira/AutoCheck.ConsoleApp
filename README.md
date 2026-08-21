<div align="center">

# 🚗 AutoCheck.ConsoleApp

### Motor de Vistoria Veicular

Aplicação de console em **C# / .NET** que automatiza o processo de vistoria técnica de veículos para uma rede de concessionárias — calcula pontuação, percentual de aprovação, classificação final e recomendações de serviço.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Console App](https://img.shields.io/badge/Tipo-Console%20Application-2F80ED?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Conclu%C3%ADdo-2ECC71?style=for-the-badge)

</div>

---

## 📑 Sumário

- [Sobre o projeto](#-sobre-o-projeto)
- [Funcionalidades](#-funcionalidades)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Como executar](#-como-executar)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Regras de negócio](#-regras-de-negócio)
- [Conceitos de POO aplicados](#-conceitos-de-poo-aplicados)
- [Robustez e tratamento de entradas](#-robustez-e-tratamento-de-entradas)
- [Sobre arquitetura cliente-servidor](#-sobre-arquitetura-cliente-servidor)
- [Vídeo de apresentação](#-vídeo-de-apresentação)
- [Possíveis melhorias futuras](#-possíveis-melhorias-futuras)
- [Autor](#-autor)

---

## 📋 Sobre o projeto

No setor automotivo (concessionárias, locadoras e seguradoras), a vistoria técnica é um processo indispensável antes de aceitar um veículo usado — seja para revenda, seja como entrada na troca por um zero-quilômetro.

O **AutoCheck.ConsoleApp** simula o motor de processamento desse fluxo: o técnico informa os dados do veículo e o status de cada item de um checklist específico do tipo (Carro, Moto ou Caminhão), e o sistema:

1. Calcula a pontuação obtida e o percentual de aprovação;
2. Classifica o veículo (Excelência, Apontamentos ou Reprovado);
3. Lista os itens críticos e de atenção;
4. Recomenda os serviços prioritários para a oficina.

---

## ✨ Funcionalidades

- [x] Cadastro de vistoria para **Carro**, **Moto** e **Caminhão**, cada um com checklist próprio
- [x] Cálculo automático de pontuação e percentual de aprovação
- [x] Classificação final por faixa de percentual
- [x] Relatório de itens críticos (🔴) e de atenção (🟡), com recomendação de serviço
- [x] Menu interativo em loop, com histórico de todas as vistorias da sessão
- [x] Validação de entradas com repetição — o programa nunca quebra por causa de um valor inválido

---

## 🛠 Tecnologias utilizadas

| Tecnologia | Uso |
|---|---|
| **C# / .NET 10** | Linguagem e runtime do projeto |
| **Console Application** | Interface do usuário via terminal |
| **Git / GitHub** | Versionamento e histórico de desenvolvimento |

---

## ▶️ Como executar

**Pré-requisito:** [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 10 ou superior).

```bash
# Clone o repositório
git clone https://github.com/CPCOliveira/AutoCheck.ConsoleApp.git

# Entre na pasta do projeto
cd AutoCheck.ConsoleApp/AutoCheck.ConsoleApp

# Execute
dotnet run
```

O menu principal será exibido no terminal:

```
=== AUTOCHECK - MENU PRINCIPAL ===
1 - Realizar Nova Vistoria
2 - Exibir Relatório das Vistorias
0 - Sair
```

---

## 📁 Estrutura do projeto

```
AutoCheck.ConsoleApp/
├── README.md
└── AutoCheck.ConsoleApp/
    ├── Program.cs                  # Menu principal e fluxo de interação
    ├── AutoCheck.ConsoleApp.csproj
    ├── Models/
    │   ├── ItemVistoria.cs         # Item inspecionado (nome + status)
    │   ├── Veiculo.cs              # Classe base — dados comuns e checklist genérico
    │   ├── Carro.cs                # Herda de Veiculo
    │   ├── Moto.cs                 # Herda de Veiculo
    │   └── Caminhao.cs             # Herda de Veiculo
    └── Services/
        └── MotorVistoria.cs        # Regras de negócio: pontuação, percentual, classificação
```

---

## 📊 Regras de negócio

### Pontuação por item

| Status | Pontos |
|:---:|:---:|
| 🟢 Bom | 10 |
| 🟡 Regular | 5 |
| 🔴 Ruim | 0 |

### Cálculo do percentual

```
Percentual = (Pontuação Obtida / Pontuação Máxima Possível) × 100
```

A Pontuação Máxima Possível é `quantidade de itens vistoriados × 10`. O cálculo exige atenção a um detalhe clássico do C#: a divisão entre dois `int` trunca o resultado antes de multiplicar — por isso a conversão para `double` é aplicada **antes** da divisão acontecer, e não depois.

### Classificação final

| Percentual | Classificação |
|:---:|---|
| 90% – 100% | ✅ Aprovado com Excelência |
| 60% – 89% | ⚠️ Aprovado com Apontamentos |
| 0% – 59% | ❌ Reprovado na Vistoria |

### Checklist por tipo de veículo

Todo veículo compartilha os itens genéricos definidos em `Veiculo`; cada subtipo adiciona os seus próprios, via herança e sobrescrita:

| Tipo | Itens comuns | Itens específicos | Atributo(s) próprio(s) |
|---|---|---|---|
| 🚗 Carro | Pneus, Motor, Faróis, Freios | Bateria, Estepe | `QuantidadePortas` |
| 🏍 Moto | Pneus, Motor, Faróis, Freios | Chicote | `Cilindradas` |
| 🚛 Caminhão | Pneus, Motor, Faróis, Freios | Estepe | `QuantidadeEixos`, `CapacidadeCargaToneladas` |

---

## 🧩 Conceitos de POO aplicados

| Conceito | Onde aparece |
|---|---|
| **Encapsulamento** | `ItemVistoria.Status` só pode ser alterado internamente (`private set`), sempre validado |
| **Construtores explícitos com `this`** | `Veiculo`, `Carro`, `Moto`, `Caminhao` |
| **Herança (`:`)** | `Carro`, `Moto` e `Caminhao` herdam de `Veiculo` |
| **Polimorfismo (`virtual` / `override`)** | `ObterChecklistObrigatorio()` — cada subtipo devolve seu próprio checklist em tempo de execução, sem nenhum `if` decidindo qual usar |
| **Composição** | `Veiculo` contém uma `List<ItemVistoria>` |
| **Coleções (`List<T>`)** | Usadas em toda a aplicação — checklist, vistorias registradas, itens críticos/atenção |
| **Laços tradicionais (`foreach`/`for`/`while`)** | Toda a varredura de listas e o menu principal — sem uso de LINQ |
| **Métodos `static`** | `ItemVistoria.StatusEhValido(...)` — validação que não depende de nenhum objeto específico |

---

## 🛡 Robustez e tratamento de entradas

Durante os testes, identifiquei que entradas inválidas do usuário derrubavam a aplicação (exceção não tratada). Em vez de deixar isso acontecer, o sistema foi ajustado para **nunca quebrar por causa de um valor inválido** — ele sempre pede novamente até receber algo válido:

- **Status do item** (`Bom`/`Regular`/`Ruim`): validado por `ItemVistoria.StatusEhValido(...)`, aceitando qualquer combinação de maiúsculas/minúsculas.
- **Tipo de veículo** (`Carro`/`Moto`/`Caminhao`): normalizado com `.ToUpper()` antes da comparação.
- **Campos numéricos** (Ano, Quilometragem, Portas, Cilindradas, Capacidade de Carga, Eixos): usam `TryParse` em vez de `Parse`, dentro de um laço que repete a pergunta enquanto o valor digitado não for um número válido.

```csharp
int LerInteiro(string mensagem)
{
    Console.Write(mensagem);
    string texto = Console.ReadLine();
    bool valido = int.TryParse(texto, out int valor);

    while (!valido)
    {
        Console.WriteLine("Valor inválido. Digite novamente um número inteiro.");
        Console.Write(mensagem);
        texto = Console.ReadLine();
        valido = int.TryParse(texto, out valor);
    }

    return valor;
}
```

---

## 🌐 Sobre arquitetura cliente-servidor

<details>
<summary>Clique para expandir</summary>

<br>

Arquitetura cliente-servidor é um modelo em que um sistema é dividido em duas partes que se comunicam por rede: o **cliente**, que faz requisições, e o **servidor**, que as processa e devolve uma resposta — é o modelo por trás de praticamente toda aplicação web.

Este projeto **não implementa** essa arquitetura: o `AutoCheck.ConsoleApp` é uma aplicação de console *standalone*, que roda inteiramente numa única máquina, sem comunicação em rede nem separação entre cliente e servidor.

Uma evolução natural seria transformar o `MotorVistoria` em uma API (com ASP.NET Core), separando o processamento das regras de negócio (servidor) da interface usada pelo técnico (cliente) — permitindo que várias concessionárias usassem o mesmo motor de vistoria remotamente.

</details>

---

## 🎥 Vídeo de apresentação

> 📌 *[Link do vídeo aqui]*

---

## 🚧 Possíveis melhorias futuras

- Persistência dos dados em banco de dados (hoje as vistorias existem só durante a execução)
- Exportação do relatório para PDF ou arquivo de texto
- Testes automatizados para as regras de negócio do `MotorVistoria`
- Evolução para uma API (ver seção sobre arquitetura cliente-servidor)

---

## 👤 Autor

**Caio Oliveira**
Desenvolvedor Back-End .NET (em formação) — SENAI/SCTEC

