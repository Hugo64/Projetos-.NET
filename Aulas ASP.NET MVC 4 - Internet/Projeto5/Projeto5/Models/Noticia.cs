using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto5.Models
{
    public class Noticia
    {
        // Atributos;
        public int noticiaId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Categoria { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Declarando a data;
        public DateTime Data { get; set; } // Atributo data;

        // Criando um "ArrayList" e inserindo dados nela, para parecer um banco de dados;
        public IEnumerable<Noticia> todasAsNoticias() // Nome da lista "todasAsNoticias()";
        {
            var retorno = new Collection<Noticia> // Método para retornar toda a lista, com dados inseridos;
                {
                    new Noticia // Instanciando e criando uma lista;
                        {
                            noticiaId = 1,
                            Categoria = "Esportes",
                            Titulo = "Felipe Massa ganha F1",
                            Conteudo = "Numa tarde de chuva Felipe Massa ganha F1 no Brasil...",
                            Data = new DateTime(2015,4,11)
                        },

                    new Noticia
                        {
                            noticiaId = 2,
                            Categoria = "Política",
                            Titulo = "Presidente assina convênios",
                            Conteudo = "Durante reunião o presidente Ismael Freitas assinou os convênios...",
                            Data = new DateTime(2015,4,11)
                        },

                    new Noticia
                        {
                            noticiaId = 3,
                            Categoria = "Política",
                            Titulo = "Vereador é eleito pela 4ª vez",
                            Conteudo = "Vereador Fabio Pratt é eleito pela quarta vez...",
                            Data = new DateTime(2015,4,12)
                        },
                    
                    new Noticia
                        {
                            noticiaId = 4,
                            Categoria = "Esportes",
                            Titulo = "O tão sonhado titulo chegou",
                            Conteudo = "Em um jogo que levou os torcedores ao delirio...",
                            Data = new DateTime(2015,4,14)
                        },

                    new Noticia
                        {
                            noticiaId = 5,
                            Categoria = "Humor",
                            Titulo = "O Comediante Anderson Renato fará shou hoje",
                            Conteudo = "O comediante mais engraçados dos comentários do Youtube fará show...",
                            Data = new DateTime(2015,4,11)
                        },

                    new Noticia
                        {
                            noticiaId = 6,
                            Categoria = "Policial",
                            Titulo = "Tenente coronel Lucas Farias Santos assume o controle",
                            Conteudo = "Durante a retomada do morro o tenente coronel disse...",
                            Data = new DateTime(2015,4,13)
                        },
                    new Noticia

                        {
                            noticiaId = 7,
                            Categoria = "Esportes",
                            Titulo = "Atacante do Barcelona faz 4 gols",
                            Conteudo = "O atacante Lucas Farias Santos Messi, fez 4 gols e decidiu o titulo...",
                            Data = new DateTime(2015,4,11)
                        }
                }; // Fim da lista
            return retorno; // Retornando a "ArrayList";
        }
    }
}