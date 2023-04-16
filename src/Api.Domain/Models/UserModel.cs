using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

		private string _phone;

		public string Phone
		{
			get { return _phone; }
			set { _phone = value; }
		}

		private int _cpf;

		public int Cpf
		{
			get { return _cpf; }
			set { _cpf = value; }
		}

        private string _rg;

        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
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
