using NgTodoList.Data.Context;
using System.Web;

namespace NgTodoList.Api.Helpers
{
    public static class DataContextHelper
    {
        public static DataContext CurrentDataContext
        {
            get { return HttpContext.Current.Items["_EntityContext"] as DataContext; }
        }
    }
}