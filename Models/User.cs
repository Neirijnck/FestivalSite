using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSite.Models
{
    public class User
    {
        private String _id;

        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        
    }
}