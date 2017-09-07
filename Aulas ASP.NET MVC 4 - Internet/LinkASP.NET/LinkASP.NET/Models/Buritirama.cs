using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkASP.NET.Models
{
    public class Buritirama
    {
        public int NoticiaId { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Comentario { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        public IEnumerable<Buritirama> listaBuritirama()
        {
            var Retorno = new Collection<Buritirama> 
            {
                new Buritirama 
                {
                    NoticiaId = 1,
                    Categoria = "Saúde",
                    Titulo = "Prêmio do nordeste!",
                    Texto = "Buritirama recebeu o prêmio de melhor saúde do nordeste...",
                    Comentario = "Hugo Vidal: Parabéns buritirama!",
                    Data = new DateTime(2015,04,01)
                },

                new Buritirama
                {
                    NoticiaId = 2,
                    Categoria = "Educação",
                    Titulo = "A educação em buritirama nunca foi tão ótima!",
                    Texto = "Secretario Geraldo Santos da Cruz Junior fez uma enorme evolução...",
                    Comentario = "Victor Vidal: Parabéns Geraldo!",
                    Data = new DateTime(2015,04,02)
                },

                new Buritirama
                {
                    NoticiaId = 3,
                    Categoria = "Educação",
                    Titulo = "Construções de escolas",
                    Texto = "É isso ae! Novas escolas sendo construidas em buritirama! ...",
                    Comentario = "Ialle Thaine: Showw muito bom!",
                    Data = new DateTime(2015,04,03)
                },

                new Buritirama
                {
                    NoticiaId = 4,
                    Categoria = "Politica",
                    Titulo = "Reeleito pelo povo!",
                    Texto = "Arival Viana é reeleito novamente pelo povo e continua sendo prefeito de buritirama!",
                    Comentario = "Geraldo Junior: Muito bom!!",
                    Data = new DateTime(2015,04,04)
                },

                new Buritirama
                {
                    NoticiaId = 5,
                    Categoria = "Esportes",
                    Titulo = "Buritirama é campeã!",
                    Texto = "É isso ae! Buritirama vence a serie C e próximo ano vai ter sua primeira vez na serie B!",
                    Comentario = "Luzinete Cruz: Parabéns buritirama!",
                    Data = new DateTime(2015,04,05)
                }
            };
            return Retorno;
        }
    }
}