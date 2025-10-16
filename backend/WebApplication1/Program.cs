
using Microsoft.EntityFrameworkCore;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using WebApplication1.Repositories;
using WebApplication1.Exceptions;
using WebApplication1.Service;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddScoped<ExpenseService>();
            builder.Services.AddScoped<IShareRequestRepository, ShareRequestRepository>();
            builder.Services.AddScoped<IShareRequestUserRepository, ShareRequestUserRepository>();
            builder.Services.AddScoped<ShareRequestService>();
            
            builder.Services.AddScoped<GroupService>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowViteDev",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                              
                    });
            });


            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowViteDev");
            app.UseExceptionHandler( _ => { });

           // app.UseHttpsRedirection();
            
            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}
