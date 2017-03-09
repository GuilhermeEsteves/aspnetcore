using System;
using System.Collections.Generic;
using System.Linq;
using AchadosPerdidosApi.Repository.Infra.Context;
using AchadosPerdidosApi.Repository.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace AchadosPerdidosApi.Repository.Infra.Repositories
{
    public class BaseRepository<T> : IDisposable where T : BaseEntity 
    {
        public IList<T> Get()
        {
            using(var context = new MySqlContext())
            {
                try
                {
                    return context.Set<T>().ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public T Get(int id)
        {
            using(var context = new MySqlContext())
            {
                try
                {
                    return context.Set<T>().First(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public T Add(T entity)
        {
            using(var context = new MySqlContext())
            {
                try
                {
                    entity.DataCadastro = DateTime.Now;
                    context.Set<T>().Add(entity);
                    context.SaveChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public T Remove(int id)
        {
            using(var context = new MySqlContext())
            {
                try
                {   
                    var entityRemove = context.Set<T>().First(x => x.Id == id);
                    context.Remove(entityRemove);
                    context.SaveChanges();
                    return entityRemove;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public T Update(T entity)
        {
            using(var context = new MySqlContext())
            {
                try
                {
                    entity.DataAlteracao = DateTime.Now;
                    context.Entry(entity).State = EntityState.Modified; 
                    context.SaveChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}