using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoFinalPOO2.Entities;
using ProyectoFinalPOO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalPOO2.Controllers
{
    public class EncargadoController : Controller
    {
        private readonly ILogger<EncargadoController> _logger;
        private readonly ApplicationDbContext _context;

        public EncargadoController(ILogger<EncargadoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Mostrar formulario de registro de empleado
        [HttpGet]
        public IActionResult RegEmpleado()
        {
            ViewBag.Jefes = _context.Jefes.ToList(); // Para llenar el dropdown de jefes
            return View();
        }

        // POST: Procesar el formulario de registro de empleado
        [HttpPost]
        public IActionResult RegEmpleado(RegEmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                RegEmpleado empleado = new RegEmpleado
                {
                    Id = Guid.NewGuid(),
                    NombreCompleto = model.NombreCompleto,
                    FechaEntrada = model.FechaEntrada,
                    FechaNac = model.FechaNac,
                    Nacionalidad = model.Nacionalidad,
                    EstadoCivil = model.EstadoCivil,
                    Curp = model.Curp,
                    Rfc = model.Rfc,
                    Domicilio = model.Domicilio,
                    Turno = model.Turno,
                    Jefe = model.Jefe,
                    Departamento = model.Departamento,
                };

                _context.RegEmpleados.Add(empleado);
                _context.SaveChanges();

                return RedirectToAction("MenuEnc");
            }
            ViewBag.Jefes = _context.Jefes.ToList(); // Para llenar el dropdown de jefes en caso de error
            return View(model);

        }

        // GET: Mostrar lista de empleados
        public IActionResult ListaEmpleado()
        {
 var empleados = _context.RegEmpleados
                .Select(e => new RegEmpleadoModel
                {
                    Id = e.Id,
                    NombreCompleto = e.NombreCompleto,
                    FechaEntrada = e.FechaEntrada,
                    FechaNac = e.FechaNac,
                    Nacionalidad = e.Nacionalidad,
                    EstadoCivil = e.EstadoCivil,
                    Curp = e.Curp,
                    Rfc = e.Rfc,
                    Domicilio = e.Domicilio,
                    Turno = e.Turno,
                    Jefe = e.Jefe,
                    Departamento = e.Departamento,
                }).ToList();

            return View(empleados);

        }

        // GET: Mostrar formulario de edición de empleado
       public IActionResult EmpleadoEdit(Guid id)
{
    var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == id);
    if (empleado == null)
    {
        return RedirectToAction("MenuEnc");
    }

    var model = new RegEmpleadoModel
    {
        Id = empleado.Id,
        NombreCompleto = empleado.NombreCompleto,
        FechaEntrada = empleado.FechaEntrada,
        FechaNac = empleado.FechaNac,
        Nacionalidad = empleado.Nacionalidad,
        EstadoCivil = empleado.EstadoCivil,
        Curp = empleado.Curp,
        Rfc = empleado.Rfc,
        Domicilio = empleado.Domicilio,
        Turno = empleado.Turno,
        Jefe = empleado.Jefe,
        Departamento = empleado.Departamento,
    };

    ViewBag.Jefes = _context.Jefes.ToList(); // Para llenar el dropdown de jefes
    return View(model);
}

        // POST: Procesar el formulario de edición de empleado
        [HttpPost]
        public IActionResult EmpleadoEdit(RegEmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == model.Id);
                if (empleado != null)
                {
                    empleado.NombreCompleto = model.NombreCompleto;
                    empleado.FechaEntrada = model.FechaEntrada;
                    empleado.FechaNac = model.FechaNac;
                    empleado.Nacionalidad = model.Nacionalidad;
                    empleado.EstadoCivil = model.EstadoCivil;
                    empleado.Curp = model.Curp;
                    empleado.Rfc = model.Rfc;
                    empleado.Domicilio = model.Domicilio;
                    empleado.Turno = model.Turno;
                    empleado.Jefe = model.Jefe;
                    empleado.Departamento = model.Departamento;

                    _context.SaveChanges();
                    return RedirectToAction("MenuEnc");
                }
            }
            ViewBag.Jefes = _context.Jefes.ToList(); // Para llenar el dropdown de jefes en caso de error
            return View(model);
        }

        // GET: Mostrar detalles de empleado para eliminar
        public IActionResult EmpleadoShowToDelete(Guid id)
        {
            var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                return RedirectToAction("MenuEnc");
            }

            var model = new RegEmpleadoModel
            {
                Id = empleado.Id,
                NombreCompleto = empleado.NombreCompleto,
                FechaEntrada = empleado.FechaEntrada,
                FechaNac = empleado.FechaNac,
                Nacionalidad = empleado.Nacionalidad,
                EstadoCivil = empleado.EstadoCivil,
                Curp = empleado.Curp,
                Rfc = empleado.Rfc,
                Domicilio = empleado.Domicilio,
                Turno = empleado.Turno,
                Jefe = empleado.Jefe,
                Departamento = empleado.Departamento,
            };

            return View(model);
        }

        // POST: Eliminar empleado
        [HttpPost]
        public IActionResult RegEmpleadoDelete(Guid id)
        {
            var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == id);
            if (empleado != null)
            {
                _context.RegEmpleados.Remove(empleado);
                _context.SaveChanges();
            }

            return RedirectToAction("MenuEnc");
        }
 // métodos del controlador, como Menú de Encargado y Asignar Tarea

        public IActionResult MenuEnc()
        {
            return View();
        }

        //public IActionResult AsignarTarea()
        //{
          //  return View();
        //}

        public IActionResult JefesLis()
        {
            List<JefeModel> list = _context.Jefes.Select(c => new JefeModel
            {
                Id = c.Id,
                NombreJefe = c.NombreJefe,
                Departamento = c.Departamento,
                Sueldo = c.Sueldo
            }).ToList();

            return View(list);
        }
 // GET: Editar jefe
        public IActionResult JefesEdit(Guid id)
        {
            var jefe = _context.Jefes.FirstOrDefault(p => p.Id == id);
            if (jefe == null)
            {
                return RedirectToAction("MenuEnc");
            }

            var model = new JefeModel
            {
                Id = jefe.Id,
                NombreJefe = jefe.NombreJefe,
                Departamento = jefe.Departamento,
                Sueldo = jefe.Sueldo
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult JefesEdit(JefeModel model)
        {
            if (ModelState.IsValid)
            {
                var jefe = _context.Jefes.FirstOrDefault(p => p.Id == model.Id);
                if (jefe != null)
                {
                    jefe.NombreJefe = model.NombreJefe;
                    jefe.Departamento = model.Departamento;
                    jefe.Sueldo = model.Sueldo;
                    _context.SaveChanges();
                    return RedirectToAction("MenuEnc");
                }
            }

            return View(model);
        }

        public IActionResult JefesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JefesAdd(JefeModel model)
        {
            if (ModelState.IsValid)
            {
                Jefe jefe = new Jefe
                {
                    Id = Guid.NewGuid(),
                    NombreJefe = model.NombreJefe,
                    Departamento = model.Departamento,
                    Sueldo = model.Sueldo
                };
                _context.Jefes.Add(jefe);
                _context.SaveChanges();

                return RedirectToAction("MenuEnc");
            }
            return View(model);
        }

        // GET: Mostrar detalles de jefe para eliminar
        public IActionResult JefeShowToDelete(Guid id)
        {
             var jefe = _context.Jefes.FirstOrDefault(p => p.Id == id);
            if (jefe == null)
            {
                return RedirectToAction("MenuEnc");
            }

            var model = new JefeModel
            {
                Id = jefe.Id,
                NombreJefe = jefe.NombreJefe,
                Departamento = jefe.Departamento,
                Sueldo = jefe.Sueldo
            };

            return View(model);
        }
 // POST: Eliminar jefe
        [HttpPost]
        public IActionResult JefeDelete(Guid id)
        {
            var jefe = _context.Jefes.FirstOrDefault(p => p.Id == id);
            if (jefe != null)
            {
                _context.Jefes.Remove(jefe);
                _context.SaveChanges();
            }

            return RedirectToAction("MenuEnc");
        }

 //---------------------------------------------------------------------------\\

        // GET: Mostrar formulario de nueva tarea
        public IActionResult NuevaTarea()
        {
            return View();
        }

        // POST: Crear nueva tarea
        [HttpPost]
        public IActionResult CrearTarea(TareaModel model)
        {
            if (ModelState.IsValid)
            {
                var tarea = new Tarea
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Description = model.Description,
                    Status = model.Status,
                    Priority = model.Priority,
                    DueDate = model.DueDate,
                    CreatedDate = DateTime.Now
                };

                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                return RedirectToAction("MenuEnc");
            }

            return View("NuevaTarea", model);
        }

        // GET: Mostrar lista de tareas en AsignarTarea
        public IActionResult AsignarTarea()
        {
            var tareas = _context.Tareas.Select(t => new TareaModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                DueDate = t.DueDate,
                CreatedDate = t.CreatedDate
            }).ToList();

            return View(tareas);
        }

        // GET: Mostrar formulario de edición de tarea
        public IActionResult TareaEdit(Guid id)
        {
            var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                return RedirectToAction("MenuEnc");
            }

            var model = new TareaModel
            {
                Id = tarea.Id,
                Title = tarea.Title,
                Description = tarea.Description,
                Status = tarea.Status,
                Priority = tarea.Priority,
                DueDate = tarea.DueDate,
                CreatedDate = tarea.CreatedDate
            };

            return View(model);
        }

        // POST: Procesar el formulario de edición de tarea
        [HttpPost]
        public IActionResult TareaEdit(TareaModel model)
        {
            if (ModelState.IsValid)
            {
                var tarea = _context.Tareas.FirstOrDefault(t => t.Id == model.Id);
                if (tarea != null)
                {
                    tarea.Title = model.Title;
                    tarea.Description = model.Description;
                    tarea.Status = model.Status;
                    tarea.Priority = model.Priority;
                    tarea.DueDate = model.DueDate;

                    _context.SaveChanges();
                    return RedirectToAction("MenuEnc");
                }
            }

            return View(model);
        }

        // GET: Mostrar detalles de tarea para eliminar
        public IActionResult TareaShowToDelete(Guid id)
        {
            var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                return RedirectToAction("AsignarTarea");
            }

            var model = new TareaModel
            {
                Id = tarea.Id,
                Title = tarea.Title,
                Description = tarea.Description,
                Status = tarea.Status,
                Priority = tarea.Priority,
                DueDate = tarea.DueDate,
                CreatedDate = tarea.CreatedDate
            };

            return View(model);
        }

        // POST: Eliminar tarea
        [HttpPost]
        public IActionResult TareaDelete(Guid id)
        {
            var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();
            }

            return RedirectToAction("MenuEnc");
        }
    }
}