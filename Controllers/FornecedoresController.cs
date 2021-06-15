﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastrosFornecedores.Database;
using CadastrosFornecedores.Models;

namespace CadastrosFornecedores.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly FornecedorContext _context;

        public FornecedoresController(FornecedorContext context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            var fornecedorContext = _context.Fornecedores.Include(f => f.Empresa);
            return View(await fornecedorContext.ToListAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj");
            return View();
        }

        // POST: Fornecedors/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf_Cnpj,HoraCadastro,Telefone,PessoaFisica,RG,DataNascimento,EmpresaId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf_Cnpj,HoraCadastro,Telefone,PessoaFisica,RG,DataNascimento,EmpresaId")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
