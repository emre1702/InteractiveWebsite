using InteractiveWebsite.Common.Classes.Information;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Information
{
    public interface INewsService
    {
        Task<IEnumerable<WebNews>> Load(int idHigherThan);
        Task Add(string text, string userId);
    }
}