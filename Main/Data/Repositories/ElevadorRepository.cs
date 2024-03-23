using Newtonsoft.Json;
using Main.Domain.Entities;


namespace Main.Data.Repositories
{
    public class ElevadorRepository
    {
        private readonly string url;

        public ElevadorRepository(string url)
        {
            this.url = url;
        }

        public async Task<List<ElevadorEntrada>> GetEntradasAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                var entradas = JsonConvert.DeserializeObject<List<ElevadorEntrada>>(json);
                
                return entradas;
            }
        }
    }
}
