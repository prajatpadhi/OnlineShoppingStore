using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_CodeProject.Generic_Repository
{
    public interface IUnitOfWork
    {
        GenericRepository<Product> ProductRepository
        {
            get;

        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        GenericRepository<User> UserRepository
        {
            get;

        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        GenericRepository<Token> TokenRepository
        {
            get;

        }


        
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();


    }
}
