using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class ItemController : ApiController
    {
        ItemRepository repository = new ItemRepository();
        public IHttpActionResult Post(Item item)
        {
            var cek = repository.Create(item);
            if (cek == null)
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
            if (cek == null)
            {
                return BadRequest("Tidak Ada Data");
            }
            else
            {
                return Ok("Data Sudah dihapus");
            }
        }
        public IHttpActionResult Put(Item item, int Id)
        {
            var cek = repository.Update(item, Id);
            if (cek == null)
            {
                return BadRequest("Data do not update!!!");
            }
            else
            {
                return Ok("Data has been update");
            }
        }
        public IEnumerable<ViewModel> Get()
        {
            return repository.Get();
        }

        public Task<IEnumerable<ViewModel>> Get(int Id)
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
