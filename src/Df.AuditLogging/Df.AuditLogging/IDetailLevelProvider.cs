public interface IDetailLevelProvider<in T>
{
    public int GetDetailsLevel(T instance);
}