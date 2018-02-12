using Domain.StoreContext.Handlers;
using Domain.StoreContext.Repositories;
using Domain.StoreContext.Services;
using Infra.StoreContext.DataContexts;
using Infra.StoreContext.Repositories;
using Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<ViniciusDataContext, ViniciusDataContext>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<ICostumerRepository, CostumerRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}