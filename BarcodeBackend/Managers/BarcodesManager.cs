namespace BarcodeBackend.Managers
{
    public class BarcodesManager
    {
        private static readonly List<Barcode> _barcodes = new List<Barcode>() {
            new Barcode(15),
            new Barcode(2746),
            new Barcode(1231),
            new Barcode(12480),
            new Barcode(1523)
            };

        public List<Barcode> barcodes
        {

            get
            {
                return _barcodes;
            }
        }
        public List<Barcode> getAll()
        {
            return _barcodes;
        }
        public Barcode getById(int id)
        {
            var result = barcodes.FirstOrDefault(barcode => barcode.id == id);
            return result;
        }
        public void add(Barcode barcode)
        {
            barcode.validation();
            barcodes.Add(barcode);
        }
        public void delete(int id)
        {

            var result = barcodes.FirstOrDefault(barcode => barcode.id == id);
            if (result != null)
            {
                barcodes.Remove(result);
            }
        }
    }
}
