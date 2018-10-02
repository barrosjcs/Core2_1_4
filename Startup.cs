using Fiap01.Data;
using Fiap01.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<PerguntasContext>(o => o.UseSqlServer(connection));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //MappingAppUse(app, env);
            MappingClass1(app, env);
        }

        private void MappingAppUse(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Ele permite que você adicione algo à resposta e passe para
            // o próximo middleware no pipeline, ou você pode forçar um
            // curto - circuito e forçar um resultado de retorno sem passar
            // para o próximo manipulador.
            app.Use((context, next) =>
            {
                context.Response.Headers.Add("X-Teste", "headerteste");
                return next();
            });

            app.Use(async (context, next) =>
            {
                var teste = 123;
                // Espera o próximo middleware para executar os proximos resultados
                await next.Invoke();
                var teste2 = 1234;
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("boa noite");
            });
        }

        private void MappingClass1(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Mostra a página de erro na tela
            // env.IsDevelopment: diz que é ambiente de desenvolvimento
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //app.UseMiddleware<LogMiddleware>();
            app.useMeuLog();

            // Rotas utilizadas no MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "autor",
                //    template: "autor/{nome}",
                //    defaults: new { controller = "Autor", action = "Index" });

                //routes.MapRoute(
                //    name: "autoresDoAno",
                //    template: "{ano:int}/autor",
                //    defaults: new { controller = "Autor", action = "ListaDosAutoresDoAno" });

                //routes.MapRoute(
                //    name: "topicosdacategoria",
                //    template: "{categoria}/{topico}",
                //    defaults: new { controller = "Topicos", action = "Index" });
            });

            // Utilizando imagens estáticas
            app.UseStaticFiles();
        }
    }
}
