using System.ComponentModel.Composition;
using Mita.DataAccess;
using Mita.DataAccess.EF;

namespace BookStore.DataAccess
{
    [Export(typeof(IRepositoryProvider))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BookStroreRepositoryPorvider : EntityRepositoryProvider<Db>
    {
    }
}
