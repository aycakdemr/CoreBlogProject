using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
