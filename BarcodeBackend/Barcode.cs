namespace BarcodeBackend;
public class Barcode
{
    public int id { get; set; }
    
    public Barcode(int id)
    {

        this.id = id;

    }
    public void validation()
    {
        if (id < 1)
        {
            throw new IndexOutOfRangeException("The id has to be greater than 1");
        }    
    }
    public override string ToString()
    {
        return $"Id Number: {id}";
    }
}
