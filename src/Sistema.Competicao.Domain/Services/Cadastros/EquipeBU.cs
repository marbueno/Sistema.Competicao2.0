using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;
using System;

namespace Sistema.Competicao.Domain.Services.Cadastros
{
    public class EquipeBU
    {
        private readonly IRepository<EquipeEN> _equipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EquipeBU(IRepository<EquipeEN> equipeRepository, IUnitOfWork unitOfWork)
        {
            _equipeRepository = equipeRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int equCodigo, string equNome, string equResponsavel, DateTime equDataFundacao, int equDDD1, int equTelefone1, int equDDD2, int equTelefone2, bool equComQuadra, int quaCodigo, string equHorario)
        {
            EquipeEN equipeEN = _equipeRepository.GetByID(equCodigo);

            if (equipeEN != null)
            {
                equipeEN.UpdateProperties(
                                        equNome,
                                        equResponsavel,
                                        equDataFundacao,
                                        equDDD1,
                                        equTelefone1,
                                        equDDD2,
                                        equTelefone2,
                                        equComQuadra,
                                        quaCodigo,
                                        equHorario
                                    );

                _equipeRepository.Edit(equipeEN);
            }
            else
            {
                equipeEN = new EquipeEN(
                                        equNome,
                                        equResponsavel,
                                        equDataFundacao,
                                        equDDD1,
                                        equTelefone1,
                                        equDDD2,
                                        equTelefone2,
                                        equComQuadra,
                                        quaCodigo,
                                        equHorario
                                    );

                _equipeRepository.Save(equipeEN);
            }

            _unitOfWork.Commit();
        }
    }
}
