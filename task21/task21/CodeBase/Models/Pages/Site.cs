﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Models
{
    public partial class Site
    {
        public string LogoUrl => this.Logo.Url;
    }
}
