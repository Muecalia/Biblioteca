using Biblioteca.Core.Enuns;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LoanStatusRepository
    {
        public static List<string> GetStatus()
        {
            //var status = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
            return Enum.GetNames(typeof(LoanStatus)).ToList();
            //return status;
        }

        public static LoanStatus? GetStatus(int status)
        {
            var enuns = Enum.GetValues(typeof(LoanStatus)).Cast<LoanStatus>().ToList();

            foreach (var item in enuns)
                if ((int)item == status) return item;
            return null;
        }
    }
}
