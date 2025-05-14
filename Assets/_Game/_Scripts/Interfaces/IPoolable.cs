public interface IPoolable
{
    void OnSpawned(); // Hàm được gọi khi đối tượng được lấy ra từ Pool
    void OnDisposed(); // Hàm được gọi khi đối tượng được trả về Pool
}