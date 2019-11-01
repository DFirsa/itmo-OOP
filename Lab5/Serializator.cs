namespace Lab5
{
    public interface Serializator
    {
        void Serialize(string path, Triangle triangle);
        
        Triangle Deserialize(string path);
    }
}