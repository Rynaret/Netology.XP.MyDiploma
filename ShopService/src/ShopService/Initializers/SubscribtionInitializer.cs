﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Entities;

namespace ShopService.Initializers
{
    public class SubscribtionInitializer : IInitializable
    {
        private readonly DbContext _dbContext;

        public SubscribtionInitializer(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Order => 1;
        public void Initialize()
        {
            var subscriptionsInDb = _dbContext.Set<Subscription>().ToList();
            var subscription = new Subscription();
           
            if(subscriptionsInDb.Any()) return;

            _dbContext.Set<Subscription>().Add(subscription);
            _dbContext.SaveChanges();
        }
    }
}