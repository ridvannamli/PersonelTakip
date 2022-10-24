﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLL
{
    public class DepartmanBLL
    {
        public static void DepartmanEkle(DEPARTMAN dpt)
        {
            DepartmanDAO.DepartmanEkle(dpt);
        }

        public static List<DEPARTMAN> DepartmanGetir()
        {
            return DepartmanDAO.DepartmanGetir();
        }
    }
}
