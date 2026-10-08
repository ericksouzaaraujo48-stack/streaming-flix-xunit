using System;

namespace StreamingFlix.App
{
    public class PlanoStreamingService
    {
        /// <summary>
        /// Retorna a classificação do plano de acordo com a quantidade de telas simultâneas.
        /// 1 tela = BÁSICO | 2 telas = PADRÃO | 4 ou mais = PREMIUM
        /// (3 telas não está especificado no enunciado; aqui é tratado como PADRÃO).
        /// </summary>
        public string ObterClassificacaoPorQualidade(int telasSimultaneas)
        {
            if (telasSimultaneas < 1)
                throw new ArgumentException("A quantidade de telas deve ser de pelo menos 1.", nameof(telasSimultaneas));

            if (telasSimultaneas == 1)
                return "BÁSICO";

            if (telasSimultaneas >= 4)
                return "PREMIUM";

            return "PADRÃO"; // 2 ou 3 telas
        }

        /// <summary>
        /// Calcula a mensalidade aplicando desconto conforme o tempo de contrato:
        /// 6 a 11 meses = 10% | 12 meses ou mais = 20% | menos de 6 meses = sem desconto.
        /// </summary>
        public decimal CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
        {
            if (valorBase < 0)
                throw new ArgumentException("O valor base não pode ser negativo.", nameof(valorBase));

            if (mesesContratados < 0)
                throw new ArgumentException("Os meses contratados não podem ser negativos.", nameof(mesesContratados));

            decimal desconto = 0m;

            if (mesesContratados >= 12)
                desconto = 0.20m;
            else if (mesesContratados >= 6)
                desconto = 0.10m;

            return valorBase * (1 - desconto);
        }

        /// <summary>
        /// Retorna true apenas se a idade for maior ou igual a 18 E o controle parental estiver desativado.
        /// </summary>
        public bool PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
        {
            return idade >= 18 && !controleParentalAtivo;
        }
    }
}