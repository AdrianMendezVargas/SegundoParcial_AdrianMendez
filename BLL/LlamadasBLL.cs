using Microsoft.EntityFrameworkCore;
using SegundoParcial_AdrianMendez.DAL;
using SegundoParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcial_AdrianMendez.BLL {
	public class LlamadasBLL {

		public static bool Guardar(Llamada llamada) {

			bool guardado = false;

			Contexto db = new Contexto();

			try {

				db.Llamadas.Add(llamada);
				guardado = (db.SaveChanges() > 0);
				

			} catch (Exception) {

				throw;
			} finally {
				db.Dispose();
			}

			return guardado;
		}

		public static Llamada Buscar(int llamadaId) {

			Contexto db = new Contexto();
			Llamada llamada;

			try {

				llamada = db.Llamadas.Where(l => l.LlamadaId == llamadaId).Include(l => l.ProblemasDetalle).SingleOrDefault();

			} catch (Exception) {

				throw;
			} finally {
				db.Dispose();
			}

			return llamada;
		}

		public static bool Eliminar(int llamadaId) {

			bool eliminado = false;

			Contexto db = new Contexto();
			

			try {

				Llamada llamadaEliminada = Buscar(llamadaId);

				if (llamadaEliminada != null) {
					db.Entry(llamadaEliminada).State = EntityState.Deleted;
					eliminado = (db.SaveChanges() > 0);
				}
				


			} catch (Exception) {

				throw;
			} finally {
				db.Dispose();
			}

			return eliminado;
		}

		public static bool Modificar(Llamada llamada) {

			bool modificado = false;

			Contexto db = new Contexto();

			try {

				db.Database.ExecuteSqlRaw($"Delete From LlamadaDetalle Where LlamadaId = {llamada.LlamadaId}");

				foreach (var item in llamada.ProblemasDetalle) {
					db.Entry(item).State = EntityState.Added;
				}

				db.Entry(llamada).State = EntityState.Modified;
				modificado = (db.SaveChanges() > 0);


			} catch (Exception) {

				throw;
			} finally {
				db.Dispose();
			}

			return modificado;
		}



	}
}
