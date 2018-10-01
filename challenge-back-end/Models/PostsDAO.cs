using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace challenge_back_end.Models
{


    public class PostsDAO
    {
        //private static List<Posts> listaPosts = new List<Posts>();

        public List<Posts> Get()
        {

            List<Posts> listaPosts = new List<Posts>();

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "select * from Posts";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Posts posts = new Posts();
                                posts.Id = Convert.ToInt32(reader["Id"]);
                                posts.Codigo = Convert.ToString(reader["Codigo"]);
                                posts.Titulo = Convert.ToString(reader["Titulo"]);
                                posts.Conteudo = Convert.ToString(reader["Conteudo"]);
                                posts.Descricao = Convert.ToString(reader["Descricao"]);
                                posts.qtdLikes = Convert.ToInt16(reader["qtdLikes"]);
                                posts.qtdViews = Convert.ToInt16(reader["qtdViews"]);

                                listaPosts.Add(posts);
                               
                            }
                            conn.Close();
                        }
                    }
                }
            }

            return listaPosts;
        }

        
        public List<Posts> GetHomePage()
        {
            List<Posts> listaPosts = new List<Posts>();

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "select top 5 * from Posts order by qtdLikes desc";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Posts posts = new Posts();
                                posts.Id = Convert.ToInt32(reader["Id"]);
                                posts.Codigo = Convert.ToString(reader["Codigo"]);
                                posts.Titulo = Convert.ToString(reader["Titulo"]);
                                posts.Conteudo = Convert.ToString(reader["Conteudo"]);
                                posts.Descricao = Convert.ToString(reader["Descricao"]);
                                posts.qtdLikes = Convert.ToInt16(reader["qtdLikes"]);
                                posts.qtdViews = Convert.ToInt16(reader["qtdViews"]);

                                listaPosts.Add(posts);
                               
                            }
                            conn.Close();
                        }
                    }
                }
            }

            return listaPosts;
        }
        
        public Posts Get(Posts posts)
        {

            List<Posts> listaPosts = new List<Posts>();
            Posts postsReturn = new Posts();

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "select * from Posts where Id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;
                        comm.Parameters.AddWithValue("@Id", posts.Id);
                        try
                        {
                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    postsReturn.Id = Convert.ToInt32(reader["Id"]);
                                    postsReturn.Codigo = Convert.ToString(reader["Codigo"]);
                                    postsReturn.Titulo = Convert.ToString(reader["Titulo"]);
                                    postsReturn.Conteudo = Convert.ToString(reader["Conteudo"]);
                                    postsReturn.Descricao = Convert.ToString(reader["Descricao"]);
                                    postsReturn.qtdLikes = Convert.ToInt16(reader["qtdLikes"]);
                                    postsReturn.qtdViews = Convert.ToInt16(reader["qtdViews"]);

                                 //   IncrementarView(postsReturn);

                                }
                            }
                        }
                        catch (SqlException e)
                        {

                            throw;
                        }

                    }
                }
            }


            return postsReturn;
        }

        public Posts GetDeitals(Posts posts)
        {

            List<Posts> listaPosts = new List<Posts>();
            Posts postsReturn = new Posts();

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "select * from Posts where Id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;
                        comm.Parameters.AddWithValue("@Id", posts.Id);
                        try
                        {
                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    postsReturn.Id = Convert.ToInt32(reader["Id"]);
                                    postsReturn.Codigo = Convert.ToString(reader["Codigo"]);
                                    postsReturn.Titulo = Convert.ToString(reader["Titulo"]);
                                    postsReturn.Conteudo = Convert.ToString(reader["Conteudo"]);
                                    postsReturn.Descricao = Convert.ToString(reader["Descricao"]);
                                    postsReturn.qtdLikes = Convert.ToInt16(reader["qtdLikes"]);
                                    postsReturn.qtdViews = Convert.ToInt16(reader["qtdViews"]);

                                      IncrementarView(postsReturn);

                                }
                            }
                        }
                        catch (SqlException e)
                        {

                            throw;
                        }

                    }
                }
            }


            return postsReturn;
        }

        public void Post(Posts newPost)
        {

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "Insert into Posts (Codigo,Titulo,Descricao,Conteudo,qtdLikes,qtdViews) VALUES ((select max(Codigo) from Posts) + 1,@Titulo,@Descricao,@Conteudo,@qtdLikes,@qtdViews)";
           
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;

                        comm.Parameters.AddWithValue("@Titulo", newPost.Titulo);
                        comm.Parameters.AddWithValue("@Descricao", newPost.Descricao);
                        comm.Parameters.AddWithValue("@Conteudo", newPost.Conteudo);
                        comm.Parameters.AddWithValue("@qtdLikes", newPost.qtdLikes);
                        comm.Parameters.AddWithValue("@qtdViews", newPost.qtdViews);
                        try
                        {
                            comm.ExecuteReader();
                            conn.Close();
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }

                    }
                }

            }


        }
        
        public void Update(Posts EditPost)
        {

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "update Posts set Titulo = @Titulo , Descricao = @Descricao , Conteudo = @Conteudo where id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;

                        comm.Parameters.AddWithValue("@Id", EditPost.Id);
                        comm.Parameters.AddWithValue("@Titulo", EditPost.Titulo);
                        comm.Parameters.AddWithValue("@Descricao", EditPost.Descricao);
                        comm.Parameters.AddWithValue("@Conteudo", EditPost.Conteudo);

                        try
                        {
                            comm.ExecuteReader();
                            conn.Close();
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }

                    }
                }

            }



        }
               
        public void Delete(Posts posts)
        {

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "delete Posts  where id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;

                        comm.Parameters.AddWithValue("@Id", posts.Id);
                        try
                        {
                            comm.ExecuteReader();
                            conn.Close();
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }

                    }
                }

            }
        }
                
        public void IncrementarLike(Posts posts)
        {

            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "update Posts set qtdLikes = (select qtdLikes from Posts where id = @Id) + 1  where id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;

                        comm.Parameters.AddWithValue("@Id", posts.Id);
                        try
                        {
                            comm.ExecuteReader();
                            conn.Close();
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }

                    }
                }

            }
        }
        
        public void IncrementarView(Posts posts)
        {
            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "update Posts set qtdViews = (select qtdViews from Posts where id = @Id) + 1  where id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;

                        comm.Parameters.AddWithValue("@Id", posts.Id);
                        try
                        {
                            comm.ExecuteReader();
                            conn.Close();
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }

                    }
                }

            }
        }

        public Resumo resumo()
        {
            List<Posts> listaPosts = new List<Posts>();
            Resumo resumo = new Resumo();


            var caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "APIDB.mdf");
            var connectionString = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; AttachDbFileName=|DataDirectory|\APIDB.mdf");
            string sql = "select sum(qtdLikes) as totalLikes, sum(qtdViews) as totalViews from Posts";
            double TotalLike = 0.0;
            double TotalViews = 0.0;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (var comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = sql;

                        try
                        {
                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    TotalLike = Convert.ToInt16(reader["totalLikes"]);
                                    TotalViews = Convert.ToInt16(reader["totalViews"]);
                                }
                            }
                        }
                        catch (SqlException e)
                        {
                            throw;
                        }

                        resumo.TotalLikes = Convert.ToInt16(TotalLike);
                        resumo.totalViews = Convert.ToInt16(TotalViews);

                        listaPosts = Get();

                        foreach(Posts item in listaPosts)
                        {
                            item.PorcentagemLike = (item.qtdLikes/TotalLike)*100;
                            item.PorcentagemView = (item.qtdViews/TotalViews)*100;
                        }

                        resumo.ListaPosts = listaPosts;

                    }
                }
            }

            return resumo;

        }
    }

   

}