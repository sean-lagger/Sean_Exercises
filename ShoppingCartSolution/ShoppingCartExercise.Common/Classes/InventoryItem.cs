namespace ShoppingCartExercise.Common.Classes
{
    public class InventoryItem
    {
        public InventoryItem()
        {
            Quantity = 1;
            isInfinite = false;
        }

        public int Quantity { get; set; }
        public bool isInfinite { get; set; }
        public string AppendedDescription { get; set; }

    }
}