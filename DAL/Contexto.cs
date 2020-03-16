using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoParcial_AdrianMendez.DAL {
	public class Contexto : DbContext{

		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			
			optionsBuilder.UseSqlite("Data Source = Registro.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			//modelBuilder.Entity<>().HasData();
			
		}

	}
}
