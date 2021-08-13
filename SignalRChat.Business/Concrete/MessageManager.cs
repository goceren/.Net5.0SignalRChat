using Microsoft.EntityFrameworkCore;
using SignalRChat.Business.Abstract;
using SignalRChat.Core.Models;
using SignalRChat.Core.Utilities;
using SignalRChat.Data.Abstract;
using SignalRChat.Data.Context;
using SignalRChat.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public StatusModel<IList<Message>> GetMessageList(Expression<Func<Message, bool>> filter)
        {
            var returnData = new StatusModel<IList<Message>>();
            try
            {
                returnData.Entity = _messageDal.GetMessageList(filter);
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

        public StatusModel<Message> GetMessage(Expression<Func<Message, bool>> filter)
        {
            var returnData = new StatusModel<Message>();
            try
            {
                returnData.Entity = _messageDal.GetMessage(filter);

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


        public StatusModel<IList<Message>> GetList(Expression<Func<Message, bool>> filter)
        {
            var returnData = new StatusModel<IList<Message>>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _messageDal.GetEntities(filter);
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

        public StatusModel<Message> Get(Expression<Func<Message, bool>> filter)
        {
            var returnData = new StatusModel<Message>();
            try
            {
                returnData.Entity = _messageDal.Get(filter);

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

        public StatusModel<Message> Add(Message entity)
        {
            var returnData = new StatusModel<Message>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _messageDal.Add(entity);

                returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<Message> Update(Message entity)
        {
            var returnData = new StatusModel<Message>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _messageDal.Update(entity);

                returnData.Status.Message = "İşlem Başarılı"; returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = ex.ToInnerFormatString();
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusModel<Message> Delete(Expression<Func<Message, bool>> filter)
        {
            var returnData = new StatusModel<Message>();
            try
            {
                // returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _messageDal.Get(filter);
                entity.State = (byte)Enums.StateEnum.Deleted;
                _messageDal.Update(entity);

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
