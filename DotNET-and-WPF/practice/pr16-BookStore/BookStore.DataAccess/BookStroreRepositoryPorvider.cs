using System.ComponentModel.Composition;
using Mita.DataAccess;
using Mita.DataAccess.EF;

namespace BookStore.DataAccess
{
    [Export(typeof(IRepositoryProvider))]
    public class BookStroreRepositoryPorvider : EntityRepositoryProvider<Db>
    {
    }
}
