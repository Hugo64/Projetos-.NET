using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : BaseController
    {

        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index() // Página principal do controler Medico.
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades").ToList(); // Enviando uma lista de medicos junto com a sua cidade e especialidade.
            return View(medicos); // Enviando a lista para View "Index".
        }

        public ActionResult Adicionar() // View para adicionar um médico.
        {
            ViewBag.Cidades_id = new SelectList(db.Cidades, "id", "Nome"); // Enviando a lista de cidades para a view "Adicionar" pelo ViewBag no qual seu atributo é "Cidades_id".
            ViewBag.Especialidades_id = new SelectList(db.Especialidades, "id", "Nome"); // Enviando a lista de especialidades para a view "Adicionar" pelo ViewBag no qual seu atributo é "Especialidades_id".
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico) // Recebendo o médico, validado e enviando para o servidor.
        {
            if (ModelState.IsValid) // Verificando se os todos os dados foram inseridos.
            {
                db.Medicos.Add(medico); // Adicionando o médico no servidor.
                db.SaveChanges(); // Salvando processo.
                return RedirectToAction("Index"); // Redirecionando a página para a página principal onde se mostra todos os dados dos médicos cadastrados.
            }

            // Caso a validação encontrar algum erro...
            ViewBag.Cidades_id = new SelectList(db.Cidades, "id", "Nome", medico.Cidades_id); // Enviando lista para a view.
            ViewBag.Especialidades_id = new SelectList(db.Especialidades, "id", "Nome", medico.Especialidades_id); // Enviando lista para a view.

            return View(medico); // Será retornada na view os dados do médico adicionado anteriormente.
        }

        public ActionResult Editar(int Id) // Pegando o id do médico selecionado.
        {
            var Medico = db.Medicos.FirstOrDefault(i => i.id == Id);  // "Procurando", verificando o id do médico.

            ViewBag.Cidades_id = new SelectList(db.Cidades, "id", "Nome", Medico.Cidades_id); // Enviando lista para a view.
            ViewBag.Especialidades_id = new SelectList(db.Especialidades, "id", "Nome", Medico.Especialidades_id); // Enviando lista para a view.

            return View(Medico); // Enviando o médico selecionado para a view. 
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico) // Recebendo o médico selecionado.
        {
            if (ModelState.IsValid) // Verificando se os dados alterados foram todos preenchidos.
            {
                db.Entry(medico).State = System.Data.EntityState.Modified; // Enviando dados para o servidor.
                db.SaveChanges(); // Salvando alteração.
                return RedirectToAction("Index"); // Redirecionando a página para a página principal onde se mostra todos os dados dos médicos cadastrados.
            }

            // Caso ocorra algum problema...

            ViewBag.Cidades_id = new SelectList(db.Cidades, "id", "Nome", medico.Cidades_id); // Enviando lista para a view.
            ViewBag.Especialidades_id = new SelectList(db.Especialidades, "id", "Nome", medico.Especialidades_id); // Enviando lista para a view.

            return View(medico); // Será retornada na view os dados do médico adicionado anteriormente.

        }

        public string Excluir(int id)
        {
            try // Abrindo tratamento de exceções.
            {
                var Medico = db.Medicos.FirstOrDefault(i => i.id == id);  // "Procurando", verificando o id do médico.

                db.Medicos.Remove(Medico); // Removendo médico.
                db.SaveChanges(); // Salvando execução.
                return bool.TrueString; // Retornando um valor verdadeiro, informando que foi excluído.
            }
            catch // Tratando exceções.
            {
                return bool.FalseString; // retonando um valor falso, informando que não foi possivel excluir.
            }
        }

        public ActionResult adicionarCidade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adicionarCidade(Cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        public ActionResult adicionarEspecialidade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adicionarEspecialidade(Especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

    }
}
