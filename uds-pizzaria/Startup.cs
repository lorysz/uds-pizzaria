﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Dao;
using Infra.DaoInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Service;
using Service.ServiceInterface;

namespace uds_pizzaria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();

            services.AddSingleton<IPedidoDao, PedidoDao>();
            services.AddSingleton<IPedidoService, PedidoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });
            app.UseMvc();

        }
    }
}
