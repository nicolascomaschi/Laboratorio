namespace Entidades
{
    public interface ICopiable<T>
    {
        void CopiarDesde(T origen);
    }
}
