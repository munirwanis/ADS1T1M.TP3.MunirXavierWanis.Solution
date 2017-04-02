using ADS1T1M.TP3.MunirXavierWanis.Domain.Entities;

namespace ADS1T1M.TP3.MunirXavierWanis.Infra.Data.Contexts
{
    public interface IAlunoContext
    {
        Aluno GetAluno(Aluno aluno);

        void AddAluno(Aluno aluno);

        void UpdateAluno(Aluno aluno);
    }
}
