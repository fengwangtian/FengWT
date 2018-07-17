using Sys.Framework.Data.EntityFramework;
using Sys.Framework.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Service.Sys
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Roles> _repository;
        public RoleService(IRepository<Roles> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int DeleteById(Expression<Func<Roles, bool>> whereLambds, bool isSave = true)
        {
            return _repository.DeleteById(whereLambds, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Roles GetModel(Expression<Func<Roles, bool>> where)
        {
            return _repository.GetModel(where);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="key"></param>
        /// <param name="totalItem"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IEnumerable<Roles> GetData(int pageIndex, int pageSize, string key, out int totalItem, bool isAsc = true)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return _repository.GetAllPaged(o => o.Role_Name.Contains(key), pageIndex, pageSize, out totalItem, o => o.Role_Id, isAsc);
            }
            return _repository.GetAllPaged(o => string.IsNullOrEmpty(o.Role_Id) , pageIndex, pageSize, out totalItem, o => o.Role_Id, isAsc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Insert(Roles entity, bool isSave = true)
        {
            return _repository.Insert(entity, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Update(Roles entity, bool isSave = true)
        {
            return _repository.Update(entity, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Roles> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
