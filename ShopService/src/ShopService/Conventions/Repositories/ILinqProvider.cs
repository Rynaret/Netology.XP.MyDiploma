using System.Linq;

namespace ShopService.Conventions.Repositories
{
    /// <summary>
    /// ��������� ������������ IQueryable ��������� ��� ������ ������ �� ��
    /// </summary>
    public interface ILinqProvider
    {
        /// <summary>
        /// ������ ������� ��� ���������� ��������
        /// </summary>
        IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity, new();
    }
}