using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppCasoPractico.Dominio
{
    public class RegistroPagoDto
    {
        string IdentificacionCliente { get; set; }
        string NombreCompleto { get; set; } 
        string Telefono { get; set; }
        string Email { get; set; }
        decimal MontoDeuda { get; set; }
        decimal MontoPropuesto { get; set; }
        int DiasMora { get; set; }
        string? Observacion { get; set; }
    }
}
