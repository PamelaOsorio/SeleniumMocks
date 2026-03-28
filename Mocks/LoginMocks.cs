using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace ProjetoSeleniumMock.Mocks
{
    public static class LoginMock
    {
        public static void ConfigMock(WireMockServer mockServer)
        {
            mockServer
                .Given(Request.Create().WithPath("/login").UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "text/html")
                    .WithBody(@"
                <html>
                    <body>
                        <h1>Pagina de Login Mock</h1>
                        <input type='text' id='email' placeholder='email' /><br/>
                        <input type='password' id='password' placeholder='password' /><br/>
                        <button id='login-button'>Login</button>
                    </body>
                </html>"));


            //Mock da home
            mockServer
                .Given(Request.Create().WithPath("/home").UsingGet())
                .RespondWith(WireMock.ResponseBuilders.Response.Create()
                     .WithStatusCode(200)
                     .WithHeader("Content-Type", "text/html")
                     .WithBody("<html><body><h1 class='welcome'>Bem-vindo</h1></body></html>"));


        }
    }
}