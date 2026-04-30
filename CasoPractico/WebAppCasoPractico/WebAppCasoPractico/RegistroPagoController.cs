using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebAppCasoPractico.Dominio;

namespace WebAppCasoPractico
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPagoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistroPagoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistroPago request)
        {
            if (request.DiasMora < 120)
                return BadRequest("Solo aplica para mora mayor a 120 días");

            _context.PaymentIntents.Add(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.PaymentIntents
                .OrderByDescending(x => x.FechaRegistro)
                .ToListAsync();

            return Ok(data);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var intent = await _context.PaymentIntents.FindAsync(id);

            if (intent == null) return NotFound();

            intent.Estado = status;
            await _context.SaveChangesAsync();

            return Ok(intent);
        }
    }
}
