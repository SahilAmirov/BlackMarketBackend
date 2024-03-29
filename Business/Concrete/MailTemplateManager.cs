﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailTemplateManager : IMailTemplateService
    {
        private readonly IMailTemplateDal _mailTemplateDal;

        public MailTemplateManager(IMailTemplateDal mailTemplateDal)
        {
            _mailTemplateDal = mailTemplateDal;
        }

        public IResult Add(MailTemplate mailTemplate)
        {
            _mailTemplateDal.Add(mailTemplate);
            return new SuccessResult(Messages.MailTemplateAdded);
        }

        public IResult Delete(MailTemplate mailTemplate)
        {
            _mailTemplateDal.Delete(mailTemplate);
            return new SuccessResult(Messages.MailTemplateDeleted);
        }

        public IDataResult<MailTemplate> Get(int id)
        {
            return new SuccessDataResult<MailTemplate>(_mailTemplateDal.Get(m=>m.ID== id));
        }

        public IDataResult<List<MailTemplate>> GetAll(int storeID)
        {
            return new SuccessDataResult<List<MailTemplate>>(_mailTemplateDal.GetList(m=>m.StoreID== storeID));
        }

        public IDataResult<MailTemplate> GetByTemplateName(int storeID, string name)
        {
            return new SuccessDataResult<MailTemplate>(_mailTemplateDal.Get(m => m.StoreID == storeID && m.Type == name));
        }

        public IResult Update(MailTemplate mailTemplate)
        {
            _mailTemplateDal.Update(mailTemplate);
            return new SuccessResult(Messages.MailTemplateUpdated);
        }
    }
}
