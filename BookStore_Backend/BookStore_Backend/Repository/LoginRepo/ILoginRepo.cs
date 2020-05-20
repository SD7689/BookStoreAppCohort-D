﻿using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.LoginRepo
{
    public interface ILoginRepo
    {
        bool Login(User user);
        Task<int> AddUser(User user);
    }
}
