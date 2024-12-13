using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternComposite.Interfaces;
using static PatternComposite.Enums.TypeItemsEnums;

namespace PatternComposite.Entities
{
    public class ItemComposite : IItemComponent
    {
        public ItemComposite(string name, string description, decimal quantity , Dictionary<TypeItem, List<IItemComponent>>? items )
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            UnitPrice = 0;
            Items = items ?? [];
        }

        public ItemComposite(string name, string description, decimal quantity):this(name, description, quantity, null) { }

        public ItemComposite(string name, string description):this(name, description,1, null) { }

        private Dictionary<TypeItem, List<IItemComponent>> Items { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        private decimal _quantity;
        public decimal Quantity
        {
            get => _quantity;
            set
            {
                if (value <= -1)
                    throw new Exception("La cantidad no puede ser negativa");
                _quantity = value;
            }
        }

        public virtual decimal Total()
        {
            return UnitPrice * Quantity;
        }

        public virtual void AddItem(TypeItem iKey, IItemComponent item)
        {
            if (!Items.ContainsKey(iKey))
                Items[iKey] = [];
            Items[iKey].Add(item);
            UnitPrice += item.Total();
        }

        public virtual void RemoveItem(TypeItem iKey, IItemComponent item)
        {
            Items[iKey].Remove(item);
            UnitPrice -= item.Total();
        }

        public virtual List<IItemComponent>? GetItemByKey(TypeItem iKey)
        {
            if (!Items.ContainsKey(iKey))
                throw new KeyNotFoundException($"The key: {iKey} does not appear in the dictionary");
            return Items[iKey];
        }
        public virtual List<IItemComponent>? GetAllItems()
        {
            List<IItemComponent> items = [];
            foreach (var ikey in Items.Keys)
            {
                foreach(var item in Items[ikey])
                {
                    if (item is ItemComposite itemComposite)
                    {
                        var bomItem = itemComposite.GetAllItems();
                        items = new List<IItemComponent>(items.Concat(bomItem!));
                        continue;
                    }    
                    items.Add(item);
                }
            }
            return items;
        }

        public void UpdateUnitPrice()
        {
            UnitPrice = 0;
            foreach(var dkey in Items.Keys)
            {
                foreach(var item in Items[dkey])
                {
                    item.UpdateUnitPrice();
                    UnitPrice += item.Total();
                }
            }
        }
    }
}
