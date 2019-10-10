using System;
using System.Data.SqlClient;


namespace ConsoleBanco01
{
    class Program
    {
        static void Main(string[] args)
        {
            var Banco = new Banco();
            var UsuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            /*Data Source é o SGBD em que está se conectando
           *User ID e Password é usado para autenticar a entrada no SGBD
           *Initial Catalog é o nome do Database que estamos acessando*/
            /*SqlConnection conexao = new SqlConnection
                (@"Data Source = DESKTOP-DBF5VMS ; Initial Catalog = dbEXEMPLO; User ID = sa; Password = 1234567");*/

            //Podemos passar os atributos da classe diretamente para receber o readline
            Console.WriteLine("Digite o Nome do usuário");
            usuario.NomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o Cargo do usuário");
            usuario.Cargo = Console.ReadLine();

            Console.WriteLine("Digite a Data de nascimento do usuário");
            usuario.DataNasc = DateTime.Parse(Console.ReadLine());

            usuario.IdUsu = Convert.ToInt32(Console.ReadLine());
            
            //FALTA TERMINAR
            /*if (usuario.IdUsu == usuario.IdUsu)
            {
                UsuarioDAO.Atualizar(usuario);
            }
            else
            {
                UsuarioDAO.Insert(usuario);
            }*/
            
            //Passando como parametro o objeto usuario para que o insert seja realizado
            //UsuarioDAO.Insert(usuario);

            string StrSelecionaUsu = "SELECT * FROM tbUsuario";

            SqlDataReader leitor = Banco.RetornaComando(StrSelecionaUsu);

            while (leitor.Read())
            {
                /*Passando parametros para serem exibidos o resultado da consulta feita ao banco, 
                 *Sempre utilizando os nomes como estão na tabela do banco*/
                Console.WriteLine("ID: {0}, Nome: {1}, Cargo: {2}, Data: {3}",
                    leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["DataNasc"]);

            };
            //Se fizer somente o 'leitor.Read()', será lido apenas o primeiro registro e por consequencia será o unico a ser mostrado

            Console.ReadLine();

            //Instanciando objeto usuario e dizendo como receberá seus valores
            //var usuario = new Usuario
            /*Instanciando objeto UsuarioDAO e utilizando o metodo Insert porem 
            é melhor instancia-lo com um nome para não precisar declara-lo novamente
            Confira o trecho de instanciação correta no topo  do metodo Main
            EXEMPLO DE INSTANCIAÇÃO >>>>>>>>>> new UsuarioDAO().Insert(vNome, vCargo, vData);*/


            //UsuarioDAO.Insert(vNome, vCargo, vData);

            //------------------------------------------OUTRA FORMA DE FAZER CONEXÃO COM O BANCO------------------------------------------//
            //SqlConnection conexao = new SqlConnection(Properties.Settings.Default.conexao);
            //conexao.Open();

            //string StrInsereUsu = string.Format("INSERT INTO tbUsuario(NomeUsu, Cargo, DataNasc) " +
            //                                //Conversão de data
            //    "VALUES('{0}', '{1}', CONVERT(DATETIME,'{2}',103));", vNome, vCargo, vData);
            ////Executando comando utilizando do metodo criado na classe Banco
            //Banco.ExecutaComando(StrInsereUsu);

            //SqlCommand StrInserir = new SqlCommand(StrInsereUsu, conexao);
            //StrInserir.ExecuteNonQuery();

            //Para comandos que não são SELECT utilizasse o 'ExecuteNonQuery'

            //SqlCommand comandoApagar = new SqlCommand("DELETE FROM tbUsuario WHERE IdUsu = 1005", conexao);
            //comandoApagar.ExecuteNonQuery();

            //string StrAtualizaUsu = "UPDATE tbUsuario SET NomeUsu = 'Me Acho Esperta' WHERE IdUsu = 2";
            //SqlCommand comandoAtualiza = new SqlCommand(StrAtualizaUsu, conexao);

            //Criando variavel do tipo string que vai receber um comando SELECT
            //Utilizar variavel apenas quando o comando irá variar
            //Criando comando do Sql e passando como parametro a string para fazer SELECT e a conexao
            //Também é possivel passar dentro do SqlCommand o próprio SELECT, sem necessidade de variavel
            //SqlCommand comando = new SqlCommand(StrSelecionaUsu, conexao);
            //SqlDataReader leitor = comando.ExecuteReader();


            //Botão direito > Snippet > Insert Snippet > Escolher a linguagem e a estrutura desejada
            //Enquanto o leitor estiver recebendo dados para ler, continuará escrevendo os registros no Console




            //----------------------------------------------------OUTRA FORMA DE FAZER----------------------------------------------------//

            //System.Data.SqlClient.SqlConnection conexao = new System.Data.SqlClient.SqlConnection();
            //conexao.ConnectionString = (@"Data Source = DESKTOP-DBF5VMS ; Initial Catalog = dbEXEMPLO; User ID = sa; Password = 1234567");
            //conexao.Open();

            //System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand();
            //comando.Connection = conexao;
            //comando.CommandText = "SELECT * FROM tbUsuario";
            //comando.CommandType = System.Data.CommandType.Text;

            //System.Data.SqlClient.SqlDataReader leitor;
            //leitor = comando.ExecuteReader;

            //while (leitor.Read())
            //{
            //  Console.WriteLine("ID: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["DataNasc"]);
            //};
            //Console.ReadLine();

        }
    }
}
