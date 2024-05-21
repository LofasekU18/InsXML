using System.Text;

namespace InsXml;
class SearchSoap
{
    private static readonly HttpClient httpClient = new HttpClient();

    public static async Task<string> SoapSearchingIC(string ic)
    {
        string url = "https://isir.justice.cz:8443/isir_cuzk_ws/IsirWsCuzkService";

        string xmlSOAP =
        $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:typ=""http://isirws.cca.cz/types/"">
<soapenv:Header/>
    <soapenv:Body>
        <typ:getIsirWsCuzkDataRequest>
            <ic>{ic}</ic>
            <maxPocetVysledku>1</maxPocetVysledku>
            <filtrAktualniRizeni>T</filtrAktualniRizeni>
        </typ:getIsirWsCuzkDataRequest>
    </soapenv:Body>
</soapenv:Envelope>";

        try
        {
            return await SendSOAPRequestAsync(url, xmlSOAP);

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static async Task<string> SoapSearchingRC(string rc)
    {
        string url = "https://isir.justice.cz:8443/isir_cuzk_ws/IsirWsCuzkService";

        string xmlSOAP =
        $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:typ=""http://isirws.cca.cz/types/"">
<soapenv:Header/>
    <soapenv:Body>
        <typ:getIsirWsCuzkDataRequest>
            <rc>{rc}</rc>
            <maxPocetVysledku>1</maxPocetVysledku>
            <filtrAktualniRizeni>T</filtrAktualniRizeni>
        </typ:getIsirWsCuzkDataRequest>
    </soapenv:Body>
</soapenv:Envelope>";

        try
        {
            return await SendSOAPRequestAsync(url, xmlSOAP);

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private static async Task<string> SendSOAPRequestAsync(string url, string text)
    {
        using (HttpContent content = new StringContent(text, Encoding.UTF8, "text/xml"))
        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
        {
            request.Headers.Add("SOAPAction", "");
            request.Content = content;
            using (HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}