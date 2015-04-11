using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class BookAmount : DomainObject
    {
        public int BookId { get; set; }
        public int BranchId { get; set; }
        public int Amount { get; set; }

        public Book Book { get; set; }
        public Branch Branch { get; set; }
    }
}
