using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using App.Metrics;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using template_identifier.Metrics;
using template_identifier.Models;

namespace ProductService.Controllers
{
    public abstract class GenericController<T> : ODataController where T: class, IEntity
    {
        DataContext db;

        public IMetrics Metrics { get;set; }

        public GenericController(DataContext context, IMetrics metrics)
        {
            db = context;
            Metrics = metrics;
        }

        private bool Exists(long key)
        {
            using (Metrics.Measure.Timer.Time(GenericRegistry.Exists(typeof(T)))) {
                return TableForT().Any(p => p.Id == key);
            }
        }

        private DbSet<T> TableForT()
        {
            return db.Set<T>();
        }

        #region CRUD

        // E.g. GET http://localhost/Products
        [EnableQuery] // EnableQuery allows filter, sort, page, top, etc.
        public IQueryable<T> Get()
        {
            using (Metrics.Measure.Timer.Time(GenericRegistry.Get(typeof(T)))) {
                return TableForT();
            }
        }

        // E.g. GET http://localhost/Products(1)
        [EnableQuery]
        [Route("{id:int}")]
        public SingleResult<T> Get([FromODataUri] long key)
        {
            using (Metrics.Measure.Timer.Time(GenericRegistry.GetById(typeof(T)))) {
                IQueryable<T> result = Get().Where(p => p.Id == key);
                return SingleResult.Create(result);
            }
        }

        // E.g. POST http://localhost/Products
        [HttpPost]
        public async Task<IActionResult> Post(T obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (Metrics.Measure.Timer.Time(GenericRegistry.Post(typeof(T)))) {
                TableForT().Add(obj);
                await db.SaveChangesAsync();
                return Created(obj);
            }
        }

        // E.g. PATCH http://localhost/Products(1)
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<T> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await TableForT().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            using (Metrics.Measure.Timer.Time(GenericRegistry.Patch(typeof(T)))) {
                delta.Patch(entity);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(key))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Updated(entity);
            }
        }

        // E.g. PUT http://localhost/Products(1)
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, T obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != obj.Id)
            {
                return BadRequest();
            }
            using (Metrics.Measure.Timer.Time(GenericRegistry.Put(typeof(T)))) {
                db.Entry(obj).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(key))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Updated(obj);
            }
        }

        // E.g. DELETE http://localhost/Products(1)
        [HttpDelete]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
            using (Metrics.Measure.Timer.Time(GenericRegistry.Delete(typeof(T)))) {
                var entity = await TableForT().FindAsync(key);
                if (entity == null)
                {
                    return NotFound();
                }

                TableForT().Remove(entity);
                await db.SaveChangesAsync();
                return NoContent();
            }
        }

        #endregion
    }
}