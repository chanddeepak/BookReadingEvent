﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class UserFacade : FacadeBase, IUserFacade
    {
        public UserFacade()
            : base(FacadeType.UserFacade)
        {

        }
        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.CreateUser(userDTO);
        }

        public OperationResult<IUserDTO> LoginUser(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.LoginUser(userDTO);
        }
    }
}
