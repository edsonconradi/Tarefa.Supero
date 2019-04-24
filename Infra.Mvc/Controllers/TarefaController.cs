using Infra.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Infra.Mvc.Controllers
{
    public class TarefaController : Controller
    {

        public ActionResult Tarefas()
        {
            IEnumerable<TarefaViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Tarefa").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<TarefaViewModel>>().Result;
            return View(empList);
        }

        public ActionResult TarefasPendentes()
        {
            IEnumerable<TarefaViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Tarefa").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<TarefaViewModel>>().Result;
            
            return View(empList.Where(x=>x.Concluida == false));
        }

        public ActionResult TarefasConcluidas()
        {
            IEnumerable<TarefaViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Tarefa").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<TarefaViewModel>>().Result;
            return View(empList.Where(x => x.Concluida == true));
        }


        public ActionResult TarefaAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var tarefa = new TarefaViewModel();
                tarefa.Data = DateTime.Now.ToString("dd/MM/yyyy");
                tarefa.Hora = DateTime.Now.ToString("HH:mm");
                return View(tarefa);
              }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Tarefa/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<TarefaViewModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult TarefaAddOrEdit(TarefaViewModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Tarefa", emp).Result;
                TempData["SuccessMessage"] = "Salvo com Sucesso";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Tarefa/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Alterado com Sucesso";
            }
            return RedirectToAction("Tarefas");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Tarefa/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Removido com Sucesso";
            return RedirectToAction("Tarefas");
        }

    }
}
