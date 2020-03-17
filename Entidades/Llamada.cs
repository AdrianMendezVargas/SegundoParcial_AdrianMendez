using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegundoParcial_AdrianMendez.Entidades {
    public class Llamada {


        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }


        [ForeignKey("LlamadaId")]
        public virtual List<LlamadaDetalle> ProblemasDetalle { get; set; }

        public Llamada() {
            LlamadaId = 0;
            Descripcion = "";
            ProblemasDetalle = new List<LlamadaDetalle>();
        }

    }
}
