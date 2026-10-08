using StreamingFlix.App;
using Xunit;

namespace StreamingFlix.Tests
{
    public class PlanoStreamingServiceTests
    {
        private readonly PlanoStreamingService _service = new PlanoStreamingService();

        // Teste 1 (Classificação de Planos)
        [Theory]
        [InlineData(1, "BÁSICO")]
        [InlineData(2, "PADRÃO")]
        [InlineData(4, "PREMIUM")]
        public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(int telas, string esperado)
        {
            var resultado = _service.ObterClassificacaoPorQualidade(telas);

            Assert.Equal(esperado, resultado);
        }

        // Teste 2 (Cálculo de Desconto)
        [Theory]
        [InlineData(50, 1, 50)]   // sem desconto
        [InlineData(50, 6, 45)]   // 10% de desconto
        [InlineData(50, 12, 40)]  // 20% de desconto
        public void CalcularMensalidadeComDesconto_DeveAplicarDescontoCorreto(int valorBase, int meses, int esperado)
        {
            var resultado = _service.CalcularMensalidadeComDesconto(valorBase, meses);

            Assert.Equal((decimal)esperado, resultado);
        }

        // Teste 3 (Validação de Acesso)
        [Theory]
        [InlineData(20, false, true)]   // maior de idade, sem restrição -> true
        [InlineData(20, true, false)]   // maior de idade, com restrição -> false
        [InlineData(16, false, false)]  // menor de idade -> false
        public void PodeAcessarConteudoAdulto_DeveValidarAcessoCorretamente(int idade, bool controleParentalAtivo, bool esperado)
        {
            var resultado = _service.PodeAcessarConteudoAdulto(idade, controleParentalAtivo);

            Assert.Equal(esperado, resultado);
        }
    }
}