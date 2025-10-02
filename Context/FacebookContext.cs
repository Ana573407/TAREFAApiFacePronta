using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefaFAcebookApi.Models;

namespace TarefaFAcebookApi.Context
{
    public class FacebookContext : DbContext
    {
        public FacebookContext(DbContextOptions<FacebookContext> options) : base(options)
        {

        }
        public DbSet<Usuario>Usuarios{ get; set; }
    }
}