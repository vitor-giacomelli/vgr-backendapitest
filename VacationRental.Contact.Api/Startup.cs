﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using VacationRental.Contact.Api.Controllers;
using VacationRental.Contact.Api.Models;
using VacationRental.Contact.Api.Models.DataManager;
using VacationRental.Contact.Api.Models.DataRepository;

namespace VacationRental.Contact.Api
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

            services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new Info { Title = "Vacation rental contact information", Version = "v1" }));

            services.AddDbContext<ContactViewModelContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ContactsDB"]));

            services.AddScoped<IDataRepository<ContactViewModel>, ContactViewModelManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact v1"));
        }
    }
}
