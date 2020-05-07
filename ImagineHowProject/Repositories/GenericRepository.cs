using ImagineHowProject.Interfaces;
using ImagineHowProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ImagineHowProject.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ImagineHowProjectContext Context;
        private readonly string _pathToTheFile = Path.Combine(Directory.GetCurrentDirectory(), "JSRepo", typeof(TEntity).FullName + ".json");

        public GenericRepository(ImagineHowProjectContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }


        public void WriteToJsonFile(TEntity entity)
        {
            if (!File.Exists(_pathToTheFile))
            {
                File.Create(_pathToTheFile);
            }
            var json = File.ReadAllText(_pathToTheFile);
            var entityResult = JsonConvert.DeserializeObject<List<TEntity>>(json);
            if (entityResult != null)
            {
                entityResult.Add(entity);
            }
            else
            {
                entityResult = new List<TEntity>();
                entityResult.Add(entity);
            }
            File.WriteAllText(_pathToTheFile, JsonConvert.SerializeObject(entityResult));
        }

        public List<TEntity> ReadFromJsonFile()
        {
            List<TEntity> entityResult = null;
            if (!File.Exists(_pathToTheFile))
            {
                var json = File.ReadAllText(_pathToTheFile);
                entityResult = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }
            return entityResult;
        }
    }
}
