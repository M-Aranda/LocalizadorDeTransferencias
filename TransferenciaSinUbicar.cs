using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizadorDeFacturasPendientes
{
    class TransferenciaSinUbicar
    {

        private String corte;
        private String monto;
        private String ubicacion;

        public TransferenciaSinUbicar()
        {
        }

        public TransferenciaSinUbicar(string corte, string monto, string ubicacion)
        {
            this.Corte = corte;
            this.Monto = monto;
            this.Ubicacion = ubicacion;
        }

        public string Corte { get => corte; set => corte = value; }
        public string Monto { get => monto; set => monto = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
    }
}
