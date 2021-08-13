using Microsoft.EntityFrameworkCore;
using SignalRChat.Core.Models;
using SignalRChat.Data.Abstract;
using SignalRChat.Data.Context;
using SignalRChat.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SignalRChat.Entity.Concrete;
using SignalRChat.Business.Helper;
using SignalRChat.Entity.ComplexTypes;

namespace SignalRChat.Data.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ISessionHelperService _sessionHelper;
        public UserManager(IUserDal userDal, ISessionHelperService sessionHelper)
        {
            _userDal = userDal;
            _sessionHelper = sessionHelper;
        }

        public StatusModel<IList<User>> GetUserList(Expression<Func<User, bool>> filter)
        {
            var returnData = new StatusModel<IList<User>>();
            try
            {
                returnData.Entity = _userDal.GetUserList(filter);
                if (returnData.Entity.Count == 0)
                {
                    returnData.Status.Message = "Veri Bulunamadı"; returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<CtIdentityUser> LoginUser(string authName, string password)
        {
            var returnData = new StatusModel<CtIdentityUser>();
            try
            {
                var md5Pass = ExtensionMethods.Md5Create(password);
                returnData.Entity = _userDal.LoginUser(authName, md5Pass);

                if (returnData.Entity == null)
                {
                    returnData.Status.Message = "Veri Bulunamadı"; returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    _sessionHelper.SetSession(returnData.Entity);
                    returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
                }

            }
            catch (Exception e)
            {
                returnData.Entity = null;
                returnData.Status.Status = Enums.StatusEnum.Error;
                returnData.Status.Message = e.ToInnerFormatString();
            }

            return returnData;
        }

        public StatusModel<User> GetUser(Expression<Func<User, bool>> filter)
        {
            var result = new StatusModel<User>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Users
                        .Where(filter)
                        .Include(i => i.Messages).ThenInclude(i => i.Receiver)
                        .Include(i => i.Messages).ThenInclude(i => i.Sender)
                        .FirstOrDefault();

                    if (query != null)
                    {
                        result.Entity = query;
                        result.Status.Status = Enums.StatusEnum.Successful;
                        result.Status.Message = Enums.StatusEnum.Successful.ToString();
                    }
                    else
                    {
                        result.Entity = null;
                        result.Status.Status = Enums.StatusEnum.EmptyData;
                        result.Status.Message = "Veri Bulunamadı";
                    }

                }
            }
            catch (Exception e)
            {
                result.Entity = null;
                result.Status.Status = Enums.StatusEnum.Error;
                result.Status.Message = e.ToInnerFormatString();
            }

            return result;
        }


        public StatusModel<IList<User>> GetList(Expression<Func<User, bool>> filter)
        {
            var returnData = new StatusModel<IList<User>>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _userDal.GetEntities(filter);
                if (returnData.Entity.Count == 0)
                {
                    returnData.Status.Message = "Veri Bulunamadı"; returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<User> Get(Expression<Func<User, bool>> filter)
        {
            var returnData = new StatusModel<User>();
            try
            {
                returnData.Entity = _userDal.Get(filter);

                if (returnData.Entity == null)
                {
                    returnData.Status.Message = "Veri Bulunamadı"; returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<User> Add(User entity)
        {
            var returnData = new StatusModel<User>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _userDal.Add(entity);

                returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<User> Update(User entity)
        {
            var returnData = new StatusModel<User>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _userDal.Update(entity);

                returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<User> Delete(Expression<Func<User, bool>> filter)
        {
            var returnData = new StatusModel<User>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _userDal.Get(filter);
                entity.State = (byte)Enums.StateEnum.Deleted;
                _userDal.Update(entity);

                returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
    }
}
