﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class DbConnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1E7H453\GIAHAN;Initial Catalog=Selenium;Integrated Security=True");
    }
}
