using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace challenge_back_end.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Titulo é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Descricao é obrigatorio")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Conteudo é obrigatorio")]
        public string Conteudo { get; set; }
        [Display(Name = "Views")]
        public int qtdViews { get; set; }
        [Display(Name = "likes")]
        public int qtdLikes { get; set; }

        public double PorcentagemLike { get; set; }
        public double PorcentagemView { get; set; }

        public Posts()
        {

        }
        public Posts(string titulo, string descricao, string conteudo)
        {
           
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Conteudo = conteudo;
            this.qtdLikes = 0;
            this.qtdViews = 0;
            this.PorcentagemLike = 0;
            this.PorcentagemView = 0;
        }

        
    }
}