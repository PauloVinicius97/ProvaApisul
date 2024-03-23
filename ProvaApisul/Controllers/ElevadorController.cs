using Microsoft.AspNetCore.Mvc;
using Main.Domain.Services;

namespace ProvaApisul.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevadorController : ControllerBase
    {
        private readonly ElevadorService _elevadorService;

        public ElevadorController()
        {
           _elevadorService = new ElevadorService(Directory.GetCurrentDirectory() + "\\bin\\Debug\\net6.0\\Data\\input.json");
        }

        [HttpGet("andarMenosUtilizado")]
        public ActionResult<int[]> AndarMenosUtilizado()
        {
            var result = _elevadorService.andarMenosUtilizado();

            return Ok(result);
        }

        [HttpGet("elevadorMaisFrequentado")]
        public ActionResult<char[]> ElevadorMaisFrequentado()
        {
            var result = _elevadorService.elevadorMaisFrequentado();

            return Ok(result);
        }

        [HttpGet("periodoMaiorFluxoElevadorMaisFrequentado")]
        public ActionResult<char[]> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            var result = _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

            return Ok(result);
        }

        [HttpGet("elevadorMenosFrequentado")]
        public ActionResult<char[]> ElevadorMenosFrequentado()
        {
            var result = _elevadorService.elevadorMenosFrequentado();

            return Ok(result);
        }

        [HttpGet("periodoMenorFluxoElevadorMenosFrequentado")]
        public ActionResult<char[]> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            var result = _elevadorService.periodoMenorFluxoElevadorMenosFrequentado();

            return Ok(result);
        }

        [HttpGet("periodoMaiorUtilizacaoConjuntoElevadores")]
        public ActionResult<char[]> PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            var result = _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();

            return Ok(result);
        }

        [HttpGet("percentualDeUsoElevadorA")]
        public ActionResult<float> PercentualDeUsoElevadorA()
        {
            var result = _elevadorService.percentualDeUsoElevadorA();

            return Ok(result);
        }

        [HttpGet("percentualDeUsoElevadorB")]
        public ActionResult<float> PercentualDeUsoElevadorB()
        {
            var result = _elevadorService.percentualDeUsoElevadorB();

            return Ok(result);
        }

        [HttpGet("percentualDeUsoElevadorC")]
        public ActionResult<float> PercentualDeUsoElevadorC()
        {
            var result = _elevadorService.percentualDeUsoElevadorC();

            return Ok(result);
        }

        [HttpGet("percentualDeUsoElevadorD")]
        public ActionResult<float> PercentualDeUsoElevadorD()
        {
            var result = _elevadorService.percentualDeUsoElevadorD();

            return Ok(result);
        }

        [HttpGet("percentualDeUsoElevadorE")]
        public ActionResult<float> PercentualDeUsoElevadorE()
        {
            var result = _elevadorService.percentualDeUsoElevadorE();

            return Ok(result);
        }
    }
}
