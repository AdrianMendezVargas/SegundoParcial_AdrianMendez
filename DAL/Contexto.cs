using Microsoft.EntityFrameworkCore;
using SegundoParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoParcial_AdrianMendez.DAL {
	public class Contexto : DbContext{


		public DbSet<Llamada> Llamadas { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			
			optionsBuilder.UseSqlite("Data Source = RegistroLlamadas.db");
		}

	}
}
