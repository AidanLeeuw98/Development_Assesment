﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Development.Assesment.Data
{
    public class GroupPermission
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
