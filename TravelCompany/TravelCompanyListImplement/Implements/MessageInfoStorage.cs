using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyListImplement.Models;

namespace TravelCompanyListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;
        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            var result = new List<MessageInfoViewModel>();
            foreach (var message in source.Messages)
            {
                result.Add(CreateModel(message));
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            int toSkip = model.ToSkip ?? 0;
            int toTake = model.ToTake ?? source.Messages.Count; 
            var result = new List<MessageInfoViewModel>();
            foreach (var message in source.Messages)
            {
                if ((model.ClientId.HasValue && message.ClientId == model.ClientId)
                    || (!model.ClientId.HasValue && (model.ToSkip.HasValue && model.ToTake.HasValue || message.DateDelivery.Date == model.DateDelivery.Date)))
                {
                    if (toSkip > 0) 
                    { 
                        toSkip--; 
                        continue; 
                    }
                    if (toTake > 0)
                    {
                        result.Add(CreateModel(message));
                        toTake--;
                    }
                }
            }
            return result;
        }

        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var message in source.Messages)
            {
                if (message.MessageId == model.MessageId)
                {
                    return CreateModel(message);
                }
            }
            return null;
        }

        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            source.Messages.Add(CreateModel(model, new MessageInfo()));
        }

        public void Update(MessageInfoBindingModel model)
        {
            MessageInfo message = null;
            foreach (var mes in source.Messages)
            {
                if (mes.MessageId == model.MessageId)
                {
                    message = mes;
                    break;
                }
            }
            if (message == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, message);
        }

        private MessageInfoViewModel CreateModel(MessageInfo message)
        {
            return new MessageInfoViewModel
            {
                MessageId = message.MessageId,
                SenderName = message.SenderName,
                DateDelivery = message.DateDelivery,
                Subject = message.Subject,
                Body = message.Body,
                Checked = message.Checked,
                AnswerText = message.AnswerText
            };
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.ClientId = model.ClientId;
            message.SenderName = model.FromMailAddress;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.Body = model.Body;
            message.Checked = model.Checked;
            message.AnswerText = model.AnswerText;
            return message;
        }
    }
}
