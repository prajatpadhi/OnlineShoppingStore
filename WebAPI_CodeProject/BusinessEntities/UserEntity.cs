﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CodeProject.BusinessEntities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}