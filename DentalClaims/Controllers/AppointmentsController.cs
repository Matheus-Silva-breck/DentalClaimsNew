using DentalClaims.Models;
using DentalClaims.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentalClaims.Controllers
{
    public class AppointmentsController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        // GET: Index 
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return View(appointments);
        }
        // GET: Delete confirmation (opcional)
        public async Task<IActionResult> Delete(int id)
    {
            var appointment = await _context.Appointments.FindAsync(id);
             if (appointment == null)
    {
             return NotFound();
    }

    return View(appointment);
    }

        // POST: Delete
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var appointment = await _context.Appointments.FindAsync(id);
    if (appointment != null)
    {
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction(nameof(Index));
}


        // GET: Create 
        public IActionResult Create()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    NomePaciente = viewModel.NomePaciente,
                    Data = viewModel.Data,
                    Procedimento = viewModel.Procedimento
                };
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Edit 
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentViewModel
            {
                Id = appointment.Id,
                NomePaciente = appointment.NomePaciente,
                Data = appointment.Data,
                Procedimento = appointment.Procedimento
            };
            return View(viewModel);
        }

        // POST: Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                appointment.NomePaciente = viewModel.NomePaciente;
                appointment.Data = viewModel.Data;
                appointment.Procedimento = viewModel.Procedimento;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
