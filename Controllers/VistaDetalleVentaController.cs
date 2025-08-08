﻿using Abarrotes.BaseDedatos;
using Abarrotes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abarrotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VistaDetalleVentaController : ControllerBase
    {
        private readonly AbarrotesReyesContext _context;

        public VistaDetalleVentaController(AbarrotesReyesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _context.VistaDetalleVentas.ToListAsync();

            if (lista.Count == 0)
                return NotFound(new { Mensaje = "No hay datos en la vista." });

            return Ok(new { Mensaje = "Vista consultada correctamente", Detalles = lista });
        }

        // ✅ GET: api/VistaDetalleVenta/porVenta/VENTA123
        [HttpGet("porVenta/{ventaId}")]
        public async Task<IActionResult> FiltrarPorVenta(string ventaId)
        {
            var resultados = await _context.VistaDetalleVentas
                .Where(v => v.VentaId == ventaId)
                .ToListAsync();

            if (resultados.Count == 0)
                return NotFound(new { Mensaje = "No se encontraron registros para esa venta." });

            return Ok(new { Mensaje = "Resultados encontrados", Detalles = resultados });
        }
    }
}
