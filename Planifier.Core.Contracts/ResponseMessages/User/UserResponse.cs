using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.Core.Contracts.ResponseMessages
{
    public class UserResponse
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AccountTypeId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
