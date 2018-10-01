using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using challenge_back_end.Models;

namespace challenge_back_end.Controllers
{
    public class ApiPostsController : ApiController
    {
        private static PostsDAO postsDAo = new PostsDAO();
      
        public List<Posts> Get()
        {
            return postsDAo.Get();
        }

        public Posts Get(int id)
        {
            Posts posts = new Posts();
            posts.Id = id;
            return postsDAo.Get(posts);
        }
        
        [HttpGet]
         public Posts GetDeitals(int id)
         {
            Posts posts = new Posts();
            posts.Id = id;
            return postsDAo.GetDeitals(posts);
         }

        [HttpGet]
        public List<Posts> GetHomePage()
        {
            return postsDAo.GetHomePage();
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Posts post)
        {
            /*Posts post = new Posts(posts.Titulo, posts.Descricao, posts.Conteudo);*/
            string msg = validar(post);
            try
            {
                if (string.IsNullOrEmpty(msg)){

                    postsDAo.Post(post);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "sucesso");
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, msg);
                    return response;
                }
            }
            catch (Exception e )
            {

                throw;                
            }
            
        }
       
        [HttpPost]
        public HttpResponseMessage Update([FromBody] Posts posts)
        {
            
          

            string msg = validar(posts);
            try
            {
                //Posts post = new Posts(posts.Titulo, posts.Descricao, posts.Conteudo);
                //post.Id = posts.Id;

                if (string.IsNullOrEmpty(msg))
                {
                    
                    postsDAo.Update(posts);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "sucesso");
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.PreconditionFailed, msg);
                    return response;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
     
       [HttpPost]
       public IHttpActionResult Delete([FromBody] Posts posts)
       {
            try
            {
                
                postsDAo.Delete(posts);
            }
            catch (Exception e)
            {
                throw e;                
            }

            return Ok();
       }

       
        [HttpPost]
        public IHttpActionResult IncrementarLike([FromBody] Posts posts)
        {
            
            try
            {

                postsDAo.IncrementarLike(posts);
            }
            catch (Exception)
            {

                return NotFound();
            }

            return Ok();
        }
       
        [HttpPost]
        public void IncrementarView(int id)
        {
        Posts posts = new Posts();
        posts.Id = id;
        postsDAo.IncrementarView(posts);

        }
      
       [HttpGet]
        public Resumo Resumo()
        {
            return postsDAo.resumo();
        }
        
        private string validar(Posts posts)
        {
            string msg = "";            
            if (string.IsNullOrEmpty(posts.Titulo) || string.IsNullOrEmpty(posts.Conteudo) || string.IsNullOrEmpty(posts.Descricao))
            {
                msg += "Erro campos:";

                if (string.IsNullOrEmpty(posts.Titulo))
                {
                    msg += " Titulo,";
                }

                if (string.IsNullOrEmpty(posts.Conteudo))
                {
                    msg += " Conteudo,";
                }
                if (string.IsNullOrEmpty(posts.Descricao))
                {
                    msg += " Descrição,";

                }


                msg += " estão nulos";
            }
            

            return msg;
        }

    }
}
