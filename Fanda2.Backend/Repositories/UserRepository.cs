﻿using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;

namespace Fanda2.Backend.Repositories
{
    public class UserRepository : IRootRepository<User, UserListModel>
    {
        public List<UserListModel> GetAll(bool includeDisabled = true, string searchTerm = null)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(KeyField keyField, string fieldValue, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
