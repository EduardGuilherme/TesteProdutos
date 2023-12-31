using TesteProdutos.Data;
using TesteProdutos.Repository.Intefaces;
using TesteProdutos.Repository;
using Microsoft.EntityFrameworkCore;

namespace ProdutosTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
               .AddDbContext<TesteProdutosDBContext>(
                   options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
               );

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}