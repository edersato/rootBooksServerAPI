using rootBooks.Models;
using System.Text.Json;
using rootBooks.Data;

using System;

namespace rootBooks.Services
{
    public class ReloaderData
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public ReloaderData(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }
        public async Task SeedDataAsync()
        {
            string clientesUrl = "https://camposdealer.dev/Sites/TesteAPI/cliente";
            string produtosUrl = "https://camposdealer.dev/Sites/TesteAPI/produto";
            string vendasUrl = "https://camposdealer.dev/Sites/TesteAPI/venda";

            var clientesResponse = await _httpClient.GetStringAsync(clientesUrl);
            string jsonString = clientesResponse.Replace("\\\"", "\"");

            Console.WriteLine(jsonString);

            try
            {
                var clientes = JsonSerializer.Deserialize<List<Cliente>>(jsonString);

                if (clientes != null)
                {
                    _context.Clientes.AddRange(clientes);
                    await _context.SaveChangesAsync();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro na desserialização: {ex.Message}");
            }

            //var produtosResponse = await _httpClient.GetStringAsync(produtosUrl);

            //Console.WriteLine(produtosResponse);

            //var produtos = produtosResponse;



            //if (produtos != null)
            //{
            //    _context.Produtos.AddRange(produtos);
            //}

            //var vendasResponse = await _httpClient.GetStringAsync(vendasUrl);

            //Console.WriteLine(vendasResponse);

            //var vendas = vendasResponse;

            //if (vendas != null)
            //{
            //    foreach (var venda in vendas)
            //    {
            //        venda.DataVenda = venda.DataVenda.ToString();
            //    }
            //    _context.Vendas.AddRange(vendas);
            //}

            //await _context.SaveChangesAsync();
        }
    }
}
