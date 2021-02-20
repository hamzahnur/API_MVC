using API.Models;
using API.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        // GET: Suppliers
        SupplierRepository repository = new SupplierRepository();
        public IHttpActionResult Post(Supplier supplier)
        {
            var cek = repository.Create(supplier);
            if (cek == 0)
            {
                return BadRequest("Data gagal di tambah!");
            }
            else
            {
                return Ok("Data berhasil ditambah");
            }

        }

        public IHttpActionResult Delete(int Id)
        {
            var cek = repository.Delete(Id);
            if (cek == 0)
            {
                return BadRequest("Tidak Ada Data");
            }
            else
            {
                return Ok("Data Sudah dihapus");
            }

        }

        public IHttpActionResult Put(Supplier supplier, int Id)
        {
            var cek = repository.Update(supplier, Id); 
            if (cek == 0)
            {
                return BadRequest("Data Gagal di Update");
            }
            else
            {
                return Ok("Data Berhasil di Update");
            }


        }

        public IEnumerable<Supplier> Get()
        {
            return repository.Get();
        }

        public Task<IEnumerable<Supplier>> Get(int Id)
        {
            return repository.Get(Id);
            //var cek = repository.Get(Id);
            //if (cek == null)
            //{
            //    return NotFound();
            //}
            //return Ok(repository.Get(Id));

        }
    }
}