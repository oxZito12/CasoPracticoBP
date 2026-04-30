using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppCasoPractico.Dominio
{
    public class RegistroPago
    {
        /// <summary>
        /// identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// identificacion del cliente
        /// </summary>
        public string IdentificacionCliente { get; set; }
        /// <summary>
        /// Nombre Completo cliente
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Telefono cliente
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Email cliente
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// MontoDeuda cliente
        /// </summary>
        public decimal MontoDeuda { get; set; }
        /// <summary>
        /// Monto Propuesto del cliente
        /// </summary>
        public decimal MontoPropuesto { get; set; }
        /// <summary>
        /// Dias de Mora
        /// </summary>
        public int DiasMora { get; set; }
        /// <summary>
        /// Estado 
        /// </summary>
        public string Estado { get; set; } = "Pendiente";
        /// <summary>
        /// FechaRegistro pago
        /// </summary>
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
