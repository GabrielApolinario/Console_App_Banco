using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco01
{
    class UsuarioDAO
    {
        private Banco db;

        
        //public void Insert(string vNome, string vCargo, string vData)

        public void Insert(Usuario usuario)
        {

            var StrQuery = "";
            StrQuery += "INSERT INTO tbUsuario(NomeUsu, Cargo, DataNasc)";             
            StrQuery += string.Format("VALUES('{0}', '{1}', CONVERT(DATETIME,'{2}',103));",
                //Passando como parametro os atributos da classe Usuario
                usuario.NomeUsu, usuario.Cargo, usuario.DataNasc);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var StrQuery = "";
            StrQuery += "UPDATE tbUsuario SET ";
            StrQuery += string.Format("NomeUsu = '{0}',", usuario.NomeUsu);
            StrQuery += string.Format("Cargo = '{0}',", usuario.Cargo);
            StrQuery += string.Format("DataNasc = '{0}'", usuario.DataNasc);
            StrQuery += string.Format("WHERE IdUsu = '{0}'", usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }



    }
}
