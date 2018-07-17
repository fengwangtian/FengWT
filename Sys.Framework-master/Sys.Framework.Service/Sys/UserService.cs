using Sys.Framework.Data.EntityFramework;
using Sys.Framework.Model.Sys;
using Sys.Framework.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Service.Sys
{
    public class UserService : IUserService
    {
        private readonly IRepository<Users> _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public UserService(IRepository<Users> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int DeleteById(Expression<Func<Users, bool>> whereLambds, bool isSave = true)
        {
            return _repository.DeleteById(whereLambds, isSave);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambds"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItem"></param>
        /// <param name="orderByLambds"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IEnumerable<Users> GetAllPaged<S>(Expression<Func<Users, bool>> whereLambds, int pageIndex, int pageSize, out int totalItem, Expression<Func<Users, S>> orderByLambds, bool isAsc = true)
        {
            return _repository.GetAllPaged(whereLambds, pageIndex, pageSize, out totalItem, orderByLambds, isAsc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Users GetModel(Expression<Func<Users, bool>> where)
        {
            return _repository.GetModel(where);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Insert(Users entity, bool isSave = true)
        {
            return _repository.Insert(entity, isSave);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<Users> SqlQuery(string sql, params object[] parameters)
        {
            return _repository.SqlQuery(sql, parameters);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public int Update(Users entity, bool isSave = true)
        {
            return _repository.Update(entity, isSave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public LoginValidate LoginValidateInfo(string Account, string Password)
        {
            if (_repository.GetModel(o => o.User_LoginName.Equals(Account)) == null)
            {
                return LoginValidate.NameNotExist;
            }
            if (_repository.GetModel(o => o.User_LoginName.Equals(Account) && o.User_LoginPassword.Equals(Password)) == null)
            {
                return LoginValidate.PasswordError;
            }
            return LoginValidate.OK;
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
        public IEnumerable<Users> GetUserData(int pageIndex, int pageSize, string key, out int totalItem, bool isAsc = true)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return _repository.GetAllPaged(o => o.User_LoginName.Contains(key), pageIndex, pageSize, out totalItem, o => o.User_CreateDate, isAsc);
            }
            return _repository.GetAllPaged(o => o.User_State == 1, pageIndex, pageSize, out totalItem, o => o.User_CreateDate, isAsc);
        }
    }
}
