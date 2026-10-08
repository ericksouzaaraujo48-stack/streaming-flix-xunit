# StreamingFlix

Projeto da disciplina de **Garantia da Qualidade de Software**, com a implementação das regras de negócio de planos de um serviço de streaming e seus respectivos testes unitários.

## Estrutura do projeto

```
StreamingFlix/
├── StreamingFlix.App/
│   └── PlanoStreamingService.cs
└── StreamingFlix.Tests/
    └── PlanoStreamingServiceTests.cs
```

## Regras implementadas

A classe `PlanoStreamingService` (projeto `StreamingFlix.App`) contém três métodos:

### `ObterClassificacaoPorQualidade(int telasSimultaneas)`

Retorna a classificação do plano de acordo com a quantidade de telas simultâneas.

| Telas simultâneas | Classificação |
|-------------------|---------------|
| 1                 | BÁSICO        |
| 2 (e 3*)          | PADRÃO        |
| 4 ou mais         | PREMIUM       |

\* O valor 3 não está especificado no enunciado e foi tratado como PADRÃO. Valores menores que 1 lançam `ArgumentException`.

### `CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)`

Aplica desconto sobre o valor base conforme o tempo de contrato.

| Meses contratados | Desconto |
|-------------------|----------|
| Menos de 6        | Nenhum   |
| 6 a 11            | 10%      |
| 12 ou mais        | 20%      |

O retorno é do tipo `decimal`. Valores negativos lançam `ArgumentException`.

### `PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)`

Retorna `true` somente se a idade for **maior ou igual a 18** **e** o controle parental estiver **desativado**.

| Idade | Controle parental | Resultado |
|-------|-------------------|-----------|
| 20    | desativado        | `true`    |
| 20    | ativo             | `false`   |
| 16    | desativado        | `false`   |

## Testes automatizados

Os testes foram escritos com **xUnit**, usando `[Theory]` e `[InlineData]`.

| Teste | Cenários cobertos |
|-------|-------------------|
| Teste 1 – Classificação de planos | `(1, "BÁSICO")`, `(2, "PADRÃO")`, `(4, "PREMIUM")` |
| Teste 2 – Cálculo de desconto | `(50, 1, 50)`, `(50, 6, 45)`, `(50, 12, 40)` |
| Teste 3 – Validação de acesso | `(20, false, true)`, `(20, true, false)`, `(16, false, false)` |

## Como executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado
- Projeto de testes com os pacotes `xunit`, `xunit.runner.visualstudio` e `Microsoft.NET.Test.Sdk`
- Referência do projeto de testes ao `StreamingFlix.App`

### Comandos

```bash
# Restaurar dependências e compilar
dotnet build

# Executar todos os testes
dotnet test
```

Também é possível executar os testes pelo **Test Explorer** do Visual Studio.

## Tecnologias

- C#
- .NET
- xUnit

## Autor

Nome do aluno – Centro Universitário UNA
