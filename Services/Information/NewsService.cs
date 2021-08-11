using AutoMapper;
using AutoMapper.QueryableExtensions;
using InteractiveWebsite.Common;
using InteractiveWebsite.Common.Interfaces.Information;
using InteractiveWebsite.Common.WebModels.Information;
using InteractiveWebsite.Database;
using InteractiveWebsite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveWebsite.Services.Information
{
    public class NewsService : INewsService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public NewsService(AppDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IEnumerable<WebNews>> Load(int idHigherThan)
        {
            var webNews = await _dbContext.News
                .Where(e => e.Id > idHigherThan)
                .OrderByDescending(e => e.Id)
                .Take(Constants.MaxNewsPerPage)
                .ProjectTo<WebNews>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return webNews;
        }

        public Task Add(string text, string userId)
        {
            var news = new News { AuthorId = userId, Content = text };
            _dbContext.News.Add(news);
            return _dbContext.SaveChangesAsync();
        }
    }
}
