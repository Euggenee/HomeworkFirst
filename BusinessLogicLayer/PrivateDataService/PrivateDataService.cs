using BusinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.PrivateDataService
{
    public class PrivateDataService : IPrivateDataService
    {
        private readonly ApplicationDbContext _dbContext;
        public PrivateDataService(ApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _dbContext = dbContext;
        }

        public List<PrivateData> GetPrivateData()
        {
            var datas = _dbContext.PrivateDatas.ToList();
            var dataResalt = new List<PrivateData>();
            foreach (var data in datas)
            {
                var mapedData = new PrivateData { Data = data.Data };
                dataResalt.Add(mapedData);
            }

            return dataResalt;
        }
    }
}
