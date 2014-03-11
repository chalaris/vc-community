using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.Foundation.Catalogs.Model;
using VirtoCommerce.Foundation.Data.Catalogs;

namespace VirtoCommerce.Web.Api.Controllers
{
    public class ItemController : ApiController
    {
        private EFCatalogRepository db = new EFCatalogRepository();

        // GET api/Default1
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        // GET api/Default1/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(string id)
        {
            Item item = null;//db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT api/Default1/5
        public IHttpActionResult PutItem(string id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ItemId)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Default1
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.ItemId }, item);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(string id)
        {
            Item item = null; //db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            //db.Items.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(string id)
        {
            return db.Items.Count(e => e.ItemId == id) > 0;
        }
    }
}