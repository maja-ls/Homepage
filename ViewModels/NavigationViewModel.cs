using Homepage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homepage.ViewModels {
    public class NavigationViewModel {
        public List<NavLinkItem> Links { get; set; }
        public string Logo { get; set; }
    }
}