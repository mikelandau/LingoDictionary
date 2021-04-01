using System.Collections.Generic;
using System.Threading.Tasks;
using LingoDictionary.Models;

namespace LingoDictionary.Repositories
{
    public interface ITermRepository
    {
        Task<IEnumerable<Term>> GetAll();
        Task<Term> GetById(string id);
        Task Insert(Term term);
    }
}