using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exemplo_grafico.Startup))]
namespace Exemplo_grafico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
