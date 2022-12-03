using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class NhanVien_BUS
    {
        NhanVien_DAL nv = new NhanVien_DAL();
        public DataTable getNhanVien()
        {
            return nv.getNhanVien();
        }
        public bool InsertNhanVien(NhanVien_DTO nhanVien)
        {
            return nv.insertNhanVien(nhanVien);
        }

        public bool UpdataNhanVien(NhanVien_DTO nhanVien)
        {
            return nv.updateNhanVien(nhanVien);
        }

        public bool DeleteNhanVien(string Email)
        {
            return nv.DeleteNhanVien(Email);
        }

        public DataTable SearchNhanVien(string email)
        {
            return nv.SearchNhanVien(email);
        }
    }
}
