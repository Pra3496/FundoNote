﻿using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Entities
{
    public class UserLoginResult
    {
        public UserEntity userEntity { get; set; }  

        public string Token { get; set; }
    }
}
