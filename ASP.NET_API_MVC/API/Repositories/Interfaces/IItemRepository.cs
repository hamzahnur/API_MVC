using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IItemRepository
    {
        IEnumerable<ViewModel> Get();
        Task<IEnumerable<ViewModel>> Get(int Id);
        int Create(Item supplier);
        int Update(Item supplier, int Id);
        int Delete(int Id);
    }
}
