﻿using Sistema.Competicao.Domain.Entities.Account;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Account
{
    public class UsuarioBU
    {
        private readonly IRepository<UsuarioEN> _repositoryUsuarioEN;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioBU (IRepository<UsuarioEN> repositoryUsuarioEN, IUnitOfWork unitOfWork)
        {
            _repositoryUsuarioEN = repositoryUsuarioEN;
            _unitOfWork = unitOfWork;
        }

        public void Save(int usuCodigo, string usuNome, string usuLogin, string usuEmail, string usuSenha, int perCodigo)
        {
            UsuarioEN usuarioEN = _repositoryUsuarioEN.GetByID(usuCodigo);

            if (usuarioEN != null)
            {
                usuarioEN.UpdateProperties
                    (
                        usuNome, 
                        usuarioEN.usuLogin,
                        usuEmail,
                        usuarioEN.usuSenha,
                        usuarioEN.perCodigo
                    );

                _repositoryUsuarioEN.Edit(usuarioEN);
            }
            else
            {
                usuarioEN = new UsuarioEN
                    (
                        usuNome, 
                        usuLogin,
                        usuEmail,
                        usuSenha, 
                        perCodigo
                    );

                _repositoryUsuarioEN.Save(usuarioEN);
            }

            _unitOfWork.Commit();
        }
    }
}
