using Main.Data.Repositories;
using Main.Domain.Entities;
using Main.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Services
{
    public class ElevadorService : IElevadorService
    {
        private readonly List<ElevadorEntrada> entradas;

        public ElevadorService()
        {
            var repository = new ElevadorRepository("https://raw.githubusercontent.com/guifilipiak/ProvaAdmissionalApisul/master/input.json");
            entradas = repository.GetEntradasAsync().Result.ToList();
        }

        public List<int> andarMenosUtilizado()
        {
            var contagemAndares = new int[16];

            foreach (var entrada in entradas)
            {
                contagemAndares[entrada.Andar]++;
            }

            var paresAndaresContagem = new List<(int, int)>();
            for (var andar = 0; andar < contagemAndares.Length; andar++)
            {
                paresAndaresContagem.Add((andar, contagemAndares[andar]));
            }

            paresAndaresContagem.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            var andaresMenosUtilizados = paresAndaresContagem.Select(par => par.Item1).ToList();

            return andaresMenosUtilizados;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var contagemElevadores = entradas.GroupBy(entrada => entrada.Elevador)
                                             .Select(group => new { Elevador = group.Key, Count = group.Count() })
                                             .OrderByDescending(entry => entry.Count)
                                             .ToList();

            var elevadoresMaisFrequentados = contagemElevadores.Select(entry => entry.Elevador).ToList();

            return elevadoresMaisFrequentados;
        }

            public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadoresMaisFrequentados = elevadorMaisFrequentado();
            var periodosMaisFluxo = new List<char>();

            foreach (char elevador in elevadoresMaisFrequentados)
            {
                var contagemPeriodos = entradas.Where(entrada => entrada.Elevador == elevador)
                                               .GroupBy(entrada => entrada.Turno)
                                               .ToDictionary(group => group.Key, group => group.Count());

                var periodoMaisFluxo = contagemPeriodos.OrderByDescending(dictionaryEntry => dictionaryEntry.Value)
                                                         .First().Key;

                periodosMaisFluxo.Add(periodoMaisFluxo);
            }

            return periodosMaisFluxo;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var elevadoresMaisFrequentados = elevadorMaisFrequentado();

            elevadoresMaisFrequentados.Reverse();

            return elevadoresMaisFrequentados;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var resultado = new List<char>();
            var turnosPossiveis = new char[] { 'M', 'V', 'N' };

            var elevadoresMenosFrequentados = elevadorMenosFrequentado();

            foreach (var elevador in elevadoresMenosFrequentados)
            {
                var menorFluxo = turnosPossiveis
                    .Select(turno => new
                    {
                        Turno = turno,
                        Contagem = entradas.Count(e => e.Elevador == elevador && e.Turno == turno)
                    })
                    .OrderBy(t => t.Contagem)
                    .ThenBy(t => t.Turno)
                    .First()
                    .Turno;

                resultado.Add(menorFluxo);
            }

            return resultado;
        }


        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            Dictionary<char, int> contagemTurnos = new Dictionary<char, int>();

            foreach (var entrada in entradas)
            {
                if (contagemTurnos.ContainsKey(entrada.Turno))
                {
                    contagemTurnos[entrada.Turno]++;
                }
                else
                {
                    contagemTurnos[entrada.Turno] = 1;
                }
            }

            List<char> turnosOrdenados = contagemTurnos.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            return turnosOrdenados;
        }


        public float percentualDeUsoElevadorA() => PercentualDeUsoElevador('A');
        public float percentualDeUsoElevadorB() => PercentualDeUsoElevador('B');
        public float percentualDeUsoElevadorC() => PercentualDeUsoElevador('C');
        public float percentualDeUsoElevadorD() => PercentualDeUsoElevador('D');
        public float percentualDeUsoElevadorE() => PercentualDeUsoElevador('E');

        private float PercentualDeUsoElevador(char elevador)
        {
            var totalUtilizacoes = entradas.Count;
            var utilizacoesElevador = entradas.Count(entrada => entrada.Elevador == elevador);

            if (totalUtilizacoes == 0)
            {
                return 0;
            }

            var percentual = (float)utilizacoesElevador / totalUtilizacoes * 100;

            return (float)Math.Round(percentual, 2);
        }
    }
}
