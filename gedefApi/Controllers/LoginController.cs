using gedefApi.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly GedefDbContext _context;

        public LoginController(GedefDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUser();

            if (currentUser.USUARIO == null)
            {
                return NotFound("Usuario no legueado");

            }
            return Ok(currentUser);
        }

        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            
            var user = Authenticate(userLogin);

            if (user != null)
            {
                if (user.ERRORMESSAGE == null)
                {

                //crear token
                var token = Generate(user);
                return Ok(token);
                }
                else
                {
                    return NotFound(user.ERRORMESSAGE);
                }
            }
            return NotFound("Usuario Incorrecto");
        }

        private Usuarios Authenticate(LoginUser userLogin)
        {
            //busca el usuario en la base, (no compara strings), por eso no se puede validar directamente aca.
            var currentUser = _context.TBA_USUARIOS.FirstOrDefault(user => user.USUARIO == userLogin.UserName
                && user.CONTRASEÑA == userLogin.Password);

            //si encuentra al usuario, continua con validaciones.
            if (currentUser != null)
            {
                //valida usuario sin importar mayusculas. Contraseña debe ser identica.
                if (currentUser.USUARIO.ToLower() == userLogin.UserName.ToLower())
                {
                    if (currentUser.CONTRASEÑA == userLogin.Password)
                    {
                        currentUser.ERRORMESSAGE = null;
                        return currentUser;

                    }
                    currentUser.ERRORMESSAGE = "Contraseña Incorrecta";
                    return currentUser;
                }
                else
                {
                    currentUser.ERRORMESSAGE = "Usuario Incorrecto";
                    return currentUser;
                }
            }
            return null;

        }

        private string Generate(Usuarios user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //crear los claims
            var claims = new[]
                {
                    //new Claim(ClaimTypes.Sid, user.IDPERFIL),
                    new Claim(ClaimTypes.NameIdentifier, user.USUARIO),
                    new Claim(ClaimTypes.Role, user.CATEGORIA),
                    new Claim(ClaimTypes.Name, user.NOMBRE),
                    new Claim(ClaimTypes.Surname, user.APELLIDO),
                    new Claim(ClaimTypes.Sid, user.IDPERFIL.ToString())

                };

            //crear el token

            var token = new JwtSecurityToken(
                            _config["Jwt:Issuer"],
                            _config["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(30000),
                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Usuarios GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity != null)
            {
                var userClaims = identity.Claims;

                return new Usuarios
                {
                    USUARIO = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    CATEGORIA = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    NOMBRE = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    APELLIDO = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    IDPERFIL = Int32.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value) 
                }; 
            }
            return null;
        }
    }
}
