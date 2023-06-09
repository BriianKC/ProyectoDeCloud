﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PELICULAS.ENTIDADES;
using PELICULAS.UAPI;

namespace PELICULAS.WebMVC.Controllers
{
    public class PeliculasController : Controller
    {

        private readonly string Url;
        private CRUD<Pelicula> CRUD { get; set; }
        public PeliculasController(IConfiguration configuration)
        {
            this.Url = configuration["Url"]+"Peliculas/";
            CRUD =new CRUD<Pelicula>();
        }
        // GET: PeliculasController
        public ActionResult Index()
        {
            var datos = CRUD.Select(Url);
            return View(datos);
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            var datos= CRUD.Select_ById(Url,id.ToString());
            return View(datos);
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pelicula datos)
        {
            try
            {
                CRUD.Insert(Url,datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos= CRUD.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pelicula datos)
        {
            try
            {
                CRUD.Update(Url,id.ToString(),datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = CRUD.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: PeliculasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pelicula datos)
        {
            try
            {
                CRUD.Delete(Url,id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
