using Bookbox.Data;
using Bookbox.Models;
using Bookbox.Repositories.Implementations;
using Bookbox.Repositories.Interface;
using Bookbox.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bookbox.Repositories.Implementations
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly BookBoxDbContext dbContext;
        private IGenericRepository<T>? _repository;
        private IDbContextTransaction? Transaction;

        public UnitOfWork(BookBoxDbContext dbContext)
        {
            this.dbContext = dbContext;
            Authors = new AuthorRepository(dbContext);
            Books = new BookRepository(dbContext);
        }
        public IGenericRepository<T> Repository => _repository ??= new GenericRepository<T>(dbContext);
        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        // Rollback method to undo changes in case of an error
        private async Task RollBack()
        {
            if (Transaction != null)
            {
                await Transaction.RollbackAsync();
            }
        }
        // CompleteAsync method with explicit transaction handling and transient error strategy
        public async Task<bool> CompleteAsync()
        {
            bool result = false;
            try
            {
                // Create execution strategy for handling transient errors
                var strategy = dbContext.Database.CreateExecutionStrategy();

                // Execute the transaction logic inside the strategy
                await strategy.ExecuteAsync(async () =>
                {
                    // Begin transaction
                    Transaction = await dbContext.Database.BeginTransactionAsync();

                    // Save changes to the database
                    result = await dbContext.SaveChangesAsync() >= 0;

                    // Commit transaction
                    await Transaction.CommitAsync();
                });
            }
            catch (Exception e)
            {
                // Rollback transaction if any error occurs
                await RollBack();
                throw new Exception(e.Message.Equals("An error occurred while updating the entries. See the inner exception for details.") ? e.InnerException?.Message : e.Message);
            }
            finally
            {
                // Ensure the transaction is disposed of after use
                if (Transaction != null)
                {
                    await Transaction.DisposeAsync();
                }
            }

            return result;
        }


    }
}