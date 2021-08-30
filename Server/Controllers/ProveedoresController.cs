using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Shared;
using WebApi.Shared.Data;
using WebApi.Shared.Data.Entity;

namespace WebApi.Server.Controllers
{
    [ApiController]
    [Route("api/Proveedorees")]
    public class ProveedoresController : ControllerBase
    {
        private readonly DataContext context;

        public ProveedoresController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> Get()
        {
            return await context.Proveedores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            var proveedor = await context.Proveedores.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (proveedor == null)
            {
                return NotFound($"No existe proveedor con un ID igual a {id}.");
            }
            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> Post(Proveedor proveedor)
        {
            try
            {
                context.Proveedores.Add(proveedor);
                await context.SaveChangesAsync();
                return proveedor;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Proveedor>> Put(int id,[FromBody] Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Prov2 = await context.Proveedores.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Prov2== null)
            {
                return NotFound("no existe el proveedor a modificar.");
            }
            Prov2.NombreProvedor = proveedor.NombreProvedor;
            Prov2.Telefono = proveedor.Telefono;
            Prov2.Empresa = proveedor.Empresa;
            Prov2.Descripcion = proveedor.Descripcion;
            try
            {
                context.Proveedores.Update(Prov2);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido modificados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proveedor = await context.Proveedores.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (proveedor==null)
            {
                return NotFound($"No existe proveedor con un Id igual a {id}.");
            }
            try
            {
                context.Proveedores.Remove(proveedor);
                await context.SaveChangesAsync();
                return Ok($"El provvedor {proveedor.NombreProvedor} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }
    }
    
}
