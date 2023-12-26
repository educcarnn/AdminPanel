using Microsoft.AspNetCore.Mvc;
using AdminPanel.Models;
using AdminPanel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.Models.ViewModels;
using AdminPanel.Services.Exceptions;
using System.Diagnostics;

namespace AdminPanel.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessageService _messageService;
        private readonly TipoService _tipoService;
        public MessagesController(MessageService messageService, TipoService tipoService)
        {
            _messageService = messageService;
            _tipoService = tipoService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _messageService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var tipos = await _tipoService.FindAllAsync();
            var viewModel = new MessageFormViewModel { Tipos = tipos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Message message)
        {
            if (!ModelState.IsValid)
            {
                var tipos = await _tipoService.FindAllAsync();
                var viewModel = new MessageFormViewModel { Message = message, Tipos = tipos };
                return View(viewModel);
            }
            await _messageService.InsertAsync(message);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _messageService.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _messageService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _messageService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _messageService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Tipo> tipos = await _tipoService.FindAllAsync();
            MessageFormViewModel viewModel = new MessageFormViewModel { Message = obj, Tipos = tipos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                var tipos = await _tipoService.FindAllAsync();
                var viewModel = new MessageFormViewModel { Message = message, Tipos = tipos };
                return View(viewModel);
            }
            if (id != message.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
            await _messageService.UpdateAsync(message);
            return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
