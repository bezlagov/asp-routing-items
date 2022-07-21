using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimpleApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // AddMvc - добавляет сервисы, необходимые для работы MVC, включая Razor-страницы
            // services.AddMvc();

            // AddControllersWithViews - добавляет сервисы, необходимые для работы MVC, 
            // не включая Razor-страницы - только контроллеры и представления.
            // Для примеров данного курса этого достаточно.
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller}/{action}/{category}"
                );
                endpoints.MapControllerRoute(
                        name: "Default",
                        pattern: "{controller}/{action}"
                    );
            });

            // {id?} - данный фрагмент шаблона описывает не обязательный сегмент в адресе запроса.
            // При этом в контроллерах по имени id можно будет получить информацию, которая пришла в запросе
            // Products/Details/10
            // {controller} = Products
            // {action} = Details
            // {id} = 10
        }
    }
}
