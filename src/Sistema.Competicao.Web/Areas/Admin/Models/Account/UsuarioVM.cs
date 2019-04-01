namespace Sistema.Competicao.Web.Areas.Admin.Models.Account
{
    public class UsuarioVM
    {
        public int Codigo { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Perfil { get; set; }
    }
}
