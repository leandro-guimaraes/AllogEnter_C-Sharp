using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace Univali.Api.Configuration
{
    public static class MyJPIF
    {
        // Este método retorna um NewtonsoftJsonPatchInputFormatter
        public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            // Cria um novo ServiceCollection para configurar os serviços necessários
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            // Obtém o IOptions<MvcOptions> do Service Provider
            var mvcOptions = builder.GetRequiredService<IOptions<MvcOptions>>();

            // Obtém o valor de MvcOptions
            var options = mvcOptions.Value;

            // Obtém todos os InputFormatters registrados em MvcOptions
            var inputFormatters = options.InputFormatters;

            // Filtra a lista de InputFormatters e obtém o primeiro NewtonsoftJsonPatchInputFormatter
            var jsonPatchInputFormatter = inputFormatters.OfType<NewtonsoftJsonPatchInputFormatter>().First();

            // Retorna o NewtonsoftJsonPatchInputFormatter obtido
            return jsonPatchInputFormatter;
        }
    }
}

