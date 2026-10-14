using Biblioteca_Usuario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Biblioteca_Usuario
{
    public class ServiceUsuario
    {
        private readonly RepositoryUsuario _Ru;
        private readonly IConfiguration _configuration;

        public ServiceUsuario(RepositoryUsuario Ru, IConfiguration configuration)
        {
            _Ru = Ru;
            _configuration = configuration;
        }

        public async Task<string?> Login(LoginDto login)
        {

            //Pega o usuario
            var usuario = await _Ru.FirsOrDefault(login.Email);

            if (usuario == null)
            {
                return null;
            }


            //verifica a senha
            bool senhavalida = BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha);
            if (!senhavalida)
            {
                return null;
            }

            var tokenhandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration ["jwt:key"]!);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Cargo)



                }),

                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["jwt:Issuer"],
                Audience = _configuration["jwt:Audience"],

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)





            };

            var token = tokenhandler.CreateToken(tokendescriptor);
            var jwt = tokenhandler.WriteToken(token);
            return jwt;



        }

        public async Task<List<DtoResponse>?> GetSU()
        {
            var Usuarios = await _Ru.GetRU();
            if (Usuarios.Count == 0)
            {
                return null;
            }
            return Usuarios.Select(u => new DtoResponse
            {
                id = u.id,
                Nome = u.Nome
              

            }).ToList();

            
            
          
        }
        public async Task<Usuario?> PostSU(DtoRequest requestdto)
        {

             if (requestdto == null)
            {
                return null;
            }

            var senha = BCrypt.Net.BCrypt.HashPassword(requestdto.Senha);
            

            var usuarionovo = new Usuario(requestdto.Nome, requestdto.Email, senha);

            await _Ru.PostRU(usuarionovo);

            return usuarionovo;
            


        }
        public async Task<Usuario?> PutSU(DtoRequest usuariodto, int id)
        {
            var usuario = await _Ru.GetIdRU(id);
            if (usuario == null)
            {
                return null;
            }

            usuario.Nome = usuariodto.Nome;
            usuario.Email = usuariodto.Email;
            usuario.Senha = usuariodto.Senha;

            
            return usuario;



        }


        public async Task<bool> DeleteSU(int id)
        {
            var usuario = await _Ru.GetIdRU(id);
            if (usuario == null)
            {
                return false;
            }
            await _Ru.DeleteRU(usuario);

            return true;

        }

        public async Task<Usuario?> GetIdSU(int id)
        {
            var usuario = await _Ru.GetIdRU(id);
            if(usuario == null)
            {
                return null;
            }
            return usuario;
        }
        

    }
}
