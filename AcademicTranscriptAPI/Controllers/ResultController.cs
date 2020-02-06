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
using AcademicTranscriptAPI.Models;

namespace AcademicTranscriptAPI.Controllers
{
    public class ResultController : ApiController
    {
        private AcademicTranscriptDBEntities db = new AcademicTranscriptDBEntities();

        // GET: api/Result
        public IQueryable<Result> GetResults()
        {
            return db.Results;
        }

        // GET: api/Result/5
        [ResponseType(typeof(Result))]
        public IHttpActionResult GetResult(int id)
        {
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Result/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResult(int id, Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != result.Id)
            {
                return BadRequest();
            }

            db.Entry(result).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
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

        // POST: api/Result
        [ResponseType(typeof(Result))]
        public IHttpActionResult PostResult(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Results.Add(result);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = result.Id }, result);
        }

        // DELETE: api/Result/5
        [ResponseType(typeof(Result))]
        public IHttpActionResult DeleteResult(int id)
        {
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            db.Results.Remove(result);
            db.SaveChanges();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultExists(int id)
        {
            return db.Results.Count(e => e.Id == id) > 0;
        }
    }
}