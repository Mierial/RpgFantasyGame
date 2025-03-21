using System.Net.Http;
using System.Threading.Tasks;
public class WebData 
{
    public static readonly HttpClient client = new HttpClient();

    public async Task<string> FetchData(string url)
    {
        string result = await client.GetStringAsync(url);
        return result;
    }
}
