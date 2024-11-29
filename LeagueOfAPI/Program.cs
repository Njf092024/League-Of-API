using Microsoft.EntityFrameworkCore;
using LeagueOfAPI.Models;
using LeagueOfAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AppDbContext<AppDbContext>(options => options.UseInMemoryDatabase("LeagueDb"));

var app = builder.Build();