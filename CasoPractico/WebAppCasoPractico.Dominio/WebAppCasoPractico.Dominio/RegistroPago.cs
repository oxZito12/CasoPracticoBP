using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppCasoPractico.Dominio
{
    public class RegistroPago
    {
        public int Id { get; set; }
        public string IdentificacionCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public decimal MontoDeuda { get; set; }
        public decimal MontoPropuesto { get; set; }
        public int DiasMora { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
