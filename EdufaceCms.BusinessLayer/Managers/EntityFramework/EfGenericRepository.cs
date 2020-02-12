using EdufaceCms.DataAccessLayer;
using EdufaceCms.DataAccessLayer.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        public DatabaseContext _context;

        public EfGenericRepository() => _context = new DatabaseContext();

        public async Task<int> AddAsync(TEntity entity)
        {
            using (_context)
            {
                entity.CreDate = DateTime.Now;
                entity.IsActive = true;
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                var id =await _context.SaveChangesAsync();

                return id;
            }
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            using (_context)
            {
                _context = new DatabaseContext();
                entity.IsActive = false;
                entity.ModDate = DateTime.Now;
                var deleEnt = _context.Entry(entity);
                deleEnt.State = EntityState.Modified;

                var id = await _context.SaveChangesAsync();

                return id;
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            using (_context)
            {
                entity.CreDate = entity.CreDate;
                entity.ModDate = DateTime.Now;
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                var id = await _context.SaveChangesAsync();
                return id;
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (_context)
            {
                return await _context.Set<TEntity>().Where(x => x.IsActive == true).SingleOrDefaultAsync(filter);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().Where(x => x.IsActive == true).SingleOrDefault(filter);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (_context)
            {
                if (filter == null)
                    return _context.Set<TEntity>().Where(x => x.IsActive == true).ToList();

                return await _context.Set<TEntity>().Where(filter).Where(x => x.IsActive==true).ToListAsync();
            }
        }

        public List<SelectListItem> GetSelectListItems(string text, string value, string defaultValue, int? selectedValue=null, Expression<Func<TEntity, bool>> filter = null)
        {
            using (_context)
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();

                if (filter == null)
                {
                    var entity = _context.Set<TEntity>();

                    selectListItems = entity.Where(x=>x.IsActive==true).Select(x => new SelectListItem
                    {
                        Text = x.GetType().GetProperty(text).GetValue(x).ToString(),
                        Value = x.GetType().GetProperty(value).GetValue(x).ToString(),
                        Selected = x.Id == selectedValue
                    }).ToList();
                }
                else
                    selectListItems = _context.Set<TEntity>().Where(filter).Select(x => new SelectListItem
                    {
                        Text = x.GetType().GetProperty(text).GetValue(x).ToString(),
                        Value = x.GetType().GetProperty(value).GetValue(x).ToString(),
                        Selected = x.Id == selectedValue
                    }).ToList();

                if (defaultValue != null && defaultValue != "")
                    selectListItems.Insert(0, new SelectListItem { Text = defaultValue, Value = "0", Selected = true, Disabled = true });

                return selectListItems;
            }
        }

        public bool IsAny(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().Any(filter);
        }

    }
}
