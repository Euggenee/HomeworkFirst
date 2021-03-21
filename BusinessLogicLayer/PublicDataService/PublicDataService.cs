using BusinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.PublicDataService
{
    public class PublicDataService : IPublicDataService
    {
       
        private readonly ApplicationDbContext _dbContext;
        public PublicDataService(ApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _dbContext = dbContext;
        }

        public List<PublicData> GetPublicData()
        {
            var datas = _dbContext.PublicDatas.ToList();
            var dataResalt = new List<PublicData>();
            foreach (var data in datas)
            {
                var mapedData = new PublicData { Data = data.Data };
                dataResalt.Add(mapedData);
            }

            return dataResalt;
        }
    }
    
}
