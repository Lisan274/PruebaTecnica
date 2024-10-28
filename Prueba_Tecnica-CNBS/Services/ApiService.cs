using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["ApiKey"] ?? throw new ArgumentNullException(nameof(configuration), "ApiKey no puede ser nulo");

        // Configuración del encabezado de autorización como "Bearer"
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<XDocument> GetDeclarationsDataAsync(string fecha)
    {
        var url = $"https://iis-des.cnbs.gob.hn/ws.TestData/api/data?Fecha={fecha}";

        try
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Aquí lee el contenido de la respuesta para más detalles
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener datos: {response.StatusCode}, Detalle: {errorContent}");
            }

            var xmlResponse = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(xmlResponse);
        }
        catch (Exception ex)
        {
            throw new Exception("Error en la solicitud al servicio de declaraciones", ex);
        }
    }

    public static async Task<string> DecompressAsync(string compressedString)
    {
        try
        {
            using (MemoryStream msi = new MemoryStream(Convert.FromBase64String(compressedString)))
            using (MemoryStream mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    await gs.CopyToAsync(mso);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al descomprimir datos", ex);
        }
    }
}
