using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel
    {
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private DateTime _createAt;

		public DateTime CreateAt
		{
			get { return _createAt; }
			set { _createAt = value != DateTime.MinValue ? value : DateTime.UtcNow; }
		}

		private DateTime _updateAt;

		public DateTime UpdateAt
		{
			get { return _updateAt; }
			set { _updateAt = value; }
		}

	}
}
