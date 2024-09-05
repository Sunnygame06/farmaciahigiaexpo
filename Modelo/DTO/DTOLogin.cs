using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    public class DTOLogin : dbContext
    {
        private int id;
        private string Username;
        private string Password;
        private int Rol;
        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public int Rol1 { get => Rol; set => Rol = value; }
        public int Id { get => id; set => id = value; }
    }
}
