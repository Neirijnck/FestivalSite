using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestivalSite.Models
{
    public class News
    {
        private String _id;

        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _author;

        public String Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private String _title;

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _content;

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private DateTime _date;

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        
        
    }
}