using AutoMapper;
using Desafio.API.Interfaces;
using Desafio.API.Models;
using Desafio.API.Util;
using Desafio.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio.API.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRep _usuarioRep;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRep usuarioRep, IMapper mapper)
        {
            _usuarioRep = usuarioRep;
            _mapper = mapper;
        }

        private BadRequestObjectResult? ValidarStatus()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
                return null;
        }

        [HttpPost, AllowAnonymous]
        [Route("/usuario/login")]
        public async Task<ActionResult> Authenticate(UsuarioAuthViewModel usuarioAuth)
        {
            try
            {
                var senha = GerarMD5.CalculaHash(usuarioAuth.Senha);
                Usuario usuario = await _usuarioRep.GetUsuario(usuarioAuth.Usuario.ToUpper(), senha);

                if (usuario == null)
                {
                    Retorno retorno = new(false, "Usuário não encontrado");
                    return Ok(retorno);
                }

                //var view = _mapper.Map<UsuarioViewModel>(usuario);
                var result = new UsuarioAuthResponseViewModel(_mapper.Map<UsuarioViewModel>(usuario), TokenService.GerarToken(usuario));
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost, AllowAnonymous]
        [Route("/usuario")]
        public async Task<ActionResult> Post([FromBody] NovoUsuarioViewModel usuarioModel)
        {
            ValidarStatus();

            try
            {
                var senha = usuarioModel.Senha;
                var confSenha = usuarioModel.ConfirmarSenha;

                if (senha != confSenha)
                    return Ok(new Retorno(false, "Senhas não conferem!"));

                Usuario usuario = new(usuarioModel.Nome, usuarioModel.CPF, usuarioModel.Senha, usuarioModel.Telefone);

                if(usuario.IsValid)
                {
                    //verificar se CPF nao esta cadastrado
                    if(await _usuarioRep.GetCPF(usuarioModel.CPF))
                        return Ok(new Retorno(false, "CPF informado encontra-se em uso no sistema!"));

                    if(usuarioModel.Endereco != null)
                    {
                        var endModel = usuarioModel.Endereco;
                        Endereco endereco = new(endModel.Logradouro, endModel.Numero, endModel.Complemento,
                                            endModel.Bairro, endModel.Cidade, endModel.Estado);

                        if (endereco.IsValid)
                            usuario.AtualizarEndereco(endereco);
                        else
                        {
                            Retorno retorno = new(false, "Endereço inválido!", endereco.Notifications);
                            return Ok(retorno);
                        }                        
                    }
                                                            
                    await _usuarioRep.Create(usuario);
                    Retorno result = new(true, $"Pessoa cadastrada com sucesso, código {usuario.Id}, CPF {usuario.CPF.Substring(0,4)}");
                    return Created("", result);
                }
                else
                {
                    Retorno result = new(false, "Usuário inválido! Verifique os erros e tente novamente.", usuario.Notifications);
                    return BadRequest(result);
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut, AllowAnonymous]
        [Route("/usuario")]
        public async Task<ActionResult> Put([FromBody] EditarUsuarioViewModel usuarioModel)
        {
            ValidarStatus();

            try
            {
                Usuario usuario = await _usuarioRep.GetById(usuarioModel.UsuarioId);
                usuario.Editar(usuarioModel.Nome, usuarioModel.Telefone);

                if (usuario != null)
                {
                    if (usuarioModel.Endereco != null)
                    {
                        var endModel = usuarioModel.Endereco;
                        Endereco endereco = new(endModel.Logradouro, endModel.Numero, endModel.Complemento,
                                            endModel.Bairro, endModel.Cidade, endModel.Estado);

                        if (!endereco.IsValid)
                        {
                            Retorno retorno = new(false, "Endereço inválido!", endereco.Notifications);
                            return Ok(retorno);
                        }

                        usuario.AtualizarEndereco(endereco);
                    }

                    if (usuario.IsValid)
                    {
                        await _usuarioRep.Update(usuario);
                        Retorno retorno = new(true, "Usuário atualizado!");
                        return Ok(retorno);
                    }
                    else
                    {
                        Retorno retorno = new(false, "Usuário inválido! Verifique os erros e tente novamente.", usuario.Notifications);
                        return Ok(retorno);
                    }
                }
                else
                    return BadRequest("Usuário não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("/usuarios/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            ValidarStatus();

            try
            {
                Usuario usuario = await _usuarioRep.GetById(id);
                await _usuarioRep.Delete(usuario);
                return Ok("Usuário removido");
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet, AllowAnonymous]
        [Route("/usuario")]
        public async Task<ActionResult> GetAll()
        {
            ValidarStatus();

            try
            {
                var usuarios = await _usuarioRep.GetAll();
                var view = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
                return Ok(view);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet, AllowAnonymous]
        [Route("/usuario/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            ValidarStatus();

            try
            {
                var usuario = await _usuarioRep.GetById(id);
                var view = _mapper.Map<UsuarioViewModel>(usuario);
                return Ok(view);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
