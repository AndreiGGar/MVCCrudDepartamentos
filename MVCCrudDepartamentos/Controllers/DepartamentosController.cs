using Microsoft.AspNetCore.Mvc;
using MVCCrudDepartamentos.Models;
using MVCCrudDepartamentos.Repositories;

namespace MVCCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController()
        {
            repo = new RepositoryDepartamentos();
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int iddepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(iddepartamento);
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repo.InsertDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            ViewData["MENSAJE"] = "Departamento insertado";
            /*return View("Index");*/
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int iddepartamento)
        {
            this.repo.DeleteDepartamento(iddepartamento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Departamento departamento)
        {
            this.repo.UpdateDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            ViewData["MENSAJE"] = "Departamento actualizado";
            return RedirectToAction("Index");
        }
    }
}
