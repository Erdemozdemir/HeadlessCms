using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract
{
    public interface IUserRepository
    {
        List<UserEntity> GetUsers();
        List<SelectListItem> GetSelectListItems(string defaultValue, string selectedValue = null, Expression<Func<UserEntity, bool>> filter = null);
    }
}
