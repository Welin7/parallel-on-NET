using Paralell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paralell.Service
{
    public class CepService
    {
        public CepModel GetCep(string cep)
        {
            var client = new HttpClient();
            var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var cepContent = JsonSerializer.Deserialize<CepModel>(content);

            return cepContent;
        }
    }
}
