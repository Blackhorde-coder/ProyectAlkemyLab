using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlkemyLabs.Models;

namespace AlkemyLabs.Models.TableViewModels
{
    public class MattersTaleViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public teacher teacher { get; set; }
        public int quota { set; get; }



    }
}