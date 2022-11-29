using System.Collections.Generic;
using System.Linq;
using api.Models;
using API_Copa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly Context _context;
        public JogoController(Context context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Jogo jogo)
        {
            jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoAId);
            jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoBId);
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            return Created("", jogo);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {

            List<Jogo> jogos = new List<Jogo>();
            List<Jogo> jogosDB = _context.Jogos.ToList(); 

            foreach(var jogo in jogosDB) {
                jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoAId); 
                jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoBId); 
                jogos.Add(jogo); 
            } 

            return Ok(jogos); 

        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            Jogo jogo = _context.Jogos.
                Find(id);
            jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoAId); 
            jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoBId); 
            return jogo != null ? Ok(jogo) : NotFound();
        }

        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Jogo jogo)
        {
            try
            { 
                jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoAId); 
                jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoBId);
                _context.Jogos.Update(jogo);
                _context.SaveChanges();
                return Ok(jogo);
            }
            catch
            {
                return NotFound();
            }
        }

    }
}