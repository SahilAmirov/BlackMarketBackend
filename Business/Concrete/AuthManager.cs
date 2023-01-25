using Autofac.Core;
using Azure.Core;
using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.DataEntity;
using Core.Utilities.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessToken = Core.Utilities.Security.JWT.AccessToken;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IStoreService _storeService;
        private readonly IUserStoreService _userStoreService;
        private readonly IMailService _mailService;
        private readonly IMailParameterService _mailParameterService;
        private readonly IMailTemplateService _mailTemplateService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IStoreService storeService, IUserStoreService userStoreService, IMailParameterService mailParameterService, IMailService mailService, IMailTemplateService mailTemplateService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _storeService = storeService;
            _userStoreService = userStoreService;
            _mailParameterService = mailParameterService;
            _mailService = mailService;
            _mailTemplateService = mailTemplateService;
        }



        public IDataResult<AccessToken> CreateAccessToken(User user, int storeID)
        {
            var claims = _userService.GetClaims(user, storeID);
            var accessToken = _tokenHelper.CreateToken(user, claims, storeID);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var userToCheck = _userService.GetByEmail(userForLogin.Email);
            if(userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (HashingHelper.VerifyPasswordHash(userForLogin.Password,userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new SuccessDataResult<User>(userToCheck, Messages.SuccessLogin);
                
            }
            return new ErrorDataResult<User>(Messages.PasswordError);

        }

        [TransactionScopeAspect]
        public IDataResult<User> Register(UserForRegister userForRegister, string password)
        {
            

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegister.Email,
                JoinedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                ConfirmDate = DateTime.Now,
                ConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = userForRegister.Name,
                Surname = userForRegister.Surname,
                JoinedFromStoreID = 1,
                PhoneConfirm = false,
            };

            // VALIDATION
            ValidationTool.Validate(new UserValidator(), user);

            _userService.Add(user);

            ///*
            string subject = "Kullanici onay maili";
            string body = "Kullaciyi onaylamak icin lutfen linke tiklayin...";
            string link = "https://localhost:7220";
            string linkDescription = "Kaydi Onayla";
            var mailTemplate = _mailTemplateService.GetByTemplateName(4, "Kyit");
            string templateBody = mailTemplate.Data.Value;
            templateBody = templateBody.Replace("{{title}}", subject);
            templateBody = templateBody.Replace("{{message}}", body);
            templateBody = templateBody.Replace("{{link}}", link);
            templateBody = templateBody.Replace("{{linkDescription}}", linkDescription);

            var mailParameter = _mailParameterService.Get(2);
            SendMailDto sendMailDto = new SendMailDto()
            {
                mailParameter = mailParameter.Data,
                email = user.Email,
                subject = "Kullanici onay maili",
                body = templateBody
            };
            _mailService.SendMail(sendMailDto);
            //*/

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult CheckStoreName(string storeName)
        {
            var result = _storeService.CheckStoreName(storeName);
            return result;
        }

        public IResult RegisterStore(string storeName, int userID)
        {
            var store = _storeService.AddStore(storeName);
            if (!store.Success)
            {
                return new ErrorResult(store.Message);
            }

            var storeBy = _storeService.GetStoreByName(storeName);
            _storeService.UserStoreAdd(userID, storeBy.Data.ID);
            return new SuccessResult(Messages.StoreRegistered);
        }

        public IDataResult<DataInt> GetStoreIdByUserId(int userID)
        {
            DataInt storeID = new DataInt();
            storeID.MyInt = _userStoreService.GetUserStore(userID).Data.StoreID;
            return new SuccessDataResult<DataInt>(storeID);
        }
    }
}
