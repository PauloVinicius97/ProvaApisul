# Prova admissional da Apisul

Resolução da prova admissional da Apisul, que pode ser encontrada aqui: [https://github.com/guifilipiak/ProvaAdmissionalApisul](https://github.com/guifilipiak/ProvaAdmissionalApisul). 

## Projeto

O projeto pode ser aberto e testado com facilidade, baixando e abrindo-o no Visual Studio. Há uma API com Swagger para executar os testes. O arquivo json de testes é recuperado da web ao passar o link do arquivo no ElevadorService, que cria uma instância do ElevadorRepository com ele.

Na biblioteca de classes **Main**, são encontrados os arquivos principais do projeto, implementados com Domain-Driven Design e arquitetura em camadas simplificados. A API fica em **ProvaApisul**.

O **ElevadorService** faz uso de dicionários, listas e LINQ para atender aos requisitos do projeto. Descrição dos métodos:

- **andarMenosUtilizado** traz todos os andares em ordem crescente de utilização;
- **elevadorMaisFrequentado** traz todos os elevadores em ordem decrescente de frequência;
- **periodoMaiorFluxoElevadorMaisFrequentado** traz todos os períodos com maior fluxo para cada um dos elevadores, em ordem decrescente de frequência;
- **elevadorMenosFrequentado** traz todos os andares em ordem crescente de frequência;
- **periodoMenorFluxoElevadorMenosFrequentado** traz todos os períodos com menor fluxo para cada um dos elevadores, em ordem crescente de frequência;
- **periodoMaiorUtilizacaoConjuntoElevadores** traz todos os períodos em ordem decrescente de utilização;
- **percentualDeUsoElevadorA**, **percentualDeUsoElevadorB**, **percentualDeUsoElevadorC**, **percentualDeUsoElevadorD**, **percentualDeUsoElevadorE** trazem o percentual de uso de seu respectivo elevador.

Optei por trazer todos os andares, elevadores e períodos pois a interface está pedindo o retorno de uma lista de chars em seus métodos. Creio que seja mais útil para o usuário ter essa visão completa do que ver apenas o único período de maior utilização dos elevadores, por exemplo.

