using PatternComposite.Entities;
using PatternComposite.Entities.Composites;
using PatternComposite.Entities.Leafs;
using PatternComposite.Interfaces;
using static PatternComposite.Enums.TypeItemsEnums;

namespace PatternComposite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var window = BuildWindow(1000.0, 1500.0);
            ShowPrices(window);
            ShowAllItems(window);

            Console.WriteLine("\nWINDOW MODIFIED");
            SetProperties(window);
            ShowPrices(window);
            ShowAllItems(window);
        }

        private static void ShowAllItems(ItemComposite window)
        {
            var items = window.GetAllItems();
            Console.WriteLine("\nALL ITEMS\n");
            foreach (var item in items!)
            {
                Console.WriteLine($"Name: {item.Name}, Description: {item.Description}, PU: ${item.UnitPrice}, Qty: {item.Quantity}, Total: {item.Total()}");
            }
        }

        private static void SetProperties(WindowOpening window)
        {
            window.Quantity = 2;
            var sash = (ItemComposite)window.GetItemByKey(TypeItem.Assembly)![1];
            sash.Quantity = 3;
            var horizontalPart = sash.GetItemByKey(TypeItem.Part)![0];
            horizontalPart.Quantity = 1;
            horizontalPart.UnitPrice = 1;
            window.UpdateUnitPrice();
        }

        private static void ShowPrices(WindowOpening window)
        {
            Console.WriteLine("\nPRICES FRAME");
            Console.WriteLine($"Frame Unit Price: {window.GetItemByKey(TypeItem.Assembly)![0].UnitPrice}");
            Console.WriteLine($"Frame Total: {window.GetItemByKey(TypeItem.Assembly)![0].Total()}");

            Console.WriteLine("\nPRICES SHASH");
            Console.WriteLine($"Sash Unit Price: {window.GetItemByKey(TypeItem.Assembly)![1].UnitPrice}");
            Console.WriteLine($"Sash Total: {window.GetItemByKey(TypeItem.Assembly)![1].Total()}");

            Console.WriteLine("\nPRICES WINDOW");
            Console.WriteLine($"Unit Price: ${window.UnitPrice}");
            Console.WriteLine($"Total: ${window.Total()}");
        }

        private static WindowOpening BuildWindow(double width, double height)
        {
            var window = new WindowOpening("Window1", "Abatement two leaf",width,height);
            var frame = BuildFrame(width,height);
            var sash = BuildSash(width -50,height -50);
            window.AddItem(TypeItem.Assembly, frame);
            window.AddItem(TypeItem.Assembly, sash);
            return window;
        }

        private static FrameAssembly BuildFrame(double width, double height)
        {
            var frame = new FrameAssembly("Frame window", "For Abatament Sash", width,height); // Unit Price: $50.0
            var horizontalParts = new AluminumProfile("Al-pf-1", "Serie A", 0.01m, 2, width); // Total: $20.0
            var verticalParts = new AluminumProfile("Al-pf-1", "Serie A", 0.01m, 2, height); // Total: $30.0
            frame.AddItem(TypeItem.Part,horizontalParts);
            frame.AddItem(TypeItem.Part, verticalParts);
            return frame;
        }

        private static SashAssembly BuildSash(double width, double height)
        {
            var sash = new SashAssembly("Sash window", "Abatament",2, width, height); // Unit Price: $85.0
            var horizontalParts = new AluminumProfile("Al-pf-2", "Serie A", 0.01m, 2, width); // Total: $19.0
            var verticalParts = new AluminumProfile("Al-pf-2", "Serie A", 0.01m, 2, height); // Total: $29.0
            var horizontalDividerParts = new AluminumProfile("Al-pf-3", "Serie A", 0.01m, 1, width-50); // Total: $9.0
            var verticalDividerParts = new AluminumProfile("Al-pf-3", "Serie A", 0.01m, 2, height-50); // Total: $28.0
            sash.AddItem(TypeItem.Part, horizontalParts);
            sash.AddItem(TypeItem.Part, verticalParts);
            sash.AddItem(TypeItem.Part, horizontalDividerParts);
            sash.AddItem(TypeItem.Part, verticalDividerParts);
            return sash;
        }
    }
}
