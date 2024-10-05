namespace Biblioteca.Core.Enuns
{
    public enum LoanStatus
    {
        //Pendente (Espera de aprovação)
        Pending = 1,
        //Emprestado
        Borrowed = 2,
        //Devolvido
        Returned = 3,
        //Cancelado
        Canceled = 4,
        //Suspendido
        Suspended = 5
    }

}
