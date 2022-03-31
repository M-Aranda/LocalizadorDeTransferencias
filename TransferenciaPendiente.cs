using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizadorDeFacturasPendientes
{
    class TransferenciaPendiente
    {

        private String centro;
        private String fechaProg;
        private String planilla;
        private String conductor;
        private String banco;
        private String observacion;
        private String corte;
        private String monto;
        private String rut;

        public TransferenciaPendiente()
        {
        }

        public TransferenciaPendiente(string centro, string fechaProg, string planilla, string conductor, string banco, string observacion, string corte, string monto, string rut)
        {
            this.Centro = centro;
            this.FechaProg = fechaProg;
            this.Planilla = planilla;
            this.Conductor = conductor;
            this.Banco = banco;
            this.Observacion = observacion;
            this.Corte = corte;
            this.Monto = monto;
            this.Rut = rut;
        }

        public string Centro { get => centro; set => centro = value; }
        public string FechaProg { get => fechaProg; set => fechaProg = value; }
        public string Planilla { get => planilla; set => planilla = value; }
        public string Conductor { get => conductor; set => conductor = value; }
        public string Banco { get => banco; set => banco = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Corte { get => corte; set => corte = value; }
        public string Monto { get => monto; set => monto = value; }
        public string Rut { get => rut; set => rut = value; }
    }
}
