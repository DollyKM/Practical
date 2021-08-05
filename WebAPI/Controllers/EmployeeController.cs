using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: api/Employee
        public IQueryable<EmployeeDetail> GetEmployeeDetails()
        {
            return db.EmployeeDetails;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> GetEmployeeDetail(int id)
        {
            EmployeeDetail employeeDetail = await db.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return Ok(employeeDetail);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {            
            if (id != employeeDetail.EmpID)
            {
                return BadRequest();
            }

            db.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
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

        // POST: api/Employee
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {       
            db.EmployeeDetails.Add(employeeDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeDetail.EmpID }, employeeDetail);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> DeleteEmployeeDetail(int id)
        {
            EmployeeDetail employeeDetail = await db.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(employeeDetail);
            await db.SaveChangesAsync();

            return Ok(employeeDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailExists(int id)
        {
            return db.EmployeeDetails.Count(e => e.EmpID == id) > 0;
        }
    }
}