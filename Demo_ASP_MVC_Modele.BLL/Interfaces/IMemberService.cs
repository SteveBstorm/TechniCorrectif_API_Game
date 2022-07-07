﻿using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Interfaces
{
    public interface IMemberService : IRepository<int, MemberModel>
    {
        MemberModel Register(MemberModel member);
        MemberModel Login(string pseudo, string password);
    }
}
