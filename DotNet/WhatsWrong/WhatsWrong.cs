using System.Collections;
using System.Linq.Expressions;

namespace IDENT;

/*
 * Класс - заглушка, используется просто для воспроизведения
 */
internal class DbSet<T> : IQueryable<T>
{
    public DbSet() { }

    public Type ElementType => throw new NotImplementedException();

    public Expression Expression => throw new NotImplementedException();

    public IQueryProvider Provider => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

/* Код из текста задания жёстко вырван из контекста и задание идёт с заголовком "Обработка исключений" я попытаюсь дать ответ
 * в контексте обработки исключений.
 * 
 * Посмотрев на строчку в блоке try я определил, что в нём потенциально могут возникнуть следующие типы ошибок:
 * InvalidCastException,
 * NullReferenceException
 * и т.к вероятнее всего dbSet будет тянуть данные из БД => могу быть связаны ошибки с подключением, например.
 * Смысл в том что все эти ошибки строго типизированы и посмотрев на их тип примерно можно понять в чем проблема,
 * но в блоке catch создаётся новый экземпляр Exception, что влечет за собой потерю типа исходного исключения, а в
 * свойство ex.Message не всегда есть информация, что впоследствии влечет за собой огромные проблемы при отладке.
 * 
 * Также в блоке catch создаётся новый экземпляр Exception и в него не передаётся значение из старого ex.StackTrace, 
 * что влечет за собой потерю старого StackTrace.
 * 
 * Насколько мне известно данный приём с throw new Exception внутри catch используется в целях безопасности, когда есть необходимость
 * скрыть часть цепочки вызовов. Насколько это применимо в конкретном случае сложно сказать, тем не менее тут сделано
 * все для того чтобы отладка этого метода была не простой.
 * 
 * В данном случае лучше не создавать новый экземпляр Exception, а использовать просто ключевое слово throw,
 * тогда ошибка "прокинется" наверх без потери информации о ней.
 */

public class WhatsWrong<T>
{
    private DbSet<T> dbSet = new DbSet<T>();

    public IQueryable<T> GetAll()
    {
        try
        {
            return dbSet.AsQueryable();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
            //throw;
        }
    }


}
