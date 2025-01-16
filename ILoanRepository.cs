using loanmgsystem.Model;

namespace loanmgsystem.Repository
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task UpdateLoanVerificationAsync(int loanId, Loan loan);
    }
}
